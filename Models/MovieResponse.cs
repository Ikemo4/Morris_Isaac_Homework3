using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Morris_Isaac_Homework3.Models
{
    public class MovieResponse
    {
        [Required]
        public string Category { get; set; }
        [Required]
        [RegularExpression("^(?!Independence Day$).*$", ErrorMessage = "Independence Day cannot be added to the database.")]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool? Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage = "Note must be 25 characters or less")]
        public string Notes { get; set; }
    }
}
