using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prototype.Interfaces;
using Prototype.Models;
using Prototype.Models.DTOs;

namespace Prototype.Controllers {
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase {
        public readonly IEventsReopsitory _eventRepo;
        public EventsController(IEventsReopsitory repo) {
            _eventRepo = repo;
        }

        [HttpGet("{id:int}/details")]
        public async Task<ActionResult<EventDetailDTO>> GetEventDetailFromID(int id) {
            return await _eventRepo.GetEventDetailFromEventID(id);
        }

        [HttpGet("company/{CompanyCode}/date/{StartTime}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsFromCompanyCodeAndDate
            (string CompanyCode, string StartTime) {
            DateTime time = DateTime.Parse(StartTime, System.Globalization.CultureInfo.InvariantCulture);
            return await _eventRepo.GetEventsFromCompanyCodeAndDate(CompanyCode, time);
        }
    }
}