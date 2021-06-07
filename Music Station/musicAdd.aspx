<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="musicAdd.aspx.cs" Inherits="Music_Station.musicAdd" %>
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
    <h1 style="color:white;">新增歌曲</h1>
    <asp:Label ID="Label1" runat="server" Text="新增歌曲:" style="color:white;"> </asp:Label>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
    <br/>
    <asp:FileUpload ID="upload" runat="server" Width="722px" AllowMultiple="True" style="color:white;" />
    <asp:Label ID="Label2" runat="server" Text="歌手名稱:" style="color:white;"></asp:Label>&nbsp;&nbsp; <asp:TextBox ID="singer" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="Label5" runat="server" Text="歌手性別:" style="color:white;"></asp:Label>&nbsp;&nbsp; <asp:DropDownList ID="sex" runat="server">
        <asp:ListItem>男</asp:ListItem>
        <asp:ListItem>女</asp:ListItem>
    </asp:DropDownList>
    <br/>
    <asp:Label ID="Label3" runat="server" Text="專輯名稱" style="color:white;"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:TextBox ID="album" runat="server"></asp:TextBox>
    <br/>
    <asp:Label ID="Label4" runat="server" Text="專輯類型" style="color:white;"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="typelist" runat="server">
        <asp:ListItem> </asp:ListItem>
        <asp:ListItem>中港台</asp:ListItem>
        <asp:ListItem>日韓</asp:ListItem>
        <asp:ListItem>歐美</asp:ListItem>
        <asp:ListItem>鄉村</asp:ListItem>
        <asp:ListItem>卡通</asp:ListItem>
        <asp:ListItem>歌劇</asp:ListItem>
        <asp:ListItem>其他</asp:ListItem>
    </asp:DropDownList>
    <br/>
    <asp:Label ID="Label6" runat="server" Text="訊息說明" style="color:white;"></asp:Label>&nbsp;&nbsp;&nbsp; <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
    <br/><br/>
    <asp:Button ID="btn" runat="server" Text="添加" OnClick="btn_Click" Width="100px" />&nbsp;&nbsp; <asp:Button ID="exit" runat="server" Text="返回" Width="100px" OnClick="exit_Click" />
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    <br />
    
</asp:Content>
