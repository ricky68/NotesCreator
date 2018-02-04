using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Note
    {
        public int ID { get; set; } // An entry of ID is automatically treated as the Key! //

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }
     
        public int ConsultantNameID { get; set; }
        //[ForeignKey("ConsultantNameID")]
        [Required]
        [Display(Name = "Consultant")]
        [Column("Consultant")]
        public Consultant ConsultantName { get; set; }

        [Required]
        [Display(Name = "Note")]
        [Column("Note")]
        public string MainNote { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Action Date")]
        public DateTime? ActionDate { get; set; }
        [Display(Name = "Action Note")]
        public string ActionNote { get; set; } = "";

        public int ActionNameID { get; set; }
        //[ForeignKey("ActionNameID")]
        [Display(Name = "Action For")]
        public Consultant ActionName { get; set; }

        public Boolean Urgent { get; set; }
        public Boolean Callback { get; set; }
    }

    public class Consultant
    {
        public int ID { get; set; } // An entry of ID is automatically treated as the Key! //
        [Required]
        [StringLength(50, ErrorMessage = "Full name cannot be longer than 50 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public Boolean Active { get; set; } = true; // Sets the default value to true!

        //public ICollection<Note> ConsultantName { get; set; }

        //public ICollection<Note> ActionName { get; set; }
    }

}
