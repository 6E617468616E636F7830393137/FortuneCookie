using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.WebModels.Fortune
{
    public static class Session
    {
        public static int? CurrentPage { get; set; }
        public static int? NextPrevPage { get; set; }        
        public static bool? descending { get; set; }
    }
}
