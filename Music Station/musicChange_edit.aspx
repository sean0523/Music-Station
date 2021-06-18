<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="musicChange_edit.aspx.cs" Inherits="Music_Station.musicChange_edit" %>
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
    <h1 style="color:white;">歌曲訊息修改</h1>
    <div id="music_add">
        <table>
            <tr style="height: 25px">
                <td style="width: 100px; text-align: right; color:white;">
                    歌 &nbsp; &nbsp; &nbsp; 曲：</td>
                    <td style="width: 300px;" align="left">
                    <asp:TextBox ID="musicName" runat="server">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" style="color:red;"
                        ControlToValidate="musicName" Display="Dynamic">歌曲名不能为空</asp:RequiredFieldValidator></td>
            </tr>
            <tr style="height: 30px">
                <td style="width: 100px; text-align: right; color:white;">
                    歌 &nbsp; &nbsp; &nbsp; 手：
                </td>
                <td style="width: 300px" >
                    <asp:DropDownList ID="singer" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 100px; text-align: right; height: 30px; color:white;">
                    專 &nbsp; &nbsp; &nbsp; 輯：
                </td>
                <td style="width: 300px; height: 30px;">
                    <asp:DropDownList ID="album" runat="server">
                    </asp:DropDownList></td>
            </tr>
            <tr style="height: 30px">
                <td style="width: 100px; text-align: right; color:white;">
                    類 &nbsp; &nbsp; &nbsp; 別：
                </td>
                <td style="width: 300px" >
                    <asp:DropDownList ID="typelist1" runat="server" >
                        <asp:ListItem> </asp:ListItem>
                        <asp:ListItem>中港台</asp:ListItem>
                        <asp:ListItem>日韓</asp:ListItem>
                        <asp:ListItem>歐美</asp:ListItem>
                        <asp:ListItem>鄉村</asp:ListItem>
                        <asp:ListItem>卡通</asp:ListItem>
                        <asp:ListItem>歌劇</asp:ListItem>
                        <asp:ListItem>其他</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr style="height: 30px">
                <td colspan="2">
                    <asp:Label ID="msg" runat="server" style="color:white;"></asp:Label>
                    <br/><br/>
                    <asp:Button ID="btn" runat="server" Text="修改" OnClick="btn_Click" Width="100px" />
                &nbsp;&nbsp;
                    <asp:Button ID="return" runat="server" Text="返回" Width="100px" OnClick="return_Click" />
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
                    
                </td>
            </tr>
        </table>
    </div>
    <div>
    </div>
</asp:Content>
