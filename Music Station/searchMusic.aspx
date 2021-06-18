<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="searchMusic.aspx.cs" Inherits="Music_Station.searchMusic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    body{
        margin:0;
        padding:0;
        background: #000 url("PIC/音樂搜尋背景.jpg") center center fixed no-repeat;
        background-size: cover;
    }
        .auto-style4 {
            width: 436px;
        }
    </style>
    <br/><br/><br/>
    <asp:Label ID="meg" runat="server" Text="" style="color:white;"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main1" runat="server">
     <h1 style="color:white;">歌名/歌手/專輯搜尋</h1>
     <table style="background-color:; " class="auto-style4">
        <tr style="height: 25px">
             <td style="width: 500px; text-align: right; color:white;">關鍵字搜尋：</td>
             <td style="width: 500px;" align="left"><asp:TextBox ID="txt" runat="server" Width="290px"></asp:TextBox>
             </td>
        </tr>
        <tr>
             <td style="width: 500px; text-align: right; color:white;">資料類型：</td>
             <td style="width: 500px;" align="left">
             &nbsp;
             <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="horizontal" Height="16px" Width="214px" style=color:white;>
             <asp:ListItem Value="music" Selected="true">歌名</asp:ListItem>
             <asp:ListItem Value="singer">歌手</asp:ListItem>
             <asp:ListItem Value="album">專輯</asp:ListItem>
             </asp:RadioButtonList>
             </td>
        </tr>
        </table>
            <br/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="search_btn" runat="server" Text="搜尋" type="submit" OnClick="search_btn_Click" Width="80px" />
             &nbsp;        
             <asp:Button ID="Button1" runat="server" Text="返回首頁" OnClick="Button1_Click" Width="80px" />


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Main2" runat="server">
     <div>
        <h1>&nbsp;</h1>
         <h1 style="color:white;">搜索结果</h1>
    </div>
    <div>
        
        <asp:DataGrid ID="dg" CssClass="dg" AutoGenerateColumns="false" AllowPaging="True" color="257" style="background-color:white;" PagerStyle-NextPageText="下一頁"  PagerStyle-PrevPageText="上一頁"
           DataKeyField="musicName" OnPageIndexChanged="dg_PageIndexChanged" runat="server" PageSize="15" OnCreateCommand="dg_CreateCommand"
            Width="597px">
            <PagerStyle BackColor="AliceBlue" />
            <Columns>
                <asp:TemplateColumn HeaderText="編號">
                    <ItemTemplate>
                        <%# Container.ItemIndex+1 %>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:HyperLinkColumn DataTextField="id" DataNavigateUrlField="id" HeaderText="歌曲id"
                    Visible="False">
                </asp:HyperLinkColumn>
                <asp:HyperLinkColumn HeaderText="收藏" DataNavigateUrlField="id" Text="收藏" DataNavigateUrlFormatString="newCreate.aspx?id={0}">
                </asp:HyperLinkColumn>
                <asp:BoundColumn DataField="musicName" HeaderText="歌名">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="singer" HeaderText="歌手">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="album" HeaderText="專輯">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="visitCount" HeaderText="訪問量" SortExpression="visitCount">
                </asp:BoundColumn>
                <asp:BoundColumn DataField="downLoadCount" HeaderText="下載量" SortExpression="downLoadCount">
                </asp:BoundColumn>
            
                <asp:HyperLinkColumn HeaderText="下載" DataNavigateUrlField="id" Text="下載" DataNavigateUrlFormatString="downLoadList.aspx?id={0}">
                </asp:HyperLinkColumn>
            </Columns>
        </asp:DataGrid>
        <asp:Label ID="msg" runat="server" Text="" style="color:red;"></asp:Label>
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
