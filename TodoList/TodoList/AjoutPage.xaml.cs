using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AjoutPage : ContentPage
	{
        private const string INVALID = "Formulaire invalide";

        public AjoutPage ()
		{
			InitializeComponent ();
		}

        private void validate(object sender, EventArgs args)
        {
            alertText.Text = "";
            if (textInput.Text == null || dateInput == null || descInput == null)
            {
                alertText.Text = "Formulaire Invalide";
            }
        }
	}
}