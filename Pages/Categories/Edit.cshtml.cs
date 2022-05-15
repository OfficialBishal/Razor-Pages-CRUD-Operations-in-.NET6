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
	public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //[BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);   //This will populate the input field in Page(View)
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
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}

