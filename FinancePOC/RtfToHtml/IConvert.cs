using System;
using System.Collections.Generic;
using System.Text;

namespace RtfToHtml
{
    public interface IConvert
    {
        string ConvertToHtml(string uploads);
    }
}
