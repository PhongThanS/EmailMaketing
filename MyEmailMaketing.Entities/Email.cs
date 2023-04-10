using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmailMaketing.Models
{
    public class Email : BaseModel
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
    }
}
