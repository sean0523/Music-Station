<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="favorite.aspx.cs" Inherits="Music_Station.favorite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/收藏背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        </style>    
    <br /><br /><br /><br />
    <asp:Label ID="meg" runat="server" Text="" style="color:white;"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
     <h1 style="color:white;" >收藏歌單</h1>
    <div id="musicchange">
        <asp:DataGrid ID="dg" CssClass="dg" AutoGenerateColumns="false" AllowPaging="True" style="background-color:white;"
            OnPageIndexChanged="dg_PageIndexChanged" runat="server" PageSize="15" OnDeleteCommand="dg_DeleteCommand"
            DataKeyField="musicName" OnItemCommand="dg_ItemCommand" Width="594px">
            <Columns>
                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除"></asp:ButtonColumn>
                <asp:BoundColumn DataField="musicName" HeaderText="音樂名稱"></asp:BoundColumn>
                <asp:BoundColumn DataField="singer" HeaderText="歌手名稱"></asp:BoundColumn>
                <asp:BoundColumn DataField="Album" HeaderText="專輯名稱"></asp:BoundColumn>

            </Columns>
        </asp:DataGrid>
    </div>
    <div>
        &nbsp;&nbsp;
        <asp:Label ID="msg" runat="server" style="color:red;"></asp:Label>
        <br /><br/>
        <asp:Button ID="New" runat="server" Text="新增" OnClick="New_Click" Width="100px" /><asp:Button ID="btn" runat="server" Text="返回" OnClick="btn_Click" Width="100px" />
        <asp:Button ID="playBtn" runat="server" OnClick="playBtn_Click" Text="播放" Width="100px" />
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
