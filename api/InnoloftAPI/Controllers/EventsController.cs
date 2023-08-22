using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace InnoloftAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class EventsController : ControllerBase
    {

        [HttpGet("[action]/{UserID}")]
        public IEnumerable<EventInfo> GetCurrentUserEvents(int UserID)
        {
            checkDBExists();
            sqlLiteDbContext c = new sqlLiteDbContext();
            return c.Events.Where(x => x.AuthorID == UserID).ToList();
        }
        [HttpGet]
        public IEnumerable<EventInfo> Get()
        {
            checkDBExists();
            sqlLiteDbContext c = new sqlLiteDbContext();
            return c.Events.ToList();
        }
        private void checkDBExists()
        {
            string dbName = "innodb.db";
            if (!System.IO.File.Exists(dbName))
            {
                sqlLiteDbContext c = new sqlLiteDbContext();
                c.Database.EnsureCreated();
                if (c.Events.ToList().Count == 0)
                {
                    c.Events.AddRange(new EventInfo[] {
                    new EventInfo(){EventID=1, AuthorID=1, EventName="Product Launch", Description = "Product launch company event organized by XYZ ", EventAddress="Event Address", IsOnline=false, EventStartDateTime=new DateTime(2023,8,1,15,0,0),EventEndDateTime=new DateTime(2023,8,1,16,0,0), TimeZone="GMT +01:00" },
                    new EventInfo(){EventID=2,  AuthorID=1, EventName="Product Awareness Programe", Description = "Product Awareness Programe organized by XYZ ", EventAddress="Company Location", IsOnline=false, EventStartDateTime=new DateTime(2023,8,31,10,0,0), EventEndDateTime= new DateTime(2023,8,31,11,0,0) , TimeZone="GMT +01:00" },
                });
                }
                c.SaveChanges();
            }
        }

    }
}
