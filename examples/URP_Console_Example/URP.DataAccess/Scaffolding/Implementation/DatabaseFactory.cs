namespace URP.DataAccess.Scaffolding.Implementation
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private ApplicationContext dataContext;

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        public ApplicationContext Get()
        {
            return dataContext ?? (dataContext = new ApplicationContext());
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
