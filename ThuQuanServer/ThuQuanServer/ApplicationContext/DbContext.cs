using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Dapper;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509.Qualified;
using Object = Mysqlx.Expr.Object;

namespace ThuQuanServer.ApplicationContext;

public class DbContext
{
    private readonly MySqlConnection _connection;
    private MySqlTransaction? _transaction;
    private readonly string _connectionString;
    
    public DbContext(IConfiguration configuration)
    {
        _connectionString= configuration.GetConnectionString("DefaultConnection");
        _connection = new MySqlConnection(_connectionString);
    }
    
    public MySqlConnection GetOpenConnection()
    {
        var connection = new MySqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
    
    public T GetFirstOrDefault<T>(string query, object parameters = null)
    {
        _connection.Open();
        try
        {
            return _connection.QueryFirstOrDefault<T>(query, parameters);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            _connection.Close();
        }
    }



    public ICollection<T> GetData<T>(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            if (values.Length > 0)
            {
                for (var i = 0; i < values.Length; ++i)
                {
                    cmd.Parameters.AddWithValue($"@{i}", values[i]);
                }
            }
            var adapter = new MySqlDataAdapter(cmd);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            var collection = dataTable.AsEnumerable()
                .Select(row => MapRowToType<T>(row))
                .ToList();

            return collection;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }
    
    public IEnumerable<Dictionary<string,object>> ExcuteQuerry(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            Console.WriteLine(query);
            if (values.Length > 0)
            {
                for (var i = 0; i < values.Length; ++i)
                {
                    cmd.Parameters.AddWithValue($"@{i}", values[i]);
                    // Console.WriteLine(values[i]);
                }
            }
            
            var adapter = new MySqlDataAdapter(cmd);
            var dataTable = new DataTable();
            adapter.Fill(dataTable);

            var collection = dataTable.AsEnumerable();
            var data = dataTable.Rows.OfType<DataRow>()
                .Select(row => dataTable.Columns.OfType<DataColumn>()
                    .ToDictionary(col => col.ColumnName, c => row[c]));
            return data;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }
    
    public int ExecuteNonQuery(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            if (values.Length > 0)
            {
                for (int i = 0; i < values.Length; ++i)
                {
                    cmd.Parameters.AddWithValue($"{i}", values[i]);
                }
            }
            
            if (cmd.Parameters.Count != values.Length)
            {
                throw new ArgumentException("The number of parameters does not match the number of placeholders in the query.");
            }
            
            var result = cmd.ExecuteNonQuery();
            return result;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }   
    
    public int Add<T>(object? value)
    {
        // Get all properties of the object
        var props = value.GetType().GetProperties();
    
        // Get all column names and placeholders
        var tableName = typeof(T).Name;
        var colNames = string.Join(", ", props.Select(p => $"`{p.Name}`"));
        var placeholders = string.Join(", ", props.Select(_ => "?"));
        string query = $"INSERT INTO {tableName} ({colNames}) VALUES ({placeholders})";
        Console.WriteLine(query);
    
        // Get all values of the object
        object?[] values = props.Select(p =>
        {
            if(p.GetValue(value)?.GetType() == typeof(DateTime))
            {
                return ((DateTime?)p.GetValue(value))?.ToString("yyyy-MM-dd hh:mm:ss");
            }
            return p.GetValue(value);
        }).ToArray();
        
        // test
        // return 1;
        
        _connection.Open();
        try
        {
            // Begin the transaction
            _transaction = _connection.BeginTransaction();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
        
        // Execute the query
        var result = ExecuteNonQuery(query, values);
        return result;
    }

    public int AddList<T>(List<T> value)
    {
        if (value.Count <= 0)
            return 1;
        var tableName = typeof(T).Name;
        var props = value.First()?.GetType().GetProperties();
        if (props == null)
            return 0;
        
        
        var colNames = string.Join(", ",props.Select(p => $"`{p.Name}`"));
        var placeHolder = "";
        for (int i = 0; i < value.Count; ++i)
        {
            var item = string.Join(", ",props.Select(_ => "?"));
            placeHolder += $"({item})";
            if(i != value.Count - 1)
                placeHolder += ", ";
        }
        var query = $"INSERT INTO {tableName} ({colNames}) VALUES {placeHolder}";
        Console.WriteLine(query); 
        var values = new List<object>();
        foreach (var item in value)
        {
            var currentInsertItem = props.Select(p =>
            {
                if (p.GetValue(item)?.GetType() == typeof(DateTime))
                {
                    return ((DateTime?)p.GetValue(item))?.ToString("yyyy-MM-dd hh:mm:ss");
                }
                
                return p.GetValue(item);
            });
            values.AddRange(currentInsertItem);
        }
        _connection.Open();
        try
        {
            _transaction = _connection.BeginTransaction();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
        
        var result = ExecuteNonQuery(query, values.ToArray());
        return result;
    }

    public int Update<T>(object? value, int id)
    {
        var tableName = typeof(T).Name;
        
        var props = value.GetType().GetProperties();
        
        var colNames = string.Join(", ", props
            .Where(p => p.GetValue(value) != null)
            .Select(p => $"{p.Name} = ?"));
        
        var query = $"UPDATE {tableName} SET {string.Join(", ", colNames)} WHERE Id = ?";
        Console.WriteLine(query);
        
        object?[] values = props.Where(p => p.GetValue(value) != null).Select(p =>
        {
            
            if(p.GetValue(value)?.GetType() == typeof(DateTime))
            {
                return ((DateTime?)p.GetValue(value))?.ToString("yyyy-MM-dd hh:mm:ss");
            }
            return p.GetValue(value);
        }).Append(id).ToArray();

        // Console.WriteLine(string.Join("\n", values));
        // return 0;
        
        _connection.Open();
        try
        {
            _transaction = _connection.BeginTransaction();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
        
        // Execute the query
        return ExecuteNonQuery(query, values); 
    }

    public bool SaveChange()
    {
        _connection.Open();
        try
        {
            _transaction?.Commit();
            return true;
        }
        catch (Exception e)
        {
            _transaction?.Rollback();
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }

    public int GetLastInsertId()
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", _connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            _connection.Close();
        }
    }

    public int AddLastInsertId(string query, params object?[] values)
    {
        _connection.Open();
        try
        {
            var cmd = new MySqlCommand(query, _connection);
            if (values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.AddWithValue($"@{i}", values[i]);
                }
            }
            var result = cmd.ExecuteScalar();
            return Convert.ToInt32(result);
            
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        finally
        {
            _connection.Close();
        }
    }

    // private static T MapRowToType<T>(DataRow row)
    // {
    //     // Create an instance of the object
    //     var obj = Activator.CreateInstance<T>();
    //     
    //     // Get all properties of the object
    //     var properties = typeof(T).GetProperties();
    //     foreach (var property in properties)
    //     {
    //         if (row[property.Name] != DBNull.Value)
    //         {
    //             var value = Convert.ChangeType(row[property.Name], property.PropertyType);
    //             property.SetValue(obj, value);   
    //         }
    //     }
    //     return obj;
    // }
    
    private static T MapRowToType<T>(DataRow row)
    {
        var obj = Activator.CreateInstance<T>();
        var properties = typeof(T).GetProperties();

        foreach (var property in properties)
        {
            if (row.Table.Columns.Contains(property.Name) && row[property.Name] != DBNull.Value)
            {
                var rawValue = row[property.Name];

                object? value = null;
                if (property.PropertyType.IsEnum)
                {
                    var rawStr = rawValue.ToString()?.Replace(" ", "_");
                    value = Enum.Parse(property.PropertyType, rawStr ?? "", ignoreCase: true);
                }
                else if (Nullable.GetUnderlyingType(property.PropertyType)?.IsEnum == true)
                {
                    var enumType = Nullable.GetUnderlyingType(property.PropertyType)!;
                    var rawStr = rawValue.ToString()?.Replace(" ", "_");
                    value = Enum.Parse(enumType, rawStr ?? "", ignoreCase: true);
                }
                else
                {
                    value = Convert.ChangeType(rawValue, property.PropertyType);
                }

                property.SetValue(obj, value);
            }
        }

        return obj;
    }


}