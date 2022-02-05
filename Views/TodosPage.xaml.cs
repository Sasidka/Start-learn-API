using Moments.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Runtime.Serialization;
using System.Windows.Shapes;
using System.Runtime.Serialization.Json;

namespace Moments.Views
{
    /// <summary>
    /// Логика взаимодействия для TodosPage.xaml
    /// </summary>
    public partial class TodosPage : Page
    {

        HttpClient client = new HttpClient();
        public TodosPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = "https://jsonplaceholder.typicode.com/photos";
                using (var response = await client.GetAsync(url))
                {
                    using (var stream= await response.Content.ReadAsStreamAsync())
                    {
                        var serialization = new DataContractJsonSerializer(typeof(List<TodosClass>));
                        var responce_obj = serialization.ReadObject(stream);
                        ListTodos.ItemsSource = responce_obj as List<TodosClass>;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

// Here was Muhammad