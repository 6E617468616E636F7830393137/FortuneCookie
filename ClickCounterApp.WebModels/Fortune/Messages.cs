using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickCounterApp.WebModels.Fortune
{
    public class Messages
    {
        [Display(Name = "Id")]
        public string Id { get; set; }
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public string CreatedDate { get; set; }
        public string LuckyNumbers { get; set; }
        [Display(Name = "Author")]
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
