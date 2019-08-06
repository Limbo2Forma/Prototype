using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Models.DTOs {
    public class EventDetailDTO {
        public int ID { get; }
        public string CompanyCode { get; }
        public int EventTypeID { get; }
        public byte DateType { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; }
        public bool IsAllDayEvent { get; }
        public byte? Status { get; }
        public bool IsDeleted { get; }
        public int? OLD_ID { get; }
        public DateTime? LastUpdated { get; }
        public int LanguageID { get; }
        public string Title { get; }
        public string Description { get; }
        public string Location { get; }
        public string LinkUrl { get; }
        public string LinkDescription { get; }
    }
}
