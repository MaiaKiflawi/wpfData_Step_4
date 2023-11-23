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
using System.Windows.Shapes;
using wpfData_Step_4.ServiceReferenceSnacks;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private ServiceSnackClient snacksService;
        public LoginWindow()
        {
            InitializeComponent();
            snacksService = new ServiceSnackClient();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.UserName = tbxID.Text;
            user.Password = tbxPassword.Password;
            user = snacksService.Login(user);
            if (user == null )
            {
                MessageBox.Show("User does not exist.", "ERROR", MessageBoxButton.OK);
                return;
            }
            if (!user.IsAdmin)
            {
                MessageBox.Show("Not admin.", "ERROR", MessageBoxButton.OK);
                return;
            }
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            tbxID.Text = tbxPassword.Password = string.Empty;
        }
    }
}
