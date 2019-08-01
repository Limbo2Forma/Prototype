using Dapper;
using Microsoft.Extensions.Configuration;
using Prototype.Interfaces;
using Prototype.Models;
using Prototype.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Repositories {
    public class EventsRepository : IEventsReopsitory {
        private readonly IConfiguration _config;
        public EventsRepository(IConfiguration config) {
            _config = config;
        }

        public IDbConnection Connection {
            get {
                return new System.Data.SqlClient.SqlConnection(_config.GetConnectionString("Events"));
            }
        }

        public async Task<EventDetailDTO> GetEventDetailFromEventID(int EventID) {
            using (IDbConnection conn = Connection) {
                conn.Open();
                var result = await conn.QueryAsync<EventDetailDTO>("GetEventDetailFromEventID",
                    new { EventID },
                    commandType: CommandType.StoredProcedure);
                return result.First();
            }
        }

        public async Task<List<Event>> GetEventsFromCompanyCodeAndDate(string CompanyCode, DateTime StartDate) {
            using (IDbConnection conn = Connection) {
                conn.Open();
                var result = await conn.QueryAsync<Event>("GetEventsFromCompanyCodeAndStartDate",
                    new { CompanyCode, Date = StartDate },
                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
