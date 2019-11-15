using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Web.Pages.Account.Settings
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Profile => "Profile";

        public static string Address => "Address";

        public static string Payment => "Payment";

        public static string ChangePassword => "ChangePassword";

        public static string Preferences => "Preferences";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        
        public static string ProfileNavClass(ViewContext viewContext) => PageNavClass(viewContext, Profile);

        public static string AddressNavClass(ViewContext viewContext) => PageNavClass(viewContext, Address);
        
        public static string PaymentNavClass(ViewContext viewContext) => PageNavClass(viewContext, Payment);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        public static string PreferencesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Preferences);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}