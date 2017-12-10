using CrawlerDataAccess.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDataAccess.Database
{
    public class DatabaseContext : UnitOfWork
    {
        protected static object lockObj = new object();
        protected DatabaseContext _instance = null;
        private DatabaseContext() { } //Singleton

        public static DatabaseContext Current
        {
            get
            {
                //if (_instance == null)
                //{
                //    lock (lockObj)
                //    {
                //        if (_instance == null)
                //            _instance = new DatabaseContext();
                //    }
                //}
                //return _instance;
                return new DatabaseContext();
            }
        }

        private FileRepository _fileRepository;

        public FileRepository UserRepository
        {
            get
            {
                if (this._fileRepository == null)
                {
                    this._fileRepository = new FileRepository(context);
                }
                return _fileRepository;
            }
        }

       
    }
}
