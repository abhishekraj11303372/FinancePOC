using RtfPipe;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace RtfToHtml
{
    public class Convert : IConvert
    {
        //static void Main(string[] args)
        public string ConvertToHtml(string uploads)
        {
            // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var location = Assembly.GetExecutingAssembly().Location;
            var contentRoot = Path.GetDirectoryName(location);
            //var input = Path.Combine(contentRoot, "E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/Rtf/FinancePOCDotnetMembers1.rtf");
            var input = Path.GetFullPath(uploads);
            //var input = Path.Combine(contentRoot, "../../../../Files/Rtf/FinancePOCDotnetMembers1.rtf");
            //var output = Path.Combine(contentRoot, "E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/Html/FinancePOCDotnetMembers1.html");
            var outputFileName = Path.GetFileName(uploads);
            var output = Path.Combine("E:/POC/FinancePOC/FinancePOC/RtfToHtml/Files/Html/", outputFileName).Replace(".rtf",".html");
            //var output = Path.GetFullPath(uploads).Replace(".rtf",".html");
            // var output = Path.Combine(contentRoot, "../../../../Files/Html/FinancePOCDotnetMembers1.html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
            return output;
        }
    }
}
