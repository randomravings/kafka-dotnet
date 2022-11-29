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

function Create-EnumFile {
  param(
    $WebResponse,
    $TableId,
    $FullyQualifiedName
  )
  $description = $WebResponse.ParsedHtml.getElementById($TableId).IHTMLDOMNode_parentNode.IHTMLDOMNode_nextSibling.innerText;
  $lines = New-Object -TypeName System.Collections.ArrayList;
  $components = $FullyQualifiedName.Split(".");
  $path = "$($PSScriptRoot)\src\Kafka\$(($components[0..1] -join '.'))";
  if($components.Length -gt 3) {
    $path += "\$(($components[2..($components.Length - 2)] -join '.'))";
  }
  $path += "\$($components[-1]).cs";
  $lines.Add("namespace $(($components[0..($components.Length - 2)] -join '.'))") | Out-Null;
  $lines.Add("{") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  $lines.Add("    /// $($description)") | Out-Null;
  $lines.Add("    ///<summary>") | Out-Null;
  if($TableId -eq 'protocol_error_codes') {
    $lines.Add("    public enum $($components[-1])") | Out-Null;
  } else {  
    $lines.Add("    public enum $($components[-1]) : short") | Out-Null;
  }
  $lines.Add("    {") | Out-Null;
  Get-KafkaHtmlTableRows -WebResponse:$WebResponse -TableId:$TableId | `    ForEach-Object {
      if($TableId -eq 'protocol_error_codes') {
        $lines.Add("        ///<summary>") | Out-Null;
        $lines.Add("        /// $($_[3].innerText)") | Out-Null;
        $lines.Add("        /// <para>Retriable: $($_[2].innerText)</para>") | Out-Null;
        $lines.Add("        ///</summary>") | Out-Null;
      }
      $lines.Add("        $($_[0].innerText) = $($_[1].innerText),") | Out-Null;    }
  ;
  $lines.Add("    }") | Out-Null;
  $lines.Add("}") | Out-Null;

  Set-Content -Path $path -Value $lines -Force;
}

$response = Invoke-WebRequest -Uri https://kafka.apache.org/protocol.html

Create-EnumFile -WebResponse $response -TableId 'protocol_error_codes' -FullyQualifiedName 'Kafka.Common.Protocol.ErrorCode';
Create-EnumFile -WebResponse $response -TableId 'protocol_api_keys' -FullyQualifiedName 'Kafka.Common.Protocol.ApiKey';


