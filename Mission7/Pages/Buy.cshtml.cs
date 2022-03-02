using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Infrastructure;
using Mission7.Models;

namespace Mission7.Pages
{
    public class BuyModel : PageModel
    {
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }



        private iBookRepository repo { get; set; }

        public BuyModel (iBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        public void OnGet(string returnUrl)
        {

            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost( int BookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == BookId);
            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

    }
}
