Imports System.Configuration

Public Class MonitorCliente
#Region "DEFINICION DE ATRIBUTOS"
    Private intHoraInicioOperaciones As Integer = 0
    Private intMinInicioOperaciones As Integer = 0
    Private intHoraFinOperaciones As Integer = 0
    Private intMinFinOperaciones As Integer = 0
    Private intTopeGuid As Integer = 0
    Private intTenantid As Integer = 0
    Private strUrlServicioWeb As String
    Private strFormatoDecimal As String
    Private strDecimal As String
    Private bolDebug As Boolean = False
    Private bolInicio As Boolean = False
    Private intMin_Timer As Integer = 0
    Public timer As New Timers.Timer
    Public bolLoad As Boolean = True
#End Region

#Region "ONSTART"
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        'VARIABLES
        Dim strHoraInicioOperaciones As String = ""
        Dim strMinInicioOperaciones As String = ""
        Dim strHoraFinOperaciones As String = ""
        Dim strMinFinOperaciones As String = ""
        Dim strTopeGuid As String = ""
        Dim strTenantid As String = ""
        Dim strMin_Timer As String = ""
        Dim strDebug As String = ""
        Dim bolIniciarServicio As Boolean = True

        Try
            'OBTENIENDO LOS VALORES DE INICIO DE TODAS LAS OPERACIONES
            strHoraInicioOperaciones = ConfigurationManager.AppSettings("HoraInicio_Operaciones").ToString()
            strMinInicioOperaciones = ConfigurationManager.AppSettings("MinInicio_Operaciones").ToString()
            strHoraFinOperaciones = ConfigurationManager.AppSettings("HoraFin_Operaciones").ToString()
            strMinFinOperaciones = ConfigurationManager.AppSettings("Minfin_Operaciones").ToString()
            strTopeGuid = ConfigurationManager.AppSettings("TopeGUID").ToString()
            strTenantid = ConfigurationManager.AppSettings("TenantID").ToString()
            strUrlServicioWeb = ConfigurationManager.AppSettings("UrlServicioWeb").ToString()
            strMin_Timer = ConfigurationManager.AppSettings("Min_Timer").ToString()
            strDebug = ConfigurationManager.AppSettings("Debug").ToString()

#Region "VALIDACION DE QUE LAS VARIABLES TENGAN DATOS"
            If strHoraInicioOperaciones IsNot "" AndAlso strHoraFinOperaciones IsNot "" Then
                intHoraInicioOperaciones = Convert.ToInt32(strHoraInicioOperaciones)
                intHoraFinOperaciones = Convert.ToInt32(strHoraFinOperaciones)
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado una hora de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado una hora de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strMinInicioOperaciones IsNot "" AndAlso strMinFinOperaciones IsNot "" Then
                intMinInicioOperaciones = Convert.ToInt32(strMinInicioOperaciones)
                intMinFinOperaciones = Convert.ToInt32(strMinFinOperaciones)
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado el Minuto de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado el Minuto de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strMin_Timer IsNot "" Then
                intMin_Timer = Convert.ToInt32(strMin_Timer)
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado el intervalo de tiempo entre corrida de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado el intervalo de tiempo entre corrida de las Operaciones. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strTopeGuid IsNot "" Then
                intTopeGuid = Convert.ToInt32(strTopeGuid)
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado el tope de registros a procesar. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado el tope de registros a procesar. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strTenantid IsNot "" Then
                intTenantid = Convert.ToInt32(strTenantid)
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado el ID del Cliente. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado el ID del Cliente. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strUrlServicioWeb = "" Then
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado la URL del Servicio Web. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado la URL del Servicio Web. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            If strDebug <> "" Then
                If strDebug = "S" Then
                    bolDebug = True
                Else
                    bolDebug = False
                End If
            Else
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "No se ha configurado la variable de Debug. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... No se ha configurado la variable de Debug. Por favor revisar el archivo de configuración del Monitor Cliente de Telko", True)
                bolIniciarServicio = False
            End If

            ' NO OCURRIERON ERRORES
            If bolIniciarServicio Then
                Dim timer As Timers.Timer = New Timers.Timer()
                timer.Interval = intMin_Timer * 1000 * 60
                AddHandler timer.Elapsed, AddressOf Timer_Procesos_Tick
                timer.Start()
                EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "Monitor Cliente de Telko Iniciado, lapso de corrida configurado (min):" & strMin_Timer, EventLogEntryType.Information)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... Monitor Cliente de Telko Iniciado, lapso de corrida configurado (min):" & strMin_Timer, True)
            Else
                Stop
            End If
#End Region
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-Start", "Ha ocurrido un error iniciando el servicio del Monitor. Error:" & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Start... Ha ocurrido un error iniciando el servicio del Monitor. Error:" & ex.Message, True)
            bolIniciarServicio = False
        End Try
    End Sub
#End Region

#Region "ONSTOP"
    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        EventViewerMonitor.addToEventViewer("MonitorCliente-Stop", "Monitor Cliente de Telko Detenido", EventLogEntryType.Information)
        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Stop... Monitor Cliente de Telko Detenido", True)
    End Sub
#End Region

#Region "EJECUCION DEL TIMER DE PROCESOS"
    Private Sub Timer_Procesos_Tick(sender As Object, e As EventArgs) Handles Timer_Procesos.Tick
#Region "DECLARACION DE VARIABLES LOCALES"
        Dim dtFechaActual As Date = Date.Now
        Dim strFecha As String = dtFechaActual.Day.ToString().PadLeft(2, "0") + dtFechaActual.Month.ToString().PadLeft(2, "0") + dtFechaActual.Year.ToString() + dtFechaActual.Hour.ToString().PadLeft(2, "0") + dtFechaActual.Minute.ToString().PadLeft(2, "0") + dtFechaActual.Second.ToString().PadLeft(2, "0")
        Dim intHoraActual As Integer = Date.Now.Hour
        Dim intMinutoActual As Integer = Date.Now.Minute
        Dim strNombreArchivo As String = ""
        Dim bolInicioOperaciones As Boolean = False
        Dim bolNoCargar As Boolean = True
        Dim strConexion_SV As String
        Dim strConexion_TSV As String
        Dim IdGuids As String = ""
        Dim ArrGuid() As String
        Dim StrGuid As Object
        Dim CuentaArchivo As Integer = 0
        Dim ResultGet As String = ""
        Dim ResultDelete As String = ""
#End Region
        ' SE OBTIENE LOS STRING DE CONEXION A LAS BASES DE DATOS
        strConexion_SV = ConfigurationManager.AppSettings("strConnDBStudio_Vision").ToString()
        strConexion_TSV = ConfigurationManager.AppSettings("strConnTelko_Vision").ToString()

        EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Inicio de operaciones", EventLogEntryType.Information)
        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Inicio de operaciones", True)
        If bolInicio = False Then
            bolInicio = True
            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Verificando archivos de actualización", EventLogEntryType.Information)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Verificando archivos de actualización", True)

            Try
                ' INSERTA EN EL EVENT VIEWER
                If bolDebug Then
                    EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Inicio del Timer de Procesos Cliente Telko", EventLogEntryType.Information)
                    Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Inicio del Timer de Procesos Cliente Telko", True)
                End If

                'CHEQUEO DE LA HORA DE PROCESAMIENTO DE LAS OPERACIONES
                If (intHoraInicioOperaciones = intHoraActual) And (intMinInicioOperaciones <= intMinutoActual) Then
                    If (intHoraFinOperaciones > intHoraActual) Then
                        bolInicioOperaciones = True
                    ElseIf (intHoraFinOperaciones = intHoraActual) And (intMinFinOperaciones > intMinutoActual) Then
                        bolInicioOperaciones = True
                    End If
                ElseIf (intHoraInicioOperaciones < intHoraActual) Then
                    If intHoraFinOperaciones > intHoraActual Then
                        bolInicioOperaciones = True
                    ElseIf (intHoraFinOperaciones = intHoraActual) And (intMinFinOperaciones > intMinutoActual) Then
                        bolInicioOperaciones = True
                    End If
                End If

                'ESTA EN HORARIO DE CORRIDA DE LAS OPERACIONES
                If bolInicioOperaciones Then
                    ' INSERTA EN EL EVENT VIEWER
                    If bolDebug Then
                        EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Inicio de operaciones", EventLogEntryType.Information)
                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Inicio de operaciones", True)
                    End If

                    'EJECUTA EL PROCESO DE DISTRIBUCION
                    bolLoad = True
                    ResultGet = ""
                    ''*** SE ELIMINO EL USO DEL SERVICIO WEB ****
                    ''ResultGet = MetodosServicio.GetPost(strUrlServicioWeb, intTenantid, intTopeGuid, bolDebug)
                    ''If ResultGet = "FALLO" Then bolLoad = False
                    ''*** FIN DE SE ELIMINO EL USO DEL SERVICIO WEB ****

                    ResultGet = MetodosServicio.GetTrama(strConexion_TSV, intTenantid, intTopeGuid, bolDebug)
                    If ResultGet = "FALLO" Then bolLoad = False

                    If bolLoad Then
                        ' SE PROCESAN LAS ENTIDADES A DISTRIBUIR Y SE Des-SERIALIZA EL JSON a DTO
                        bolLoad = ProcesarEntidades.ProcesarEntidadesAActualizar(strConexion_SV, strConexion_SV, bolDebug, ResultGet, IdGuids, CuentaArchivo)

                        If bolLoad Then
                            If IdGuids <> "" Then
                                'Split value in variable IdGuids using delimiting character;
                                ArrGuid = Split(IdGuids, ";")
                                'Iterate through each substring
                                For Each StrGuid In ArrGuid
                                    ''*** SE ELIMINO EL USO DEL SERVICIO WEB ****
                                    ''ResultDelete = MetodosServicio.DeleteValue(strUrlServicioWeb, Trim(StrGuid), bolDebug)
                                    ''If ResultDelete = "FALLO" Then bolLoad = False
                                    ''*** FIN DE SE ELIMINO EL USO DEL SERVICIO WEB ***

                                    Dim gudNumeroGuid As Guid
                                    gudNumeroGuid = Guid.Parse(Trim(StrGuid))
                                    ResultDelete = MetodosServicio.DeleteTrama(strConexion_TSV, gudNumeroGuid, bolDebug)
                                    If ResultDelete = "FALLO" Then bolLoad = False
                                Next
                            End If
                        End If
                        EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Se procesaron " & CuentaArchivo & " Archivos para el TenantId: " & intTenantid, EventLogEntryType.Information)
                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Se procesaron " & CuentaArchivo & " Archivos para el TenantId: " & intTenantid, True)
                    End If

                    ' DETERMINA SI EL PROCESO CORRIO SIN ERRORES
                    If bolLoad Then
                        If bolDebug Then
                            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Proceso ejecutado exitosamente", EventLogEntryType.Information)
                            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Proceso ejecutado exitosamente", True)
                        End If
                    Else
                        If ResultGet = "FALLO" Then
                            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Falló el proceso de actualización de entidades -- No se pudo conectar al Servicio Web", EventLogEntryType.Error)
                            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Falló el proceso de actualización de entidades -- No se pudo conectar al Servicio Web", True)
                        Else
                            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Falló el proceso de actualización de entidades", EventLogEntryType.Error)
                            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Falló el proceso de actualización de entidades", True)
                        End If
                    End If
                Else
                    EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Horario fuera de corrida", EventLogEntryType.Information)
                    Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Horario fuera de corrida", True)
                End If ' Fin de If bolInicioOperaciones Then
            Catch ex As Exception
                EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Ha ocurrido un error en el monitor cliente de procesos. Error: " & ex.Message, EventLogEntryType.Error)
                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Ha ocurrido un error en el monitor cliente de procesos. Error: " & ex.Message, True)
                bolInicio = False
            End Try
            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "Archivos de actualización finalizada", EventLogEntryType.Information)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... Archivos de actualización finalizada", True)
            bolInicio = False
        Else
            EventViewerMonitor.addToEventViewer("MonitorCliente-Timer", "en proceso...", EventLogEntryType.Information)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-Timer... En proceso...", True)
        End If ' fin de If bolInicio = False Then
    End Sub
#End Region

End Class
