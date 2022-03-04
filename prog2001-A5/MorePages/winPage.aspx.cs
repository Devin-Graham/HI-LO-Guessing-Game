using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * FILE             :   winPage.aspx.cs
 * PROJECT          :   PROG2001: Hi-Lo in ASP.NET
 * PROGRAMMER       :   Devin Graham
 * FIRST VERSION    :   2021-11-8
 * DESCRIPTION      :
 *      The purpose of this file is provide the server side
 *      processing. When the user presses the button it clears
 *      the session variables and starts the game over again from
 *      the max guess screen.
 * 
 */

namespace prog2001_A5.MorePages
{
    public partial class winPage : System.Web.UI.Page
    {

        /*
         * FUNCTION     :   submitWin_click
         * DESCRIPTION  :   Clears all the session variables except for the name and returns
         *                  to the guess range screen so the user can play again
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void submitWin_click(object sender, EventArgs e)
        {
            Session.Remove("minGuess");
            Session.Remove("maxGuess");
            Session.Remove("randomNumber");
            Session.Remove("guess");
            Server.Transfer("guessRange.aspx");
        }
    }
}