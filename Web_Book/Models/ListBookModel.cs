using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_Book.Models
{
    public class ListBookModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength =3)]
        [Display(Name ="Name Book")]
        public string BookName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Genre Book")]
        public string BookGenre { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Author Book")]
        public string BookAuthor { get; set; }

    }
}