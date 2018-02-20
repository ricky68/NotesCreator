using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NotesCreatorDTO
{
    [Table("Notes")]
    public class NoteDTO
    {
        public int ID { get; set; } // An entry of ID is automatically treated as the Key! //

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        public int ConsultantNameID { get; set; }
        [Display(Name = "Consultant")]
        public ConsultantDTO ConsultantName { get; set; }

        [Required]
        [Display(Name = "Note")]
        [Column("Note")]
        public string MainNote { get; set; }
        public NoteActionDTO NoteAction { get; set; }
    }

    public class NoteActionDTO
    {
        public int ID { get; set; } // An entry of ID is automatically treated as the Key! //

        [DisplayFormat(DataFormatString = "{0:dd MMM yy hh:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Action Date")]
        public DateTime ActionDate { get; set; }

        [Display(Name = "Action Note")]
        public string ActionNote { get; set; } = "";

        public int ActionNameID { get; set; }
        [Display(Name = "Action For")]
        public ConsultantDTO ActionName { get; set; }

        public Boolean Urgent { get; set; }
        public Boolean Callback { get; set; }

        public int NoteID { get; set; }
        public NoteDTO Note {get; set;}
    }
}
