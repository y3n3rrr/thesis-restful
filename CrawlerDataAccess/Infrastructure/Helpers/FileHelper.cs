using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDataAccess.Infrastructure.Helpers
{
    public class FileHelper
    {
        public static string generatePath(string filename)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads/" + filename);
        }
    }
}
