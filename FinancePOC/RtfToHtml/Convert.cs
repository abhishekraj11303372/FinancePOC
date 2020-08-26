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
        public string ConvertToHtml()
        {
            // Add a reference to the NuGet package System.Text.Encoding.CodePages for .Net core only
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var location = Assembly.GetExecutingAssembly().Location;
            var contentRoot = Path.GetDirectoryName(location);
            var input = Path.Combine(contentRoot, "C:/Users/annu.kumari/source/repos/FinancePOC/FinancePOC/RtfToHtml/Files/Rtf/f_rpt_potential_gap_refund_notice.rtf");
            // var input = Path.Combine(contentRoot, "C:/Users/annu.kumari/source/repos/FinancePOC/FinancePOC/RtfToHtml/Files/Rtf/annu.rtf");
            //var input = Path.Combine(contentRoot, "../../../../Files/Rtf/FinancePOCDotnetMembers1.rtf");
            var output = Path.Combine(contentRoot, "C:/Users/annu.kumari/source/repos/FinancePOC/FinancePOC/RtfToHtml/Files/Html/f_rpt_potential_gap_refund_notice.html");
            // var output = Path.Combine(contentRoot, "../../../../Files/Html/FinancePOCDotnetMembers1.html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
            return output;
        }
    }
}