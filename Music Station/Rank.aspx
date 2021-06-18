<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rank.aspx.cs" Inherits="Music_Station.Rank" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/Rank.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        .auto-style1 {
        width: 818px;
    }
    .auto-style2 {
        width: 1022px;
    }
    .auto-style3 {
        width: 812px;
    }
        </style>

<br/><br/><br/>
     <h1 style="color:white;">新歌專輯榜 <asp:Label ID="Label3" runat="server" Text="(點選瀏覽專輯說明)" Font-Size="X-Small"></asp:Label></h1>
    <asp:Label ID="Label4" runat="server" Text="專輯搜尋" ForeColor="White"></asp:Label>
    <asp:TextBox ID="search" runat="server" Width="340px"></asp:TextBox>
    <asp:Button ID="btn" runat="server" Text="搜尋" style="color:black; height: 27px;" OnClick="btn_Click" />
    <asp:Label ID="msg" runat="server" Text="" ForeColor="white"></asp:Label>
    <br />
    <p class="auto-style3">
        <br/>
        <asp:ImageButton ID="ImageButton7" runat="server" Height="200px" ImageUrl="~/PIC/都是因為愛.jpg" Width="200px" OnClick="ImageButton7_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton8" runat="server" Height="200px" ImageUrl="~/PIC/刻在我心底的名字.jpg" Width="200px" OnClick="ImageButton8_Click" />
        &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton9" runat="server" Height="200px" ImageUrl="~/PIC/唯一想了解的人.jpg" Width="200px" OnClick="ImageButton9_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p style="color:white">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;都是因為愛&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 刻在我心底的名字&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 唯一想了解的人&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>  


    <h1 style="color:white;">新歌單曲榜 <asp:Label ID="Label1" runat="server" Text="(點選立即試聽)" Font-Size="X-Small"></asp:Label>
    </h1>
    
    <p class="auto-style1">
        <asp:ImageButton ID="ImageButton1" runat="server" Height="200px" ImageUrl="~/PIC/韋禮安.jpg" Width="200px" OnClick="ImageButton1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="200px" ImageUrl="~/PIC/唯一想了解的人.jpg" Width="200px" OnClick="ImageButton2_Click" />
        &nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" Height="200px" ImageUrl="~/PIC/周興哲.jpg" Width="200px" OnClick="ImageButton3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p style="color:white"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 因為是你&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 我們都傷&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 離開你以後&nbsp;</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
    <h1 style="color:white">&nbsp;專輯單曲榜 <asp:Label ID="Label2" runat="server" Text="(點選立即試聽)" Font-Size="X-Small"></asp:Label></h1>
    <p class="auto-style1">
        <asp:ImageButton ID="ImageButton4" runat="server" Height="200px" ImageUrl="~/PIC/都是因為愛.jpg" Width="200px" OnClick="ImageButton4_Click" />
&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" Height="200px" ImageUrl="~/PIC/刻在我心底的名字.jpg" Width="200px" OnClick="ImageButton5_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:ImageButton ID="ImageButton6" runat="server" Height="200px" ImageUrl="~/PIC/阿冗.jpg" Width="200px" OnClick="ImageButton6_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p style="color:white" class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 我很好騙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 刻在我心底的名字&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;與我無關&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>   
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
   
  <audio autoplay="autoplay" src=<%= name %>>
  </audio>
</asp:Content>
