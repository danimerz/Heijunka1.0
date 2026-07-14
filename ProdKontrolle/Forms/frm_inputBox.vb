Public Class frm_inputBox

    Private _TitelText As String
    Private _inputText As String
    Private _FrageText As String

    Public Property TitelText As String
        Set(value As String)
            _TitelText = value
        End Set
        Get
            Return _TitelText
        End Get
    End Property
    Public Property inputText As String
        Set(value As String)
            _inputText = value
        End Set
        Get
            Return _inputText
        End Get
    End Property
    Public Property FrageText As String
        Set(value As String)
            _FrageText = value
        End Set
        Get
            Return _FrageText
        End Get
    End Property

    Public Sub New(Titel As String, Text As String, Frage As String)

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        TitelText = Titel
        inputText = Text
        FrageText = Frage

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub frm_inputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = TitelText
        Label1.Text = FrageText
        TextBox1.Text = inputText
    End Sub
End Class