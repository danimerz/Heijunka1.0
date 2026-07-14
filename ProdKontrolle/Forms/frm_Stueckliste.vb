Imports System.ComponentModel
Imports System.IO
Public Class frm_Stueckliste
    Private SAP_XML As New SAP_XML
    Private globaleFunktionen As New GlobaleFunktionen

    Public Mat As String
    Public FAUF As String
    Public Soll As Integer
    Public Gruppe As String
    Public Vorg1 As String
    Public Linie As String
    Public Ist As Integer
    Public FM As Boolean = False 'entscheided wenn das Dialog Result OK sein soll.Unterbindet das schliessen des Forms wenn mehrere FM gemeldet werden sollen

    Enum ListViewSubItems
        PLO = 0
        Material = 1
        Kurztext = 2
        Lagerort = 3
        Anzahl = 4
    End Enum

    Public Sub New(Auftrag As String, Material As String, Stuckzahl As Integer, grp As String, istStk As Integer, Line As String, Vorg As String)
        InitializeComponent()

        Mat = Material.Replace("/", "$")
        FAUF = Auftrag
        Soll = Stuckzahl
        Gruppe = grp
        Vorg1 = Vorg
        Linie = Line
        Ist = istStk

        'Listview füllen

        LV_Stuli.Sorting = SortOrder.None
        LV_Stuli.View = View.Details
        'Spalten hinzufügen
        LV_Stuli.Columns.Add(New ColumnHeader)
        LV_Stuli.Columns(0).Text = "PLO"
        LV_Stuli.Columns(0).Width = 100
        LV_Stuli.Columns.Add(New ColumnHeader)
        LV_Stuli.Columns(1).Text = "Material"
        LV_Stuli.Columns(1).Width = 270
        LV_Stuli.Columns.Add(New ColumnHeader)
        LV_Stuli.Columns(2).Text = "Kurztext"
        LV_Stuli.Columns(2).Width = 610
        LV_Stuli.Columns.Add(New ColumnHeader)
        LV_Stuli.Columns(3).Text = "Lagerort"
        LV_Stuli.Columns(3).Width = 180
        LV_Stuli.Columns.Add(New ColumnHeader)
        LV_Stuli.Columns(4).Text = "Stk"
        LV_Stuli.Columns(4).Width = 120

        'Gruppen erstellen und in Liste schreiben
        Dim vorgang_alt As String = ""
        'liste der vorgänge
        Dim list As New List(Of String)
        For Each Vorgang In globaleFunktionen.GetStuecklisteFromSAPXML(Material, Auftrag)
            If vorgang_alt = Vorgang.vrg Then
                vorgang_alt = Vorgang.vrg
            Else
                AddGroup(Vorgang.vrg & " - " & Vorgang.vrg_text)
                list.Add(Vorgang.vrg)
                vorgang_alt = Vorgang.vrg
            End If
        Next

        'Wenn es sich um CEVA handelt
        If Gruppe = "CEVA" Then
            AddGroup("Getriebe")
            list.Add("Getriebe")

            Dim Getriebe As String = ""
            Dim AusTC3 As String = globaleFunktionen.GetCEVA_GearBoxNr_TC3(FAUF)
            Dim AusDok As String = globaleFunktionen.GetCEVA_GearBoxNr(FAUF)

            If AusTC3 = "" Then
                Getriebe = AusDok
            Else
                Getriebe = AusTC3
            End If

            LV_Stuli.Items.Add(New ListViewItem(New String() {"", Getriebe, "Getriebe", "FIFO", Soll & " ST"}, LV_Stuli.Groups("Getriebe")))
        End If


        'Vcheck TextFile auslesen und in DT speichern
        Dim Pfad As String = My.Settings.PfadLagerortAusnhamen
        Dim Lines() As String = System.IO.File.ReadAllLines(Pfad)

        Dim DT_LoAus As New DataTable

        'Columns definieren
        DT_LoAus.Columns.Add("Material", Type.GetType("System.String"))
        DT_LoAus.Columns.Add("Text", Type.GetType("System.String"))


        'Text Datei in Datatable schreiben
        Dim dr As DataRow = DT_LoAus.NewRow
        For Each l As String In Lines
            dr = DT_LoAus.NewRow
            Dim split() As String = l.Split(";")
            dr("Material") = split(0)
            dr("Text") = split(1)
            DT_LoAus.Rows.Add(dr)
        Next



        'Item erstellen und an Gruppe zuweisen
        Dim countList As Integer = list.Count
        For Each item In globaleFunktionen.GetStuecklisteFromSAPXML(Material, Auftrag)
            Dim Lagerort As String = item.LO
            For Each r In DT_LoAus.AsEnumerable
                If item.Material = r.Field(Of String)("Material") Then
                    Lagerort = r.Field(Of String)("Text")
                    Exit For
                End If
            Next

            Dim index = list.IndexOf(item.vrg)
            Dim Stuck As Double = 0
            Stuck = Math.Ceiling(Soll * item.STK)
            LV_Stuli.Items.Add(New ListViewItem(New String() {item.PLO, item.Material, item.Pos_Text, Lagerort, Stuck & " " & item.einheit}, LV_Stuli.Groups(index)))
        Next
    End Sub

    Private Sub AddGroup(ByRef gruppe As String)
        LV_Stuli.Groups.Add(New ListViewGroup(gruppe, HorizontalAlignment.Left))
    End Sub

    Private Sub frm_Stueckliste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Stückliste" & vbCrLf & "Material: " & Mat.Replace("$", "/") & " FAUF: " & FAUF
        LV_Stuli.SelectedItems.Clear()

    End Sub

    Private Sub LV_Stuli_DoubleClick(sender As Object, e As EventArgs) Handles LV_Stuli.DoubleClick
        For Each lvi As ListViewItem In LV_Stuli.SelectedItems
            If Not lvi.BackColor = Color.Red Then
                lvi.BackColor = Color.LightGreen
            End If
        Next
        LV_Stuli.SelectedItems.Clear()
    End Sub

    Private Sub GrünMarkierenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrünMarkierenToolStripMenuItem.Click
        For Each lvi As ListViewItem In LV_Stuli.SelectedItems
            If Not lvi.BackColor = Color.Red Then
                lvi.BackColor = Color.LightGreen
            End If
        Next
        LV_Stuli.SelectedItems.Clear()
    End Sub

    Private Sub FehlmaterialMeldenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FehlmaterialMeldenToolStripMenuItem.Click
        Dim Tbl_ProdKontrolleTableAdapter As New DS_ProdKontrolleTableAdapters.tbl_ProdKontrolleTableAdapter

        For Each lvi As ListViewItem In LV_Stuli.SelectedItems
            Tbl_ProdKontrolleTableAdapter.InsertQuery(Now, Linie, Mat, FAUF, Soll, Ist, "offen", "Fehlmaterial", lvi.SubItems(ListViewSubItems.Material).Text & " - " & lvi.SubItems(ListViewSubItems.Kurztext).Text, Vorg1)
            lvi.BackColor = Color.Red
        Next
        FM = True
        LV_Stuli.SelectedItems.Clear()
    End Sub

    Private Sub frm_Stueckliste_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If FM = True Then
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub AusschussBuchenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AusschussBuchenToolStripMenuItem.Click

    End Sub
End Class