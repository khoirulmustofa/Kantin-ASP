<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="EmployeDetail.aspx.cs" Inherits="KantinASP.Pages.Master.EmployeDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Employee | PT Khoirul Mustofa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPreview" />
        </Triggers>
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
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">
                                            NIK
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNik" runat="server" CssClass=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Name Employee
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNameEmployee" runat="server" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Department Employee
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtDepartmentEmployee" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Photo
                                        </label>
                                        <div class="controls">
                                            <asp:Image ID="imgPhotoEmployee" runat="server" class="editable img-responsive" Height="200px"
                                                Width="180px" />
                                            <br />
                                            <asp:FileUpload ID="FileUpload_Photo" runat="server" />
                                            <br />
                                            <asp:Button ID="btnPreview" runat="server" Text="Upload" CssClass="btn btn-info"
                                                OnClick="btnPreview_Click" />
                                            &nbsp;<asp:Label ID="lblNamePhoto" CssClass="ace-icon fa fa-check bigger-110 green"
                                                runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnSave_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn" Text="Cancel"
                                            OnClientClick="history.back();" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <!--/span-->
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
