   M S B A M L   `   `   `  ????F  BTrendyolApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:TrendyolApp.ViewTrendyolApp.View  5   	   =#clr-namespace:TrendyolApp.ViewModelTrendyolApp.ViewModel  5   	       TrendyolApp.View.MainView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:TrendyolApp.View     5   	   9	viewModel#clr-namespace:TrendyolApp.ViewModel     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a:mD1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          ? WindowStyle$
  None=?5	   	    ? WindowStartupLocation$ CenterScreen=?5   	   $	??550??5   	   $	??800??6   
??????? ? 
ResizeMode$ NoResize=?5   	    ? Title$ MainView??5   	      MaterialDesignBody#???   5   	   $??Regular"?5   	   $??14(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignFont#???  5   	    ? WindowState 5
   	   ?? *State+??5      ?? 5   
    ?? 
TargetType" ?6   .R?5      ??  ?? CornerRadius$ 15??6   
???????._?5      ? .+?5       ?? ??6%   ?? *CurrentViewModel+? 5"      	 ? RowDefinitions	 5#      ?? 5$      $??0.09* ?6,   ?? 5%      .+?5(      ? $??0??6   $??Right=?6,   
 ? ColumnDefinitions
 5)      ?? 5*   "   $	??700 ?63   ?? 5+   "   $??30 ?63   ?? 5,   "   $??30 ?63   ?? 5-   "   $??10 ?63   .+?50      ?? ???#0C65EB$??0q?51   )   
???????$??
Montserrat)?53   )   $??Center=?54   )   $??Center=?55   )   $??18(?56   )   $??-??67   $??26??57   )   $??3,0,3,3q?64   $??1??58   )   $??26??5:   )   $
??Bold"?65   ??59   )   ?? *MinimalizeCommand+5:   5   ?? 5<      ???#FF19C6$??0q?5=   )   
???????$??
Montserrat)?5?   )   $??Center=?5@   )   $??Center=?5A   )   $??18(?5B   )   $??X??67   $??2??5C   )   $??26??5D   )   $??3,2,3,3q?64   $??26??5E   I   $
??Bold"?6U   ??6)   ?? *ExitCommand+6U   5F      5G      5H      5I      5J      5L      