Imports Studio_Telko_Sync.EntityClasses
Imports Studio_Telko_Sync.HelperClasses

Public Class Tenant
    Shared Tenant As TenantEntity = Nothing

    Public Shared Function VerificarTenant(ByVal strConexion As String, ByVal bolDebug As Boolean, ByRef entitiesTenant As IEnumerable(Of TenantEntity)) As Boolean
        Try
            'Consulto la tabla Tenant de STS para consultar Clientes y su ultima fecha de actualización
            Using adapterTenant As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
                Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterTenant)
                Dim q = (From c In metaData.Tenant Select c Where c.Activo = True)
                entitiesTenant = q.ToList()
            End Using
            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Tenant", "Ha ocurrido un error en el monitor de procesos." & VerificarTenant & " Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-Tenant... Ha ocurrido un error en el monitor de procesos." & VerificarTenant & " Error: " & ex.Message, True)
            Return False
        End Try
    End Function

    Public Shared Function ActualizarFechaTenant(ByVal strConexion As String, ByVal bolDebug As Boolean, ByVal intTenantID As Integer) As Boolean
        Try
            ''SE MODIFICA EN LA TABLA Tenant de STS
            Dim bucket As New RelationPredicateBucket(TenantFields.Id = intTenantID)
            Dim updateValuesTenant As New TenantEntity()
            updateValuesTenant.FechaActualizacion = DateTime.Now
            Using adapterTenant As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
                Dim amountUpdated As Integer = adapterTenant.UpdateEntitiesDirectly(updateValuesTenant, bucket)
            End Using
            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Tenant", "Ha ocurrido un error en el monitor de procesos." & ActualizarFechaTenant & " Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-Tenant... Ha ocurrido un error en el monitor de procesos." & ActualizarFechaTenant & " Error: " & ex.Message, True)
            Return False
        End Try
    End Function
End Class
