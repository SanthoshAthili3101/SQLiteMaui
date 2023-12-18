using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteMaui.Data
{
    public class DatabaseContext
    {
        private SQLiteConnection Database;
        private string DbName;
        public DatabaseContext(string dbName)
        {
            DbName = dbName;
        }
        
        private void OpenConnection()
        {
            string DbPath = Path.Combine(MauiProgram.localFolderPath, DbName);

            Database = new SQLiteConnection(DbPath);
        }

        private void CreateTableIfNotExists<TTable>() where TTable : class, new()
        {
            Database.CreateTable<TTable>();
        }

        private TableQuery<TTable> GetTable<TTable>() where TTable : class, new()
        {
            CreateTableIfNotExists<TTable>();
            return Database.Table<TTable>();
        }

        public IEnumerable<TTable> GetAll<TTable>() where TTable : class, new()
        {
            OpenConnection();
            var table = GetTable<TTable>();
            var response = table.ToList();
            Database.Close();
            return response;
        }

        public IEnumerable<TTable> GetFiletered<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            OpenConnection();
            var table = GetTable<TTable>();
            var response = table.Where(predicate).ToList();
            Database.Close();
            return response;
        }

        public TTable GetByFiletered<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            OpenConnection();
            var table = GetTable<TTable>();
            var response = table.Where(predicate).FirstOrDefault();
            Database.Close();
            return response;
        }

        public TTable GetItemByKey<TTable>(object primaryKey) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.Get<TTable>(primaryKey);
            Database.Close();
            return response;
        }

        public bool AddItem<TTable>(TTable item) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.Insert(item) > 0;
            Database.Close();
            return response;
        }

        public bool AddAllItem<TTable>(IEnumerable<TTable> items) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.InsertAll(items) > 0;
            Database.Close();
            return response;
        }

        public bool UpdateItem<TTable>(TTable item) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.Update(item) > 0;
            Database.Close();
            return response;
        }

        public bool UpdateAllItem<TTable>(IEnumerable<TTable> items) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.UpdateAll(items) > 0;
            Database.Close();
            return response;
        }

        public bool DeleteItem<TTable>(TTable item) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.Delete(item) > 0;
            Database.Close();
            return response;
        }

        public bool DeleteAll<TTable>() where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.DeleteAll<TTable>() > 0;
            Database.Close();
            return response;
        }

        public bool DeleteItemByKey<TTable>(object primaryKey) where TTable : class, new()
        {
            OpenConnection();
            CreateTableIfNotExists<TTable>();
            var response = Database.Delete<TTable>(primaryKey) > 0;
            Database.Close();
            return response;
        }
    }
}
