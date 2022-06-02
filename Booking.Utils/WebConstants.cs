namespace Booking.Utils
{
    public static class WebConstants
    {
        public class Account
        {
            public const string MemberRole = "Member";
            public const string AdminRole = "Admin";
            
            public class Routes
            {
                public const string BaseRoute = "api/account";
                public const string Login = "login";
                public const string Register = "register";
                public const string CurrentUser = "current-user";
            }
        }
        
        public class Advertisement
        {
            public class Routes
            { 
                public const string BaseRoute = "api/advertisement";
                public const string GetById = "get-by-id";
            }
        }

        public class Filter
        {
            public class Routes
            { 
                public const string BaseRoute = "api/filter";
            }
        }

        public class Prepopulator
        {
            public const string Execute = "FillInDatabase";
            public const string CountriesFileName = "countries.json";
            public const string CitiesFileName = "cities.json";
            public const string AdvertisementsFileName = "advertisements.json";
            public const string ApplicationRolesFileName = "roles.json";
            public const string ApplicationUsersFileName = "users.json";
            
            public class Routes
            { 
                public const string BaseRoute = "api/prepopulator";
            }
        }
    }
}
