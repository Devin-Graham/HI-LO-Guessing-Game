<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="makeGuess.aspx.cs" Inherits="prog2001_A5.MorePages.makeGuess" %>

<!DOCTYPE html>

<!--
    FILE            :   makeGuess.aspx
    PROJECT         :   PROG2001: Hi-Lo in ASP.NET
    PROGRAMMER      :   Devin Graham
    FIRST VERSION   :   2021-11-8
    DESCRIPTION     :   
        The purpose of this file is to provide the guess screen
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
    <form id="form1" runat="server">

        <!--
            Display the title of the page
        -->
        <div>
        <hr id="hr1"/>
        <hr id="hr2"/>
        <hr id="hr3"/>
        <h1>
        <asp:Label ID="intro" runat="server" Text="Name - we're playing Hi-Lo!" Font-Names="Arial Black" Font-Size="XX-Large"></asp:Label>
        </h1>
        <hr id="hr4"/>
        <hr id="hr5"/>
        <hr id="hr6"/>

        <!--
            Display the guessing prompt, entry box, and submit button
        -->
        <p style="margin-left: 39%">
        <asp:Label ID="guessPrompt" runat="server" Height="24px" Text="Enter your guess: " Width="120px"></asp:Label>
        <asp:TextBox ID="guessBox" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="guessBoxValidator" runat="server" ControlToValidate="guessBox" ErrorMessage="CustomValidator" Height="24px" OnServerValidate="guessBoxValidator_ServerValidate" ValidateEmptyText="True"></asp:CustomValidator>
        </p>
        <div style="text-align: center;">
            <asp:Button ID="submitGuess" runat="server" Text="Make this Guess" onclick="submitGuess_click"/>
        </div>
        
        <p style="text-align: center;">
        <asp:Label ID="rangePrompt" runat="server" ForeColor="Red" Text="Your allowable guessing range is any value between 1 and undefined"></asp:Label>
        </p>
        </div>
        
    </form>
</body>
</html>
