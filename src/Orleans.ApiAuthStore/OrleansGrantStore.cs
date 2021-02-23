using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Stores;

namespace Orleans.ApiAuthStore
{
    public class OrleansGrantStore : IPersistedGrantStore
    {
        private readonly IClusterClient _client;

        public OrleansGrantStore(IClusterClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new NotSupportedException();
        }

        public Task<PersistedGrant> GetAsync(string key)
        {
            return _client.GetGrain<IGrantGrain>(key).Get();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new NotSupportedException();
        }

        public Task RemoveAsync(string key)
        {
            return _client.GetGrain<IGrantGrain>(key).Remove();
        }

        public Task StoreAsync(PersistedGrant grant)
        {
            return _client.GetGrain<IGrantGrain>(grant.Key).Store(grant);
        }
    }
}