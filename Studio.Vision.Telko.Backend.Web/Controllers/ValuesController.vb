Imports System.Net
Imports System.Web.Http
Imports Studio_Telko_Sync.EntityClasses

Public Class ValuesController
    Inherits ApiController
    Dim entitiesTenant As IEnumerable(Of TenantEntity)
    Dim strConexion_STS = ConfigurationManager.AppSettings("strConnDBStudio_Telko_Sync").ToString()

    '' GET api/values
    'Public Function GetValues() As IEnumerable(Of String)
    'Return New String() {"value1", "value2"}
    'End Function

    ' GET api/values
    Public Function GetValues() As IEnumerable(Of TenantEntity)
        'Consulto la tabla Tenant de STS para consultar Clientes y su ultima fecha de actualización
        Using adapterTenant As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(ConfigurationManager.AppSettings("strConnDBStudio_Telko_Sync").ToString())
            Dim metaData = New Studio_Telko_Sync.Linq.LinqMetaData(adapterTenant)
            Dim q = (From c In metaData.Tenant Select c Where c.Activo = True)
            entitiesTenant = q.ToList()
        End Using

        Return entitiesTenant
    End Function

    ' GET api/values/5
    Public Function GetValue(ByVal id As Integer, ByVal TopeRegistros As Integer) As String
        Return Studio.Vision.Telko.Shared.DistribucionRegistro.GetDistribucionRegistro(strConexion_STS, id, TopeRegistros)
    End Function
    'Public Function GetValue(ByVal id As Integer) As String
    '    Return "value"
    'End Function

    ' POST api/values
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/values/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/values/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class
