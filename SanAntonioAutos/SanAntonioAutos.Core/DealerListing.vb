Public Class DealerListing
#Region "Private Members"
    Private _AskingPrice As Decimal
    Private _VehicleInfo As VehicleInformation
#End Region

#Region "Properties"
    Public Property AskingPrice As Decimal
        Get
            Return Me._AskingPrice
        End Get
        Friend Set(ByVal value As Decimal)
            Me._AskingPrice = value
        End Set
    End Property

    Public ReadOnly Property Vehicle As VehicleInformation
        Get
            Return Me._VehicleInfo
        End Get
    End Property
#End Region

#Region "Public Methods"
#Region "Initialization / Cleanup"
    Public Sub New()
        Me._AskingPrice = 0D
        Me._VehicleInfo = Nothing
    End Sub

    Public Sub New(ByVal vehicleInfo As VehicleInformation, ByVal askingPrice As Decimal)
        Me._AskingPrice = askingPrice
        Me._VehicleInfo = New VehicleInformation(vehicleInfo)
    End Sub
#End Region
#End Region
End Class