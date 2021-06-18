<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SongAdd.aspx.cs" Inherits="Music_Station.SongAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
body{
     margin:0;
     padding:0;
     background: #000 url("PIC/後台管理背景.jpg") center center fixed no-repeat;
     background-size: cover;
    }

</style>  
    <br/><br/><br/>
    <h1 style="color:white;">新增試聽歌曲</h1>
    <asp:Label ID="Label1" runat="server" Text="試聽歌曲:" style="color:white;"></asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
    <br/>
    <asp:FileUpload ID="upload" runat="server" Width="722px" AllowMultiple="True" style="color:white;" />
    <br/>
    <asp:Label ID="Label6" runat="server" Text="訊息說明" style="color:white;"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
    <br/><br/>
    <asp:Button ID="btn" runat="server" Text="添加" OnClick="btn_Click" Width="100px" />&nbsp;&nbsp; <asp:Button ID="exit" runat="server" Text="返回" Width="100px" OnClick="exit_Click" />
    
        <br />



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
