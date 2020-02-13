using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {

        public int ID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Release Date")] // Sets the display name of the variable on the /movies index page
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [Column(TypeName = "decimal(18,2)")] // Allows the EF Core to correctly display the currency in the database
        public decimal Price { get; set; }

    }
}
