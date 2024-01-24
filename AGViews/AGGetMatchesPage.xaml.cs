using GuamanExamenApi.Models;
using System.Net.Http;
using System.Text.Json;
using Newtonsoft.Json;
using GuamanExamenApi.Data;

namespace GuamanExamenApi.Views
{
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

                //Fechas
                DateTime startDate = new DateTime(2024, 1, 23);
                DateTime endDate = new DateTime(2024, 1, 25);

                string apiUrl = $"https://api.football-data.org/v4/matches/?apikey={apiKey}&dateFrom={startDate:yyyy-MM-dd}&dateTo={endDate:yyyy-MM-dd}";

                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        var matchesData = JsonConvert.DeserializeObject<Soccer.Rootobject>(jsonResponse);


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


}