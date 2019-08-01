using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Models {
    public class EventDetail {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string LinkUrl { get; set; }
        public string LinkDescription { get; set; }
    }
}
