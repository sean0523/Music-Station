<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RankLink.aspx.cs" Inherits="Music_Station.RankLink" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
    body{
        margin:0;
        padding:0;
        background: #000 url("PIC/Rank.jpg") center center fixed no-repeat;
        background-size: cover;
    }
    .auto-style1 {
        width: 290px;
    }
    .auto-style2 {
        color: white;
    }
</style> 

<div class="row">
    <div class="col-md-6">
        <br/><br/>
        <h1 class="auto-style2">專輯介紹</h1>
        <asp:Image ID="Image1" runat="server" Height="250px" Width="300px" ImageUrl="~/PIC/1.jpg"  />
        <br />
        <br/>
        <asp:Label ID="Label1" runat="server" Text="專輯:" Style="color:white" Font-Size="Medium"></asp:Label> &nbsp;
        <asp:Label ID="album" runat="server" Text="" Style="color:white" Font-Size="Medium"></asp:Label>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="歌手:" Style="color:white" Font-Size="Medium"></asp:Label> &nbsp;
        <asp:Label ID="singer" runat="server" Text="" Style="color:white" Font-Size="Medium"></asp:Label>
         <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="曲目試聽" Style="color:white" Font-Size="Medium"></asp:Label>
        <br />
       

         <asp:Label ID="msg" runat="server" Text="" Style="color:white"></asp:Label>
        <br/>
         <select runat="server" size="10" ondblclick="selectPlay()" id="Select1" style="background-color:white; " class="auto-style1">
                </select>
                     <span style="font-family:Microsoft YaHei;font-size:18px;">
                     <audio autoplay="autoplay" loop src=<%= name %>>
                      </audio>
        <asp:Button ID="btnSelectPlay" runat="server" Text="試聽" OnClick="btnSelectPlay_Click" />
        <asp:Button ID="return" runat="server" Text="返回" OnClick="return_Click" />
        </span>
        <br />
    </div>
    <div class="col-md-6">
        <br/><br/><br/>
       

        <br/>
        <asp:Label ID="list" runat="server" Text="" Style="color:white" Font-Size="small"></asp:Label>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
