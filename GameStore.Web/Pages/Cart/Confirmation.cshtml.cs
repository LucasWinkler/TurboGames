using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore.Web.Pages.Cart
{
    public class ConfirmationModel : PageModel
    {
        public void OnGet(Guid cartId)
        {
            /* TODO:
             * Make sure user is signed in.
             * Find the cart by id. If no cart then redirect to cart or home.
             * If cart doesnt belong to the current user then show access-denied page.
             * Display details
             */

            Debug.WriteLine("---> Cart Id:" + cartId);
        }
    }
}