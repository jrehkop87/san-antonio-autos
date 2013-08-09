Imports SAAutos.Core

Public Class VehicleInfoDisplay
    Inherits UserControl

#Region "Properties"
    Public Property CityEconomy As String
        Get
            Return Me.spn_CityEconomy.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_CityEconomy.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property Engine As String
        Get
            Return Me.spn_Engine.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_Engine.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property ExteriorColor As String
        Get
            Return Me.spn_ExtColor.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_ExtColor.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property Heading As String
        Get
            Return Me.spn_Heading.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_Heading.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property HighwayEconomy As String
        Get
            Return Me.spn_HwyEconomy.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_HwyEconomy.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property InteriorColor As String
        Get
            Return Me.spn_IntColor.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_IntColor.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property Mileage As String
        Get
            Return Me.spn_Mileage.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_Mileage.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property Price As String
        Get
            Return Me.spn_Price.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_Price.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property ThumbnailUrl As String
        Get
            Return Me.img_Thumbnail.Attributes("src")
        End Get
        Set(ByVal value As String)
            Me.img_Thumbnail.Attributes("src") = String.Copy(value)
        End Set
    End Property

    Public Property Transmission As String
        Get
            Return Me.spn_Trans.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_Trans.InnerText = String.Copy(value)
        End Set
    End Property

    Public Property VIN As String
        Get
            Return Me.spn_VIN.InnerText
        End Get
        Set(ByVal value As String)
            Me.spn_VIN.InnerText = String.Copy(value)
        End Set
    End Property
#End Region

#Region "Control Methods"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub
#End Region

#Region "Public Methods"
    Public Shared Function BuildVehicleInfoDisplay(ByVal listing As DealerListing, ByVal page As Page) As VehicleInfoDisplay
        Dim newVehicleInfoDisplay As VehicleInfoDisplay = DirectCast(page.LoadControl("~/Controls/VehicleInfoDisplay.ascx"), VehicleInfoDisplay)

        newVehicleInfoDisplay.CityEconomy = CInt(listing.Vehicle.FuelConsumption.CityRating).ToString()
        newVehicleInfoDisplay.Engine = listing.Vehicle.Engine.ToString()
        newVehicleInfoDisplay.ExteriorColor = listing.Vehicle.ExteriorColor
        newVehicleInfoDisplay.Heading = String.Format("{0} {1} {2}", listing.Vehicle.Year, listing.Vehicle.Make, listing.Vehicle.Model)
        newVehicleInfoDisplay.HighwayEconomy = CInt(listing.Vehicle.FuelConsumption.HighwayRating).ToString()
        newVehicleInfoDisplay.InteriorColor = listing.Vehicle.InteriorColor
        newVehicleInfoDisplay.Mileage = listing.Vehicle.Mileage.ToString("#,#")
        newVehicleInfoDisplay.Price = listing.AskingPrice.ToString("C")
        newVehicleInfoDisplay.ThumbnailUrl = listing.ThumbnailUrl
        newVehicleInfoDisplay.Transmission = listing.Vehicle.TransmissionType.ToString()
        newVehicleInfoDisplay.VIN = listing.Vehicle.VIN

        Return newVehicleInfoDisplay
    End Function
#End Region
End Class