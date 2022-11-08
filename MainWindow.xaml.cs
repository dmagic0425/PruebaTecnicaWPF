using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using RestSharp;

namespace Prueba_DanielMarin
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public async void Button_Consumir_Action(object sender, RoutedEventArgs e)
        {
            Text_MuestaDatos.Text = "";
            Btn_Consumir.IsEnabled = false;
            String URL_API = "https://api.github.com/users";
            await ProcesJSON(URL_API);
        }


        public void Button_Cancel_Action(object sender, RoutedEventArgs e) {
            Btn_Consumir.IsEnabled = true;
            Text_MuestaDatos.Text = "";
        }

        private async Task<String> ProcesJSON(String uri)
        {
            String JsonCadena = "", responseString = "";

            try
            {
                var client = new RestClient(uri);
                var request = new RestRequest(Method.GET);
                request.AddHeader("content-type", "application/json");
                IRestResponse response = client.Execute(request);

                var Array = JsonConvert.DeserializeObject(response.Content);
                responseString = Array.ToString();
            }
            catch (Exception ex)
            {
                responseString = ex.Message.ToString();
            }

            Btn_Consumir.IsEnabled = true;
            Text_MuestaDatos.Text = responseString;
            return JsonCadena;
        }
    }
}
