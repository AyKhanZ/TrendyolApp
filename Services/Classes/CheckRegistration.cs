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
                            if (Regex.IsMatch((user?.Serial!), @"^[a-zA-Z]{2,3}(\d{7,15})$"))
                            {
                                if (Regex.IsMatch((user?.Address!), @"^[A-Za-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{1,63}$"))
                                {
                                    if (Regex.IsMatch((user?.Phone!), @"^(070)|(050)|(010)|(055)|(051)|(077)[0-9]$") && user?.Phone!.Length == 10)
                                    {
                                        if (Regex.IsMatch((user?.Fin!), @"^[a-zA-Z0-9]{6,9}$"))
                                        {
                                            Users.UsersDict.Add(user!.UserName, user);
                                            return null;
                                        }
                                        return "FIN number must have 6-9 symbols of alphabits and digits \n(Ex: 7FCW2x2)";
                                    }
                                    return "Phone number must be az-format and contains 10 simbols";
                                }
                                return "Invalid email! Email must contain '@',digits,althabits and length must be more than 1 and less than 63 !";
                            }
                            return "Serial in the beginning must have 2-3 english alphabit and 7-15 digits!\n(Ex: AA1234567 or Aab1234567890)";
                        }
                        return "Password is not equal confirm password!";
                    }
                    return "The password must be at least 8 characters long and contain 1 digit ,1 uppercase (A-Z) and 1 lowercase (a-z) letters";

                }
                return "Choose another username!";

            }
            return "Incorrect username format!\n" +
            "Username\'s length must be more than 4 and less than 15 simbols and must be english althabit.Can be contain of any simbols!";
        }
        return "Line empty!";
    }



}
