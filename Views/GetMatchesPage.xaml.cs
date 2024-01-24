using GuamanExamenApi.Models;
using System.Net.Sockets;
using System.Text.Json;
using Newtonsoft.Json;

namespace GuamanExamenApi.Views;

public partial class GetMatchesPage : ContentPage
{
    public GetMatchesPage()
    {
        InitializeComponent();
    }

   

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            string apiKey = "a43d9381662e4720a89ec322e5e5ab15";

            // Configura las fechas en el formato correcto (YYYY-MM-DD)
            DateTime startDate = new DateTime(2024, 1, 24);
            DateTime endDate = new DateTime(2024, 1, 25);

            string apiUrl = $"https://api.football-data.org/v4/matches/?apikey={apiKey}&dateFrom={startDate:yyyy-MM-dd}&dateTo={endDate:yyyy-MM-dd}";

            using (HttpClient client = new HttpClient())
            {
                // Agrega la clave de API como encabezado
                client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Deserializa la respuesta en tu modelo de datos
                    var matchesData = JsonConvert.DeserializeObject<Soccer.Rootobject>(jsonResponse);

                    // Accede a la lista de partidos bajo la propiedad matches en el objeto resultSet
                    MatchesListView.ItemsSource = matchesData.matches;
                }

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


}