using System.Collections.Generic;

namespace Chat.Application.ViewModels
{
    public class RoomViewModel
    {
        public string Nickname { get; set; }
        public List<string> ActiveUsers { get; set; }
    }
}
