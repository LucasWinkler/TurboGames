using System.Collections.Generic;
using System.Globalization;

namespace GameStore.Web.Helpers
{
    /// <summary>
    /// Contains methods to help with addresses.
    /// Such as getting a list of countries or provinces.
    /// </summary>
    public static class AddressHelper
    {
        /// <summary>
        /// Returns a dictionary of countries from .NET's System.Globalization.CultureInfo class
        /// </summary>
        /// <returns>Dictionary of countries.</returns>
        public static Dictionary<string, string> GetCountries()
        {
            var countries = new Dictionary<string, string>();
            var cultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (var culture in cultureInfo)
            {
                if (!countries.ContainsKey(new RegionInfo(culture.LCID).Name))
                {
                    countries.Add(new RegionInfo(culture.LCID).Name, new RegionInfo(culture.LCID).EnglishName);
                }
            }

            return countries;
        }

        /// <summary>
        /// Returns a dictionary of provinces
        /// </summary>
        /// <returns>Dictionary of provinces.</returns>
        public static Dictionary<string, string> GetProvinces() => new Dictionary<string, string>()
            {
                { "AB", "Alberta" },
                { "BC", "British Columbia" },
                { "MB", "Manitoba" },
                { "NB", "New Brunswick" },
                { "NF", "Newfoundland" },
                { "NT", "Northwest Territories" },
                { "NS", "Nova Scotia" },
                { "NU", "Nunavut" },
                { "ON", "Ontario" },
                { "PE", "Prince Edward Island" },
                { "PQ", "Quebec" },
                { "SK", "Saskatchewan" },
                { "YT", "Yukon" }
            };
    }
}
