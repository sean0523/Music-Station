<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="albumInfoChange_edit.aspx.cs" Inherits="Music_Station.albumInfoChange_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/後台管理背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        </style>   

    <br/><br/><br />
    <h1 style="color:white;">專輯資訊修改</h1>
    <div id="music_add">
        <table border="1px">
            <tr style="height: 30px">
                <td style="width: 100px; text-align: right;color:white;">
                    專輯名稱：
                </td>
                <td style="width: 300px" align="left">
                    <asp:TextBox ID="album" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="album" style="color:red;"
                        Display="Dynamic" ErrorMessage="RequiredFieldValidator">必須填寫專輯名稱</asp:RequiredFieldValidator></td>
            </tr>
            <tr style="height: 30px">
                <td style="width: 100px; text-align: right;color:white;">
                    歌手名稱：
                </td>
                <td style="width: 300px" align="left">
                    <asp:TextBox ID="singer" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" style="color:red;"
                        ControlToValidate="singer">必須填寫歌手名稱</asp:RequiredFieldValidator></td>
            </tr>
            <tr style="height: 30px">
                <td align="edge" colspan="2">
                    <br/>
                    <asp:Button ID="btn" runat="server" Text="修改" OnClick="btn_Click" Width="100px" />
                    <asp:Button ID="return" runat="server" Text="返回" OnClick="return_Click" Width="100px" />
                </td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
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
        <br />
        <br />
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
