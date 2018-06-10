using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoList
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            alertText.Text = "";
            if (login.Text == null || passwd == null)
            {
                alertText.Text = "Formulaire Invalide";
            } else
            {
                await Navigation.PushAsync(new ToDoPage());
            }
            
        }
    }
}
