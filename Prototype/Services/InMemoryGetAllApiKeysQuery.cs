using Prototype.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prototype.Services {
    public class InMemoryGetAllApiKeysQuery : IGetAllApiKeysQuery {
        public Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync() {
            var apiKeys = new List<ApiKey> {
                new ApiKey("C5BFF7F0-B4DF-475E-A331-F737424F013C"),
                new ApiKey("5908D47C-85D3-4024-8C2B-6EC9464398AD"),
                new ApiKey("06795D9D-A770-44B9-9B27-03C6ABDB1BAE"),
                new ApiKey("FA872702-6396-45DC-89F0-FC1BE900591B")
            };

            IReadOnlyDictionary<string, ApiKey> readonlyDictionary 
                = apiKeys.ToDictionary(x => x.Key, x => x);
            return Task.FromResult(readonlyDictionary);
        }
    }
}
