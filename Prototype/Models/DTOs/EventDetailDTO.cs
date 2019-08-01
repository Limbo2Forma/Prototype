using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Models.DTOs {
    public class EventDetailDTO {
        public int ID { get; set; }
        public string CompanyCode { get; set; }
        public int EventTypeID { get; set; }
        public byte DateType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsAllDayEvent { get; set; }
        public byte? Status { get; set; }
        public bool IsDeleted { get; set; }
        public int? OLD_ID { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int LanguageID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string LinkUrl { get; set; }
        public string LinkDescription { get; set; }
    }
}
