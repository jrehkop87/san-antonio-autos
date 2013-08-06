<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="VehicleInfo.ascx.vb" Inherits="SAAutos.WebApp.VehicleInfo" %>

<div id="div_VehicleInfo" style="height: 224px; width: 800px;">
    <div id="div_VehicleName" style="padding-bottom: 6px; width: 100%;">
        <span style="font-size: 1.5em;">2009 Acura TL - Northside Ford</span>
    </div>

    <div id="div_Vehicle">
        <div style="max-width: 240px; width: 240px;">
            <img alt="" src="../Media/Images/TestCarImg.jpg" style="width: 100%;" />
        </div>

        <div id="div_Specs" style="height: 180px; position: relative; left: 252px; top: -180px; width: 296px;">
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">Engine:</span><span>Gas V6 3.5L</span></span><br />
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">Transmission:</span><span>Automatic</span></span><br />
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">Miles: </span><span>75,450</span></span><br />
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">Exterior Color:</span><span>Gray</span></span><br />
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">Interior Color:</span><span>Not Available</span></span><br />
            <span style="display: inline-block; padding-bottom: 6px;"><span style="font-weight: bold; padding-right: 6px;">VIN #:</span><span>19UUA86589A012003</span></span><br />
        </div>

        <div id="div_PriceAndEconomy" style="height: 180px; position: relative; top: -360px; left: 560px; width: 240px;">
            <div id="div_Price" style="padding-bottom: 12px; text-align: center;">
                <span style="font-size: 1.5em;">Asking: $22,540</span>
            </div>

            <div id="div_Economy" style="text-align: center;">
                <span>Fuel Economy</span><br />

                <span style="font-size: 1em; position: absolute; left: 8px; top: 75px;">City MPG</span>
                <span style="font-size: 2em; position: absolute; left: 20px; top: 105px;">18</span>

                <span style="font-size: 1em; position: absolute; right: 6px; top: 75px;">Hwy MPG</span>
                <span style="font-size: 2em; position: absolute; right: 20px; top: 105px;">26</span>

                <img alt="" src="../Media/Images/Fuel_Pump.png" style="margin-left: 85px; margin-right: 85px; position:relative; width: 70px;" />
            </div>
        </div>
    </div>
</div>