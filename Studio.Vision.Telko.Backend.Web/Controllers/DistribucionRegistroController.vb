Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports SD.LLBLGen.Pro.ORMSupportClasses
'29/10/2021 Imports Studio_Telko_Sync.EntityClasses
'29/10/2021 Imports Studio_Telko_Sync.HelperClasses

Namespace Controllers
    Public Class DistribucionRegistroController
        Inherits ApiController
        Dim httpResponseMessage As HttpResponseMessage
        Dim strMessage As String
        ' 29/10/2021 Dim strConexion_STS = ConfigurationManager.AppSettings("strConnDBStudio_Telko_Sync").ToString()
        Dim strConexion_SV = ConfigurationManager.AppSettings("strConnDBStudio_Vision").ToString()

        ' GET: api/DistribucionRegistro
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/DistribucionRegistro/5
        Public Function GetValue(ByVal id As Integer, ByVal TopeRegistros As Integer) As String
            Try
                strMessage = Studio.Vision.Telko.Shared.DistribucionRegistro.GetDistribucionRegistro(strConexion_SV, id, TopeRegistros)
                If (strMessage = "") Then
                    httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, "id inválido")
                    strMessage = httpResponseMessage.ToString().Substring(0, httpResponseMessage.ToString().IndexOf("Version") - 3)
                    Return strMessage
                Else
                    Return strMessage
                End If
            Catch ex As Exception
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("Controllers DistribucionRegistroController... Ha ocurrido un error en Function GetValue: " & ex.Message, True)
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message)
                strMessage = httpResponseMessage.ToString().Substring(0, httpResponseMessage.ToString().IndexOf("Version") - 3)
                Return strMessage
            End Try
        End Function

        ' POST: api/DistribucionRegistro
        Public Sub PostValue(<FromBody()> ByVal value As String)

        End Sub

        ' PUT: api/DistribucionRegistro/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/DistribucionRegistro/5
        Public Function DeleteValue(ByVal id As String) As String
            Try
                Dim gudNumeroGuid As Guid
                gudNumeroGuid = Guid.Parse(id.ToString())
                Studio.Vision.Telko.Shared.DistribucionRegistro.DeleteDistribucionRegistro(strConexion_SV, gudNumeroGuid)
                'Version
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, "OK")
                strMessage = httpResponseMessage.ToString().Substring(0, httpResponseMessage.ToString().IndexOf("Version") - 3)

                Return strMessage
            Catch ex As Exception
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("Controllers DistribucionRegistroController... Ha ocurrido un error en Function DeleteValue: " & ex.Message, True)
                httpResponseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message)
                strMessage = httpResponseMessage.ToString().Substring(0, httpResponseMessage.ToString().IndexOf("Version") - 3)
                Return strMessage
            End Try
        End Function
    End Class
End Namespace