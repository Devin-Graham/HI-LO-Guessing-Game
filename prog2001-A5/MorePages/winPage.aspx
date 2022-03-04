<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="winPage.aspx.cs" Inherits="prog2001_A5.MorePages.winPage" %>

<!DOCTYPE html>

<!--
    FILE            :   winPage.aspx
    PROJECT         :   PROG2001: Hi-Lo in ASP.NET
    PROGRAMMER      :   Devin Graham
    FIRST VERSION   :   2021-11-8
    DESCRIPTION     :   
        The purpose of this file is to provide the win screen
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
                background-color: lightgreen;
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
            #button {
                text-align: center;
            }
            
        </style>
</head>
<body>
    <form id="form1" runat="server">

        <!--
        Display the title of the of the page
         -->
        <div>
            <hr id="hr1"/>
            <hr id="hr2"/>
            <hr id="hr3"/>
            <h1><asp:Label ID="title" runat="server" Text="You Win!! You guessed the number!!" Font-Names="Arial Black" Font-Size="XX-Large"></asp:Label></h1>
            <hr id="hr4"/>
            <hr id="hr5"/>
            <hr id="hr6"/>

        <!--
        Display the play again button
         -->
            <div id="button">
                <asp:Button ID="submitWin" runat="server" Text="Play Again" onclick="submitWin_click" BackColor="White" Height="40px"/>
            </div>
        </div>
        
    </form>
</body>
</html>
