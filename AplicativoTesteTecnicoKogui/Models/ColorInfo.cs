using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoTesteTecnicoKogui.Models
{
    public sealed class ColorInfo
    {
        public HexInfo? Hex { get; set; }
        public NameInfo? Name { get; set; }
    }

    public sealed class HexInfo
    {
        public string? Value { get; set; }
        public string? Clean { get; set; }
    }

    public sealed class NameInfo
    {
        public string? Value { get; set; }
    }

    public sealed class ColorScheme
    {
        public List<ColorInfo>? Colors { get; set; }
    }
}
