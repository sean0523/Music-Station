<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Music_Station.regist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .log{
        text-align: center;
        margin:auto;
        margin-top:15%;
        margin-left:28%;
        height:200px;
        width:400px;
    }
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/登入背景.jpg") center center fixed no-repeat;
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

    <div class="log">
    <h1 style="color:white;"> 登入/註冊資訊 </h1>
    <table class="auto-style1">

    <tr>
    <td style="color:white"; >使用者帳號：</td><td align="left" class="auto-style3" >
    <asp:TextBox ID="userId" runat="server" Width="300px" ></asp:TextBox>  &nbsp;&nbsp;<asp:Label ID="FailureText" runat="server" Text="" style="color:red;"></asp:Label>
    </td>
    </tr>
    <tr style="height: 25px">
    <td style="color:white"; >使用者密碼：</td><td "width: 500px;" align="left">
    <asp:TextBox ID="Password" runat="server" Width="300px"  TextMode="Password"></asp:TextBox>                
    </td>                
    </tr>   
    </table>
    <br/><br/>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btn" runat="server" Text="登入" Width="100px" OnClick="btn_Click" />
        &nbsp;&nbsp;<asp:Button ID="button" runat="server" Text="註冊" Width="100px" OnClick="button_Click" TabIndex="1" />
        &nbsp;&nbsp;<asp:Button ID="forget" runat="server" Text="重設密碼" OnClick="forget_Click" Width="100px" TabIndex="1" />
        
   </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
    <br/><br/><br/>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br/><br/>
</asp:Content>
