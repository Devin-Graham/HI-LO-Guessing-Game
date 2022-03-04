<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="prog2001_A5._default" %>

<!DOCTYPE html>

<!--
    FILE            :   default.aspx
    PROJECT         :   PROG2001: Hi-Lo in ASP.NET
    PROGRAMMER      :   Devin Graham
    FIRST VERSION   :   2021-11-8
    DESCRIPTION     :   
        The purpose of this file is to provide the starting screen
        for the Hi-Lo game. This file gives all the styling and formatting
        of the elements of the page.
 -->


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hi-Lo Game</title>

    <style>
            h1 {
                text-align:center; 
                border-top: 10px solid whitesmoke;
                border-bottom: 10px solid whitesmoke;
                border-radius: 25px;
                font-family: Arial, Helvetica, sans-serif;
                font-weight: bold;
            }
            body {
                background-color: lightskyblue;
            }
            #hr1,#hr6 {
                border-top: 4px solid whitesmoke;
                border-bottom: none;
                border-left: none;
                border-right: none;
            }
            #hr2,#hr5 {
                border-top: 6px solid whitesmoke;
                border-bottom: none;
                border-left: none;
                border-right: none;
            }
            #hr3,#hr4 {
                border-top: 8px solid whitesmoke;
                border-bottom: none;
                border-left: none;
                border-right: none;
            }
            
        </style>
</head>
<body>
    <!--
        Display the title of the of the page
    -->
    <form id="form1" runat="server">
        <div >
            <hr id="hr1"/>
            <hr id="hr2"/>
            <hr id="hr3"/>
            <h1>
            <asp:Label ID="title" runat="server" Text="Let's Play Hi-Lo" Font-Names="Arial Black" Font-Size="XX-Large" Font-Underline="False"></asp:Label>
            </h1>
            <hr id="hr4"/>
            <hr id="hr5"/>
            <hr id="hr6"/>
           
        </div>

         <!--
            Display name prompt and entry box and button
        -->
        <div>
            <p style="margin-left: 39%;">
                <asp:Label ID="namePrompt" runat="server" Height="24px" Text="Please enter your name:" Width="160px"></asp:Label>
                <asp:TextBox ID="nameBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="nameBoxValidator" runat="server" ControlToValidate="nameBox" ErrorMessage="Your name &lt;b&gt;cannot&lt;/b&gt; be BLANK" Height="24px" Width="220px"></asp:RequiredFieldValidator>
            </p>
            
            <p style="text-align: center;">
                <asp:Button ID="submitName" runat="server" Text="Submit" onclick="submitName_click" Width="137px" />
            </p>
             
        </div>
            
        
        
    </form>
</body>
</html>
