Imports System.ComponentModel

Public Class Form1

    Public arr(3) As Boolean
    Dim WithEvents el As New System.ComponentModel.BackgroundWorker With {.WorkerReportsProgress = True, .WorkerSupportsCancellation = True}



    Public Sub eventlistener()
        For j = 0 To arr.Count - 1
            For i = 0 To arr.Count - 1
                If arr(i) = True Then
                    If i > 0 Then
                        If arr(i - 1) = False Then 'Prüfen ob platz im vorherhergenden Platz ist
                            arr(i) = False 'Wenn vorhergender paltz Frei, nummer leeren
                            arr(i - 1) = True 'Wert in den Platz zuvor schieben
                        End If
                    End If
                End If
            Next
        Next
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        arr(0) = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        arr(1) = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        arr(2) = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        arr(3) = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        For i = 0 To arr.Count - 1
            arr(i) = False
        Next
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox1.Text = ""
        For i = 0 To arr.Count - 1
            TextBox1.Text += arr(i).ToString & vbCrLf
        Next
    End Sub

    Private Sub el_DoWork(sender As Object, e As DoWorkEventArgs) Handles el.DoWork
        eventlistener()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not el.IsBusy Then
            el.RunWorkerAsync()
        End If
    End Sub

    Private Sub el_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles el.RunWorkerCompleted
        TextBox1.Text = ""
        For i = 0 To arr.Count - 1
            TextBox1.Text += arr(i).ToString & vbCrLf
        Next
    End Sub
End Class
