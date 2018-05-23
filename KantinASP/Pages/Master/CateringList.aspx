<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="CateringList.aspx.cs" Inherits="KantinASP.Pages.Master.CateringList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>Catering | PT Khoirul Mustofa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <div id="content" class="span10">
                <ul class="breadcrumb">
                    <li><i class="icon-home"></i><a href="#">Home</a> <i class="icon-angle-right"></i>
                    </li>
                    <li><i class="icon-edit"></i><a href="#">
                        <asp:Label ID="lblTitleForm" runat="server" Text=""></asp:Label></a> </li>
                </ul>
                <div class="row-fluid sortable">
                    <div class="box span12">
                        <div class="box-header" data-original-title>
                            <h2>
                                <i class="icon-edit"></i><span class="break"></span>Form Elements</h2>
                            <div class="box-icon">
                                <a href="#" class="btn-setting"><i class="icon-wrench"></i></a><a href="#" class="btn-minimize">
                                    <i class="icon-chevron-up"></i></a>
                            </div>
                        </div>
                        <div class="box-content">
                            <div class="form-horizontal">
                                <div class="form-horizontal">
                                    <fieldset>
                                        <div class="control-group">
                                            <asp:Button ID="btnAddCatering" CssClass="btn btn-sm btn-success" runat="server"
                                                Text="Add New Catering" OnClick="btnAddCatering_Click" />
                                            &nbsp;Criteria &nbsp;
                                            <asp:DropDownList ID="dllCriteria" runat="server" CssClass="col-xs-12 col-sm-12">
                                                <asp:ListItem Value="">-- Chose Criteria --</asp:ListItem>
                                                <asp:ListItem Value="IdCatering">Id Catering</asp:ListItem>
                                                <asp:ListItem Value="NameCatering">Name Catering</asp:ListItem>
                                                <asp:ListItem Value="TelpCatering">Telp Catering</asp:ListItem>
                                                <asp:ListItem Value="AddressCatering">Address Catering</asp:ListItem>
                                                <asp:ListItem Value="EmailCatering">Email Catering</asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;Value&nbsp;
                                            <asp:TextBox ID="txtValue" runat="server" CssClass="col-xs-12 col-sm-12"></asp:TextBox>
                                            &nbsp;
                                            <asp:Button ID="btnSearch" CssClass="btn btn-sm btn-primary" runat="server" Text="Search"
                                                OnClick="btnSearch_Click" />
                                        </div>
                                    </fieldset>
                                </div>
                                <asp:GridView ID="gvCatering" runat="server" CssClass="table table-striped table-bordered table-hover"
                                        AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEditCatering" ToolTip="Edit" OnClick="btnEditCatering_Click"
                                                        CommandArgument='<%# Eval("IdCatering") %>' runat="server" CssClass="btn-info icon-edit"></asp:LinkButton>&nbsp
                                                    <asp:LinkButton ID="btnDeleteCatering" ToolTip="Delete" OnClick="btnDeleteCatering_Click"
                                                        CommandArgument='<%# Eval("IdCatering") %>' OnClientClick="return confirm('Are you sure want to delete this data ?');"
                                                        runat="server" CssClass="btn-danger icon-trash"></asp:LinkButton>
                                                    <headerstyle width="2%" />
                                                    <itemstyle width="2%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="No" DataField="ROW_NUMBER" SortExpression="ROW_NUMBER" />
                                            <asp:BoundField HeaderText="Id Catering" DataField="IdCatering" SortExpression="IdCatering" />
                                            <asp:BoundField HeaderText="Name Catering" DataField="NameCatering" SortExpression="NameCatering" />
                                            <asp:BoundField HeaderText="Telp Catering" DataField="TelpCatering" SortExpression="TelpCatering" />
                                            <asp:BoundField HeaderText="Address Catering" DataField="AddressCatering" SortExpression="AddressCatering" />
                                            <asp:BoundField HeaderText="Email Catering" DataField="EmailCatering" SortExpression="EmailCatering" />
                                        </Columns>
                                    </asp:GridView>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <th>
                                                Total Record
                                                <asp:Label ID="lblTotalRecord" runat="server" Text=""></asp:Label>
                                            </th>
                                            <th style="text-align: right; padding: 5px">
                                                Item Per Page&nbsp;
                                                <asp:DropDownList AutoPostBack="true" ID="dllListPerPage" CssClass="span2" runat="server"
                                                    OnSelectedIndexChanged="dllListPerPage_SelectedIndexChanged">
                                                    <asp:ListItem Selected="True">10</asp:ListItem>
                                                    <asp:ListItem>25</asp:ListItem>
                                                    <asp:ListItem>50</asp:ListItem>
                                                    <asp:ListItem>100</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;Page &nbsp;
                                                <asp:Label ID="lblPage" runat="server" Text=""></asp:Label>
                                                &nbsp;/ &nbsp;<asp:Label ID="lblTotalPage" runat="server" Text=""></asp:Label>
                                                &nbsp;
                                                <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-small btn-primary"
                                                    OnClick="btnPrevious_Click" Text="Previous" />
                                                &nbsp;
                                                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-small btn-primary" Text="Next"
                                                    OnClick="btnNext_Click" />
                                            </th>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                </div>
            </div>
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
