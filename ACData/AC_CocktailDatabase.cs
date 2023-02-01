using SQLite;
using AmelyCordova_ExamenFinal.ACModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmelyCordova_ExamenFinal.ACData
{
    public class AC_CockatailDatabase
    {
        string _dbPath;
        private SQLiteConnection conn;
        public AC_CockatailDatabase(string DatabasePath)
        {
            _dbPath = DatabasePath;
        }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Drink>();
        }
        public int AC_AddNewItem(Drink drink)
        {
            Init();
            if (drink.Id != 0)
            {
                return conn.Update(drink);
            }
            else
            {
                return conn.Insert(drink);
            }
        }
        public List<Drink> AC_GetAll()
        {
            Init();
            List<Drink> drinks = conn.Table<Drink>().ToList();
            return drinks;
        }

        public int AC_DeleteItem(Drink drink)
        {
            Init();
            return conn.Delete(drink);
        }
    }
}
