namespace Repository
{
    public class ServiceBase
    {
        protected BaseDbContext context = null;
        public ServiceBase()
        {
            context = new BaseDbContext();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
