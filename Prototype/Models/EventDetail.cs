using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Models {
    public class EventDetail {
        public int ID { get; }
        public int EventID { get; }
        public int LanguageID { get; }
        public string Title { get; }
        public string Description { get; }
        public string Location { get; }
        public string LinkUrl { get; }
        public string LinkDescription { get; }
    }
}
