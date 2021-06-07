<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="singerInfoChange_edit.aspx.cs" Inherits="Music_Station.singerInfoChange_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/後台管理背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
    .auto-style1 {
        width: 100px;
        height: 30px;
    }
    .auto-style2 {
        width: 30px;
        height: 30px;
    }
    .auto-style3 {
        width: 606px;
    }
</style>   
    <br/><br/><br/>
     <h1 style="color:white;">歌手訊息</h1>
    <div id="music_add">
        <table border="1px" class="auto-style3">
            <tr style="height: 30px">
                <td style="width: 100px; text-align: right; color:white">
                    歌 &nbsp; &nbsp; &nbsp; 手：
                </td>
                <td style="width: 300px" align="left">
                    <asp:TextBox ID="singer" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="singer" style="color:red"
                        Display="Dynamic" ErrorMessage="RequiredFieldValidator">歌手名稱不能為空</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; color:white" class="auto-style1">
                    性 &nbsp; &nbsp; &nbsp; 别：
                </td>
                <td align="left" class="auto-style2">
                    <asp:DropDownList ID="sex" runat="server">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </td>
        </table>
    </div>
    <div>
        <asp:Label ID="msg" runat="server" Text="" style="color:white;"></asp:Label>
        <br />
        <br/>
        <asp:Button ID="btn" runat="server" Text="修改" OnClick="btn_Click" />
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
