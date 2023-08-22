using InnoloftAPI.Controllers;
using static InnoloftAPI.Controllers.EventsController;
using InnoloftAPI.Models;
namespace InnoloftAPI
{
    public static class DBHelper
    {
        internal static void checkDBExists()
        {
            string dbName = "innodb.db";
            if (!File.Exists(dbName))
            {
                sqlLiteDbContext c = new sqlLiteDbContext();
                c.Database.EnsureCreated();
                if (c.Events.ToList().Count == 0)
                {
                    c.Events.AddRange(
                        new EventInfo[]
                        {
                            new EventInfo(){EventID=1, AuthorID=1, EventName="Product Launch", Description = "Product launch company event organized by XYZ ", EventAddress="Event Address", IsOnline=false, EventStartDateTime=new DateTime(2023,8,1,15,0,0),EventEndDateTime=new DateTime(2023,8,1,16,0,0), TimeZone="GMT +01:00" },
                            new EventInfo(){EventID=2,  AuthorID=2, EventName="Product Awareness Programe", Description = "Product Awareness Programe organized by XYZ ", EventAddress="Company Location", IsOnline=false, EventStartDateTime=new DateTime(2023,8,31,10,0,0), EventEndDateTime= new DateTime(2023,8,31,11,0,0) , TimeZone="GMT +01:00" },
                        }
                    );
                    c.SaveChanges();
                }

                if (c.Users.ToList().Count == 0)
                {
                    c.Users.AddRange(
                        new UserInfo[]
                        {
                            new UserInfo(){id=1,name="Ishrar Godil", username="ishrarg",email="ishrarg@gmail.com", address="India", company="Ishrar", phone="+91-11223344", website="ishrar.in" },
                            new UserInfo(){id=2,name="Leanne Graham",username="Bret", email="Sincere@april.biz", address="India", company="Romaguera-Crona", phone="1-770-736-8031 x56442", website="hildegard.org" }
                        }
                    );
                    c.SaveChanges();
                }

            }
        }
    }
}
