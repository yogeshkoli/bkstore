using BookStoreRazor.Data;
using BookStoreRazor.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreRazor.Pages.Categories
{
    [BindProperties]
    public class Delete : PageModel
    {
        private readonly ILogger<Delete> _logger;

        private readonly StoreContext _storeContext;

        public Category Category { get; set; }

        public Delete(ILogger<Delete> logger, StoreContext storeContext)
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
            var category = _storeContext.Category.Find(Category.Id);
            if (category != null)
            {
                _storeContext.Category.Remove(category);
                await _storeContext.SaveChangesAsync();
                TempData["success"] = "Category deleted successfully!";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}