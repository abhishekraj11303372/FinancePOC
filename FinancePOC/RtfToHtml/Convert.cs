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

            var input = Path.GetFullPath(uploads);
            var outputFileName = Path.GetFileName(uploads);
            var output = Path.Combine("../RtfToHtml/Files/Html/", outputFileName).Replace(".rtf",".html");

            var html = Rtf.ToHtml(File.ReadAllText(input));
            File.WriteAllText(output, html);

            Console.WriteLine($"Done. Output file: {output}");
            return output;
        }
    }
}
