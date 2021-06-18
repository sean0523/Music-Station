<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="musicChange.aspx.cs" Inherits="Music_Station.musicChange" %>
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
    <h1 style="color:white;">歌曲曲目清單</h1>
    <div id="musicchange">
        <asp:DataGrid ID="dg" CssClass="dg" AutoGenerateColumns="False" AllowPaging="True" style="background-color:white;" PagerStyle-NextPageText="下一頁"  PagerStyle-PrevPageText="上一頁"
            OnPageIndexChanged="dg_PageIndexChanged" runat="server" PageSize="15" 
            OnDeleteCommand="dg_DeleteCommand"  DataKeyField ="id" Width="796px">
            <Columns>
                <asp:HyperLinkColumn HeaderText ="修改" DataNavigateUrlField="id" DataNavigateUrlFormatString="~/musicChange_edit.aspx?id={0}" NavigateUrl="~/musicChange_edit.aspx" Text="修改"> 
                </asp:HyperLinkColumn>
                <asp:ButtonColumn CommandName="Delete" Text="删除" HeaderText="删除">
                </asp:ButtonColumn>
                <asp:BoundColumn DataField="musicName" HeaderText="歌名"></asp:BoundColumn>
                <asp:BoundColumn DataField="singer" HeaderText="歌手"></asp:BoundColumn>
                <asp:BoundColumn DataField="album" HeaderText="專輯"></asp:BoundColumn>
                <asp:TemplateColumn HeaderText="類型">
                    <ItemTemplate>
                        <asp:Label ID="typelabel" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "type") %>'></asp:Label></ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="typelist" runat="server" SelectedIndex='<%# gettype(DataBinder.Eval(Container.DataItem, "type").ToString()) %>'>
                        <asp:ListItem>中港台</asp:ListItem>
                        <asp:ListItem>日韓</asp:ListItem>
                        <asp:ListItem>歐美</asp:ListItem>
                        <asp:ListItem>鄉村</asp:ListItem>
                        <asp:ListItem>卡通</asp:ListItem>
                        <asp:ListItem>歌劇</asp:ListItem>
                        <asp:ListItem>其它</asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateColumn>
            </Columns>

<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
        </asp:DataGrid>
    </div>
    <div>
        <asp:Label ID="msg" runat="server" style="color:white;"></asp:Label>
        <br/><br/>
        <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" Width="100px" />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
</asp:Content>
