using System.Net;
using AmelyCordova_ExamenFinal.ACData;
using AmelyCordova_ExamenFinal.ACModels;
using Newtonsoft.Json;

namespace AmelyCordova_ExamenFinal.ACViews;

public partial class AC_ViewItems : ContentPage
{
	public AC_ViewItems()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://www.thecocktaildb.com/api/json/v1/1/random.php");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json"); var client = new HttpClient(); HttpResponseMessage response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Drink>>(content);
            Lista.ItemsSource = resultado;
        }
    }
}
