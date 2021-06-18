<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="playList.aspx.cs" Inherits="Music_Station.playList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
       .playlist{
        margin:auto;
        margin-top:6%;
       }
body{
        margin:0;
        padding:0;
        background: #000 url("PIC/撥放背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        </style> 
<div class="row">
    <div class="col-md-6">
    <div class="playlist">
        <br/><br/>
        <h1 style="color:white;">歌曲播放清單</h1>
        <div id="playpage">
        <div id="playbody">
            <div id="playlist">
                <select runat="server" size="10" ondblclick="selectPlay()" id="Select1" style="background-color:white; width: 234px;">
                </select>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
            <div id="checkplay">
                
                <asp:Button ID="btnIsPlay" runat="server" Text="下一首" OnClick="btnIsPlay_Click" Width="100px" />
                <asp:Button ID="btnSelectPlay" runat="server" Text="播放" OnClick="btnSelectPlay_Click1" Width="100px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <td style="text-align: center; width: 100px;" valign="top">
                    <asp:DropDownList ID="ddlPlayType" runat="server">
                        <asp:ListItem Value="0">順序撥放</asp:ListItem>
                        <asp:ListItem Value="1">隨機撥放</asp:ListItem>
                        <asp:ListItem Value="2">單曲循環</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="Button1" runat="server" Text="返回" Width="80px" OnClick="Button1_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
                    <br/><br/>
                     <span style="font-family:Microsoft YaHei;font-size:18px;">
                     <audio controls="controls" autoplay="autoplay" loop src=<%= name %>>
                    </></span>
                </td>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>
        </div>
    </div>
    </div>
    <div class="col-md-6">
        <br/><br/><br/><br/>
        <asp:Label ID="Label1" runat="server" Style="color:white" Width="500px"></asp:Label>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
