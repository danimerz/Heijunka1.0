

Imports System.Xml
Imports ProdKontrolle.DS_ProdKontrolleTableAdapters

Public Class frm_Ruckmelden
    'Gloable Funktionen Init
    Private f As New GlobaleFunktionen

    Public ASN As String
    Public Auftrag As String

    'Bilder
    Public Box As Boolean = False
    Public K2 As Boolean = False
    Public MA As Boolean = False
    Public Karton As Boolean = False

    Public MagOffen As Image
    Public MagErledigt As Image
    Public K2Offen As Image
    Public K2Erledigt As Image
    Public offenBox As Image
    Public ErledigtBox As Image
    Public offenKarton As Image
    Public ErledigtKarton As Image

    Public StkProBehaelter As Integer = 0

    Public Sub New(Material As String, FAUF As String, Result As Object, BehData As EnumerableRowCollection, SollStk As Integer, FarbigeMelder As FarbigeMelder)
        InitializeComponent()

        offenBox = My.Resources.DC_box
        ErledigtBox = My.Resources.DC_box_gebucht
        offenKarton = My.Resources.Karton
        ErledigtKarton = My.Resources.Karton_gebucht
        K2Offen = My.Resources.K2_Box
        K2Erledigt = My.Resources.K2_Box_gebucht

        ASN = Material
        Auftrag = FAUF

        Dim AnzBehaelter As Integer = 0

        Dim FormHeight As Integer = 350 - 145 ' Form höhe für ein barcode minus grösse einer groupbox

        Dim gp As New GroupBox
        Dim lbl_Ruckcode As New Label
        Dim lbl_stk As New Label
        Dim lbl_KdNr As New Label
        Dim lbl_PosNr As New Label
        Dim PB_BC As New PictureBox
        Dim PB_BC_Stk As New PictureBox
        Dim PB_Logo As New PictureBox
        Dim PB_KdNr As New PictureBox
        Dim PB_PosNr As New PictureBox
        Dim FLP_Beh As New FlowLayoutPanel
        ' Dim FLP_Button As New FlowLayoutPanel

        FLP.BackColor = Color.White

        'Anzahl Behälter ermitteln
        'überprüfen ob Behälterdaten nicht Nothing sind --> Falls keine Behälterdaten im SAP gepflegt sind

        If Not IsNothing(BehData) Then
            For Each item In BehData
                'Behälterinhalt in Public schreiben
                If SollStk <= CInt(item.bh_stk) Then
                    StkProBehaelter = SollStk
                Else
                    StkProBehaelter = CInt(item.bh_stk)
                End If

                'SChlaufe für Anzahl behälter
                If item.bh_stk > 0 Then
                    Select Case item.BH_Typ
                        Case "K1", "K2", "K3", "G1"
                            K2 = True
                            AnzBehaelter = Math.Ceiling(SollStk / CInt(item.bh_stk))
                        Case "E4", "MA"
                            Box = True
                            AnzBehaelter = Math.Ceiling(SollStk / CInt(item.bh_stk))
                        Case "PL"
                            Karton = True
                            AnzBehaelter = Math.Ceiling(SollStk / CInt(item.bh_stk))
                        Case "E5"

                        Case Else
                            Box = True
                            AnzBehaelter = Math.Ceiling(SollStk / CInt(item.bh_stk))
                    End Select
                Else
                    MsgBox("Behälterdaten in SAP stimmen nicht!" & vbCrLf & "Resultat = " & item.bh_stk, vbCritical, "Fehler")
                    Exit Sub
                End If
            Next
        Else
            Box = True
            AnzBehaelter = 1
        End If

        'MsgBox(AnzBehaelter)

        'Nur die Zeilen dieses Auftrags laden statt der kompletten (über die Zeit wachsenden) Tabelle
        Dim tbl_Ruckmelden As DataTable = f.GetRueckmeldenStatusByFAUF(FAUF)

        'Bereits gebuchte Rückmeldecodes einmalig in ein HashSet, statt die Tabelle pro Behälter
        'erneut per LINQ zu durchsuchen
        Dim gebuchteRuckCodes As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        For Each row As DataRow In tbl_Ruckmelden.Rows
            If row("Status").ToString() = "1" Then
                gebuchteRuckCodes.Add(row("RuckCode").ToString())
            End If
        Next

        'if Abfrage wenn Farbigemelder
        Dim i As Integer = 0
        For Each vrg In Result
            If vrg.StrSchl = "A002" Or vrg.StrSchl = "A003" Or vrg.StrSchl = "A022" Then
                i = i + 1
                'Wenn letzer Vorgang und Farbiger Melder
                If vrg.StrSchl = "A003" And FarbigeMelder.FarbigerMelder = True Then
                    With gp
                        .Text = "Vorgang: " & vrg.VrgNr & " - " & vrg.LT
                        .Left = 10
                        .Name = vrg.Rueck
                        .Size = New Size(529, 245)
                    End With
                    With PB_KdNr
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .Image = Code128Rendering.MakeBarcodeImage(FarbigeMelder.Kundenauftragsnummer, 3, True)
                        .Location = New Point(5, 140)
                        .Size = New Size(250, 100)
                        .Name = "pb_KdNr"
                    End With
                    With lbl_KdNr
                        .Location = New Point(5, 210)
                        .Size = New Size(200, 15)
                        .Text = "KAUF Nr.: " & FarbigeMelder.Kundenauftragsnummer
                    End With
                    With PB_PosNr
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .Image = Code128Rendering.MakeBarcodeImage(FarbigeMelder.PositionsText, 3, True)
                        .Location = New Point(300, 140)
                        .Size = New Size(200, 100)
                        .Name = "pb_PosTxt"
                    End With
                    With lbl_PosNr
                        .Location = New Point(300, 210)
                        .Size = New Size(200, 15)
                        .Text = "Pos. Text: " & FarbigeMelder.PositionsText
                    End With

                Else
                    With gp
                        .Text = "Vorgang: " & vrg.VrgNr & " - " & vrg.LT
                        .Left = 10
                        .Name = vrg.Rueck
                        .Size = New Size(529, 145)
                    End With
                End If

                With PB_BC
                    'Als DMC oder als Barcode Darstellen abhänging von einstellungen

                    If My.Settings.showDMC = False Then
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .Image = Code128Rendering.MakeBarcodeImage(vrg.Rueck, 3, True)
                    Else
                        .SizeMode = PictureBoxSizeMode.CenterImage
                        .Image = f.GenerateDMC(vrg.Rueck, 3, 15)
                    End If
                    .Location = New Point(5, 15)
                    .Size = New Size(350, 80)
                    '.SizeMode = PictureBoxSizeMode.Zoom
                    .Name = vrg.Rueck
                End With

                With PB_BC_Stk
                    .SizeMode = PictureBoxSizeMode.Zoom
                    .Image = Code128Rendering.MakeBarcodeImage(StkProBehaelter, 3, True)
                    .Location = New Point(5, 90)
                    .Size = New Size(230, 40)
                    .Name = vrg.Rueck
                End With
                With lbl_stk
                    .Location = New Point(5, 128)
                    .Size = New Size(200, 15)
                    .Text = " Anz. stk. pro Behälter: " & StkProBehaelter
                End With

                With FLP_Beh
                    .FlowDirection = FlowDirection.LeftToRight
                    .Location = New Point(360, 10)
                    .Size = New Point(163, 128)
                End With
                With lbl_Ruckcode
                    .Location = New Point(8, 80)
                    .Size = New Size(200, 20)
                    .Text = "SAP Rückmeldecode: " & vrg.Rueck
                End With

                'Controll hinzufügen
                If FarbigeMelder.FarbigerMelder = True Then
                    FLP.Controls.Add(gp)
                    With gp.Controls
                        .Add(lbl_Ruckcode)
                        .Add(lbl_stk)
                        .Add(lbl_KdNr)
                        .Add(lbl_PosNr)
                        .Add(PB_BC)
                        .Add(PB_BC_Stk)
                        .Add(FLP_Beh)
                        .Add(PB_KdNr)
                        .Add(PB_PosNr)
                    End With
                Else
                    FLP.Controls.Add(gp)
                    With gp.Controls
                        .Add(lbl_Ruckcode)
                        .Add(lbl_stk)
                        .Add(PB_BC)
                        .Add(PB_BC_Stk)
                        .Add(FLP_Beh)
                    End With

                End If



                If vrg.StrSchl = "A003" Then
                    For j As Integer = 1 To AnzBehaelter
                        Dim y As Integer = j

                        With PB_Logo
                            If gebuchteRuckCodes.Contains(vrg.Rueck & "_" & y) Then
                                Select Case True
                                    Case Box
                                        .Image = ErledigtBox
                                    Case Karton
                                        .Image = ErledigtKarton
                                    Case K2
                                        .Image = K2Erledigt
                                End Select
                            Else
                                Select Case True
                                    Case Box
                                        .Image = offenBox
                                    Case Karton
                                        .Image = offenKarton
                                    Case K2
                                        .Image = K2Offen
                                End Select
                            End If
                            'Bildgrösse bestimmen
                            Select Case AnzBehaelter
                                Case 1
                                    .Size = New Size(136, 110)
                                Case 2 To 4
                                    .Size = New Size(126 / 2, 100 / 2)
                                Case 5 To 9
                                    .Size = New Size(126 / 3, 100 / 3)
                                Case Else
                                    .Size = New Size(126 / 4, 100 / 4)
                            End Select

                            .SizeMode = PictureBoxSizeMode.Zoom
                            .Name = vrg.Rueck & "_" & y
                            'Event Handler erstellen
                            AddHandler PB_Logo.DoubleClick, AddressOf DoubleClickPicture
                            FLP_Beh.Controls.Add(PB_Logo)
                            PB_Logo = New PictureBox
                        End With
                    Next
                Else
                    With PB_Logo

                        If gebuchteRuckCodes.Contains(vrg.Rueck) Then

                            Select Case True
                                Case Box
                                    .Image = ErledigtBox
                                Case Karton
                                    .Image = ErledigtKarton
                                Case K2
                                    .Image = K2Erledigt
                            End Select
                        Else
                            Select Case True
                                Case Box
                                    .Image = offenBox
                                Case Karton
                                    .Image = offenKarton
                                Case K2
                                    .Image = K2Offen
                            End Select
                        End If
                        '.Location = New Point(387, 19)
                        .Size = New Size(136, 110)
                        .SizeMode = PictureBoxSizeMode.Zoom
                        .Name = vrg.Rueck
                        'Event Handler erstellen
                        AddHandler PB_Logo.DoubleClick, AddressOf DoubleClickPicture
                        FLP_Beh.Controls.Add(PB_Logo)
                        PB_Logo = New PictureBox

                    End With
                End If

                PB_BC = New PictureBox
                PB_BC_Stk = New PictureBox
                lbl_Ruckcode = New Label
                lbl_stk = New Label
                lbl_KdNr = New Label
                lbl_PosNr = New Label
                gp = New GroupBox
                FLP_Beh = New FlowLayoutPanel
                PB_KdNr = New PictureBox
                PB_PosNr = New PictureBox

                If FarbigeMelder.FarbigerMelder = True Then
                    Me.Height = FormHeight + 100 + (148 * i)
                Else
                    Me.Height = FormHeight + (148 * i)
                End If

            End If
        Next

        lbl_ASN.Text = "ASN / SSN: " + Material
        lbl_FAUF.Text = "Auftrag: " + FAUF
    End Sub

    Private Sub DoubleClickPicture(ByVal sender As Object, ByVal e As EventArgs)
        Dim clickedPB As PictureBox = DirectCast(sender, PictureBox)
        Select Case True
            Case clickedPB.Image Is offenBox
                Tbl_Rueckmelden_StatusTableAdapter.InsertQuery(ASN, Auftrag, clickedPB.Name, Now.ToShortDateString, "1")
                clickedPB.Image = ErledigtBox
            Case clickedPB.Image Is offenKarton
                Tbl_Rueckmelden_StatusTableAdapter.InsertQuery(ASN, Auftrag, clickedPB.Name, Now.ToShortDateString, "1")
                clickedPB.Image = ErledigtKarton
            Case clickedPB.Image Is ErledigtBox
                Tbl_Rueckmelden_StatusTableAdapter.DeleteQuery(clickedPB.Name)
                clickedPB.Image = offenBox
            Case clickedPB.Image Is ErledigtKarton
                Tbl_Rueckmelden_StatusTableAdapter.DeleteQuery(clickedPB.Name)
                clickedPB.Image = offenKarton
            Case clickedPB.Image Is K2Erledigt
                Tbl_Rueckmelden_StatusTableAdapter.DeleteQuery(clickedPB.Name)
                clickedPB.Image = K2Offen
            Case clickedPB.Image Is K2Offen
                Tbl_Rueckmelden_StatusTableAdapter.InsertQuery(ASN, Auftrag, clickedPB.Name, Now.ToShortDateString, "1")
                clickedPB.Image = K2Erledigt
        End Select
    End Sub

    Private Sub btn_close_Click(sender As Object, e As EventArgs) Handles btn_close.Click
        Me.Close()
    End Sub

    Private Sub frm_Ruckmelden_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class