using System;

namespace Prototype.Models {
    public class Event {
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
    }
}
