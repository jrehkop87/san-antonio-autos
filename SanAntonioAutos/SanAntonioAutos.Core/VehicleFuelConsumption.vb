Imports System
Imports System.Runtime.CompilerServices

'Required for the unit testing solution to pick up "Friend" methods
<Assembly: InternalsVisibleTo("SanAntonioAutos.Core.Testing")> 

Public Class VehicleFuelConsumption
#Region "Private Members"
    Private _CityRating As Decimal
    Private _HighwayRating As Decimal
    Private _ConsumptionUnit As VehicleFuelConsumptionUnit
#End Region

#Region "Properties"
#Region "Class Properties"
    Private Shared ReadOnly Property ImperialGallonsPerUsGallon As Decimal
        Get
            Return 0.832674D
        End Get
    End Property

    Private Shared ReadOnly Property MaxDecimalPrecision As Integer
        Get
            Return 2
        End Get
    End Property

    Private Shared ReadOnly Property UsGallonsPerImperialGallon As Decimal
        Get
            Return 1.200950D
        End Get
    End Property
#End Region

#Region "Instance Properties"
    Public Property CityRating As Decimal
        Get
            Return Me._CityRating
        End Get
        Friend Set(ByVal value As Decimal)
            Me._CityRating = Math.Round(value, VehicleFuelConsumption.MaxDecimalPrecision)
        End Set
    End Property

    Public Property ConsumptionUnit As VehicleFuelConsumptionUnit
        Get
            Return Me._ConsumptionUnit
        End Get
        Set(ByVal value As VehicleFuelConsumptionUnit)
            Me.ConvertRatingsToNewUnit(Me._ConsumptionUnit, value)
            Me._ConsumptionUnit = value
        End Set
    End Property

    Public Property HighwayRating As Decimal
        Get
            Return Me._HighwayRating
        End Get
        Friend Set(ByVal value As Decimal)
            Me._HighwayRating = Math.Round(value, VehicleFuelConsumption.MaxDecimalPrecision)
        End Set
    End Property
#End Region
#End Region

#Region "Operators"
    Public Shared Operator =(ByVal lhs As VehicleFuelConsumption, ByVal rhs As VehicleFuelConsumption) As Boolean
        Return lhs.Equals(rhs)
    End Operator

    Public Shared Operator <>(ByVal lhs As VehicleFuelConsumption, ByVal rhs As VehicleFuelConsumption) As Boolean
        Return Not lhs.Equals(rhs)
    End Operator
#End Region

#Region "Public Methods"
#Region "Initialization / Cleanup"
    Public Sub New()
        Me.New(0D, 0D, VehicleFuelConsumptionUnit.MilesPerGallon_USGallons)
    End Sub

    Public Sub New(ByVal copy As VehicleFuelConsumption)
        Me.New(copy.CityRating, copy.HighwayRating, copy.ConsumptionUnit)
    End Sub

    Public Sub New(ByVal cityRating As Decimal, ByVal highwayRating As Decimal, ByVal units As VehicleFuelConsumptionUnit)
        Me._CityRating = cityRating
        Me._HighwayRating = highwayRating
        Me._ConsumptionUnit = units
    End Sub
#End Region

#Region "Overrides"
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim areEqual As Boolean = False
        If TypeOf(obj) Is VehicleFuelConsumption
            Dim castedObj As VehicleFuelConsumption = DirectCast(obj, VehicleFuelConsumption)
            areEqual = (
                Me.CityRating = castedObj.CityRating AndAlso
                Me.HighwayRating = castedObj.HighwayRating AndAlso
                Me.ConsumptionUnit = castedObj.ConsumptionUnit
            )
        End If
        Return areEqual
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return (
            Me.CityRating.ToString() &
            Me.HighwayRating.ToString() &
            Me.ConsumptionUnit.ToString()
        ).GetHashCode()
    End Function
#End Region
#End Region

#Region "Private Methods"
    Private Sub ConvertRatingsToNewUnit(ByVal fromUnit As VehicleFuelConsumptionUnit, ByVal toUnit As VehicleFuelConsumptionUnit)
        Select Case fromUnit
            Case VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons
                Select Case toUnit
                    '*FROM* MPG Imperial *TO* MPG Imperial
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons
                        Me._CityRating = Me._CityRating
                        Me._HighwayRating = Me._HighwayRating

                    '*FROM* MPG Imperial *TO* MPG US
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGImperial_To_MPGUS(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGImperial_To_MPGUS(Me._HighwayRating)

                    '*FROM* MPG Imperial *TO* Km/L
                    Case VehicleFuelConsumptionUnit.KilometersPerLiter
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGImperial_To_KmPerLiter(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGImperial_To_KmPerLiter(Me._HighwayRating)

                    '*FROM* MPG Imperial *TO* L/100Km
                    Case VehicleFuelConsumptionUnit.LitersPer100Kilometers
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGImperial_To_LiterPer100Km(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGImperial_To_LiterPer100Km(Me._HighwayRating)

                    Case Else
                        Throw New Exception("Unknown VehicleFuelConsumptionUnit")

                End Select

            Case VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
                Select Case toUnit
                    '*FROM* MPG US *TO* MPG Imperial
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGUS_To_MPGImperial(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGUS_To_MPGImperial(Me._HighwayRating)

                    '*FROM* MPG US *TO* MPG US
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
                        Me._CityRating = Me._CityRating
                        Me._HighwayRating = Me._HighwayRating

                    '*FROM* MPG US *TO* Km/L
                    Case VehicleFuelConsumptionUnit.KilometersPerLiter
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGUS_To_KmPerLiter(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGUS_To_KmPerLiter(Me._HighwayRating)

                    '*FROM* MPG US *TO* L/100Km
                    Case VehicleFuelConsumptionUnit.LitersPer100Kilometers
                        Me._CityRating = VehicleFuelConsumption.Convert_MPGUS_To_LiterPer100Km(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_MPGUS_To_LiterPer100Km(Me._HighwayRating)

                    Case Else
                        Throw New Exception("Unknown VehicleFuelConsumptionUnit")

                End Select
            Case VehicleFuelConsumptionUnit.KilometersPerLiter
                Select Case toUnit
                    '*FROM* Km/L *TO* MPG Imperial
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_KmPerLiter_To_MPGImperial(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_KmPerLiter_To_MPGImperial(Me._HighwayRating)

                    '*FROM* Km/L *TO* MPG US
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_KmPerLiter_To_MPGUS(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_KmPerLiter_To_MPGUS(Me._HighwayRating)

                    '*FROM* Km/L *TO* Km/L
                    Case VehicleFuelConsumptionUnit.KilometersPerLiter
                        Me._CityRating = Me._CityRating
                        Me._HighwayRating = Me._HighwayRating

                    '*FROM* Km/L *TO* L/100Km
                    Case VehicleFuelConsumptionUnit.LitersPer100Kilometers
                        Me._CityRating = VehicleFuelConsumption.Convert_KmPerLiter_To_LiterPer100Km(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_KmPerLiter_To_LiterPer100Km(Me._HighwayRating)

                    Case Else
                        Throw New Exception("Unknown VehicleFuelConsumptionUnit")

                End Select

            Case VehicleFuelConsumptionUnit.LitersPer100Kilometers
                Select Case toUnit
                    '*FROM* L/100Km *TO* MGP Imperial
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_MPGImperial(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_MPGImperial(Me._HighwayRating)

                    '*FROM* L/100Km *TO* MGP US
                    Case VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
                        Me._CityRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_MPGUS(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_MPGUS(Me._HighwayRating)

                    '*FROM* L/100Km *TO* Km/L
                    Case VehicleFuelConsumptionUnit.KilometersPerLiter
                        Me._CityRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_KmPerLiter(Me._CityRating)
                        Me._HighwayRating = VehicleFuelConsumption.Convert_LiterPer100Km_To_KmPerLiter(Me._HighwayRating)

                    '*FROM* L/100Km *TO* L/100Km
                    Case VehicleFuelConsumptionUnit.LitersPer100Kilometers
                        Me._CityRating = Me._CityRating
                        Me._HighwayRating = Me._HighwayRating

                    Case Else
                        Throw New Exception("Unknown VehicleFuelConsumptionUnit")

                End Select

            Case Else
                Throw New Exception("Unknown VehicleFuelConsumptionUnit")

        End Select
    End Sub
#End Region

#Region "Converter Methods"
#Region "MPG Imperial To Other Unit"
    Private Shared Function Convert_MPGImperial_To_MPGUS(ByVal value As Decimal) As Decimal
        Return Math.Round(value * VehicleFuelConsumption.ImperialGallonsPerUsGallon, VehicleFuelConsumption.MaxDecimalPrecision)
    End Function

    Private Shared Function Convert_MPGImperial_To_KmPerLiter(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_MPGImperial_To_KmPerLiter Not Implemented")
    End Function

    Private Shared Function Convert_MPGImperial_To_LiterPer100Km(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_MPGImperial_To_LiterPer100Km Not Implemented")
    End Function
#End Region

#Region "MPG US To Other Unit"
    Private Shared Function Convert_MPGUS_To_MPGImperial(ByVal value As Decimal) As Decimal
        Return Math.Round(value * VehicleFuelConsumption.UsGallonsPerImperialGallon, VehicleFuelConsumption.MaxDecimalPrecision)
    End Function

    Private Shared Function Convert_MPGUS_To_KmPerLiter(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_MPGUS_To_KmPerLiter Not Implemented")
    End Function

    Private Shared Function Convert_MPGUS_To_LiterPer100Km(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_MPGUS_To_LiterPer100Km Not Implemented")
    End Function
#End Region

#Region "Km/L To Other Unit"
    Private Shared Function Convert_KmPerLiter_To_MPGImperial(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_KmPerLiter_To_MPGImperial Not Implemented")
    End Function

    Private Shared Function Convert_KmPerLiter_To_MPGUS(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_KmPerLiter_To_MPGUS Not Implemented")
    End Function

    Private Shared Function Convert_KmPerLiter_To_LiterPer100Km(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_KmPerLiter_To_LiterPer100Km Not Implemented")
    End Function
#End Region

#Region "L/100Km To Other Unit"
    Private Shared Function Convert_LiterPer100Km_To_MPGImperial(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_LiterPer100Km_To_MPGImperial Not Implemented")
    End Function

    Private Shared Function Convert_LiterPer100Km_To_MPGUS(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_LiterPer100Km_To_MPGUS Not Implemented")
    End Function

    Private Shared Function Convert_LiterPer100Km_To_KmPerLiter(ByVal value As Decimal) As Decimal
        Throw New NotImplementedException("Convert_LiterPer100Km_To_KmPerLiter Not Implemented")
    End Function
#End Region
#End Region
End Class