using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Redarbor.Inventory.Infrastructure.Data;

public class DbConnectionFactory
{
    private readonly string _connectionString;
    public DbConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}