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

#Region "Property Tests"
#Region "MPG Imperial To Other Unit"
    <Test()>
    Public Sub TestMPGImperialToMPGImperialConversion()
        Dim testObject As New VehicleFuelConsumption(15.7D, 21.3D, VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons)
        testObject.ConsumptionUnit = VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons

        Assert.AreEqual(15.7D, testObject.CityRating)
        Assert.AreEqual(21.3D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons, testObject.ConsumptionUnit)
    End Sub

    <Test()>
    Public Sub TestMPGImperialToMPGUSConversion()
        Dim testObject As New VehicleFuelConsumption(15.7D, 21.3D, VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons)
        testObject.ConsumptionUnit = VehicleFuelConsumptionUnit.MilesPerGallon_USGallons

        Assert.AreEqual(13.07D, testObject.CityRating)
        Assert.AreEqual(17.74D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_USGallons, testObject.ConsumptionUnit)
    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestMPGImperialToKmPerLiterConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestMPGImperialToLitersPer100KmConversion()

    End Sub
#End Region

#Region "MPG US To Other Unit"
    <Test()>
    Public Sub TestMPGUSToMPGImperialConversion()
        Dim testObject As New VehicleFuelConsumption(18.4D, 23D, VehicleFuelConsumptionUnit.MilesPerGallon_USGallons)
        testObject.ConsumptionUnit = VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons

        Assert.AreEqual(22.10D, testObject.CityRating)
        Assert.AreEqual(27.62D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_ImperialGallons, testObject.ConsumptionUnit)
    End Sub

    <Test()>
    Public Sub TestMPGUSToMPGUSConversion()
        Dim testObject As New VehicleFuelConsumption(18.4D, 23D, VehicleFuelConsumptionUnit.MilesPerGallon_USGallons)
        testObject.ConsumptionUnit = VehicleFuelConsumptionUnit.MilesPerGallon_USGallons

        Assert.AreEqual(18.4D, testObject.CityRating)
        Assert.AreEqual(23D, testObject.HighwayRating)
        Assert.AreEqual(VehicleFuelConsumptionUnit.MilesPerGallon_USGallons, testObject.ConsumptionUnit)
    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestMPGUSToKmPerLiterConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestMPGUSToLitersPer100KmConversion()

    End Sub
#End Region

#Region "Km/L To Other Unit"
    <Test(), Ignore("Not implemented")>
    Public Sub TestKmPerLiterToMPGImperialConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestKmPerLiterToMPGUSConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestKmPerLiterToKmPerLiterConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestKmPerLiterToLitersPer100KmConversion()

    End Sub
#End Region

#Region "L/100Km To Other Unit"
    <Test(), Ignore("Not implemented")>
    Public Sub TestLitersPer100KmToMPGImperialConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestLitersPer100KmToMPGUSConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestLitersPer100KmToKmPerLiterConversion()

    End Sub

    <Test(), Ignore("Not implemented")>
    Public Sub TestLitersPer100KmToLitersPer100KmConversion()

    End Sub
#End Region
#End Region
#End Region
End Class