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
    public class Create : PageModel
    {
        private readonly ILogger<Create> _logger;
        public Category Category { get; set; }

        private readonly StoreContext _storeContext;

        public Create(ILogger<Create> logger, StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                await _storeContext.Category.AddAsync(Category);
                await _storeContext.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}