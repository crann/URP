namespace URP.DataAccess.Scaffolding.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private ApplicationContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        protected ApplicationContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
