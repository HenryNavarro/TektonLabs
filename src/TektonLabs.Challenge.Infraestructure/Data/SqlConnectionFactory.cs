//using Npgsql;
using System.Data;
using TektonLabs.Challenge.Application.Abstractions.Data;

namespace TektonLabs.Challenge.Infraestructure.Data;
internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        //var connection = new NpgsqlConnection(_connectionString);
        //connection.Open();

        //return connection;
        throw new NotImplementedException();
    }
}