Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class MetodosServicio
    Public Shared Function GetPost(ByVal url As String, ByVal miID As Integer, ByVal miTope As Integer, ByVal bolDebug As Boolean) As String
        Dim responseFromServer As String = ""
        Try
            ' Create a request for the URL. 
            Dim request As HttpWebRequest = WebRequest.Create(url & miID & "?TopeRegistros=" & miTope)
            request.Method = "GET"
            request.ContentType = "application/json"
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            responseFromServer = reader.ReadToEnd()
            ' Clean up the streams and the response.
            reader.Close()
            response.Close()
            Return responseFromServer
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-MetodosServicio", "Ha ocurrido un error en el monitor de cliente del método GetPost: Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-MetodosServicio... Ha ocurrido un error en el monitor de cliente del método GetPost: Error: " & ex.Message, True)
            Return responseFromServer = "FALLO"
        End Try
    End Function

    Public Shared Function DeleteValue(ByVal url As String, ByVal miGUID As String, ByVal bolDebug As Boolean) As String
        Dim responseFromServer As String = ""
        Try
            ' Create a request for the URL. 
            Dim request As HttpWebRequest = WebRequest.Create(url & miGUID)
            request.Method = "DELETE"
            request.ContentType = "application/json"
            ' Get the response.
            Dim response As WebResponse = request.GetResponse()
            ' Get the stream containing content returned by the server.
            Dim dataStream As Stream = response.GetResponseStream()
            ' Open the stream using a StreamReader for easy access.
            Dim reader As New StreamReader(dataStream)
            ' Read the content.
            responseFromServer = reader.ReadToEnd()
            ' Clean up the streams and the response.
            reader.Close()
            response.Close()
            Return responseFromServer
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-MetodosServicio", "Ha ocurrido un error en el monitor de cliente del método DeleteValue: Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-MetodosServicio... Ha ocurrido un error en el monitor de cliente del método DeleteValue: Error: " & ex.Message, True)
            Return responseFromServer = "FALLO"
        End Try
    End Function
    Public Shared Function GetTrama(ByVal Conexion As String, ByVal miID As Integer, ByVal miTope As Integer, ByVal bolDebug As Boolean) As String
        Dim responseFromServer As String = ""
        Dim strMessage As String
        Try

            strMessage = Studio.Vision.Telko.Shared.DistribucionRegistro.GetDistribucionRegistro(Conexion, miID, miTope)
            responseFromServer = JsonConvert.SerializeObject(strMessage)
            Return responseFromServer
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-MetodosServicio", "Ha ocurrido un error en el monitor de cliente del método GetTrama: Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-MetodosServicio... Ha ocurrido un error en el monitor de cliente del método GetTrama: Error: " & ex.Message, True)
            Return responseFromServer = "FALLO"
        End Try
    End Function

    Public Shared Function DeleteTrama(ByVal Conexion As String, ByVal miGUID As Guid, ByVal bolDebug As Boolean) As String
        Dim responseFromServer As String = ""
        Try
            Studio.Vision.Telko.Shared.DistribucionRegistro.DeleteDistribucionRegistro(Conexion, miGUID)
            responseFromServer = "OK"
            Return responseFromServer
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-MetodosServicio", "Ha ocurrido un error en el monitor de cliente del método DeleteValue: Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-MetodosServicio... Ha ocurrido un error en el monitor de cliente del método DeleteValue: Error: " & ex.Message, True)
            Return responseFromServer = "FALLO"
        End Try
    End Function

End Class
