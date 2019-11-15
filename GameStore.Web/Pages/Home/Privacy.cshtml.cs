using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameStore.Web.Pages.Home
{
    [AllowAnonymous]
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}