<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="ScanBarcode.aspx.cs" Inherits="KantinASP.Pages.Kantin.ScanBarcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Scan Barcode | PT Khoirul Mustofa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content" class="span10">
                <ul class="breadcrumb">
                    <li><i class="icon-home"></i><a href="#">Home</a> <i class="icon-angle-right"></i>
                    </li>
                    <li><i class="icon-edit"></i><a href="#">
                        HHHHHH</a> </li>
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
                                <div class="control-group">
                                    <h1>
                                        Scan Your Barcode In Here : <span>
                                            <asp:TextBox ID="txtNik" runat="server" placeholder="Barcode" class="input-xlarge"></asp:TextBox></span>
                                        <span>
                                            <asp:Button ID="btnSearchNik" runat="server" class="btn btn-sm btn-warning" Text="Search"
                                                OnClick="btnSearchNik_Click" /></span>
                                    </h1>
                                </div>
                                <hr />
                                <div class="span3">
                                    <asp:Image ID="Image1" runat="server" class="grayscale" Height="200px" Width="180px"
                                        ImageUrl="~/Images/profile-pic.jpg" />
                                </div>
                                <div class="span7 noMarginLeft">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">
                                                NIK</label>
                                            <div class="controls">
                                                <asp:Label ID="lblNik" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                User Name</label>
                                            <div class="controls">
                                                <asp:Label ID="lblNameEmployee" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                Department</label>
                                            <div class="controls">
                                                <asp:Label ID="lblDepartmentEmployee" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                Scan In</label>
                                            <div class="controls">
                                                <asp:Label ID="lblScan" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                Status</label>
                                            <div class="controls">
                                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
