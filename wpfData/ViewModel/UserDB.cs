using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using wpfData_Step_4.Model;

namespace wpfData_Step_4.ViewModel
{
    public class UserDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User() as BaseEntity;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = (User)entity;
            user.Id = int.Parse(reader["personID"].ToString());
            user.FirstName = reader["FirstName"].ToString();
            user.LastName = reader["LastName"].ToString();
            user.Phone = reader["Phone"].ToString();
            user.UserName = reader["UserName"].ToString();
            user.Password = reader["Password"].ToString();
            user.IsAdmin = bool.Parse(reader["isAdmin"].ToString());

            // השלמת הבאת נתוני עיר לפי קוד העיר
            int cityID = (int)reader["CityID"];
            CityDB cityDB = new CityDB();
            user.City = cityDB.SelectById(cityID);

            SnackDB snackDB = new SnackDB();
            user.MySnacks = snackDB.SelectByUser(user);

            return user;
        }


        public UserList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM TblUsers";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }

        public User SelectById(int id)
        {
            command.CommandText = string.Format($"SELECT * FROM TblUsers WHERE (ID = {id})");
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public UserList SelectBySnack(Snack snack)
        {
            command.CommandText = $"SELECT * FROM (TblUsersSnack INNER JOIN TblUsers " +
                $" ON TblUsersSnacks.UserID = TblUsers.personID) " +
                $" WHERE UserID={snack.Id}";
            UserList list = new UserList(base.ExecuteCommand());
            return list;
        }

        public User LogIn(User user)
        {
            command.CommandText = string.Format($" SELECT * " +
                $" FROM TblUsers " +
                $" WHERE (UserName = '{user.UserName}') AND ([Password] = '{user.Password}') ");
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }
    }
}

