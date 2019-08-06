using System;

namespace Prototype.Models {
    public class Event {
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
    }
}
