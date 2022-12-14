using System.Linq;
using System.Text.RegularExpressions;
using TrendyolApp.Model;
namespace TrendyolApp.Services.Classes;
public static class CheckRegistration
{
    public static string? CheckUser(User? user, string? confirmPassword)
    {
        if (!string.IsNullOrEmpty(user?.Address) &&
           !string.IsNullOrEmpty(user?.UserName) &&
           !string.IsNullOrEmpty(user?.Password) &&
           !string.IsNullOrEmpty(confirmPassword!) &&
           !string.IsNullOrEmpty(user?.Serial) &&
           !string.IsNullOrEmpty(user?.Phone) &&
           !string.IsNullOrEmpty(user?.Fin))
        {
            if (Regex.IsMatch((user?.UserName!), @"^[~`!@#$%^&*()_+=[\]\\{}|;':"",.\/<>?a-zA-Z0-9-]{4,15}$"))
            {
                if (!Users.UsersDict!.ContainsKey(user!.UserName))
                {
                    if (Regex.IsMatch((user?.Password!), @"^[A-Za-z0-9]{8,}$") && user!.Password!.Any(char.IsUpper) && user!.Password!.Any(char.IsLower) && user!.Password!.Any(char.IsDigit))
                    {
                        if (user?.Password == confirmPassword)
                        {
                            if (Regex.IsMatch((user?.Serial!), @"^[A-Z]{2,3}(\d{7,10})$"))
                            {
                                if (Regex.IsMatch((user?.Address!), @"^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{1,50}$"))
                                {
                                    if (Regex.IsMatch((user?.Phone!), @"^(070)|(050)|(010)|(055)|(051)|(077)[0-9]$") && user?.Phone!.Length == 10)
                                    {
                                        if (Regex.IsMatch((user?.Fin!), @"^[A-Z0-9]{6,9}$"))
                                        {
                                            Users.UsersDict.Add(user!.UserName, user);
                                            return null;
                                        }
                                        return "FIN number must have 6-9 symbols of upper alphabits and digits \n(Ex: 7FCW2X2)";
                                    }
                                    return "Phone number must be az-format and contains 10 simbols";
                                }
                                return "Invalid email! Email must contain '@',digits,althabits!";
                            }
                            return "Serial in the beginning must have 2-3 uppercase english alphabit and digits!\n(Ex: AA1234567 or AKP1234567)";
                        }
                        return "Password is not equal confirm password!";
                    }
                    return "The password must be at least 8 characters long and contain 1 digits,uppercase(A-Z) and lowercase(a-z) letters";
                }
                return "Choose another username!";
            }
            return "Incorrect username format!\n" +
            "Username must be than 4 any simbols and must be english althabit!";
        }
        return "Line empty!";
    }
}