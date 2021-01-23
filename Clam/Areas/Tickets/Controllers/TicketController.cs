using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Clam.Areas.Tickets.Models;
using Clam.Repository;
using ClamDataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clam.Areas.Tickets.Controllers
{
    [Authorize(Policy = "Level-One")]
    [Area("Tickets")]
    [Route("tickets")]
    public class TicketController : Controller
    {
        private readonly UserManager<ClamUserAccountRegister> _userManager;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public TicketController(UserManager<ClamUserAccountRegister> userManager, IMapper mapper, UnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var model = await _unitOfWork.TicketControl.GetAllUserTickets(userName);

            // Model Lists & Data
            TicketHome ticketPanel = new TicketHome();
            ticketPanel.AreaUserTickets = model;
            return View(ticketPanel);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var model = await _unitOfWork.TicketControl.GetAsyncTicket(id);
            return View(model);
        }

        [HttpGet("update-ticket/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            List<SelectListItem> ticketStatus = new List<SelectListItem>();
            List<string> StatusTickets = new List<string>()
            {
                "Pending",
                "In Progress",
                "Resolved",
                "Closed"
            };

            foreach (var status in StatusTickets)
            {
                ticketStatus.Add(new SelectListItem() { Value = status, Text = status });
            }
            ViewBag.TicketStatus = ticketStatus;
            var model = await _unitOfWork.TicketControl.GetAsyncTicket(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTicket(AreaUserTicket model)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity.Name;
                await _unitOfWork.TicketControl.UpdateTicket(model, user);
                _unitOfWork.Complete();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("create-ticket")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketHome model)
        {
            try
            {
                // TODO: Add insert logic here
                var user = User.Identity.Name;
                await _unitOfWork.TicketControl.AddAsyncTicket(model.TicketModel, user);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("create-ticket-quick")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShortCutCreate(AreaUserTicket model)
        {
            try
            {
                // TODO: Add insert logic here
                var user = User.Identity.Name;
                await _unitOfWork.TicketControl.AddAsyncTicket(model, user);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost("remove-ticket")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(Guid id)
        {
            await _unitOfWork.TicketControl.RemoveTicket(id);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

    }
}