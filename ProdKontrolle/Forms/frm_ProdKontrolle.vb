Imports System.Text
Imports iTextSharp.text.pdf
Imports System.IO
Imports ProdKontrolle.DS_ProdKontrolleTableAdapters
Imports ProdKontrolle.Form1

Public Class frm_ProdKontrolle
    Private globaleFunktonen As New GlobaleFunktionen

    Public Material As String
    Dim Linie As String
    Public Fauf As String
    Public Soll As Integer
    Public ist As Integer
    Public AP As String
    Public vrg As String
    Dim AV As New List(Of Arbeitsvorrat)
    Public rIndex As Integer
    Private SAP_XML As New SAP_XML

    Event ColoringHeijunkaEvent(sender As Object, e As Form1.ColoringHeijunkaEventArgs)


    Public Sub New(Material1 As String, FAUF1 As String, Soll1 As Integer, Ist1 As Integer, Linie1 As String, AP1 As String, vorgang As String, Arbeitsvorrat As List(Of Arbeitsvorrat), RowIndex As Integer)
        InitializeComponent()

        Material = Material1 '.Replace("/", "$")
        Fauf = FAUF1
        Soll = Soll1
        ist = Ist1
        Linie = Linie1
        vrg = vorgang
        AP = AP1
        AV = Arbeitsvorrat
        rIndex = RowIndex
    End Sub

    Private Sub cb_grund_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_grund.SelectedIndexChanged
        Select Case cb_grund.Text
            Case "MA Kapazität"
                Me.Height = 178
                txt_Grund.Visible = False
                txt_Grund.Text = ""
                LB_stuli.Visible = False
            Case "Fehlmaterial"
                Me.Height = 333
                LB_stuli.Visible = True
                txt_Grund.Visible = False
                txt_Grund.Text = ""

                For Each item In globaleFunktonen.GetStuecklisteFromSAPXML(Material, Fauf)
                    LB_stuli.Items.Add(item.Material & " - " & item.Pos_Text)
                Next

            Case "Maschine"
                Me.Height = 333
                txt_Grund.Visible = True
                txt_Grund.Text = ""
                LB_stuli.Visible = False
            Case "Sonstiges"
                Me.Height = 333
                txt_Grund.Visible = True
                LB_stuli.Visible = False
                txt_Grund.Text = ""
        End Select
    End Sub

    Private Sub frm_ProdKontrolle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Tbl_ProdKontrolleTableAdapter.Fill(Me.DS_ProdKontrolle.tbl_ProdKontrolle)
        txt_Grund.Visible = False
        LB_stuli.Visible = False
        Me.Height = 178
    End Sub

    Private Sub btn_Eintragen_Click(sender As Object, e As EventArgs) Handles btn_Eintragen.Click
        Dim Fehlerzettel As Boolean = My.Settings.Fehlerzettel
        Dim args = New ColoringHeijunkaEventArgs

        If Not cb_grund.Text = "" Then
            Dim GrundText As String = ""
            Select Case cb_grund.Text
                Case "MA Kapazität"
                    GrundText = ""
                    Fehlerzettel = False
                    args.RowIndex = rIndex
                    RaiseEvent ColoringHeijunkaEvent(Me, args)
                Case "Fehlmaterial"
                    For i = 0 To LB_stuli.SelectedItems.Count - 1
                        'Multi FM eintragen über ganzes Heijunka                       
                        If My.Settings.MultiFmProdKont = True Then
                            If MessageBox.Show("Soll das Fehlmaterial: " & LB_stuli.SelectedItems(i).ToString & " im ganzen Heijunka eingetragen werden?", "Frage?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                Dim FehlMatArr() As String = Split(LB_stuli.SelectedItems(i), " - ")
                                FehlmaterialInArbeitsvorratSuchenUndEintragen(FehlMatArr(0), FehlMatArr(1))
                            Else
                                'es wurde nein geklickt, nur aktueller FAUF erhält Auftrag
                                args.RowIndex = rIndex
                                RaiseEvent ColoringHeijunkaEvent(Me, args)
                                Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, Linie, Material, Fauf, Soll, ist, "offen", cb_grund.Text, LB_stuli.SelectedItems(i).ToString, vrg)
                            End If
                        Else
                            args.RowIndex = rIndex
                            RaiseEvent ColoringHeijunkaEvent(Me, args)
                            Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, Linie, Material, Fauf, Soll, ist, "offen", cb_grund.Text, LB_stuli.SelectedItems(i).ToString, vrg)
                        End If
                    Next
                    DialogResult = DialogResult.OK
                    Exit Sub
                    'GrundText = LB_stuli.SelectedItem.ToString
                Case "Maschine"
                    GrundText = txt_Grund.Text
                    args.RowIndex = rIndex
                    RaiseEvent ColoringHeijunkaEvent(Me, args)
                Case "Sonstiges"
                    GrundText = txt_Grund.Text
                    args.RowIndex = rIndex
                    RaiseEvent ColoringHeijunkaEvent(Me, args)
                Case Else
                    cb_grund.Text = ""
                    MsgBox("Bitte Grund aus Liste auswählen", vbInformation, "Information")
                    cb_grund.DroppedDown = True
                    Exit Sub
            End Select

            Try
                Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, Linie, Material, Fauf, Soll, ist, "offen", cb_grund.Text, GrundText, vrg)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            'Fehlerzettel erstellen
            If Fehlerzettel = True Then
                If PDF_fuellen(Material, Soll, ist, Fauf, GrundText, Linie, cb_grund.Text) = True Then
                    If PrintPdf(Application.StartupPath & "\TEMP_Fehlermeldung.pdf") = False Then
                        MsgBox("Es gabe einen Fehler beim Drucken des Fehlerzettel", "Fehler", vbCritical)
                    End If
                Else
                    MsgBox("Es gabe einen Fehler beim etsellen des Fehlerzettel", "Fehler", vbCritical)
                End If
            End If
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Function PDF_fuellen(ByVal Mat As String, ByVal Soll As String, ByVal ist As String, ByVal Fauf As String,
                                 ByVal Text As String, ByVal Linie As String, ByVal Grund As String) As Boolean
        Try
            Dim AppPfad As String = Application.StartupPath
            Dim pdfTemplate As String = Application.StartupPath & "\Fehlermeldung.pdf"
            Dim newFile As String = Application.StartupPath & "\TEMP_Fehlermeldung.pdf"

            Dim pdfReader As New PdfReader(pdfTemplate)
            Dim pdfStamper As New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))

            Dim pdfFormFields As AcroFields = pdfStamper.AcroFields
            'TextBoxen
            pdfFormFields.SetField("txt_Matnr", Mat)
            pdfFormFields.SetField("txt_Menge", Soll)
            pdfFormFields.SetField("txt_FAUF", Fauf)
            pdfFormFields.SetField("txt_Fehlerhaft", Soll - ist)
            pdfFormFields.SetField("txt_Fehlerbeschreib", Text)
            pdfFormFields.SetField("txt_Ersteller", Linie)
            pdfFormFields.SetField("txt_Datum", Now.ToLongDateString)
            pdfFormFields.SetField("txt_Verantwortlicher", "Teamleiter")
            pdfFormFields.SetField("txt_erledigt_Datum", "")
            ' Checkboxen

            Select Case Grund
                Case "MA Kapazität"
                    pdfFormFields.SetField("ChkBox_Gesperrt", "Yes")
                Case "Fehlmaterial"
                    pdfFormFields.SetField("ChkBox_Fehlmaterial", "Yes")
                Case "Maschine"
                    pdfFormFields.SetField("ChkBox_Gesperrt", "Yes")
                Case "Sonstiges"
                    pdfFormFields.SetField("ChkBox_Gesperrt", "Yes")
            End Select

            pdfFormFields.SetField("ChkBox_SAP_Ja", "0")
            pdfFormFields.SetField("ChkBox_SAP_Nein", "Yes")
            pdfFormFields.SetField("ChkBox_QMNC_Ja", "0")
            pdfFormFields.SetField("ChkBox_QMNC_Nein", "Yes")
            pdfStamper.FormFlattening = True
            pdfStamper.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function PrintPdf(ByVal sPdfToPrint As String) As Boolean
        Try
            If File.Exists(sPdfToPrint) Then
                Using oProcess As New System.Diagnostics.Process
                    With oProcess.StartInfo
                        .WindowStyle = ProcessWindowStyle.Hidden
                        .Verb = "print"
                        .UseShellExecute = True
                        .FileName = sPdfToPrint
                    End With
                    oProcess.Start()
                    oProcess.WaitForInputIdle()
                    oProcess.CloseMainWindow()
                End Using
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub FehlmaterialInArbeitsvorratSuchenUndEintragen(FehlMaterial As String, KurzText As String)
        Dim args = New ColoringHeijunkaEventArgs
        For Each a In AV
            If a.ist < a.Soll Then
                For Each item In globaleFunktonen.GetStuecklisteFromSAPXML(a.Material, a.Fauf)
                    If item.Material = FehlMaterial Then
                        args.RowIndex = a.RowIndex
                        RaiseEvent ColoringHeijunkaEvent(Me, args)
                        Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, Linie, a.Material, a.Fauf, a.Soll, a.ist, "offen", cb_grund.Text, FehlMaterial & " - " & KurzText, a.vrg)
                    End If
                Next
            End If
        Next
    End Sub
End Class

Public Class Arbeitsvorrat
    Public RowIndex As Integer
    Public Material As String
    Public Fauf As String
    Public Soll As Integer
    Public ist As Integer
    Public AP As String
    Public vrg As String
End Class
