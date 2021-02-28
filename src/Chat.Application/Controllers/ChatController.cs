using Chat.Application.ViewModels;
using Chat.Business.Interfaces;
using Chat.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Chat.Application.Controllers
{
    public class ChatController : Controller
    {
        private readonly IActiveUserService _activeUserService;
        private readonly IConfiguration _configuration;


        public ChatController(IActiveUserService activeUserService, IConfiguration configuration)
        {
            _activeUserService = activeUserService;
            _configuration = configuration;
            //_activeUserService.ExcluirTodosRegistros();
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string nickname)
        {
            var activeUser = _activeUserService.ObterPorId(nickname);
            if (activeUser == null)
            {
                _activeUserService.Adicionar(new ActiveUser { Nickname = nickname }, nickname);
                var activeUserConfiguration = _configuration.GetSection("ActiveUser");
                activeUserConfiguration["Nickname"] = nickname;

                var teste = _configuration.GetSection("ActiveUser");
                var teste2 = teste["Nickname"];
                ViewBag.error = "";

            }
            else
            {
                ViewBag.error = "The nickname is already taken. Please choose another.";
                return View();
            }

            List<string> nicknames = new List<string>();
            var activeUsers = _activeUserService.ObterTodos();
            foreach (var users in activeUsers)
            {
                if(users != null)
                nicknames.Add(users.Nickname);
            }
            
            RoomViewModel roomViewModel = new RoomViewModel { Nickname = nickname, ActiveUsers = nicknames };
            return View("Room", roomViewModel);
        }

        [HttpPost]
        public void RemoveActiveUser([FromBody] ActiveUser user)
        {
            _activeUserService.ExcluirRegistro(user.Nickname);            
        }
    }
}
