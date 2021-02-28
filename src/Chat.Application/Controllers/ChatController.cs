using Chat.Application.ViewModels;
using Chat.Business.Interfaces;
using Chat.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chat.Application.Controllers
{
    public class ChatController : Controller
    {
        private readonly IActiveUserService _activeUserService;
        public ChatController(IActiveUserService activeUserService)
        {
            _activeUserService = activeUserService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string nickname)
        {
            var activeUser = _activeUserService.ObterPorId(nickname);

            if (activeUser != null)
            {
                ViewBag.error = "The nickname is already taken. Please choose another.";
                return View();
            }

            _activeUserService.Adicionar(new ActiveUser { Nickname = nickname }, nickname);
            ViewBag.error = "";

            List<string> nicknames = new List<string>();
            var activeUsers = _activeUserService.ObterTodos();
            foreach (var users in activeUsers)
            {
                if (users != null)
                    nicknames.Add(users.Nickname);
            }

            RoomViewModel roomViewModel = new RoomViewModel { Nickname = nickname, ActiveUsers = nicknames };
            return View("Room", roomViewModel);
        }
        [HttpPost]
        public void RemoveActiveUser([FromBody] ActiveUser user)
        {
            if (user == null)
                return;

            _activeUserService.ExcluirRegistro(user.Nickname);
        }
    }
}
