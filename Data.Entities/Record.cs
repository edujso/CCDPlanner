using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }

        public string Name { get; set; }

        public string Budget { get; set; }

        public string Sponsor { get; set; }

        public Guid ProjectId { get; set; }
    }
}