using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using TrendyolApp.Model;
namespace TrendyolApp.Services.Classes;
public static class CheckOrder
{
    public static bool CheckDeclareOrder(Order? order, string? user_info)
    {
        if (!string.IsNullOrWhiteSpace(order?.Price)
            && !string.IsNullOrWhiteSpace(order?.Quantity)
            && !string.IsNullOrWhiteSpace(order?.Link)
            && !string.IsNullOrWhiteSpace(order?.ProductCategory)
            && !string.IsNullOrWhiteSpace(order?.TrackingNumber))
        {
            if (Regex.IsMatch((order?.Link!), @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
            {
                if (Regex.IsMatch((order?.TrackingNumber!), @"^[0-9]+$"))
                {
                    if (Regex.IsMatch((order?.ProductCategory!), @"^[A-Za-z]+$"))
                    {
                        if (Regex.IsMatch((order?.Price!), @"^[0-9]+$"))
                        {
                            if (Convert.ToInt32(order?.Price) <= 0) { MessageBox.Show("Price should be more than 0!"); return false; }
                            else
                            {
                                if (Regex.IsMatch((order?.Quantity!), @"^[0-9]+$"))
                                {
                                    if (Convert.ToInt32(order?.Quantity) <= 0) { MessageBox.Show("Quality should be more than 0!"); return false; }
                                    else
                                    {
                                        if (Users.UsersDict![user_info!]!.Balance - Convert.ToInt32(order?.Price) * Convert.ToInt32(order!.Quantity) >= 0)
                                        {
                                            return true;
                                        }
                                        else { MessageBox.Show("You have no enought money on your balance!"); return false; }
                                    }
                                }
                                else { MessageBox.Show("Invalid quantity!It must be contains only of digits!"); return false; }
                            }
                        }
                        else { MessageBox.Show("Invalid price!It must be contains only of digits!"); return false; }
                    }
                    else { MessageBox.Show("Invalid product category!It must be contains only of althabits!"); return false; }
                }
                else { MessageBox.Show("Invalid tracing number! It must be contains only of digits!"); return false; }
            }
            else MessageBox.Show("Invalid link"); return false;
        }
        else { MessageBox.Show("Link,size,color,price rows are requared!"); return false; }
    }
    public static bool CheckPlaceOrder(Order? order, string? user_info)
    {
        if (!string.IsNullOrWhiteSpace(order?.Link)
            && !string.IsNullOrWhiteSpace(order?.Size)
            && !string.IsNullOrWhiteSpace(order?.Color)
            && !string.IsNullOrWhiteSpace(order?.Quantity)
            && !string.IsNullOrWhiteSpace(order?.Price)
            && !string.IsNullOrWhiteSpace(order?.ShopDeliveryPrice))
        {
            if (Regex.IsMatch((order?.Link!), @"^http(s)?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$"))
            {
                if (Regex.IsMatch((order?.Size!), @"^[A-Za-z0-9]+$"))
                {
                    if (Regex.IsMatch((order?.Color!), @"^[A-Za-z]+$"))
                    {
                        if (Regex.IsMatch((order?.Quantity!), @"^[0-9]+$"))
                        {
                            if (Convert.ToInt32(order?.Quantity) <= 0) { MessageBox.Show("Quality should be more than 0!"); return false; }
                            else
                            {
                                if (Regex.IsMatch((order?.Price!), @"^[0-9]+$") && order!.Price!.Any(char.IsDigit))
                                {
                                    if (Regex.IsMatch((order?.ShopDeliveryPrice!), @"^[0-9]+$") && order!.ShopDeliveryPrice!.Any(char.IsDigit))
                                    {
                                        if (Convert.ToSingle(order.Price) <= 0 && Convert.ToSingle(order.ShopDeliveryPrice) <= 0) { MessageBox.Show("Price should be more than 0!"); return false; }
                                        else
                                        {
                                            if (Users.UsersDict![user_info!]!.Balance - Convert.ToSingle(order?.Price) * Convert.ToInt32(order?.Quantity) - Convert.ToSingle(order?.ShopDeliveryPrice) * Convert.ToInt32(order?.Quantity) >= 0)
                                            {
                                                return true;
                                            }
                                            else { MessageBox.Show("You have no enought money on your balance!"); return false; }
                                        }
                                    }
                                    else MessageBox.Show("Invalid shop delivery price! It must be digit!"); return false;
                                }
                                else MessageBox.Show("Invalid Price! It must be digit!"); return false;
                            }
                        }
                        else MessageBox.Show("Invalid quality! It must be digit!"); return false;
                    }
                    else MessageBox.Show("Invalid color!Color must be contains only althabit\n (Ex: black,white,pink,green,...)"); return false;
                }
                else MessageBox.Show("Invalid size!Size can be contains only of althabits and digits\n (Ex: M,XXL,45,32,...)"); return false;
            }
            else MessageBox.Show("Invalid link"); return false;
        }
        else { MessageBox.Show("Link,size,color,quantity,price,shop delivery price rows have to be completed"); return false; }
    }
    public static bool CheckBalance(BalanceCardService? card)
    {
        if (!string.IsNullOrWhiteSpace(card?.HexCode)
            && !string.IsNullOrWhiteSpace(card?.NameBankCard)
            && !string.IsNullOrWhiteSpace(card?.Balance)
            && !string.IsNullOrWhiteSpace(card?.Cvv)
            && !string.IsNullOrWhiteSpace(card?.ValidThru))
        {
            if (Regex.IsMatch((card?.NameBankCard!), @"^[a-zA-Z0-9]+$"))
            {
                if (Regex.IsMatch((card?.HexCode!), @"^[0-9]{16}$"))
                {
                    if (Regex.IsMatch((card?.Balance!), @"^[0-9]+$"))
                    {
                        if (Regex.IsMatch((card?.Cvv!), @"^[0-9]{3}$"))
                        {
                            if (Regex.IsMatch((card?.ValidThru!), @"^[0-9]{2}/[0-9]{2}$"))
                            {
                                return true;
                            }
                            else MessageBox.Show("Invalid Valid thru!Valid thru must be 2 digits/2 digits\n (Ex: 02/27,03/12,...)"); return false;
                        }
                        else MessageBox.Show("Invalid CVV!CVV must be  3 digits\n (Ex: 027,312,...)"); return false;
                    }
                    else MessageBox.Show("Invalid balance!It must be contains of digits!"); return false;
                }
                else MessageBox.Show("Invalid Hex code!It must be contains of 16 digits!"); return false;
            }
            else MessageBox.Show("Invalid name of bank card!It must be contains of simbols and digits!"); return false;
        }
        else { MessageBox.Show("Link,size,color,quantity,price,shop delivery price rows have to be completed"); return false; }
    }
}
