using System.Text.RegularExpressions;

namespace SchoolManagementSystem.Configurations
{
    public static class StringAdditions
    {
        public static bool IsEmail(this string text){
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(text);
            if (match.Success)
                return true;
            return false;
        }
    }
}