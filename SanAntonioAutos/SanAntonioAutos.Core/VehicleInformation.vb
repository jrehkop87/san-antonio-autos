Public Class VehicleInformation
#Region "Private Members"
    Private _Make As String
    Private _Model As String
    Private _Year As Integer
    Private _VIN As String
#End Region

#Region "Properties"
    Public Property Make As String
        Get
            Return Me._Make
        End Get
        Friend Set(ByVal value As String)
            Me._Make = String.Copy(value)
        End Set
    End Property
#End Region

#Region "Public Methods"
#Region "Initialization / Cleanup"

#End Region
#End Region
End Class