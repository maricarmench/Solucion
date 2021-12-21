'27/10/2021 Imports Studio_Telko_Sync.EntityClasses
'27/10/2021 Imports Studio_Telko_Sync.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses

Public Class Tenant
    Shared Tenant As TenantEntity = Nothing

    Public Shared Function VerificarTenant(ByVal strConexion As String, ByVal bolDebug As Boolean, ByRef entitiesTenant As IEnumerable(Of TenantEntity)) As Boolean
        Try
            'Consulto la tabla Tenant de STS para consultar Clientes y su ultima fecha de actualización
            '27/102021 Using adapterTenant As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterTenant As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                '27/10/2021 Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterTenant)
                Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapterTenant)
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
            'Using adapterTenant As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterTenant As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
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
