using HttpClientApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HttpClientApp.Views.Pages;
/// <summary>
/// Interaktionslogik für FavoritesPage.xaml
/// </summary>
public partial class FavoritesPage : Page
{
    public FavoritesPage(FavoritesViewModel vm)
    {
        InitializeComponent();
        this.DataContext = vm;
    }
}
