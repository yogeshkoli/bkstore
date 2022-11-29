using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreRazor.Data;
using BookStoreRazor.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BookStoreRazor.Pages.Categories
{
    [BindProperties]
    public class Edit : PageModel
    {
        private readonly ILogger<Edit> _logger;

        private readonly StoreContext _storeContext;

        public Category Category { get; set; }

        public Edit(ILogger<Edit> logger, StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;
        }

        public void OnGet(int id)
        {
            Category = _storeContext.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _storeContext.Category.Update(Category);
                await _storeContext.SaveChangesAsync();
                TempData["success"] = "Category updated successfully!";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}