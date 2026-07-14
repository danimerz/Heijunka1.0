Imports System.ComponentModel

Public Class frm_Ruckstand

    Public Sub New(Data As DataTable, Linie As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        'ProdKontrolle Tabele Laden
        Dim tbl_Prod_Kont As DataTable = Tbl_ProdKontrolleTableAdapter.GetData

        ' Datatable in Tabele füllen
        Dim i As Integer = 0
        For Each row As DataRow In Data.AsEnumerable
            Dim Grund As String = ""

            Dim Query = From item In tbl_Prod_Kont
                        Where row("Auftrag") = item.Field(Of String)("FAUF")

            For Each r In Query.AsEnumerable
                If Not r("Zusatz") = "" Then
                    Grund = r("Grund") & ": " & r("Zusatz")
                Else
                    Grund = r("Grund")
                End If
            Next

            DGV_Ruck.Rows.Add(row("Material"))
            DGV_Ruck.Rows(i).Cells(1).Value = row("Auftrag")
            DGV_Ruck.Rows(i).Cells(2).Value = row("SpatStartDat")
            DGV_Ruck.Rows(i).Cells(3).Value = CInt(row("Vorgangsmenge"))
            DGV_Ruck.Rows(i).Cells(4).Value = row("Ablieferort")
            DGV_Ruck.Rows(i).Cells(5).Value = row("Anwenderstatus")
            DGV_Ruck.Rows(i).Cells(6).Value = Grund

            i = i + 1
        Next

        lbl_titel.Text = "Rückstände " & Linie & ", per " & Now.ToShortDateString
        Me.Text = "Rückstände " & Linie

    End Sub

    Private Sub frm_Ruckstand_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Der vorherige zweite Fill von Me.DS_ProdKontrolle.tbl_ProdKontrolle hier war komplett
        'redundant (nochmal die volle, ungefilterte Tabelle laden) - das Ergebnis wurde nirgends
        'gelesen, die Anzeige nutzt ausschliesslich die im Konstruktor bereits aufbereiteten Daten.
        'Der BackgroundWorker BGW_RS_Load wurde nie gestartet (alle Handler waren leer) und wurde
        'entfernt.
        If DGV_Ruck.Rows.Count > 0 Then
            DGV_Ruck.CurrentCell.Selected = False
        End If
    End Sub
End Class