Imports NUnit.Framework
Imports SAAutos.Core

<TestFixture()>
Public Class TestVehicleFuelConsumption
#Region "Test Setup / Teardown"

#End Region

#Region "Tests"
#Region "Constructor Tests"
    <Test()>
    Public Sub TestDefaultConstructor()
        Dim testObject As New VehicleFuelConsumption()

        Assert.AreEqual(0D, testObject.CityRating)
        Assert.AreEqual(0D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_USGallons, testObject.ConsumptionUnit)
    End Sub

    <Test()>
    Public Sub TestCopyConstructor()
        Dim testObject1 As New VehicleFuelConsumption(18.4D, 23D, VehicleFuelConsumptionUnit.KilometersPerLiter)
        Dim testObject2 As New VehicleFuelConsumption(testObject1)

        Assert.AreEqual(18.4D, testObject2.CityRating)
        Assert.AreEqual(23D, testObject2.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.KilometersPerLiter, testObject2.ConsumptionUnit)
    End Sub

    <Test()>
    Public Sub TestThreeParameterConstructor()
        Dim testObject As New VehicleFuelConsumption(15.7D, 21.3D, VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons)

        Assert.AreEqual(15.7D, testObject.CityRating)
        Assert.AreEqual(21.3D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons, testObject.ConsumptionUnit)
    End Sub
#End Region

#Region "Equality Tests"
    <Test()>
    Public Sub TestEqualsMethod()
        Dim testObject1 As New VehicleFuelConsumption(18.4D, 23D, VehicleFuelConsumptionUnit.KilometersPerLiter)
        Dim testObject2 As New VehicleFuelConsumption(testObject1)
        Dim testObject3 As New VehicleFuelConsumption(15.7D, 21.3D, VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons)

        Assert.AreEqual(True, testObject1.Equals(testObject2))
        Assert.AreEqual(False, testObject1.Equals(testObject3))
    End Sub

    <Test()>
    Public Sub TestEqualsOperator()
        Dim testObject1 As New VehicleFuelConsumption(18.4D, 23D, VehicleFuelConsumptionUnit.KilometersPerLiter)
        Dim testObject2 As New VehicleFuelConsumption(testObject1)
        Dim testObject3 As New VehicleFuelConsumption(15.7D, 21.3D, VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons)

        Assert.AreEqual(True, (testObject1 = testObject2))
        Assert.AreEqual(False, (testObject1 = testObject3))
    End Sub
#End Region
#End Region
End Class