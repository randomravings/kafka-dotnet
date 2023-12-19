using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace Kafka.Cli.Cmd
{
    internal static class HelpTextWriter
    {
        public static Task<int> DisplayHelp<T>(ParserResult<T> result)
        {
            var name = "";
            var version = "";
            var copyright = "";
            var assemmbly = Assembly.GetAssembly(typeof(Program));

            if (assemmbly != null)
            {
                name = assemmbly.GetName().Name;
                version = assemmbly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion ?? "";
                copyright = assemmbly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "";
            }
            var helpText = HelpText.AutoBuild(result, h =>
            {
                h.Heading = $"{name} - {version}";
                h.Copyright = copyright;
                h.AutoVersion = true;
                h.AutoHelp = true;
                h.AdditionalNewLineAfterOption = false;
                h.AddNewLineBetweenHelpSections = false;
                h.AddEnumValuesToHelpText = true;
                return HelpText.DefaultParsingErrorsHandler(result, h);
            }, e => e);
            Console.WriteLine(helpText);
            return Task.FromResult(-1);
        }
    }
}