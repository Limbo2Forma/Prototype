using Prototype.Models;
using Prototype.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prototype.Interfaces {
    public interface IEventsReopsitory {
        Task<List<Event>> GetEventsFromCompanyCodeAndDate(string CompanyCode, System.DateTime StartDate);
        Task<EventDetailDTO> GetEventDetailFromEventID(int EventID);
    }
}
