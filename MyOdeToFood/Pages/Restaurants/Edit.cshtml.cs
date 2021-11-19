using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyOdeToFood.Core;
using MyOdeToFood.Data;

namespace MyOdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? RestaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            
            if(RestaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(RestaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            
            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            
                return Page();
            } 
            
            if(Restaurant.Id > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Create(Restaurant);
            }
            
            restaurantData.Commit();

            TempData["Message"] = "Restaurant saved.";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}