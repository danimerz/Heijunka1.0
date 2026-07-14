Module Extensions
    <System.Runtime.CompilerServices.Extension()>
    Public Sub InvokeIfRequired(ByVal Control As Control, ByVal Method As [Delegate], ByVal ParamArray Parameters As Object())
        If Parameters IsNot Nothing AndAlso
        Parameters.Length = 0 Then Parameters = Nothing
        If Control.InvokeRequired = True Then
            Control.Invoke(Method, Parameters)
        Else
            Method.DynamicInvoke(Parameters)
        End If
    End Sub
End Module
