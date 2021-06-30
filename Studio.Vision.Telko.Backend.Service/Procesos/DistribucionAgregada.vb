Imports Studio_Telko_Sync.EntityClasses

Public Class DistribucionAgregada

    Public Shared Function VerificarEntidadesADistribuirAgregadas(ByVal strConexion As String, ByVal bolDebug As Boolean, ByRef entitiesDis As IEnumerable(Of Studio.Vision.Telko.Shared.Entity_EntiyAgregVM)) As Boolean

        Try
            'Consulto la tabla EntitiyDistribucion de STS para consultar las tablas a distribuir
            'Dim entitiesDis As IEnumerable(Of EntityDistribucionAgregadaEntity) = Nothing
            Using adapterEntitiyDistribucion As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
                Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterEntitiyDistribucion)

                Dim q = From c In metaData.EntityDistribucionAgregada
                        Join ed In metaData.EntitiyDistribucion
                         On c.EntityAgregadaId Equals ed.Id
                        Order By c.EntityId
                        Select New Studio.Vision.Telko.Shared.Entity_EntiyAgregVM With
                         {
                            .EntityHijaID = ed.Id,
                            .EntityMadreID = c.EntityId,
                            .EntityName = ed.EntityName
                         }
                entitiesDis = q.ToList()
            End Using

            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-DistribucionAgregada", "Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-DistribucionAgregada... Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, True)
            Return False
        End Try
        Return True
    End Function
    Public Shared Function FiltrarEntidadesADistribuirAgregadas(ByVal strConexion As String, ByVal bolDebug As Boolean, ByVal intIDMadre As Integer, ByRef entitiesDis As IEnumerable(Of Studio.Vision.Telko.Shared.Entity_EntiyAgregVM)) As Boolean

        Try
            'Consulto la tabla EntitiyDistribucion de STS para consultar las tablas a distribuir
            Using adapterEntitiyDistribucion As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
                Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterEntitiyDistribucion)

                If intIDMadre <> 0 Then
                    Dim q = From c In metaData.EntityDistribucionAgregada
                            Join ed In metaData.EntitiyDistribucion
                            On c.EntityAgregadaId Equals ed.Id
                            Where c.EntityId = intIDMadre
                            Order By c.EntityId
                            Select New Studio.Vision.Telko.Shared.Entity_EntiyAgregVM With
                             {
                                .EntityHijaID = ed.Id,
                                .EntityMadreID = c.EntityId,
                                .EntityName = ed.EntityName
                             }
                    entitiesDis = q.ToList()
                Else
                    Dim q = From c In metaData.EntityDistribucionAgregada
                            Join ed In metaData.EntitiyDistribucion
                             On c.EntityAgregadaId Equals ed.Id
                            Order By c.EntityId
                            Select New Studio.Vision.Telko.Shared.Entity_EntiyAgregVM With
                             {
                                .EntityHijaID = ed.Id,
                                .EntityMadreID = c.EntityId,
                                .EntityName = ed.EntityName
                             }
                    entitiesDis = q.ToList()
                End If
            End Using
            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-DistribucionAgregada", "Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-DistribucionAgregada... Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, True)
            Return False
        End Try
        Return True
    End Function
End Class
