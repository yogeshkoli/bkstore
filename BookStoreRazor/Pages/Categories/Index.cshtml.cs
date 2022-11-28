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
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        private readonly StoreContext _storeContext;

        public IEnumerable<Category> Categories { get; set; }

        public Index(ILogger<Index> logger, StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;
        }

        public void OnGet()
        {
            Categories = _storeContext.Category.ToList();
        }
    }
}