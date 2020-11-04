using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCWF.AppSettings
{
    class AppData
    {
        public static string Color1Property = nameof(Color1);
        public Color? Color1 { get; set; }

        public static string Color2Property = nameof(Color2);
        public Color? Color2 { get; set; }
    }
}
