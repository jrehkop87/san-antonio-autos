Imports SAAutos.Core
Imports SAAutos.Core.WebParsers

Module Module1
    Public Sub Main()
        Dim parser As IDealershipWebParser = New SanAntonio_NorthSideFord_WebParser()
        Dim inventoryList As List(Of DealerListing) = parser.GetCurrentInventory()
    End Sub
End Module