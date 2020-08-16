using RtfPipe;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace RtfToHtml
{
    public class Convert
    {
        static void Main(string[] args)
        {
            // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var location = Assembly.GetExecutingAssembly().Location;
            var contentRoot = Path.GetDirectoryName(location);
            var input = Path.Combine(contentRoot, "FinancePOCDotnetMembers.rtf");
            var output = Path.Combine(contentRoot, "FinancePOCDotnetMembers.html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
        }
    }
}
