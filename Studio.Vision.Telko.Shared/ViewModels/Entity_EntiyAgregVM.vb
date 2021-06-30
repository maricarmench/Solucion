Public Class Entity_EntiyAgregVM
    Private _EntityHijaID As Integer
    Private _EntityMadreID As Integer
    Private _EntityName As String

    Public Property EntityHijaID As Integer
        Get
            Return _EntityHijaID
        End Get
        Set(value As Integer)
            _EntityHijaID = value
        End Set
    End Property
    Public Property EntityMadreID As Integer
        Get
            Return _EntityMadreID
        End Get
        Set(value As Integer)
            _EntityMadreID = value
        End Set
    End Property
    Public Property EntityName As String
        Get
            Return _EntityName
        End Get
        Set(value As String)
            _EntityName = value
        End Set
    End Property

End Class
