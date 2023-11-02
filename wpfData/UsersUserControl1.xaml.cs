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
using wpfData_Step_4.Model;
using wpfData_Step_4.ViewModel;

namespace wpfData_Step_4
{
    /// <summary>
    /// Interaction logic for UsersUserControl1.xaml
    /// </summary>
    public partial class UsersUserControl1 : UserControl
    {
        public UsersUserControl1()
        {
            InitializeComponent();
            UserDB userDB = new UserDB();
            UserList list = userDB.SelectAll();
            usersListView.ItemsSource = list;
        }
    }
}