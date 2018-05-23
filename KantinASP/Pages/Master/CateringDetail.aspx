<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="CateringDetail.aspx.cs" Inherits="KantinASP.Pages.Master.CateringDetail" %>

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
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Id Catering
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtIdCatering" runat="server" CssClass="span3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Name Catering
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtNameCatering" runat="server" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Telp Catering
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtTelpCatering" runat="server" CssClass="span3"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Address Catering
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtAddressCatering" runat="server" CssClass="span6"
                                                TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Email Catering
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtEmailCatering" runat="server" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-actions">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click" />
                                        &nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-inverse" Text="Cancel"
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
