using System.Configuration;

namespace FinanceApp.Data
{
    public static class Settings
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
    }
}
