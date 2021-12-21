'27/10/2021 Imports Studio_Telko_Sync.EntityClasses
Imports Studio.Phone.DAL.EntityClasses

Public Class EntidadesADistribuir
    Public Shared Function VerificarEntidadesADistribuir(ByVal strConexion As String, ByVal bolDebug As Boolean, ByRef entitiesDis As IEnumerable(Of EntitiyDistribucionEntity)) As Boolean

        Try
            'Consulto la tabla EntitiyDistribucion de STS para consultar las tablas a distribuir
            'Dim entitiesDis As IEnumerable(Of EntitiyDistribucionEntity) = Nothing
            '27/10/21 Using adapterEntitiyDistribucion As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterEntitiyDistribucion As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                '27/10/2021 Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterEntitiyDistribucion)
                Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapterEntitiyDistribucion)
                Dim q = (From c In metaData.EntitiyDistribucion Order By c.Orden Select c)
                entitiesDis = q.ToList()
            End Using

            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-EntidadesADistribuir", "Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-EntidadesADistribuir... Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, True)
            Return False
        End Try
    End Function
End Class
