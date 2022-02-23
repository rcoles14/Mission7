using Microsoft.AspNetCore.Mvc;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private iBookRepository repo { get; set; }

        public CategoryViewComponent (iBookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCat = RouteData?.Values["category"];
            var cat = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cat);
        }
    }
}
