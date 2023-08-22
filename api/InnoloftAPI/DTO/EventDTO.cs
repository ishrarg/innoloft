using InnoloftAPI.Controllers;
using InnoloftAPI.Models;

namespace InnoloftAPI.DTO
{
    public class EventDTO
    {
        public EventInfo EventDetails { get; set; }
        public UserInfo OrganizerDetails { get; set; }
    }
}
