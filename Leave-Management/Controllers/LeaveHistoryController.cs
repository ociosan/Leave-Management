using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Leave_Management.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave_Management.Controllers
{
    public class LeaveHistoryController : Controller
    {
        //Dependency Injection
        private readonly ILeaveRequestRepository _leaveHistoryRepo;
        private readonly IMapper _mapper;

        public LeaveHistoryController(ILeaveRequestRepository therepo, IMapper themapper)
        {
            _leaveHistoryRepo = therepo;
            _mapper = themapper;
        }

        // GET: LeaveHistory
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeaveHistory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveHistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveHistory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveHistory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveHistory/Delete/5
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