<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="singerInfoChange.aspx.cs" Inherits="Music_Station.singerInfoChange" %>
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
      <h1 style="color:white;">歌手訊息</h1>
      <div id="musicchange">
        <asp:DataGrid ID="dg" CssClass="dg" AutoGenerateColumns="False" AllowPaging="True" style="background-color:white;"
            OnPageIndexChanged="dg_PageIndexChanged" runat="server" PageSize="15" OnDeleteCommand="dg_DeleteCommand"
            DataKeyField="singer" Width="562px">
            <Columns>
                <asp:HyperLinkColumn HeaderText="修改" DataNavigateUrlField="singerId" DataNavigateUrlFormatString="~/singerInfoChange_edit.aspx?id={0}"
                    NavigateUrl="~/singerInfoChange_edit.aspx" Text="修改"></asp:HyperLinkColumn>
                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除"></asp:ButtonColumn>
                <asp:BoundColumn DataField="singer" HeaderText="歌手名"></asp:BoundColumn>
                <asp:BoundColumn DataField="sex" HeaderText="性别"></asp:BoundColumn>

            </Columns>
        </asp:DataGrid>
    </div>
    <div>
        <asp:Label ID="msg" runat="server" style="color:white;"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" Width="100px" />
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
