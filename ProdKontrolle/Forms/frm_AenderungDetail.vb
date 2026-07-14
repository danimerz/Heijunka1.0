Imports iTextSharp.text

Public Class frm_AenderungDetail

    Public FAUF As String
    Private globaleFunktionen As New GlobaleFunktionen
    Public Sub New(Auftragsnummer As String)
        InitializeComponent()
        FAUF = Auftragsnummer
    End Sub

    Private Sub frm_AenderungDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_titel.Text = "Änderungs Details für Auftrag " & FAUF
        Dim Aenderung As New Aenderungen
        Aenderung = globaleFunktionen.GetAnwStatusAenderung(FAUF)

        Dim listCount As Integer = 0
        Dim AenderungStart As Integer = 0
        Dim AenderungEnde As Integer = 0

        'Start und Ende des Änderungstext suchen
        For Each row As String In Aenderung.AenderungsTextList
            Select Case row
                Case "INFO_AEND:"
                    AenderungStart = listCount
                Case "INFO_AEND_END"
                    AenderungEnde = listCount
            End Select
            listCount += 1
        Next

        'Nur Änderungstext anzeigen
        listCount = 0
        For Each row As String In Aenderung.AenderungsTextList
            If AenderungStart < listCount And AenderungEnde > listCount Then
                Select Case row
                    Case "newLine"
                        txt_Aenderungstext.Text += System.Environment.NewLine
                    Case Else
                        txt_Aenderungstext.Text += row & System.Environment.NewLine
                End Select
            End If
            listCount += 1
        Next
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub
End Class