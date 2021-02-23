using IdentityServer4.Models;
using Orleans.Concurrency;
using Orleans.Runtime;
using System.Threading.Tasks;

namespace Orleans.ApiAuthStore
{
    public interface IGrantGrain : IGrainWithStringKey
    {
        public Task Store(PersistedGrant grant);

        public Task Remove();

        [AlwaysInterleave]
        public Task<PersistedGrant> Get();
    }

    internal class GrantGrain : Grain, IGrantGrain
    {
        private readonly IPersistentState<GrantGrainState> _data;

        public GrantGrain([PersistentState("Grant", ApiAuthConstants.OrleansGrantStorageProvider)] IPersistentState<GrantGrainState> data)
        {
            _data = data;
        }

        public Task<PersistedGrant> Get()
        {
            return Task.FromResult(_data.State.Grant);
        }

        public Task Remove()
        {
            DeactivateOnIdle();
            return _data.ClearStateAsync();
        }

        public Task Store(PersistedGrant grant)
        {
            _data.State.Grant = grant;
            return _data.WriteStateAsync();
        }
    }

    internal class GrantGrainState
    {
        public PersistedGrant Grant { get; set; }
    }
}