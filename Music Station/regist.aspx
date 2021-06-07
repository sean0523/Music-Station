<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="Music_Station.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .reg{
        
        margin:auto;
        margin-top:15%;
        margin-left:22%;
        width: 80vmin;
        height: 30vmin;
      
    }
        body{
        margin:0;
        padding:0;
        background: #000 url("PIC/註冊背景.jpg") center center fixed no-repeat;

        background-size: cover;
    }
        .auto-style1 {
            width: 650px;
        }
        .auto-style2 {
            width: 128px;
        }
        </style>

<div class="reg">
    <h1 style="color:white;">註冊資訊</h1>
     <table  class="auto-style1">
            <tr style="height: 25px">
                <td style=" color:white; text-align: right;" class="auto-style2">使用者帳號：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="userId" runat="server" Width="300px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="使用者帳號不能為空" style="color:red;"></asp:Label>
                </td>
            </tr>
            <tr style="height: 25px">
                <td style="color:white; text-align: right;" class="auto-style2">使用者密碼：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="password" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label1" runat="server" Text="使用者密碼不能為空" style="color:red;"></asp:Label>
                </td>                
            </tr>
            <tr style="height: 25px">
                <td style="color:white; text-align: right;" class="auto-style2">再次輸入密碼：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="repassword" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="再輸入一次密碼" style="color:red;"></asp:Label>
                </td>                
            </tr>         
            <tr style="height: 25px">
                <td style="color:white; text-align: right;" class="auto-style2">使用者姓名：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="name" runat="server" Width="300px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;          
            </tr>                
            <tr style="height: 25px">
                <td style="color:white; text-align: right;" class="auto-style2">使用者性別：</td>
                <td style="width: 300px" >
                <asp:DropDownList ID="sex" runat="server" >
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>                   
            <tr style="height: 25px">
                <td style="color:white; text-align: right;" class="auto-style2">e-Mail：</td>
                <td style="width: 500px;" align="left"><asp:TextBox ID="mail" runat="server" Width="300px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label4" runat="server" Text="E-Mail不能為空" style="color:red;"></asp:Label>
                </td>                
            </tr>                   
    </table>
    <asp:Label ID="meg" runat="server" style="color:red;"></asp:Label>
    <br/>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="addbtn" runat="server" Text="確認" OnClick="addbtn_Click" Width="80px" />&nbsp;&nbsp;&nbsp; <asp:Button ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" Width="80px" />
    </div>
    <br />
    <br/><br/>  
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
