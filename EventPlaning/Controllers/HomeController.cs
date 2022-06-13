using EventPlaning.Models;
using EventPlaning.Models.Users;
using EventPlaning.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace EventPlaning.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;

        private IUserEventService _userEventService;
        private IParticipantService _participantService;

        public HomeController(IParticipantService participantService, IUserEventService userEventService, UserManager<User> userManager)
        {
            _userEventService = userEventService ?? throw new ArgumentNullException(nameof(userEventService));
            _participantService = participantService ?? throw new ArgumentNullException(nameof(participantService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public IActionResult Index() => View(_userEventService.GetItems());

        [HttpGet]
        public IActionResult Create() => View();

        public IActionResult Create(UserEvent userEvent)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _userEventService.AddItem(userEvent, userId);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GoToEvent(Guid Id)
        {
            if (Id != null)
            {
                var userEvent = _userEventService.GetItemById(Id);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userEvent.Owner != Guid.Parse(userId) && userId != null)
                {
                    _participantService.GoToEvent(eventId: Id, userEvent: userEvent, userId: userId);
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
