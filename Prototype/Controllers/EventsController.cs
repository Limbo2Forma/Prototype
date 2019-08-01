using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.Interfaces;
using Prototype.Models;

namespace Prototype.Controllers {
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase {
        public readonly IEventsReopsitory _eventRepo;
        public EventsController(IEventsReopsitory repo) {
            _eventRepo = repo;
        }      

        [HttpGet("company/{CompanyCode}/date/{StartTime:datetime}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsFromCompanyCodeAndDate
            (string CompanyCode, DateTime StartTime) {
            return await _eventRepo.GetEventFromCompanyCodeAndDate(CompanyCode, StartTime);
        }
    }
}