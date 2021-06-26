<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Successful.aspx.cs" Inherits="Music_Station.Successful" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/註冊背景.jpg") center center fixed no-repeat;

        background-size: cover;
    }
        .auto-style2 {
        width: 500px;
        height: 25px;
    }
    .auto-style3 {
        width: 764px;
    }
    .auto-style4 {
        width: 608px;
        height: 25px;
    }
        </style>

    <br/><br/><br/><br/>
    <p style="color:white;"> 恭喜您  註冊成功，請至註冊的 E-Mail 帳戶確認並妥善保存個人驗證碼，便於下次登入使用
    </p>
    <p style="color:white;"> 
        &nbsp;請按下方離開並重新登入，謝謝。</p>
    <asp:Button ID="exit" runat="server" Text="離開" OnClick="exit_Click" color="black" ForeColor="Black"/>
    <asp:Label ID="status" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
