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
//using static WeatherApp.Weather;
//using static WeatherApp.Weather.WeatherData;
using static WeatherApp.WeatherData;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
               base.OnAppearing();
            BindingContext = await GetWeather();

        }

      
        async private Task<OpenWeatherData> GetWeather()
        {
            var details = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (details != PermissionStatus.Granted)
            {
                var newdetail = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }
            var location = await Geolocation.GetLocationAsync();
            var latitude = location.Latitude;
            var longitude = location.Longitude;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=-33&lon=18&units=metric&appid=cd154b8d364ddbf23fb1135e0b44b6af");
            var weatherData = JsonConvert.DeserializeObject<OpenWeatherData>(response);
            return weatherData;
        }
    }
}
