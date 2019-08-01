using Prototype.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prototype.Interfaces {
    public interface IEventsReopsitory {
        Task<List<Event>> GetEventFromCompanyCodeAndDate(string CompanyCode, System.DateTime StartDate);
    }
}
