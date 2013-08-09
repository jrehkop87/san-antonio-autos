Public Class DealerListing
#Region "Private Members"
    Private _AskingPrice As Decimal
    Private _DetailPageUrl As String
    Private _ThumbnailUrl As String
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

    Public Property DetailPageUrl As String
        Get
            Return Me._DetailPageUrl
        End Get
        Friend Set(ByVal value As String)
            Me._DetailPageUrl = String.Copy(value)
        End Set
    End Property

    Public Property ThumbnailUrl As String
        Get
            Return Me._ThumbnailUrl
        End Get
        Friend Set(ByVal value As String)
            Me._ThumbnailUrl = String.Copy(value)
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
        Me._DetailPageUrl = String.Empty
        Me._ThumbnailUrl = String.Empty
        Me._VehicleInfo = Nothing
    End Sub

    Public Sub New(ByVal vehicleInfo As VehicleInformation, ByVal askingPrice As Decimal)
        Me.New(vehicleInfo, askingPrice, String.Empty, String.Empty)
    End Sub

    Public Sub New(ByVal vehicleInfo As VehicleInformation, ByVal askingPrice As Decimal, ByVal detailPageUrl As String)
        Me.New(vehicleInfo, askingPrice, detailPageUrl, String.Empty)
    End Sub

    Public Sub New(ByVal vehicleInfo As VehicleInformation, ByVal askingPrice As Decimal, ByVal detailPageUrl As String, ByVal thumbnailUrl As String)
        Me._AskingPrice = askingPrice
        Me._DetailPageUrl = String.Copy(detailPageUrl)
        Me._ThumbnailUrl = String.Copy(thumbnailUrl)
        Me._VehicleInfo = New VehicleInformation(vehicleInfo)
    End Sub
#End Region
#End Region
End Class