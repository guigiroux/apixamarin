using Newtonsoft.Json;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : TabbedPage
    {
        public ToDoPage ()
        {
            InitializeComponent();
        }

        public async void GetData()
        {
            string url = "http://formation-roomy.inow.fr/api/todoitems";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "1szD6CDHvhZ7yHVuo2XjU2vOt65UPdpsiivmAxpNJiKqtzIC7v9FHS6NYtIuqLE7gFTJUrbKc5aNmZ61-gphUP9BraL5kESamgih-xGA6PyinQmaFCu3EzVQgjqzoXcK0uuTR2PXojA_x9BjWAWf8BMVEplH6X1J7FZ9LayP1vxZjxo1C1Dgiy9vmuubCR2qb6BS6tCfNJsth2Bk72B3LThdi2I67YN_3UMLhHNpJ6c");
            Task<string> downloadTask = httpClient.GetStringAsync(url);
            string response = await downloadTask;
            List<ToDoItem> listItems = new List<ToDoItem>();
            listItems = JsonConvert.DeserializeObject<List<ToDoItem>>(response);
            Console.Out.WriteLine(listItems);
            MyListView.ItemsSource = listItems;
        }

        private void Apiclicked(object sender, EventArgs args)
        {
            GetData();
            MyListView.EndRefresh();
        }

        async void GoAjoutPage(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new AjoutPage());
        }
    }
    public class ToDoItem
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string text { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public string createdDate { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }

        [JsonProperty(PropertyName = "isDone")]
        public bool isDone { get; set; }

        [JsonProperty(PropertyName = "doneDate")]
        public string doneDate { get; set; }

        [JsonProperty(PropertyName = "priority")]
        public int priority { get; set; }

    }

    public class ListToDoItem
    {
        public List<ToDoItem> items { get; set; }
    }
}