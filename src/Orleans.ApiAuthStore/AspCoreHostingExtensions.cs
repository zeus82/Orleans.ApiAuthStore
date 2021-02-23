using Orleans.ApiAuthStore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AspCoreHostingExtensions
    {
        public static IIdentityServerBuilder AddOrleansApiAuthorization(this IIdentityServerBuilder builder)
        {
            return builder.AddPersistedGrantStore<OrleansGrantStore>();
        }
    }
}
