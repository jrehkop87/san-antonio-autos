Imports System.Runtime.CompilerServices

'Required so the WebParser project can access the property setters
<Assembly: InternalsVisibleTo("SanAntonioAutos.Core.WebParsers")> 

Public Class VehicleInformation
#Region "Private Members"
    Private _BodyStyle As VehicleBodyStyle
    Private _Engine As VehicleEngineInformation
    Private _ExteriorColor As String
    Private _FuelConsumption As VehicleFuelConsumption
    Private _InteriorColor As String
    Private _Make As String
    Private _Model As String
    Private _TransmissionType As VehicleTransmissionType
    Private _VIN As String
    Private _Year As Integer
#End Region

#Region "Properties"
    Public Property BodyStyle As VehicleBodyStyle
        Get
            Return Me._BodyStyle
        End Get
        Friend Set(ByVal value As VehicleBodyStyle)
            Me._BodyStyle = value
        End Set
    End Property

    Public Property Engine As VehicleEngineInformation
        Get
            Return Me._Engine
        End Get
        Friend Set(ByVal value As VehicleEngineInformation)
            Me._Engine = New VehicleEngineInformation(value)
        End Set
    End Property

    Public Property ExteriorColor As String
        Get
            Return Me._ExteriorColor
        End Get
        Friend Set(ByVal value As String)
            Me._ExteriorColor = String.Copy(value)
        End Set
    End Property

    Public Property FuelConsumption As VehicleFuelConsumption
        Get
            Return Me._FuelConsumption
        End Get
        Friend Set(ByVal value As VehicleFuelConsumption)
            Me._FuelConsumption = New VehicleFuelConsumption(value)
        End Set
    End Property

    Public Property InteriorColor As String
        Get
            Return Me._InteriorColor
        End Get
        Friend Set(ByVal value As String)
            Me._InteriorColor = String.Copy(value)
        End Set
    End Property

    Public Property Make As String
        Get
            Return Me._Make
        End Get
        Friend Set(ByVal value As String)
            Me._Make = String.Copy(value)
        End Set
    End Property

    Public Property Model As String
        Get
            Return Me._Model
        End Get
        Friend Set(ByVal value As String)
            Me._Model = String.Copy(value)
        End Set
    End Property

    Public Property TransmissionType As VehicleTransmissionType
        Get
            Return Me._TransmissionType
        End Get
        Friend Set(ByVal value As VehicleTransmissionType)
            Me._TransmissionType = value
        End Set
    End Property

    Public Property VIN As String
        Get
            Return Me._VIN
        End Get
        Friend Set(ByVal value As String)
            Me._VIN = String.Copy(value)
        End Set
    End Property

    Public Property Year As Integer
        Get
            Return Me._Year
        End Get
        Friend Set(ByVal value As Integer)
            Me._Year = value
        End Set
    End Property
#End Region

#Region "Public Methods"
#Region "Initialization / Cleanup"
    Public Sub New()

    End Sub

    Public Sub New(ByVal copy As VehicleInformation)
        Me.BodyStyle = copy.BodyStyle
        Me.Engine = copy.Engine
        Me.ExteriorColor = copy.ExteriorColor
        Me.FuelConsumption = copy.FuelConsumption
        Me.InteriorColor = copy.InteriorColor
        Me.Make = copy.Make
        Me.Model = copy.Model
        Me.TransmissionType = copy.TransmissionType
        Me.VIN = copy.VIN
        Me.Year = copy.Year
    End Sub
#End Region
#End Region
End Class