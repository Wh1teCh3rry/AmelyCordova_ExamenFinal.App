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
        public int AddNewElement(Drink cocktail)
        {
            Init();
            int result = conn.Insert(cocktail);
            return result;
        }
        public List<Drink> GetAllElements()
        {
            Init();
            List<Drink > cocktails = conn.Table<Drink>().ToList();
            return cocktails;
        }
    }
}
