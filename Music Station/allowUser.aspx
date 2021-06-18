<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="allowUser.aspx.cs" Inherits="Music_Station.allowUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/使用者授權.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        </style>
    <br/><br/><br/>
    <h1 style="color:white;">使用者清單</h1>
    <div id="musicchange">
        <asp:DataGrid ID="dg" CssClass="dg" AutoGenerateColumns="False" AllowPaging="True" style="background-color:white;"
            OnPageIndexChanged="dg_PageIndexChanged" runat="server" PageSize="15" OnDeleteCommand="dg_DeleteCommand"
            DataKeyField="userId" OnItemCommand="dg_ItemCommand" Width="796px">
            <Columns>
                <asp:ButtonColumn ButtonType="linkButton" HeaderText="授權" CommandName ="allowUser" Text="授權"></asp:ButtonColumn>
                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除"></asp:ButtonColumn>
                <asp:BoundColumn DataField="userId" HeaderText="用户Id"></asp:BoundColumn>
                <asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
                <asp:BoundColumn DataField="sex" HeaderText="性别"></asp:BoundColumn>
                <asp:BoundColumn DataField="mail" HeaderText="e_mail"></asp:BoundColumn>
            </Columns>
        </asp:DataGrid>
    </div>
    <div>
        <asp:Label ID="msg" runat="server" style="color:white;"></asp:Label>
        <br />
        <br/>
        <asp:Button ID="btn" runat="server" Text="返回" OnClick="btn_Click" Width="100px" />
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
    </div>
</asp:Content>
