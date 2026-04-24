using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using IT3048FinalNationalParksApp.Models;

namespace IT3048FinalNationalParksApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ParksApp.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            await _database.CreateTableAsync<User>();
        }

        public async Task<int> RegisterUser(User user)
        {
            await Init();
            return await _database.InsertAsync(user);
        }

        public async Task<User> GetUser(string username, string password)
        {
            await Init();
            return await _database.Table<User>()
                .Where(u => u.Username == username && u.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
