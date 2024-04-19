using IT3048C_Final.Models;
using SQLite;

namespace IT3048C_Final.Data
{
    public class AccountDB
    {
        readonly SQLiteAsyncConnection database;

        static readonly string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AccountDB.db3");

        const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.FullMutex |
            SQLiteOpenFlags.ProtectionComplete;

        public AccountDB() 
        {
            database = new SQLiteAsyncConnection(dbPath, Flags);
            database.CreateTableAsync<AccountEntry>().Wait();
        }

        public async Task<AccountEntry> GetAccountEntryAsync(int id)
        {
            return await database.Table<AccountEntry>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<List<AccountEntry>> GetAccountEntriesAsync()
        {
            return await database.Table<AccountEntry>().ToListAsync();
        }

        public async Task InsertAccountAsync(AccountEntry account)
        {
            await database.InsertAsync(account);
        }

        public async Task UpdateAccountAsync(AccountEntry account)
        {
            await database.UpdateAsync(account);
        }

        public async Task DeleteAccountAsync(AccountEntry account)
        {
            await database.DeleteAsync(account);
        }
    }
}
