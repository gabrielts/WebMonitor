using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTSWebServiceMonitor.DB
{
    public class ServiceDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        public ObservableCollection<Service> Services { get; set; }

        private static ServiceDataAccess dataAccess;
        public static ServiceDataAccess DataAccess
        {
            get
            {
                if (dataAccess == null)
                {
                    dataAccess = new ServiceDataAccess();
                }
                return dataAccess;
            }
        }

        public ServiceDataAccess()
        {
            database =
              DependencyService.Get<IDatabaseConnection>().
              DbConnection();
            database.CreateTable<Service>();
            this.Services =
              new ObservableCollection<Service>(database.Table<Service>());
            
            if (!database.Table<Service>().Any())
            {
                Service s = new Service()
                {
                    Description = "Google",
                    URL = "http://www.google.com"
                };
                SaveService(s);
                Service s1 = new Service()
                {
                    Description = "Microsoft",
                    URL = "http://www.microsoft.com"
                };
                SaveService(s1);
            }
        }

        private void AddNewService(Service service)
        {
            this.Services.Add(service);
        }

        public int SaveService(Service service)
        {
            lock (collisionLock)
            {
                if (service.Id != 0)
                {
                    database.Update(service);
                    return service.Id;
                }
                else
                {
                    database.Insert(service);
                    AddNewService(service);
                    return service.Id;
                }
            }
        }

        public int DeleteService(Service service)
        {
            var id = service.Id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Service>(id);
                }
            }
            this.Services.Remove(service);
            return id;
        }
    }
}
