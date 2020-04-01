using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Tempus4._0.Models
{
    public class EmployeeMetaData
    {
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Date of Hire")]
        public Nullable<System.DateTime> HireDate { get; set; }
    }
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {

    }
}