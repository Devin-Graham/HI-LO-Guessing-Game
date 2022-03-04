using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * FILE             :   makeGuess.aspx.cs
 * PROJECT          :   PROG2001: Hi-Lo in ASP.NET
 * PROGRAMMER       :   Devin Graham
 * FIRST VERSION    :   2021-11-8
 * DESCRIPTION      :
 *      The purpose of this file is provide the server side
 *      processing. This file creates the random number to be guessed
 *      on initialization, and displays the bounds of the game. This file
 *      also contains server side validation for the guess box. When all
 *      validation checks are passed the guess is processed. If the guess
 *      matches the random number the page is transfered to the win screen.
 * 
 */

namespace prog2001_A5.MorePages
{
    public partial class makeGuess : System.Web.UI.Page
    {

        /*
         * FUNCTION     :   Page_Init
         * DESCRIPTION  :   Creates the random number of the game on initialization and
         *                  no postbacks have occured
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void Page_Init(object sender, EventArgs e)
        {
            //Create random number to be guessed if no postbacks have occured
            if (IsPostBack == false)
            {
                int lowerBound = Convert.ToInt32(Session["minGuess"]);
                int upperBound = Convert.ToInt32(Session["maxGuess"]);
                Random rnd = new Random();
                int randomNumber = rnd.Next(lowerBound, upperBound);
                Session["randomNumber"] = randomNumber;
            }
        }


        /*
         * FUNCTION     :   Page_Load
         * DESCRIPTION  :   Update the user interface with allowable ranges for the game
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string lowerBound = Session["minGuess"].ToString();
            string upperBound = Session["maxGuess"].ToString();

            string getName = Session["name"].ToString();
            intro.Text = getName + " - we're playing Hi-Lo!";

            rangePrompt.Text = "Your allowable guessing range is any value between " + lowerBound + " and " + upperBound;
        }

        /*
         * FUNCTION     :   guessBoxValidator_ServerValidate
         * DESCRIPTION  :   Validate to ensure the guess is a valid integer
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      ServerValidateEventArgs args     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void guessBoxValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int lowerBound = Convert.ToInt32(Session["minGuess"]);
            int upperBound = Convert.ToInt32(Session["maxGuess"]);

            //Validate to see if guess is blank
            if (args.Value.Trim() == "")
            {
                args.IsValid = false;
                guessBoxValidator.Text = "The input <b>cannot</b> be blank";
                return;
            }

            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"-?^\d+$");

            //Validate to see if guess is a valid integer number
            if (r.IsMatch(guessBox.Text) == true)
            {
                //Validate to see if guess is within range
                if (Convert.ToInt32(args.Value) < lowerBound || Convert.ToInt32(args.Value) > upperBound)
                {
                    args.IsValid = false;
                    guessBoxValidator.Text = "Your guess <b>cannot</b> outside the allowed range";
                    return;
                }
                else
                {
                    args.IsValid = true;
                    Session["guess"] = guessBox.Text;
                    return;
                }
            }
            else
            {
                args.IsValid = false;
                guessBoxValidator.Text = "Your maximum guess <b>must</b> be an integer value";
                return;
            }
        }

        /*
         * FUNCTION     :   submitGuess_click
         * DESCRIPTION  :   Checks if the guess is high, low, or equal to the random number.
         *                  If it is equal it transfers the page to win page.
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void submitGuess_click(object sender, EventArgs e)
        {
            //Check to see if the server side validation checks have been passed
            if(Page.IsValid == true)
            {
                int randomNumber = Convert.ToInt32(Session["randomNumber"]);
                int guess = Convert.ToInt32(Session["guess"]);

                //Check if random number has been guessed
                if (guess > randomNumber)
                {
                    Session["maxGuess"] = guess - 1;
                }
                else if (guess < randomNumber)
                {
                    Session["minGuess"] = guess + 1;
                }
                else
                {
                    Server.Transfer("winPage.aspx");
                }

                string lowerBound = Session["minGuess"].ToString();
                string upperBound = Session["maxGuess"].ToString();

                rangePrompt.Text = "Your allowable guessing range is any value between " + lowerBound + " and " + upperBound;
            }
            
        }
    }
}