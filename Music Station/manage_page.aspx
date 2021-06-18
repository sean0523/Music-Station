<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="manage_page.aspx.cs" Inherits="Music_Station.manage_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/後台管理背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        .auto-style1 {
            width: 604px;
        }
        .auto-style3 {
            width: 500px;
            height: 25px;
        }
    </style>   
    <div id="menu">
        
            <br/>&nbsp;
            <asp:Label ID="msg" runat="server" style="color:red;"></asp:Label>
            <br/><br/>

            <ul>
            <h1 style="color:white;"> 後台管理 </h1>
            <br/>
            <li><a href="musicAdd.aspx" style="color:white;">添加新音樂</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="musicChange.aspx" style="color:white;">音樂修改</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="albumInfoChange.aspx" style="color:white;">專輯修改</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="singerInfoChange.aspx" style="color:white;">歌手信息修改</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="textAdd.aspx" style="color:white;">添加歌曲歌詞</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="introductionAdd.aspx" style="color:white;">添加專輯介紹</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="SongAdd.aspx" style="color:white;">添加試聽歌曲</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="allowUser.aspx" style="color:white;">使用者授權</a></li>
            <li class="menuDiv" style="color:white;">|</li>
            <li><a href="manageExit.aspx" style="color:white;">管理者退出</a></li>
        </ul>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
    </div>
</asp:Content>
