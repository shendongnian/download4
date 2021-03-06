    /// <summary>
    /// An aggregated service provider.
    /// </summary>
    public class AggregatedServiceProvider : IServiceProvider, IDisposable
    {
        private readonly IList<IServiceProvider> innerServiceProviders;
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedServiceProvider"/> class.
        /// </summary>
        /// <param name="innerServiceProviders">A variable-length parameters list containing inner
        ///                                     service providers.</param>
        public AggregatedServiceProvider(params IServiceProvider[] innerServiceProviders)
        {
            this.innerServiceProviders = innerServiceProviders.ToList();
        }
        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <param name="serviceType">An object that specifies the type of service object to get.</param>
        /// <returns>
        /// A service object of type <paramref name="serviceType">serviceType</paramref>.   -or-  null if
        /// there is no service object of type <paramref name="serviceType">serviceType</paramref>.
        /// </returns>
        public object GetService(Type serviceType)
        {
            foreach (var serviceProvider in this.innerServiceProviders)
            {
                var service = serviceProvider.GetService(serviceType);
                if (service != null)
                {
                    return service;
                }
            }
            return null;
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        /// resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var serviceProvider in this.innerServiceProviders)
            {
                (serviceProvider as IDisposable)?.Dispose();
            }
            this.innerServiceProviders.Clear();
        }
    }
