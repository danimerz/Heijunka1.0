Public Class HeijunkaAnzeige
    Public _Material As String
    Public Property Material() As String
        Get
            Return _Material
        End Get
        Set(ByVal value As String)
            _Material = value
        End Set
    End Property

End Class
