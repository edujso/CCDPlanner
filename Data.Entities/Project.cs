using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        public string Name { get; set; }

        public string Budget { get; set; }

        public string Sponsor { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ICollection<Record> Records { get; set; }
            = new List<Record>();
    }
}
