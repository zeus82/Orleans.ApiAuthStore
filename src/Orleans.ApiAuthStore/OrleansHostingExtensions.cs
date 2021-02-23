using Orleans.Hosting;

namespace Orleans.ApiAuthStore
{
    public static class SiloBuilderExtensions
    {
        /// <summary>
        /// Add identity store to orleans. Grain storage provider name can be found at <see
        /// cref="OrleansIdentityConstants.OrleansStorageProvider"/> ///
        /// </summary>
        /// <param name="builder">Silo builder</param>
        public static ISiloBuilder UseOrleanIdentityStore(this ISiloBuilder builder)
        {
            try
            {
                builder.AddMemoryGrainStorage(ApiAuthConstants.OrleansGrantStorageProvider);
            }
            catch
            {
                // Store was already added
            }

            //JsonConvert.DefaultSettings = () =>
            //{
            //    return new JsonSerializerSettings()
            //    {
            //        Converters = new List<JsonConverter>() { new JsonClaimConverter(), new JsonClaimsPrincipalConverter(), new JsonClaimsIdentityConverter() }
            //    };
            //};

            return builder
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IGrantGrain).Assembly).WithReferences());
        }

        /// <summary>
        /// Add identity store to orleans. Grain storage provider name can be found at <see
        /// cref="OrleansIdentityConstants.OrleansStorageProvider"/> ///
        /// </summary>
        /// <param name="builder">Silo builder</param>
        public static ISiloHostBuilder UseOrleanIdentityStore(this ISiloHostBuilder builder)
        {
            try
            {
                builder.AddMemoryGrainStorage(ApiAuthConstants.OrleansGrantStorageProvider);
            }
            catch
            {
                // Store was already added
            }

            //JsonConvert.DefaultSettings = () =>
            //{
            //    return new JsonSerializerSettings()
            //    {
            //        Converters = new List<JsonConverter>() { new JsonClaimConverter(), new JsonClaimsPrincipalConverter(), new JsonClaimsIdentityConverter() }
            //    };
            //};

            return builder
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IGrantGrain).Assembly).WithReferences());
        }
    }
}
