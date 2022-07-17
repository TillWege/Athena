using Athena.Common;
using Npgsql;

namespace Athena.Server
{
    public class Database
    {
        readonly NpgsqlConnection DatabaseConnection;

        public Database()
        {
            var dbURL = Environment.GetEnvironmentVariable("DB_URL");
            var dbUser = Environment.GetEnvironmentVariable("DB_USER");
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var ConnectionString = String.Format(@"Host={0};Username={1};Password={2};Database=athena", dbURL, dbUser, dbPassword);

            DatabaseConnection = new NpgsqlConnection(ConnectionString);
            DatabaseConnection.Open();
        }

        public async void Test()
        {
            await using var cmd = new NpgsqlCommand("SELECT * FROM tasks", DatabaseConnection);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Console.WriteLine(reader.GetInt32(0));
            }

        }


    }
}

