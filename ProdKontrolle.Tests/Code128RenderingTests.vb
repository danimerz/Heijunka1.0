Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports ProdKontrolle

<TestClass>
Public Class Code128RenderingTests

    <TestMethod>
    Public Sub MakeBarcodeImage_GueltigerInhalt_ErzeugtBildMitPositiverGroesse()
        Dim img As Drawing.Image = Code128Rendering.MakeBarcodeImage("TEST123", 1, True)

        Assert.IsNotNull(img)
        Assert.IsTrue(img.Width > 0)
        Assert.IsTrue(img.Height > 0)
    End Sub

    <TestMethod>
    Public Sub MakeBarcodeImage_GroesseresBarWeight_ErzeugtBreiteresBild()
        Dim schmal As Drawing.Image = Code128Rendering.MakeBarcodeImage("TEST123", 1, True)
        Dim breit As Drawing.Image = Code128Rendering.MakeBarcodeImage("TEST123", 3, True)

        Assert.IsTrue(breit.Width > schmal.Width)
    End Sub

    <TestMethod>
    Public Sub MakeBarcodeImage_MitUndOhneQuietZone_UnterschiedlicheBreite()
        Dim mitZone As Drawing.Image = Code128Rendering.MakeBarcodeImage("TEST123", 1, True)
        Dim ohneZone As Drawing.Image = Code128Rendering.MakeBarcodeImage("TEST123", 1, False)

        Assert.IsTrue(mitZone.Width > ohneZone.Width)
    End Sub

End Class
