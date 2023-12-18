function Get-KafkaHtmlTableRows {
  param(
    $WebResponse,
    $TableId
  );
  $rows = New-Object -TypeName System.Collections.ArrayList;
  $table = $WebResponse.ParsedHtml.getElementById($TableId).IHTMLDOMNode_parentNode.IHTMLDOMNode_nextSibling.IHTMLDOMNode_nextSibling;
  foreach($row in $table.rows) {
    $cells = $row.cells;
    if($cells[0].tagName -eq 'th') {
      continue;
    }
    $rows.Add($cells) | Out-Null;
  }
  $rows;
}

function Create-ApiKeys {
  param(
    $WebResponse,
    $TableId,
    $FullyQualifiedName
  )
  $description = $WebResponse.ParsedHtml.getElementById($TableId).IHTMLDOMNode_parentNode.IHTMLDOMNode_nextSibling.innerText;
  $lines = New-Object -TypeName System.Collections.ArrayList;
  $components = $FullyQualifiedName.Split(".");
  $lines.Add("namespace $(($components[0..($components.Length - 2)] -join '.'))") | Out-Null;
  $lines.Add("{") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  $lines.Add("    /// $($description)") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  $lines.Add("    public enum $($components[-1]) : short") | Out-Null;
  $lines.Add("    {") | Out-Null;
  Get-KafkaHtmlTableRows -WebResponse:$WebResponse -TableId:$TableId | `
    ForEach-Object {
      $member = $_[0].innerText;
      $label = [regex]::replace($member, '(?<=.)(?=[A-Z])', '_').ToUpper();
      $lines.Add("        [EnumMember(Value = `"$($label)`")]") | Out-Null;
      $lines.Add("        $($member) = $($_[1].innerText),") | Out-Null;
    }
  ;
  $lines.Add("    }") | Out-Null;
  $lines.Add("}") | Out-Null;
  $lines;
}

function Create-ApiErrors {
  param(
    $WebResponse,
    $TableId,
    $FullyQualifiedName
  )
  $description = $WebResponse.ParsedHtml.getElementById($TableId).IHTMLDOMNode_parentNode.IHTMLDOMNode_nextSibling.innerText;
  $lines = New-Object -TypeName System.Collections.ArrayList;
  $components = $FullyQualifiedName.Split(".");
  $lines.Add("namespace $(($components[0..($components.Length - 2)] -join '.'))") | Out-Null;
  $lines.Add("{") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  $lines.Add("    /// $($description)") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  $lines.Add("    public enum $($components[-1])") | Out-Null;
  $lines.Add("    {") | Out-Null;
  Get-KafkaHtmlTableRows -WebResponse:$WebResponse -TableId:$TableId | `
    ForEach-Object {
      $errorLabel = $_[0].innerText;
      $errorCode = $_[1].innerText;
      $errorRetriable = $_[2].innerText.ToLower();
      $errorText = $_[3].innerText;
      $propertyName = [regex]::replace($errorLabel.ToLower(), '(^|_)(.)', { $args[0].Groups[2].Value.ToUpper()});
      $definition = "public static readonly ApiError $($propertyName) = new($($errorCode), `"$($errorLabel)`", $($errorRetriable), `"$($errorText)`");"
      $lines.Add($definition) | Out-Null;
    }
  ;
  $lines.Add("    }") | Out-Null;
  $lines.Add("}") | Out-Null;
  $lines;
}

$response = Invoke-WebRequest -Uri https://kafka.apache.org/protocol.html

Create-ApiKeys -WebResponse $response -TableId 'protocol_api_keys' -FullyQualifiedName 'Kafka.Common.Protocol.ApiKey'
Create-ApiErrors -WebResponse $response -TableId 'protocol_error_codes' -FullyQualifiedName 'Kafka.Common.Protocol.ApiErrors'


