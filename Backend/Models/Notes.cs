using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Notes
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        public string Note { get; set; }

        public DateTime ActionDate { get; set; }
        public string ActionNote { get; set; }

        public Boolean Urgent { get; set; }
        public Boolean Callback { get; set; }
    }
}
