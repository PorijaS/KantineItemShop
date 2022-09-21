using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MonkeyFinder.Services;

public class FoodService
{
    HttpClient httpClient;
    string token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjhCMkQ1MkM2RjRBRDBFRjg5NzI1MjJCNjZDOTVCQkY5IiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NjM2NjE1MTUsImV4cCI6MTY2MzY2NTExNSwiaXNzIjoiaHR0cHM6Ly9zZGVLYW50aW5lLmNvbSIsImNsaWVudF9pZCI6ImFwaSIsInN1YiI6IjIiLCJhdXRoX3RpbWUiOjE2NjM2NjE1MTUsImlkcCI6ImxvY2FsIiwiVXNlcklkIjoiMiIsImp0aSI6IkRCNTlCMDc2N0EwQzk1MDI2MjU0NTUxNkY0NEY2NERBIiwiaWF0IjoxNjYzNjYxNTE1LCJzY29wZSI6WyJvcGVuaWQiLCJwcm9maWxlIiwib2ZmbGluZV9hY2Nlc3MiXSwiYW1yIjpbImN1c3RvbSJdfQ.TweENWF20LK3dAxMhw4qZUc_aVQd5rpQkb2fdmr6GFtmEbtXAU3qjEyw4Kf2YAQtPwmdpm9Q78bm3PLaU1EORLewOdcY_qTHaFTFMppZm7SiERwH4cjP7Fu-3xpPr8fNUwzuTTFkFrPExDGRFAD3IR_heKIDzTd8kCpVUO1gny-a9V1hz61sDef-xWvs_WNKVW9SN0JccYBjt6DV9U8RvYOGS9k38KzYj0BaArgIMEPrGApSEsI3aA96Nj-WZEQ3CMdZIgFA_uuGuZugC2bBqQ9pT07FlxP1LUYwyLf06cONhIUEgzJWyZ1Co1837erD4RUYb1-aXH_iq4EY6is4CQ";
    public FoodService()
    {
        httpClient = new HttpClient();
    }

    List<Food> foodList = new();
    public async Task<List<Food>> GetFoods()
    {
        if (foodList.Count > 0)
            return foodList;

        var url = "http://10.130.52.70:80/api/food";

        //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer ", token);

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            foodList = await response.Content.ReadFromJsonAsync<List<Food>>();
        }

        return foodList;
    }
}
