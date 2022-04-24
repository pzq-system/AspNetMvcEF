using Entity;

namespace Service
{
    public class ServiceBase
    {
        protected DbEntities context = null;

        public ServiceBase()
        {
            context = new DbEntities();
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
