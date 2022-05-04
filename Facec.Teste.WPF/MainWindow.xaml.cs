using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

namespace Facec.Teste.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44355/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(10);

                var json = new JavaScriptSerializer().Serialize(new Cliente(txtDocumento.Text, txtNome.Text));
                var conteudo = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync("clientes", conteudo).Result;

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Erro ao gravar cliente!");
                    return;
                }

                MessageBox.Show("Sucesso ao gravar cliente!");
            }
        }
    }
}