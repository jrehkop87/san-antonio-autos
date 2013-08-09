<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SAAutos.Master" CodeBehind="Home.aspx.vb" Inherits="SAAutos.WebApp.Home" %>

<%@ Register Src="~/Controls/VehicleInfoDisplay.ascx" TagPrefix="SAAutos" TagName="VehicleInfoDisplay" %>

<asp:Content id="Content1" runat="server" ContentPlaceHolderID="cph_MainPageContent">
    <div style="padding-left: 224px;">
        <asp:Panel id="pnl_VehicleList" runat="server"></asp:Panel>
    </div>
</asp:Content>