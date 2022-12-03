using System.Linq;
using System.Text.RegularExpressions;
using TrendyolApp.Model;
namespace TrendyolApp.Services.Classes;
public static class CheckRegistration
{
    public static string? CheckUser(User? user, string? confirmPassword)
    {
        if (!string.IsNullOrEmpty(user!.UserName) &&
           !string.IsNullOrEmpty(user.Password) &&
           !string.IsNullOrEmpty(user.Address) &&
           !string.IsNullOrEmpty(user.Phone) &&
           !string.IsNullOrEmpty(user.Fin))
        {
            if (!Users.UsersDict!.ContainsKey(user!.UserName))
            {
                if (user.Password == confirmPassword)
                {
                    if (user.Password.Length >= 6 &&
                        user.Password.Any(char.IsLetter) &&
                        user.Password.Any(char.IsDigit) &&
                        user.Password.Any(char.IsLower) &&
                        user.Password.Any(char.IsUpper))
                    {
                        if (Regex.IsMatch(user?.Phone!, "\\+?[1-9][0-9]{7}"))
                        {
                            Users.UsersDict.Add(user!.UserName, user);
                            return null;
                        }
                        return "Phone number should contain digits and need be more than 7 simbols";
                    }
                    return "Password should contain of: lower and upper letters,digits,punctuations";
                }
                return "Password is not equal confirm password!";
            }
            return "Choose another username!";
        }
        return "Line empty!";
    }
}

