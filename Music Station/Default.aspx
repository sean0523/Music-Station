<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Music_Station._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br/><br/><br/><br/><br/>
    <asp:Label ID="msg" runat="server" style=color:white;></asp:Label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main1" runat="server">
<style>
        .default{
        margin:auto;
        margin-top:13%;
        margin-left:2%;
        height:200px;
        width:400px;
    }
body{
        margin:0;
        padding:0;
        background: #000 url("PIC/b1.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        .auto-style1 {
        width: 768px;
        margin-left: 0;
    }
        .auto-style2 {
        font-size: 21px;
        font-weight: 300;
        line-height: 1.4;
        width: 890px;
        margin-bottom: 20px;
    }
        </style>
    <div class="default">
        <p style="color:white; font-size:80px"  class="auto-style1">Melody For You</p>

        <p style="color:white; font-size:30px"class="auto-style2" >Find More Innovative &amp; Creative Music Albums</p>
        <p ><a href="login" class="btn btn-primary btn-lg" >Listen Here </a>
        <p>&nbsp;<p>&nbsp;<p>&nbsp;</div>
    <audio autoplay="autoplay" loop src="listen/背景音樂.mp3">>
  </audio>
    <br/><br/>
    <br />
    <br />
    <br />
    <br/>
    <br />
    <br/><br/>
</asp:Content>
   



