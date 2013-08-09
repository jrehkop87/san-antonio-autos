<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VehicleInfoDisplay.ascx.vb" Inherits="SAAutos.WebApp.VehicleInfoDisplay" %>

<div id="div_VehicleInfo" class="vid_Container">
    <div id="div_Heading" class="vid_Heading">
        <span id="spn_Heading"  runat="server" class="vid_HeadingText">2009 Acura TL - Northside Ford</span>
    </div>

    <div id="div_Vehicle">
        <div class="vid_ThumbnailContainer">
            <img id="img_Thumbnail" runat="server" alt="" src="" class="vid_Thumbnail" />
        </div>

        <div id="div_Specs" class="vid_SpecsContainer">
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">Engine:</span><span id="spn_Engine" runat="server"></span></span><br />
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">Transmission:</span><span id="spn_Trans" runat="server"></span></span><br />
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">Miles: </span><span id="spn_Mileage" runat="server"></span></span><br />
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">Exterior Color:</span><span id="spn_ExtColor" runat="server"></span></span><br />
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">Interior Color:</span><span id="spn_IntColor" runat="server"></span></span><br />
            <span class="vid_SpecsEntry"><span class="vid_SpecsEntryName">VIN #:</span><span id="spn_VIN" runat="server"></span></span><br />
        </div>

        <div id="div_PriceAndEconomy" style="height: 180px; position: relative; top: -360px; left: 560px; width: 240px;">
            <div id="div_Price" style="padding-bottom: 12px; text-align: center;">
                <span id="spn_Price" runat="server" style="font-size: 1.5em;">$22,540</span>
            </div>

            <div id="div_Economy" style="text-align: center;">
                <span>Fuel Economy</span><br />

                <span style="font-size: 1em; position: absolute; left: 8px; top: 75px;">City MPG</span>
                <span id="spn_CityEconomy" runat="server" style="font-size: 2em; position: absolute; left: 20px; top: 105px;">18</span>

                <span style="font-size: 1em; position: absolute; right: 6px; top: 75px;">Hwy MPG</span>
                <span id="spn_HwyEconomy" runat="server" style="font-size: 2em; position: absolute; right: 20px; top: 105px;">26</span>

                <img alt="" src="../Media/Images/Fuel_Pump.png" style="margin-left: 85px; margin-right: 85px; position:relative; width: 70px;" />
            </div>
        </div>
    </div>
</div>