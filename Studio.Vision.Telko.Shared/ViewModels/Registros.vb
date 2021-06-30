Public Class Registros
    Private _PaqueteRegistros As String
    Public Property PaqueteRegistros As String
        Get
            Return _PaqueteRegistros
        End Get
        Set(value As String)
            _PaqueteRegistros = value
        End Set
    End Property
End Class
