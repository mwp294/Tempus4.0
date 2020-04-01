using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Tempus4._0.Models
{
    public class JobsMetaData
    {
        [StringLength(50)]
        public string Title { get; set; }
        [Range(1, 12)]
        public int Hours { get; set; }
        [StringLength(50)]
        public string Shift { get; set; }
    }
[MetadataType(typeof(JobsMetaData))]
    public partial class Job
    {

    }
}