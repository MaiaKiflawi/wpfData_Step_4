using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wpfData_Step_4.Model;

namespace wpfData_Step_4.Model
{
    public class Snack: BaseEntity
    {
        private string snackName;
        private int calAmount;
        public bool isSweet;
        public int amount;
        public int grams;
        public bool like;
        public string company;

        public string SnackName 
        {
            get { return snackName; }
            set { snackName = value; }
        }
        public int CalAmount
        {
            get { return calAmount; }
            set { calAmount = value; }
        }
        public bool IsSweet
        {
            get { return isSweet; }
            set { isSweet = value; }
        }
        public int Amount

        {
            get { return amount; }
            set { amount = value; }
        }
        public int Grams
        {
            get { return grams; }
            set { grams = value; }
        }
        public bool Like
        {
            get { return like; }
            set { like = value; }
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }
    }

    public class SnackList : List<Snack>
    {
        public SnackList() { } //בנאי ברירת מחדל
        public SnackList(IEnumerable<Snack> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public SnackList(IEnumerable<BaseEntity> list) :
            base(list.Cast<Snack>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}
