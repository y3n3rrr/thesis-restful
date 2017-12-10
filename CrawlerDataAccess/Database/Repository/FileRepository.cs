using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDataAccess.Database.Repository
{
    public class FileRepository //: GenericRepository<T>, IDisposable
    {
        public FileRepository(CrawlerDBContext context)
            ///: base(context)
        {
            context.Configuration.ProxyCreationEnabled = false;
        }
      
        public void Dispose()
        {
            Dispose();
        }
    }
}
