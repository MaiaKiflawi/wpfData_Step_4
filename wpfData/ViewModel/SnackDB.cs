using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfData_Step_4.Model;
using wpfData_Step_4.ViewModel;

namespace wpfData_Step_4.ViewModel
{
    public class SnackDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Snack snack = (Snack)entity;
            snack.Id = int.Parse(reader["ID"].ToString());
            snack.SnackName = reader["SnackName"].ToString();
            snack.CalAmount = int.Parse(reader["CalAmount"].ToString());
            snack.IsSweet = bool.Parse(reader["IsSweet"].ToString());
            snack.Amount = int.Parse(reader["Amount"].ToString());
            snack.Grams = int.Parse(reader["Grams"].ToString());
            snack.Like = bool.Parse(reader["Like"].ToString());
            snack.Company = reader["Company"].ToString();
            return snack;
        }

        protected override BaseEntity NewEntity()
        {
            return new Snack() as BaseEntity;
        }

        public SnackList SelectAll()
        {
            command.CommandText = "SELECT * FROM TblSnacks";
            SnackList snackList = new SnackList(base.ExecuteCommand());
            return snackList;
        }

        public SnackList SelectByUser(User user)
        {
            command.CommandText = $"SELECT * FROM (TblUsersSnack INNER JOIN TblSnacks " +
                $" ON TblUsersSnack.SnackID = TblSnacks.ID) " +
                $" WHERE TblUsersSnack.UserID={user.Id}";
            SnackList list = new SnackList(base.ExecuteCommand());
            return list;
        }

        public Snack SelectById(int id)
        {
            command.CommandText = string.Format($"SELECT * FROM TblSnacks WHERE ID={id}");
            SnackList snackList = new SnackList(base.ExecuteCommand());
            if (snackList.Count == 0)
                return null;
            return snackList[0];
        }
    }
}
