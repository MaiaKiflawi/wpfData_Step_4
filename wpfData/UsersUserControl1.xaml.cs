﻿using System;
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
    /// Interaction logic for UsersUserControl1.xaml
    /// </summary>
    public partial class UsersUserControl1 : UserControl
    {
        private ServiceSnackClient snacksService;
        public UsersUserControl1()
        {
            InitializeComponent();
            snacksService = new ServiceSnackClient();
            UserList list = snacksService.GetAllUsers();
            usersListView.ItemsSource = list;
        }
    }
}
