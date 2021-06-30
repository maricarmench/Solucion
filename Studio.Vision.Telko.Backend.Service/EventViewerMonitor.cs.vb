Public Class EventViewerMonitor
#Region "VARIABLES PUBLICAS"
    Private Shared strLogName As String = "MonitorProcesos-TELKO"
#End Region

#Region "EVENT-VIEWER"
    Public Shared Sub addToEventViewer(ByVal strApplicationName As String, ByVal strMessage As String, ByVal entryType As EventLogEntryType)
        Try
            Dim evtLog As EventLog = New EventLog()
            If Not EventLog.Exists(strLogName) Then
                EventLog.CreateEventSource(strApplicationName, strLogName)
            End If

            evtLog.Log = strLogName
            evtLog.Source = strApplicationName
            If strMessage.Length >= 32766 Then
                strMessage = strMessage.Substring(0, 30000) & "..."
            Else
                strMessage = strMessage
            End If
            evtLog.WriteEntry(strMessage, entryType, 1)
        Catch exp As Exception
            Dim myLog As EventLog = New EventLog()
            myLog.Log = "Application"
            myLog.Source = "MonitorProcesos-TELKO"
            myLog.WriteEntry(exp.Message, entryType)
        End Try
    End Sub

#End Region

End Class
