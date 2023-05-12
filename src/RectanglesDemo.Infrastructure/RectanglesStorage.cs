using Microsoft.Data.SqlClient;
using RectanglesDemo.Application.Common;
using RectanglesDemo.Domain;
using System.Data;

namespace RectanglesDemo.Infrastructure;

public class RectanglesStorage : IRectanglesStorage
{
    private readonly string _connectionString;
    private IDbConnection? _connection { get; set; }

    protected IDbConnection Connection
    {
        get
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = new SqlConnection(_connectionString);
                _connection.Open();
            }

            return _connection;
        }
    }

    public RectanglesStorage(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Task CheckAndCreateStorage()
    {
        throw new NotImplementedException();
    }

    public Task<List<Rectangle>> GetRectanglesWithPoint(int x, int y)
    {
        throw new NotImplementedException();
    }

    public Task Save(IEnumerable<Rectangle> rectangles)
    {
        throw new NotImplementedException();
    }
}