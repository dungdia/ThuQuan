using RestSharp;
using System.Text.Json;

namespace DesktopClient.APIs;

public class APIContext
{

    public static T ConvertToModel<T>(Dictionary<string, object> lem) where T : new()
    {
        T t = new T();

        foreach (var p in typeof(T).GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
        {
            if (lem.TryGetValue(p.Name, out object v))
            {
                if (p.PropertyType.Name == "Int32")
                {
                    p.SetValue(t, Int32.Parse(v.ToString()));
                }
                if (p.PropertyType.Name == "String")
                    p.SetValue(t, v.ToString());
                if (p.PropertyType.Name == "DateTime")
                    p.SetValue(t, DateTime.Parse(v.ToString()));
            }
        }

        return t;
    }

    public static List<T> GetMethod<T>(string url) where T : new()
    {

        try
        {
            var client = new RestClient("http://localhost:3000/" + url);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("Authorization", "Bearer " + MainFrame._adminLoginDTO?.accesstoken);
            var response = client.Get(request);
            var collection = JsonSerializer.Deserialize<IEnumerable<Dictionary<string, Object>>>(response.Content);
            var result = collection.Select(e => ConvertToModel<T>(e)).ToList();
            return result;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return [];
    }

    public static RestResponse PostMethod(string url, object obj)
    {
        var client = new RestClient("http://localhost:3000/" + url);
        var request = new RestRequest();
        request.Method = Method.Post;
        request.AddHeader("Authorization", "Bearer " + MainFrame._adminLoginDTO?.accesstoken);
        RestResponse response = null;
        try
        {
            request.Method = Method.Post;
            Object body = JsonSerializer.Serialize(obj);
            request.AddJsonBody(body);
            response = client.Execute(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return response;
    }

    public static async Task<RestResponse> PutMethodAsync(string url, object obj)
    {
        var client = new RestClient("http://localhost:3000/" + url);
        var request = new RestRequest();
        request.Method = Method.Put;
        request.AddHeader("Authorization", "Bearer " + MainFrame._adminLoginDTO?.accesstoken);

        RestResponse response = null;
        try
        {
            var body = JsonSerializer.Serialize(obj);
            request.AddJsonBody(body);

            response = await client.ExecuteAsync(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return response;
    }

    public static string translateResponse(string test)
    {
        var response = JsonSerializer.Deserialize<Dictionary<string, Object>>(test).First();
        var collection = JsonSerializer.Deserialize<Dictionary<string, Object>>(response.Value.ToString());
        string message = collection.First().Value.ToString();
        return message;
    }

    public static string getErrorMessage(RestResponse response)
    {
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            return response.Content;
        }
        string message = "";
        try
        {
            var resultDictionary = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Object>>(response.Content);
            foreach (var item in resultDictionary)
            {
                message += item.Value.ToString();
                message += "\n";
            }
        }
        catch (Exception e)
        {
            message = response.Content;
        }
        return message;
    }

}