using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameStore.Web.Pages.Admin
{
    public static class DashboardNavPages
    {
        public static string Index => "Index";

        public static string ManageGames => "Games";

        public static string ManageEvents => "Events";

        public static string ManageReviews => "Reviews";

        public static string GameReport => "GameReport";

        public static string GameDetailsReport => "GameDetailsReport";

        public static string MemberReport => "MemberReport";

        public static string MemberDetailsReport => "MemberDetailsReport";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string GamesNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageGames);

        public static string EventsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageEvents);

        public static string ReviewsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ManageReviews);

        public static string GameReportNavClass(ViewContext viewContext) => PageNavClass(viewContext, GameReport);

        public static string GameDetailsReportNavClass(ViewContext viewContext) => PageNavClass(viewContext, GameDetailsReport);

        public static string MemberReportNavClass(ViewContext viewContext) => PageNavClass(viewContext, MemberReport);

        public static string MemberDetailsReportNavClass(ViewContext viewContext) => PageNavClass(viewContext, MemberDetailsReport);

        private static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}