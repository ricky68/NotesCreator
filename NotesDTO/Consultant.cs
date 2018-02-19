using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NotesCreatorDTO
{
    [Table("Consultants")]
    public class ConsultantDTO
    {
        public int ID { get; set; } // An entry of ID is automatically treated as the Key! //
        [Required]
        [StringLength(50, ErrorMessage = "Full name cannot be longer than 50 characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public Boolean Active { get; set; } = true; // Sets the default value to true!
        //[NotMapped]
        //public ICollection<NoteDTO> Notes { get; set; }
    }
}
