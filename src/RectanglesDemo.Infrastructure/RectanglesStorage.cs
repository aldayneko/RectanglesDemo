using Dapper;
using Microsoft.Data.SqlClient;
using RectanglesDemo.Application.Common;
using RectanglesDemo.Domain;
using System.Data;

namespace RectanglesDemo.Infrastructure;

public class RectanglesStorage : IRectanglesStorage
{
    private readonly string rectangleTable = "rectangles";

    private IDbConnection _connection { get; set; }

    public RectanglesStorage(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task CheckAndCreateStorage()
    {
        var builder = new SqlConnectionStringBuilder(_connection.ConnectionString);
        var connectionString = @$"Server={builder.DataSource}; Database=master; User Id={builder.UserID}; Password={builder.Password};
                                 MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        
        using var masterConnection = new SqlConnection(connectionString);
        var checkAndCreateDatabaseSql = @$"IF NOT EXISTS (SELECT *
                FROM sys.databases WHERE name = '{builder.InitialCatalog}') 
                    CREATE DATABASE [{builder.InitialCatalog}];";
        await masterConnection.ExecuteAsync(checkAndCreateDatabaseSql);

        var checkAndCreateTable = @$"IF(NOT EXISTS(SELECT *
                FROM INFORMATION_SCHEMA.TABLES
                WHERE TABLE_SCHEMA = 'dbo'
                AND TABLE_NAME = '{rectangleTable}'))
                BEGIN
                    CREATE TABLE [{rectangleTable}] (
                        [id] int NOT NULL IDENTITY,
                        [x1] float NOT NULL,
                        [y1] float NOT NULL,
                        [x2] float NOT NULL,
                        [y2] float NOT NULL,
                        [x3] float NOT NULL,
                        [y3] float NOT NULL,
                        [x4] float NOT NULL,
                        [y4] float NOT NULL,
                        CONSTRAINT [PK_Rectangles] PRIMARY KEY ([Id])
                    );

                    CREATE INDEX [IX_rectangles_x1] ON [{rectangleTable}] ([x1]);
                    CREATE INDEX [IX_rectangles_y1] ON [{rectangleTable}] ([y1]);
                    CREATE INDEX [IX_rectangles_x2] ON [{rectangleTable}] ([x2]);
                    CREATE INDEX [IX_rectangles_y2] ON [{rectangleTable}] ([y2]);
                    CREATE INDEX [IX_rectangles_x3] ON [{rectangleTable}] ([x3]);
                    CREATE INDEX [IX_rectangles_y3] ON [{rectangleTable}] ([y3]);
                    CREATE INDEX [IX_rectangles_x4] ON [{rectangleTable}] ([x4]);
                    CREATE INDEX [IX_rectangles_y4] ON [{rectangleTable}] ([y4]);
                END";

        await _connection.ExecuteAsync(checkAndCreateTable);
    }

    public Task RemoveAllRectangles()
    {
        return _connection.ExecuteAsync("truncate table rectangles");
    }

    public async Task Save(IEnumerable<Rectangle> rectangles)
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }

        var bulk = GetBulkOperation();
        var table = GetRectangleDataTable(rectangles);
        await bulk.WriteToServerAsync(table);
    }

    private SqlBulkCopy GetBulkOperation()
    {
        var bulk = new SqlBulkCopy((SqlConnection)_connection);
        bulk.DestinationTableName = rectangleTable;

        bulk.ColumnMappings.Add("x1", "x1");
        bulk.ColumnMappings.Add("y1", "y1");
        bulk.ColumnMappings.Add("x2", "x2");
        bulk.ColumnMappings.Add("y2", "y2");
        bulk.ColumnMappings.Add("x3", "x3");
        bulk.ColumnMappings.Add("y3", "y3");
        bulk.ColumnMappings.Add("x4", "x4");
        bulk.ColumnMappings.Add("y4", "y4");

        return bulk;
    }

    private DataTable GetRectangleDataTable(IEnumerable<Rectangle> rectangles)
    {
        var table = new DataTable();
        table.Columns.Add(new DataColumn("x1", typeof(double)));
        table.Columns.Add(new DataColumn("y1", typeof(double)));
        table.Columns.Add(new DataColumn("x2", typeof(double)));
        table.Columns.Add(new DataColumn("y2", typeof(double)));
        table.Columns.Add(new DataColumn("x3", typeof(double)));
        table.Columns.Add(new DataColumn("y3", typeof(double)));
        table.Columns.Add(new DataColumn("x4", typeof(double)));
        table.Columns.Add(new DataColumn("y4", typeof(double)));

        foreach (var rectangle in rectangles)
        {
            var row = table.NewRow();
            row["x1"] = rectangle.X1;
            row["y1"] = rectangle.Y1;
            row["x2"] = rectangle.X2;
            row["y2"] = rectangle.Y2;
            row["x3"] = rectangle.X3;
            row["y3"] = rectangle.Y3;
            row["x4"] = rectangle.X4;
            row["y4"] = rectangle.Y4;

            table.Rows.Add(row);
        }

        return table;
    }

    public Task<List<Rectangle>> GetRectanglesWithPoint(int x, int y)
    {
        throw new NotImplementedException();
    }
}