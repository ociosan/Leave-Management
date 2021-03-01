using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class LeaveTypesController : Controller
    {
        //Dependency Injection
        private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository therepo, IMapper themapper)
        {
            _leaveTypeRepo = therepo;
            _mapper = themapper;
        }

        // GET: LeaveTypes
        public async Task<ActionResult> Index()
        {
            var leavetypes = await _leaveTypeRepo.FindAll();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leavetypes.ToList());
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _leaveTypeRepo.IsExists(id);
            if (!isExists)
                return NotFound();

            var leaveType = await _leaveTypeRepo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LeaveTypeViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View(model);

                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                bool isSuccess = await _leaveTypeRepo.Create(leaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            bool isExists = await _leaveTypeRepo.IsExists(id);
            if (!isExists) 
                return NotFound();

            var leaveType = await _leaveTypeRepo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LeaveTypeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var leaveType = _mapper.Map<LeaveType>(model);
                bool leaveTypeUpdateResult = await _leaveTypeRepo.Update(leaveType);
                if (!leaveTypeUpdateResult)
                {
                    ModelState.AddModelError("","Something went wrong...");
                    return View(model);

                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("","Something went wrong...");
                return View(model);
            }
        }

        // GET: LeaveTypes/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var leaveType = await _leaveTypeRepo.FindById(id);
            if (leaveType == null)
                return NotFound();

            bool leaveTypeRepoDeleteResult = await _leaveTypeRepo.Delete(leaveType);

            if (!leaveTypeRepoDeleteResult)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, LeaveTypeViewModel model)
        {
            try
            {

                var leaveType = await _leaveTypeRepo.FindById(id);
                if (leaveType == null)
                    return NotFound();

                bool leaveTypeRepoDeleteResult = await _leaveTypeRepo.Delete(leaveType);
                if (!leaveTypeRepoDeleteResult)
                    return View(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(model);
            }
        }
    }
}