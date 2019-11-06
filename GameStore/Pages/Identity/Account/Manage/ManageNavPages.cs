using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Pages.Identity.Account.Manage
{
    public static class ManageNavPages
    {
        public static string Index => "Index";

        public static string Public => "Public";

        public static string Address => "Address";

        public static string Payment => "Payment";

        public static string ChangePassword => "ChangePassword";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        
        public static string PublicNavClass(ViewContext viewContext) => PageNavClass(viewContext, Public);

        public static string AddressNavClass(ViewContext viewContext) => PageNavClass(viewContext, Address);
        
        public static string PaymentNavClass(ViewContext viewContext) => PageNavClass(viewContext, Payment);

        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}