<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forgetId.aspx.cs" Inherits="Music_Station.forgetId" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .forgetId{
        margin:auto;
        margin-top:18%;
        margin-left:27%;
        height:200px;
        width:600px;
    }
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/註冊背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        .auto-style1 {
            width: 748px;
        }
    .auto-style2 {
        margin-top: 15%;
        margin-left: 27%;
        height: 200px;
        width: 624px;
        margin-right: auto;
        margin-bottom: auto;
    }
</style>
<div class="auto-style2">
<h1 style="color:white;" >重設密碼</h1>
     <table  class="auto-style1">
            <tr style="height: 25px">
             <td style=" color:white; width: 100px; text-align: right;">使用者帳號：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="userId" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height: 25px">
                <td style="color:white; width: 100px; text-align: right;">e-mail：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="eMail" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>                    
            <tr style="height: 25px">
                <td style="color:white; width: 100px; text-align: right;">新使用者密碼：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>  
            <tr style="height: 25px">
                <td style="color:white; width: 100px; text-align: right;">再次輸入密碼：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="repassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>  
    </table>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
            <asp:Label ID="meg" runat="server" Text="" style="color:white;"></asp:Label>
            <br/><br/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="check" runat="server" Text="確認" OnClick="check_Click" Width="100px" /><asp:Button ID="cancel" runat="server" Text="取消" Width="100px" OnClick="cancel_Click" />

</div>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
</asp:Content>
