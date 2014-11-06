namespace URP.DataAccess.Scaffolding.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this._databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>The data context.</value>
        protected ApplicationContext DataContext
        {
            get { return _dataContext ?? (_dataContext = _databaseFactory.Get()); }
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            DataContext.Commit();
        }

        private readonly IDatabaseFactory _databaseFactory;
        private ApplicationContext _dataContext;
    }
}
