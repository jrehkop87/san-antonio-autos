Imports NUnit.Framework
Imports SAAutos.Core

<TestFixture()>
Public Class TestVehicleEngineInformation
#Region "Test Setup / Teardown"

#End Region

#Region "Tests"
#Region "Constructor Tests"
    <Test()>
    Public Sub TestDefaultConstructor()
        Dim testObject As New VehicleEngineInformation()

        Assert.AreEqual(0, testObject.CylinderCount)
        Assert.AreEqual(0D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.Liters, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub

    <Test()>
    Public Sub TestCopyConstructor()
        Dim testObject1 As New VehicleEngineInformation(8, 5.7D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
        Dim testObject2 As New VehicleEngineInformation(testObject1)

        Assert.AreEqual(8, testObject2.CylinderCount)
        Assert.AreEqual(5.7D, testObject2.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.Liters, testObject2.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject2.FuelType)
    End Sub

    <Test()>
    Public Sub TestThreeParameterConstructor()
        Dim testObject As New VehicleEngineInformation(8, 4.6D, VehicleEngineFuelType.Gasoline)

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(4.6D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.Liters, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub

    <Test()>
    Public Sub TestFourParameterConstructor()
        Dim testObject As New VehicleEngineInformation(8, 302D, VehicleEngineDisplacementUnit.CubicInches, VehicleEngineFuelType.Gasoline)

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(302D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.CubicInches, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub
#End Region

#Region "Equality Tests"
    <Test()>
    Public Sub TestEqualsMethod()
        Dim testObject1 As New VehicleEngineInformation(8, 5.7D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
        Dim testObject2 As New VehicleEngineInformation(testObject1)
        Dim testObject3 As New VehicleEngineInformation(8, 302D, VehicleEngineDisplacementUnit.CubicInches, VehicleEngineFuelType.Gasoline)

        Assert.AreEqual(True, testObject1.Equals(testObject2))
        Assert.AreEqual(False, testObject1.Equals(testObject3))
    End Sub

    <Test()>
    Public Sub TestEqualsOperator()
        Dim testObject1 As New VehicleEngineInformation(8, 5.7D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
        Dim testObject2 As New VehicleEngineInformation(testObject1)
        Dim testObject3 As New VehicleEngineInformation(8, 302D, VehicleEngineDisplacementUnit.CubicInches, VehicleEngineFuelType.Gasoline)

        Assert.AreEqual(True, (testObject1 = testObject2))
        Assert.AreEqual(False, (testObject1 = testObject3))
    End Sub
#End Region

#Region "Property Tests"
#Region "Cubic Inches To Other Unit Conversion Tests"
    <Test()>
    Public Sub TestCubicInchesToCubicInchesConversion()
        Dim testObject As New VehicleEngineInformation(8, 350D, VehicleEngineDisplacementUnit.CubicInches, VehicleEngineFuelType.Gasoline)
        testObject.DisplacementUnit = VehicleEngineDisplacementUnit.CubicInches

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(350D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.CubicInches, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub

    <Test()>
    Public Sub TestCubicInchesToLitersConversion()
        Dim testObject As New VehicleEngineInformation(8, 350D, VehicleEngineDisplacementUnit.CubicInches, VehicleEngineFuelType.Gasoline)
        testObject.DisplacementUnit = VehicleEngineDisplacementUnit.Liters

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(5.74D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.Liters, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub
#End Region

#Region "Liters To Other Unit Conversion Tests"
    <Test()>
    Public Sub TestLitersToCubicInchesConversion()
        Dim testObject As New VehicleEngineInformation(8, 4.6D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
        testObject.DisplacementUnit = VehicleEngineDisplacementUnit.CubicInches

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(280.71D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.CubicInches, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub

    <Test()>
    Public Sub TestLitersToLitersConversion()
        Dim testObject As New VehicleEngineInformation(8, 4.6D, VehicleEngineDisplacementUnit.Liters, VehicleEngineFuelType.Gasoline)
        testObject.DisplacementUnit = VehicleEngineDisplacementUnit.Liters

        Assert.AreEqual(8, testObject.CylinderCount)
        Assert.AreEqual(4.6D, testObject.Displacement)
        Assert.AreEqual(VehicleEngineDisplacementUnit.Liters, testObject.DisplacementUnit)
        Assert.AreEqual(VehicleEngineFuelType.Gasoline, testObject.FuelType)
    End Sub
#End Region
#End Region
#End Region
End Class