Imports HtmlAgilityPack
Imports System.Net
Imports System.Text.RegularExpressions

Public Class SanAntonio_NorthSideFord_WebParser
    Implements IDealershipWebParser

#Region "Private Members"
    Private _WebClient As WebClient
#End Region

#Region "Properties"
#Region "Class Properties"
    Private Shared ReadOnly Property UrlFormat As String
        Get
            Return "http://nsford.com/San-Antonio/For-Sale/Used/?PageSize=100&Page={0}"
        End Get
    End Property
#End Region

#Region "Instance Properties"
    Private ReadOnly Property WebClient As WebClient
        Get
            If Me._WebClient Is Nothing
                Me._WebClient = New WebClient()
                Me._WebClient.Proxy = New WebProxy("inetprox", 8080)
                Me._WebClient.Credentials = New NetworkCredential("testserver", "strpdsql", "labattsa")
            End If
            Return Me._WebClient
        End Get
    End Property
#End Region
#End Region

#Region "Public Methods"

#Region "Interface Methods"
    Public Function GetCurrentInventory() As List(Of DealerListing) _
    Implements IDealershipWebParser.GetCurrentInventory
        Dim dealerInventory As New List(Of DealerListing)()

        Try
            Dim currentPage As HtmlDocument = Me.DownloadPage(1)
            Dim pageCount As Integer = Me.GetPageCount(currentPage)

            For pageIndex As Integer = 1 To pageCount
                Dim pageInventoryNodes As HtmlNodeCollection = Me.SelectInventoryNodes(currentPage)

                For Each inventoryNode As HtmlNode In pageInventoryNodes
                    Dim nodeVehicleInformation As VehicleInformation = Me.BuildVehicleInformationFromInventoryNode(inventoryNode)
                    Dim nodeVehiclePrice As Decimal = Me.ExtractAskingPriceFromInventoryNode(inventoryNode)
                    dealerInventory.Add(New DealerListing(nodeVehicleInformation, nodeVehiclePrice))
                Next

                If pageIndex < pageCount
                    currentPage = Me.DownloadPage(pageIndex + 1)
                End If
            Next
        Catch ex As Exception

        End Try

        Return dealerInventory
    End Function
#End Region
#End Region

#Region "Private Methods"
    Private Function BuildVehicleInformationFromInventoryNode(ByVal node As HtmlNode) As VehicleInformation
        Dim nodeVehicleInformation As New VehicleInformation()

        nodeVehicleInformation.BodyStyle = Me.ExtractBodyStyleFromInventoryNode(node)
        nodeVehicleInformation.Engine = Me.ExtractEngineInformationFromInventoryNode(node)
        nodeVehicleInformation.ExteriorColor = node.SelectSingleNode(".//dd[@class='ext. color']").InnerText
        nodeVehicleInformation.FuelConsumption = Me.ExtractFuelConsumptionRatingFromInventoryNode(node)
        nodeVehicleInformation.InteriorColor = node.SelectSingleNode(".//dd[@class='int. color']").InnerText
        nodeVehicleInformation.Make = node.SelectSingleNode(".//input[@class='vehicle-make']").GetAttributeValue("value", String.Empty)
        nodeVehicleInformation.Model = node.SelectSingleNode(".//input[@class='vehicle-model']").GetAttributeValue("value", String.Empty)
        nodeVehicleInformation.TransmissionType = Me.ExtractTransmissionTypeFromInventoryNode(node)
        nodeVehicleInformation.VIN = node.SelectSingleNode(".//dd[@class='vin #']").InnerText
        nodeVehicleInformation.Year = CInt(node.SelectSingleNode(".//input[@class='vehicle-year']").GetAttributeValue("value", String.Empty))

        Return nodeVehicleInformation
    End Function

    Private Function DownloadPage(ByVal pageNumber As Integer) As HtmlDocument
        Dim pageUrl As String = String.Format(SanAntonio_NorthSideFord_WebParser.UrlFormat, pageNumber)
        Dim pageXmlString As String = Me.WebClient.DownloadString(pageUrl)

        Dim page As New HtmlDocument()
        page.LoadHtml(pageXmlString)

        Return page
    End Function

    Private Function ExtractAskingPriceFromInventoryNode(ByVal node As HtmlNode) As Decimal
        Dim vehiclePrice As Decimal

        Dim priceNode As HtmlNode = node.SelectSingleNode(".//dd[@class='vehicle-price-default-price']")
        If priceNode IsNot Nothing
            vehiclePrice = CDec(priceNode.InnerText.Replace("*", String.Empty))
        Else
            'priceNode = node.SelectSingleNode(".//p[@class='vehicle-price-zero-label']")
            vehiclePrice = -1D
        End If

        Return vehiclePrice
    End Function

    Private Function ExtractBodyStyleFromInventoryNode(ByVal node As HtmlNode) As VehicleBodyStyle
        Dim bodyStyle As VehicleBodyStyle

        Dim bodyStyleNode As HtmlNode = node.SelectSingleNode(".//dd[@class='body style']")
        Select Case bodyStyleNode.InnerText
            Case "Convertible"
                bodyStyle = VehicleBodyStyle.Convertible

            Case "Coupe"
                bodyStyle = VehicleBodyStyle.Coupe

            Case "Sedan"
                bodyStyle = VehicleBodyStyle.Sedan

            Case "SUV"
                bodyStyle = VehicleBodyStyle.SUV

            Case "Truck"
                bodyStyle = VehicleBodyStyle.Truck

            Case Else
                bodyStyle = VehicleBodyStyle.Unknown
        End Select

        Return bodyStyle
    End Function

    Private Function ExtractEngineInformationFromInventoryNode(ByVal node As HtmlNode) As VehicleEngineInformation
        Dim engineInformation As New VehicleEngineInformation()

        Dim engineNode As HtmlNode = node.SelectSingleNode(".//dd[@class='engine']")
        Dim engineNodeText As String = engineNode.InnerText

        Dim cylinderCount As Integer
        If engineNodeText.Contains("I4") OrElse engineNodeText.Contains("V4") OrElse engineNodeText.Contains("W4")
            cylinderCount = 4
        ElseIf engineNodeText.Contains("I5") OrElse engineNodeText.Contains("V5") OrElse engineNodeText.Contains("W5")
            cylinderCount = 5
        ElseIf engineNodeText.Contains("I6") OrElse engineNodeText.Contains("V6") OrElse engineNodeText.Contains("W6")
            cylinderCount = 6
        ElseIf engineNodeText.Contains("I8") OrElse engineNodeText.Contains("V8") OrElse engineNodeText.Contains("W8")
            cylinderCount = 8
        ElseIf engineNodeText.Contains("I10") OrElse engineNodeText.Contains("V10") OrElse engineNodeText.Contains("W10")
            cylinderCount = 10
        ElseIf engineNodeText.Contains("I12") OrElse engineNodeText.Contains("V12") OrElse engineNodeText.Contains("W12")
            cylinderCount = 12
        Else
            cylinderCount = -1
        End If

        Dim engineDisplacementString As String = Regex.Match(engineNodeText, "["" ""][\d]*.[\d]*[\w]*/[\d]*").Value
        Dim engineDisplacement As Decimal

        If engineDisplacementString <> String.Empty
            engineDisplacementString = engineDisplacementString.Remove(engineDisplacementString.IndexOf("/"c))
            engineDisplacementString = engineDisplacementString.Replace("L", String.Empty)
            engineDisplacement = CDec(engineDisplacementString)
        Else
            engineDisplacement = -1D
        End If

        Dim fuelType As VehicleEngineFuelType
        If engineNodeText.Contains("Gas")
            fuelType = VehicleEngineFuelType.Gasoline
        ElseIf engineNodeText.Contains("Diesel")
            fuelType = VehicleEngineFuelType.Diesel
        Else
            fuelType = VehicleEngineFuelType.Unknown
        End If

        engineInformation.CylinderCount = cylinderCount
        engineInformation.DisplacementUnit = VehicleEngineDisplacementUnit.Liters
        engineInformation.Displacement = engineDisplacement
        engineInformation.FuelType = fuelType

        Return engineInformation
    End Function

    Private Function ExtractFuelConsumptionRatingFromInventoryNode(ByVal node As HtmlNode) As VehicleFuelConsumption
        Dim fuelConsumption As New VehicleFuelConsumption()

        Dim fuelConsumptionNode As HtmlNode = node.SelectSingleNode(".//dd[@class='mpg']")
        Dim fuelConsumptionText As String = fuelConsumptionNode.InnerText

        Dim cityConsumptionString As String = Regex.Match(fuelConsumptionText, "[\d]* City EPA-Est").Value
        cityConsumptionString = cityConsumptionString.Remove(cityConsumptionString.IndexOf(" "c))

        Dim cityConsumptionRating As Decimal
        If cityConsumptionString <> String.Empty
            cityConsumptionRating = CDec(cityConsumptionString)
        Else
            cityConsumptionRating = 0D
        End If

        Dim highwayConsumptionString As String = Regex.Match(fuelConsumptionText, "[\d]* Hwy EPA-Est").Value
        highwayConsumptionString = highwayConsumptionString.Remove(highwayConsumptionString.IndexOf(" "c))

        Dim highwayConsumptionRating As Decimal
        If highwayConsumptionString <> String.Empty
            highwayConsumptionRating = CDec(highwayConsumptionString)
        Else
            highwayConsumptionRating = 0D
        End If

        fuelConsumption.ConsumptionUnit = VehicleFuelConsumptionUnit.MilesPerGallon_USGallons
        fuelConsumption.CityRating = cityConsumptionRating
        fuelConsumption.HighwayRating = highwayConsumptionRating

        Return fuelConsumption
    End Function

    Private Function ExtractTransmissionTypeFromInventoryNode(ByVal node As HtmlNode) As VehicleTransmissionType
        Dim transmissionType As VehicleTransmissionType

        Dim transmissionTypeNode As HtmlNode = node.SelectSingleNode(".//dd[@class='trans']")
        Select Case transmissionTypeNode.InnerText
            Case "Automatic"
                transmissionType = VehicleTransmissionType.Automatic

            Case "Manual"
                transmissionType = VehicleTransmissionType.Manual

            Case Else
                transmissionType = VehicleTransmissionType.Unknown
        End Select

        Return transmissionType
    End Function

    Private Function GetPageCount(ByVal document As HtmlDocument) As Integer
        Dim numPages As Integer = 0

        Dim pageCountNodes As HtmlNodeCollection = document.DocumentNode.SelectNodes("//span[@class='page-count']/span")
        If pageCountNodes.Count > 0
            numPages = CInt(pageCountNodes.Item(0).InnerHtml)
        End If

        Return numPages
    End Function

    Private Function SelectInventoryNodes(ByVal document As HtmlDocument) As HtmlNodeCollection
        Return document.DocumentNode.SelectNodes("//ul[@class='inventory-list']/li")
    End Function
#End Region
End Class