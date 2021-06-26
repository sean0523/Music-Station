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
    <div class="col-md-4">
    <div class="playlist">
        <br/><br/>
        <h1 style="color:white;">歌曲播放清單</h1>
        <div id="playpage">
        <div id="playbody">
            <div id="playlist">
                <select runat="server" size="10" ondblclick="selectPlay()" id="Select1" style="background-color:white; width: 234px;" >
                </select>
            </div>
            <div id="checkplay">
                
                <asp:Button ID="btnIsPlay" runat="server" Text="下一首" OnClick="btnIsPlay_Click" Width="100px" />
                &nbsp;<asp:Button ID="btnSelectPlay" runat="server" Text="播放" OnClick="btnSelectPlay_Click1" Width="100px" />
                &nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="ddlPlayType" runat="server">
                        <asp:ListItem Value="0">順序撥放</asp:ListItem>
                        <asp:ListItem Value="1">隨機撥放</asp:ListItem>
                        <asp:ListItem Value="2">單曲循環</asp:ListItem>
                    </asp:DropDownList>
                 <br/><br/>
                <asp:Button ID="mvSearch" runat="server" Text="MV搜尋" OnClick="mvSearch_Click" Width="100px"/>
                 &nbsp;<asp:Button ID="Button1" runat="server" Text="關閉" Width="100px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
                    <br/><br/>
                     <span style="font-family:Microsoft YaHei;font-size:18px;">
                     <audio controls id="player" autoplay="autoplay" src=<%= name %>>
                     </audio>
                    </></span>
                
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
        </div>
        </div>
    </div>
    </div>
    <div class="col-md-4">
    <div class="album">
        <br/><br/><br/><br/>
        <asp:Label ID="Label3" runat="server" style="color:white" Font-Size="Large" Text="專輯:  "></asp:Label>
        <asp:Label ID="album" runat="server" style="color:white" Font-Size="Large" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Label4" runat="server" style="color:white" Font-Size="Large" Text="歌手:  "></asp:Label>
        <asp:Label ID="singer" runat="server" style="color:white" Font-Size="Large" Text=""></asp:Label>
        <br/>
        <asp:Image ID="Image1" runat="server" Height="250px" Width="250px" />
    </div>

    </div>
    <div class="col-md-4">
        <br/><br/><br/><br/><br/>
        <asp:Label ID="Label1" runat="server" Style="color:white" Width="500px"></asp:Label>
    </div>
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
 <script>
     (function (window, undefined) {
         var player = document.getElementById('player'),
             map = ['currentTime', 'duration'];
         window.setInterval(function () {
             if (player[map[0]] == player[map[1]]) {
                 document.getElementById("<%=btnIsPlay.ClientID %>").click();
          }
      }, 1000);
     })(window);

     function selectPlay() {
         document.getElementById("<%=btnSelectPlay.ClientID %>").click();
     }

 </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
