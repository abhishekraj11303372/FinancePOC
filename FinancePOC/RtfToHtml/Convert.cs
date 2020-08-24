using RtfPipe;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace RtfToHtml
{
    public class Convert
    {
        //static void Main(string[] args)
        public string ConvertToHtml()
        {
            // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var location = Assembly.GetExecutingAssembly().Location;
            var contentRoot = Path.GetDirectoryName(location);
            var input = Path.Combine(contentRoot, "../../../Files/Rtf/FinancePOCDotnetMembers.rtf");
            var output = Path.Combine(contentRoot, "../../../Files/Html/FinancePOCDotnetMembers.html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
            return output;
        }
    }
}
