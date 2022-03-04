using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * FILE             :   guessRange.aspx.cs
 * PROJECT          :   PROG2001: Hi-Lo in ASP.NET
 * PROGRAMMER       :   Devin Graham
 * FIRST VERSION    :   2021-11-8
 * DESCRIPTION      :
 *      The purpose of this file is provide the server side
 *      processing. The file validates the maximum guess is greater
 *      than 1 and an integer number. If all checks are passed the page
 *      is transfered to the guess page.
 * 
 */

namespace prog2001_A5.MorePages
{
    public partial class guessRange : System.Web.UI.Page
    {

        /*
         * FUNCTION     :   Page_Load
         * DESCRIPTION  :   Updates the UI on load to display the users name in the prompt
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            string getName = Session["name"].ToString();
            maxGuessPrompt.Text = "Hello, " + getName + "! Please enter the maximum guess value: ";
        }

        /*
         * FUNCTION     :   maxGuessValidator_ServerValidate
         * DESCRIPTION  :   Validates the users max guess to ensure it is a valid integer greater than 1
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      ServerValidateEventArgs args     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void maxGuessValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //Validate to check if max guess is blank
            if(args.Value.Trim() == "")
            {
                args.IsValid = false;
                maxGuessValidator.Text = "The input <b>cannot</b> be blank";
                return;
            }

            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"-?^\d+$");

            //Validate to check if max guess is an integer
            if(r.IsMatch(maxGuessBox.Text) == true)
            {
                //Validate to check if value is greater than 1
                if (Convert.ToInt32(args.Value) <= 1)
                {
                    args.IsValid = false;
                    maxGuessValidator.Text = "Your maximum guess <b>must</b> be greater than 1";
                    return;
                }
                else
                {
                    args.IsValid = true;
                    return;
                }
            }
            else
            {
                args.IsValid = false;
                maxGuessValidator.Text = "Your maximum guess <b>must</b> be an integer value";
                return;
            }
        }

        /*
         * FUNCTION     :   submitRange_click
         * DESCRIPTION  :   If all validation checks are passed it sets the session variables
         *                  for the min and max guess and transfers the server so the user can
         *                  start guessing
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void submitRange_click(object sender, EventArgs e)
        {
            //Check to make sure page validation checks are passed
            if(Page.IsValid == true)
            {
                Session["minGuess"] = 1;
                Session["maxGuess"] = maxGuessBox.Text;
                Server.Transfer("makeGuess.aspx");
            }
        }
    }
}