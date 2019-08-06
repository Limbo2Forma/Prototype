using Prototype.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prototype.Interfaces {
    public interface IGetAllApiKeysQuery {
        Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync();
    }
}
