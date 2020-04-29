using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    /*The view model is kind of a clone of a entity framework class but, it only takes the fields we want to get to the UI*/
    /*The IEnumerable reflects the foreign key join, example: 1 Employee to many LeavesTypes*/
    public class LeaveHistoryViewModel
    {

        public int Id { get; set; }
        public EmployeeViewModel RequestingEmployee { get; set; }
        public string RequestingEmployeeId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public DetailsLeaveTypeViewModel LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public IEnumerable<SelectListItem> LeaveTypes { get; set; }
        public DateTime DateRequested { get; set; }
        public DateTime DateActioned { get; set; }
        public bool? Approved { get; set; }
        public EmployeeViewModel ApprovedBy { get; set; }
        public string ApprovedById { get; set; }
    }
}
