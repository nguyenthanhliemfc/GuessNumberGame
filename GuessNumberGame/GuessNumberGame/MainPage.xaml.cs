using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuessNumberGame
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private async void PlayButton_OnTapped(object sender, EventArgs e)
	    {
	        await Task.WhenAll(
	            ImgGuessNumber.TranslateTo(0, -1000, 1000),
	            ImgPlayButton.FadeTo(0, 1000)
	        );
	        await Navigation.PushModalAsync(new GamePlay());
        }
	}
}
