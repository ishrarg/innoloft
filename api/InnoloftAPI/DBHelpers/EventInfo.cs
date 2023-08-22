using System.ComponentModel;

namespace InnoloftAPI.Models
{
   
        public class EventInfo
        {
            public int EventID { get; set; }
            public string EventName { get; set; }
            public string Description { get; set; }
            public DateTime EventStartDateTime { get; set; }
            public DateTime EventEndDateTime { get; set; }
            public int AuthorID { get; set; }
            public string EventAddress { get; set; }
            public bool IsOnline { get; set; }
            [DefaultValue("GMT +1:00")]
            public string? TimeZone { get; set; }

        }


    
}
