<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPages/Main.Master"
    AutoEventWireup="true" CodeBehind="ReportEmployeeNotDiscipline.aspx.cs" Inherits="KantinASP.Pages.Report.ReportEmployeeNotDiscipline" %>

<%@ register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Report Employee | PT Khoirul Mustofa</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content" class="span10">
                <ul class="breadcrumb">
                    <li><i class="icon-home"></i><a href="#">Home</a> <i class="icon-angle-right"></i>
                    </li>
                    <li><i class="icon-edit"></i><a href="#">HHHHHH</a> </li>
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
                                        Start Date &nbsp
                                        <asp:TextBox ID="txtStartDate" CssClass="input-xlarge datepicker" runat="server"
                                            formatDate="yyyy-MM-hh"></asp:TextBox>
                                        &nbsp End Date&nbsp
                                        <asp:TextBox ID="txtEndDate" CssClass="input-xlarge datepicker" runat="server"></asp:TextBox>
                                        &nbsp<asp:Button ID="btnProcess" CssClass="btn btn-primary" runat="server" Text="Process"
                                            OnClick="btnProcess_Click" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <rsweb:ReportViewer ID="rvEmpleyeeNotDiscipline" CssClass="span12" runat="server"
                            Height="1000px" Width="100%" Font-Names="Segoe UI Light" Font-Size="8pt">
                        </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
