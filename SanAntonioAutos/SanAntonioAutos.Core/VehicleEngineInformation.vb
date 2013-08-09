Imports System.Runtime.CompilerServices

'Required for the unit testing solution to pick up "Friend" methods
<Assembly: InternalsVisibleTo("SanAntonioAutos.Core.Testing")> 

Public Class VehicleEngineInformation
#Region "Private Members"
    Private _CylinderCount As Integer
    Private _Displacement As Decimal
    Private _DisplacementUnit As VehicleEngineDisplacementUnit
    Private _FuelType As VehicleEngineFuelType
#End Region

#Region "Properties"
#Region "Class Properties"
    Private Shared ReadOnly Property CubicInchesPerLiter As Decimal
        Get
            Return 61.023744D
        End Get
    End Property

    Private Shared ReadOnly Property LitersPerCubicInch As Decimal
        Get
            Return 0.016387D
        End Get
    End Property

    Private Shared ReadOnly Property MaxDecimalPrecision As Integer
        Get
            Return 2
        End Get
    End Property
#End Region

#Region "Instance Properties"
    Public Property CylinderCount As Integer
        Get
            Return Me._CylinderCount
        End Get
        Friend Set(ByVal value As Integer)
            Me._CylinderCount = value
        End Set
    End Property

    Public Property Displacement As Decimal
        Get
            Return Me._Displacement
        End Get
        Friend Set(ByVal value As Decimal)
            Me._Displacement = value
        End Set
    End Property

    Public Property DisplacementUnit As VehicleEngineDisplacementUnit
        Get
            Return Me._DisplacementUnit
        End Get
        Friend Set(ByVal value As VehicleEngineDisplacementUnit)
            Me.ConvertDisplacementToNewUnit(Me._DisplacementUnit, value)
            Me._DisplacementUnit = value
        End Set
    End Property

    Public Property FuelType As VehicleEngineFuelType
        Get
            Return Me._FuelType
        End Get
        Friend Set(ByVal value As VehicleEngineFuelType)
            Me._FuelType = value
        End Set
    End Property
#End Region
#End Region

#Region "Operators"
    Public Shared Operator =(ByVal lhs As VehicleEngineInformation, ByVal rhs As VehicleEngineInformation) As Boolean
        Return lhs.Equals(rhs)
    End Operator

    Public Shared Operator <>(ByVal lhs As VehicleEngineInformation, ByVal rhs As VehicleEngineInformation) As Boolean
        Return Not lhs.Equals(rhs)
    End Operator
#End Region

#Region "Public Methods"
#Region "Initialization / Cleanup"
    Public Sub New()
        Me.New(0, 0D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
    End Sub

    Public Sub New(ByVal copy As VehicleEngineInformation)
        Me.New(copy.CylinderCount, copy.Displacement, copy.DisplacementUnit, copy.FuelType)
    End Sub

    Public Sub New(ByVal cylinderCount As Integer, ByVal displacement As Decimal, ByVal fuelType As VehicleEngineFuelType)
        Me.New(cylinderCount, displacement, VehicleEngineDisplacementUnit.Liters, fuelType)
    End Sub

    Public Sub New(ByVal cylinderCount As Integer, ByVal displacement As Decimal, ByVal displacementUnit As VehicleEngineDisplacementUnit, ByVal fuelType As VehicleEngineFuelType)
        Me._CylinderCount = cylinderCount
        Me._Displacement = displacement
        Me._DisplacementUnit = displacementUnit
        Me._FuelType = fuelType
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim areEqual As Boolean = False
        If TypeOf(obj) Is VehicleEngineInformation
            Dim castedObj As VehicleEngineInformation = DirectCast(obj, VehicleEngineInformation)
            areEqual = (
                Me.CylinderCount = castedObj.CylinderCount AndAlso
                Me.Displacement = castedObj.Displacement AndAlso
                Me.DisplacementUnit = castedObj.DisplacementUnit AndAlso
                Me.FuelType = castedObj.FuelType
            )
        End If
        Return areEqual
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (
            Me.CylinderCount.ToString() &
            Me.Displacement.ToString() &
            Me.DisplacementUnit.ToString() &
            Me.FuelType.ToString()
        ).GetHashCode()
    End Function

    Public Overrides Function ToString() As String
        Dim fuelTypeString As String = String.Empty
        Select Case Me.FuelType
            Case VehicleEngineFuelType.Diesel
                fuelTypeString = "Diesel"

            Case VehicleEngineFuelType.Gasoline
                fuelTypeString = "Gas"

            Case VehicleEngineFuelType.Unknown
                fuelTypeString = "Unknown"
        End Select

        Dim arrangementString As String = String.Format("V{0}", Me.CylinderCount)

        Dim displacementString As String = String.Empty
        Select Case Me.DisplacementUnit
            Case VehicleEngineDisplacementUnit.CubicInches
                displacementString = String.Format("{0} {1}", Math.Round(Me.Displacement).ToString(), "cubic inches")

            Case VehicleEngineDisplacementUnit.Liters
                displacementString = String.Format("{0}L", Me.Displacement.ToString("0.0"))
        End Select

        Return String.Format("{0} {1} {2}", fuelTypeString, arrangementString, displacementString)
    End Function
#End Region
#End Region

#Region "Private Methods"
    Private Sub ConvertDisplacementToNewUnit(ByVal fromUnit As VehicleEngineDisplacementUnit, ByVal toUnit As VehicleEngineDisplacementUnit)
        Select Case fromUnit
            Case VehicleEngineDisplacementUnit.CubicInches
                Select Case toUnit
                    '*FROM* Cubic Inches *TO* Cubic Inches
                    Case VehicleEngineDisplacementUnit.CubicInches
                        Me._Displacement = Me._Displacement

                    '*FROM* Cubic Inches *TO* Liters
                    Case VehicleEngineDisplacementUnit.Liters
                        Me._Displacement = VehicleEngineInformation.Convert_CubicInches_To_Liters(Me._Displacement)

                    Case Else
                        Throw New Exception("Unknown VehicleEngineDisplacementUnit")

                End Select

            Case VehicleEngineDisplacementUnit.Liters
                Select Case toUnit
                    '*FROM* Liters *TO* Cubic Inches
                    Case VehicleEngineDisplacementUnit.CubicInches
                        Me._Displacement = VehicleEngineInformation.Convert_Liters_To_CubicInches(Me._Displacement)

                    '*FROM* Liters *TO* Liters
                    Case VehicleEngineDisplacementUnit.Liters
                        Me._Displacement = Me._Displacement

                    Case Else
                        Throw New Exception("Unknown VehicleEngineDisplacementUnit")

                End Select

            Case Else
                Throw New Exception("Unknown VehicleFuelConsumptionUnit")

        End Select
    End Sub
#End Region

#Region "Converter Methods"
#Region "Cubic Inches To Other Unit"
    Private Shared Function Convert_CubicInches_To_Liters(ByVal value As Decimal) As Decimal
        Return Math.Round(value * VehicleEngineInformation.LitersPerCubicInch, VehicleEngineInformation.MaxDecimalPrecision)
    End Function
#End Region

#Region "Liters To Other Unit"
    Private Shared Function Convert_Liters_To_CubicInches(ByVal value As Decimal) As Decimal
        Return Math.Round(value * VehicleEngineInformation.CubicInchesPerLiter, VehicleEngineInformation.MaxDecimalPrecision)
    End Function
#End Region
#End Region
End Class