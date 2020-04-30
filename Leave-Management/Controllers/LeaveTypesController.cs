using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Leave_Management.Data;
using Leave_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers
{
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
        public ActionResult Index()
        {
            var leavetypes = _leaveTypeRepo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeViewModel>>(leavetypes);
            return View(model);
        }

        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                    return View(model);

                var leaveType = _mapper.Map<LeaveType>(model);
                leaveType.DateCreated = DateTime.Now;

                var isSuccess = _leaveTypeRepo.Create(leaveType);

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
        public ActionResult Edit(int id)
        {
            if (!_leaveTypeRepo.IsExists(id))
                return NotFound();

            var leaveType = _leaveTypeRepo.FindById(id);
            var model = _mapper.Map<LeaveTypeViewModel>(leaveType);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                    return View(model);

                var leaveType = _mapper.Map<LeaveType>(model);
                if(!_leaveTypeRepo.Update(leaveType))
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}