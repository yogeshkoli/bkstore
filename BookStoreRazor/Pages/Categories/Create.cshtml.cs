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

        public async Task<IActionResult> OnPost(Category category)
        {
            await _storeContext.Category.AddAsync(category);
            await _storeContext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}