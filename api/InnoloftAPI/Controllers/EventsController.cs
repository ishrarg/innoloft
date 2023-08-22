
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using InnoloftAPI;
using InnoloftAPI.DTO;
using InnoloftAPI.Models;

namespace InnoloftAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public partial class EventsController : ControllerBase
    {

        [HttpGet("[action]/{UserID}")]
        public IEnumerable<EventInfo> GetUserEvents(int UserID)
        {
            DBHelper.checkDBExists();
            sqlLiteDbContext c = new sqlLiteDbContext();
            return c.Events.Where(x => x.AuthorID == UserID).ToList();
        }
        //[HttpGet]
        //public IEnumerable<EventInfo> Get()
        //{
        //    DBHelper.checkDBExists();
        //    sqlLiteDbContext c = new sqlLiteDbContext();
        //    return c.Events.ToList();
        //}

        [HttpGet("[action]/{EventID}")]
        public EventDTO GetEvent(int EventID)
        {
            DBHelper.checkDBExists();
            sqlLiteDbContext c = new sqlLiteDbContext();
            var eventInfo = (from eve in c.Events
                     where eve.EventID == EventID
                     select eve).FirstOrDefault();
            var o = (from i in c.Users where i.id == eventInfo.AuthorID select i).FirstOrDefault();
            var retVal = new EventDTO { EventDetails = eventInfo, OrganizerDetails = o };
            return retVal;
        }

        [HttpPost("[action]")]
        public void UpdateEvent(EventInfo p)
        {
            sqlLiteDbContext c = new sqlLiteDbContext();
            var eventObj = new EventInfo();
            if (p.EventID > 0)
            {
                eventObj = c.Events.Where(x => x.EventID == p.EventID).FirstOrDefault();
            }
            eventObj.EventName = p.EventName;
            eventObj.Description = p.Description;
            eventObj.EventStartDateTime = p.EventStartDateTime;
            eventObj.EventEndDateTime = p.EventEndDateTime;
            eventObj.AuthorID = p.AuthorID;
            eventObj.IsOnline = p.IsOnline;
            eventObj.TimeZone = p.TimeZone;
            eventObj.EventAddress = p.EventAddress;

            if (p.EventID == 0)
            {
                c.Events.Add(eventObj);
            }
            c.SaveChanges();
        }
        [HttpPost("[action]")]
        public void RemoveEvent(EventInfo p)
        {
            sqlLiteDbContext c = new sqlLiteDbContext();
            var eventObj = new EventInfo();
            if (p.EventID > 0)
            {
                eventObj = c.Events.Where(x => x.EventID == p.EventID).FirstOrDefault();
                c.Events.Remove(eventObj);
                c.SaveChanges();
            }
        }
    }
}
