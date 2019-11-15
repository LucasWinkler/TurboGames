﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Web.Pages.Admin
{
    public static class DashboardNavPages
    {
        public static string Index => "Index";

        public static string Games => "Games";

        public static string Events => "Events";

        public static string Reviews => "Reviews";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string GamesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Games);

        public static string EventsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Events);

        public static string ReviewsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Reviews);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}