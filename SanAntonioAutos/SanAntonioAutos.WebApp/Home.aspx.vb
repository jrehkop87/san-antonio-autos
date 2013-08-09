Imports SAAutos.Core
Imports SAAutos.Core.WebParsers

Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim nsfordParser As IDealershipWebParser = New SanAntonio_NorthSideFord_WebParser()
        Dim vehicleListings As List(Of DealerListing) = nsfordParser.GetCurrentInventory()

        For Each listing As DealerListing In vehicleListings
            pnl_VehicleList.Controls.Add(VehicleInfoDisplay.BuildVehicleInfoDisplay(listing, Me))
        Next  
    End Sub
End Class