using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Api
{
    public partial class Form1 : Form
    {
        const string token = "7809fe29ca8896d2e3bd371196cd4b76";
        public Form1()
        {
            InitializeComponent();
            string url = $"http://api.openweathermap.org/data/2.5/weather?q=Russian&lang=ru&units=metric&appid={token}";

            var request = (HttpWebRequest)WebRequest.Create(url);

            var httpresponse = (HttpWebResponse)request.GetResponse();
            string response;
            using (var reader = new StreamReader(httpresponse.GetResponseStream()))
            {
                response = reader.ReadToEnd();
            }

            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

            label1.Text = $"В {weatherResponse.Name} {weatherResponse.Main.Temp}°C\n" +
                $"Ощущается {weatherResponse.Main.FeelsLike}°C\n" +
                $"Максималная {weatherResponse.Main.TempMax}°C и минимальная {weatherResponse.Main.TempMin}°C погода на сегодня\n" +
                $"Скорость ветра: {weatherResponse.Wind.Speed} метр/сек";
        }
    }
}
