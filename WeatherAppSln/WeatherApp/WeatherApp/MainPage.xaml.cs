using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static WeatherApp.WeatherDatabase.WeatherData;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
      
        async private void GetWeatherData()
        {
            var loaction = await Geolocation.GetLocationAsync();
            // loaction.Latitude = 
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetStringAsync("http://https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=cd154b8d364ddbf23fb1135e0b44b6af");
            var weatherData = JsonConvert.DeserializeObject<OpenWeatherDatabase>(response);
            // weatherData.main.temp
        }
    }
}
