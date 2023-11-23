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
using wpfData_Step_4.ServiceReferenceSnacks;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for CityUserControl.xaml
    /// </summary>
    public partial class CityUserControl : UserControl
    {
        private ServiceSnackClient snacksService;

        public CityUserControl()
        {
            InitializeComponent();
            snacksService = new ServiceSnackClient();
            cityListView.ItemsSource = snacksService.GetAllCities();
        }
    }
}
