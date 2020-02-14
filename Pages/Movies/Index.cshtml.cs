using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesMovie
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Data.RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovie.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        [BindProperty(SupportsGet = true)]          // Binds form values and query strings with the same name as the property
        public string SearchString {get; set;}      // This will contain the user search string
        // Need to use Microsoft.AspNetCore.Mvc.Rendering; 
        public SelectList Genres { get; set;}       // Will contain a list of genres
        [BindProperty(SupportsGet = true)]  
        public string MovieGenre { get; set;}       // Contains the genre the user selected

        public async Task OnGetAsync()
        {
            var movies = from m in _content.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString)) 
            {
                movies = movies.Where(s=> s.Title.Contains(SearchString));
            }


            Movie = await _context.Movie.ToListAsync();
        }
    }
}
