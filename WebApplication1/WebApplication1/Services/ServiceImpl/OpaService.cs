using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class OpaService
{
    private readonly HttpClient _httpClient;

    public OpaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Check if a specific action is allowed
    public async Task<bool> IsAllowed(
     int userId,
     string role,
     string action,
     string resourceType,
     object? resourceAttributes = null)
    {
        var inputObject = new
        {
            input = new
            {
                user = new
                {
                    id = userId,
                    role = role
                },
                action = action,
                resource = new
                {
                    type = resourceType,
                    attributes = resourceAttributes
                }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(inputObject), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:8181/v1/data/authz/allow", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpaResponseBool>(json);
        return result?.result ?? false;
    }

    // Get all permissions for a role
    public async Task<List<Permission>> GetPermissions(string role)
    {
        var input = new { input = new { user = new { role } } };
        var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("http://localhost:8181/v1/data/authz/allowed_permissions", content);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<OpaResponseList>(json);
        return result?.result ?? new List<Permission>();
    }

    private class OpaResponseBool { public bool result { get; set; } }
    private class OpaResponseList { public List<Permission> result { get; set; } }
}

public class Permission
{
    public string action { get; set; }
    public string resource { get; set; }
}



//using System.Net.Http;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//public class OpaService
//{
//    private readonly HttpClient _httpClient;

//    public OpaService(HttpClient httpClient)
//    {
//        _httpClient = httpClient;
//    }

//    public async Task<bool> IsAllowed(string role, string action, string resource)
//    {
//        var input = new
//        {
//            input = new
//            {
//                user = new { role = role },
//                action = action,
//                resource = resource
//            }
//        };

//        var content = new StringContent(
//            JsonSerializer.Serialize(input),
//            Encoding.UTF8,
//            "application/json");

//        var response = await _httpClient.PostAsync(
//            "http://localhost:8181/v1/data/authz/allow",
//            content);

//        var json = await response.Content.ReadAsStringAsync();
//        var result = JsonSerializer.Deserialize<OpaResponse>(json);

//        return result?.result == true;
//    }

//    private class OpaResponse
//    {
//        public bool result { get; set; }
//    }
//}
