using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuessNumberGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePlay : ContentPage
	{
	    private int _brainNumber; //Keep number of Brain (computer) 0..500
	    private int _userNum; //Get the number on keyboard
	    private int _guessNum;  //Keep current number of user
	    private int _numFail = 6; //Count fail time 
	    private string tempNum = ""; //string number to show on UI
        public GamePlay ()
		{
			InitializeComponent ();
		}

	    private void ButtonBay_OnTapped(object sender, EventArgs e)
	    {
	        //Get the number of user when tap on key board.
	        //Get current Image tapped
	        var _buttonNum = sender as Image;

	        //Full file name is File: two.png Split .png and File: 
	        //Ex: File: seven.png => two
	        var subNum = _buttonNum.Source.ToString().Substring(0, _buttonNum.Source.ToString().Length - 4);
	        var pickNum = subNum.Substring(6, subNum.Length - 6);

	        //Convert string after split to number
	        if (pickNum == "zero")
	        {
	            _userNum = 0;
	        }
	        else if (pickNum == "one")
	        {
	            _userNum = 1;
	        }
	        else if (pickNum == "two")
	        {
	            _userNum = 2;
	        }
	        else if (pickNum == "three")
	        {
	            _userNum = 3;
	        }
	        else if (pickNum == "four")
	        {
	            _userNum = 4;
	        }
	        else if (pickNum == "five")
	        {
	            _userNum = 5;
	        }
	        else if (pickNum == "six")
	        {
	            _userNum = 6;
	        }
	        else if (pickNum == "seven")
	        {
	            _userNum = 7;
	        }
	        else if (pickNum == "eight")
	        {
	            _userNum = 8;
	        }
	        else if (pickNum == "nine")
	        {
	            _userNum = 9;
	        }

	        //Show tapped number on UI
	        tempNum += _userNum;
	        LabelYourNum.Text = tempNum;
        }

	    private void ButtonOK_OnTapped(object sender, EventArgs e)
	    {
	        try
	        {
	            //Get User number by Int
	            _guessNum = Int32.Parse(tempNum);

	            //Show on UI
	            LabelPlayerNum.Text = "You guess: " + _guessNum;
	            LabelYourNum.Text = "Your number show here!";
	            tempNum = "";

	            //Check Usernumber with Brain number
	            CheckResult();
	        }
	        catch (Exception exception)
	        {

	        }
        }

	    private void CheckResult()
	    {
	        if (_guessNum != _brainNumber)
	        {
	            if (_numFail <= 0)
	            {
	                LabelStatus.Text = "YOU LOSE! My number is " + _brainNumber;
	                RestartGame();
	            }
	            else
	            {
	                if (_guessNum > _brainNumber)
	                {
	                    LabelStatus.Text = "Your number larger my number, You have " + _numFail + " guesses left";
	                    _numFail--;
	                }
	                else
	                {
	                    LabelStatus.Text = "Your number smaller my number, You have " + _numFail + " guesses left";
	                    _numFail--;
	                }
	            }
	        }
	        else
	        {
	            LabelStatus.Text = "YOU WIN!";
	            RestartGame();
	        }
        }

        private async void RestartGame()
        {
            var option = await DisplayAlert("Hi!", "Play again?", "Yes", "No");
            if (option == true)
            {
                CreateRandom();

                //Reset the game
                _numFail = 6;
                LabelStatus.Text = "";
                LabelPlayerNum.Text = "";

            }
            else
            {
                await Navigation.PushModalAsync(new MainPage());
            }
        }

        private void CreateRandom()
        {
            Random random = new Random();
            _brainNumber = random.Next(0, 500);
        }

        private void ButtonClear_OnTapped(object sender, EventArgs e)
	    {
	        try
	        {
	            //Clear the number at the end 
	            tempNum = tempNum.Substring(0, tempNum.Length - 1);
	            LabelYourNum.Text = tempNum;
	        }
	        catch (Exception ex)
	        {

	        }
        }
	}
}