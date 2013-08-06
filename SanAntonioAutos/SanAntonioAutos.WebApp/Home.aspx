<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/SAAutos.Master" CodeBehind="Home.aspx.vb" Inherits="SAAutos.WebApp.Home" %>

<%@ Register Src="~/Controls/VehicleInfo.ascx" TagPrefix="SAAutos" TagName="VehicleInfo" %>

<asp:Content id="Content1" ContentPlaceHolderID="cph_MainPageContent" runat="server">
    <div style="padding-left: 224px;">
        <SAAutos:VehicleInfo runat="server"></SAAutos:VehicleInfo><br />
        <SAAutos:VehicleInfo runat="server"></SAAutos:VehicleInfo>
    </div>
</asp:Content>