using System;
using System.Reflection;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
 * FILE             :   default.aspx.cs
 * PROJECT          :   PROG2001: Hi-Lo in ASP.NET
 * PROGRAMMER       :   Devin Graham
 * FIRST VERSION    :   2021-11-8
 * DESCRIPTION      :
 *      The purpose of this file is provide the server side
 *      processing. If all client side checks are passed this
 *      code is run and transfers the server to the next page.
 * 
 */

namespace prog2001_A5
{
    public partial class _default : System.Web.UI.Page
    {
       
        /*
         * FUNCTION     :   submitName_click
         * DESCRIPTION  :   Creates a session variable for the name of the user and transfers
         *                  to the next page
         * PARAMETERS   :   
         *      object sender   :   The control of the action
         *      EventArgs e     :   The base class for classes that contain event data
         * RETURNS      :
         *      void
         */
        protected void submitName_click(object sender, EventArgs e)
        {
            Session["name"] = nameBox.Text;
            Server.Transfer("MorePages/guessRange.aspx");
        }
    }
}