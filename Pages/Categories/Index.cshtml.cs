using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnoxyWeb.Data;
using AnoxyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnoxyWeb.Pages.Categories
{
	public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Category> Categories { get; set; }

        //Implementation of it with container
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
