using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnoxyWeb.Data;
using AnoxyWeb.Model;
using AnoxyWeb.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnoxyWeb.Pages.Categories
{
    [BindProperties]
	public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        //public async Task<IActionResult> OnPost(Category category)
        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError(Category.Name, "The Display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";

                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}

