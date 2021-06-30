Imports System.Configuration
Imports System.Threading
Imports Studio.Vision.Telko.Backend.Service
Imports System.Timers
Imports Studio_Telko_Sync.EntityClasses
Imports System.Globalization
'Imports System.IO

Imports System.Diagnostics
Imports System.Reflection


Public Class Form1
#Region "DEFINICION DE ATRIBUTOS"
    Private intHoraInicioOperaciones As Integer = 0
    Private intMinInicioOperaciones As Integer = 0
    Private intHoraFinOperaciones As Integer = 0
    Private intMinFinOperaciones As Integer = 0
    Private strFormatoDecimal As String
    Private strDecimal As String
    Private bolDebug As Boolean = False
    Private bolInicio As Boolean = False
    Private intMin_Timer As Integer = 0
    Public timer As New Timers.Timer
    Public bolLoad As Boolean = True
    'Private Timer_Procesos_Tick As Timers.Timer = Nothing
#End Region
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        'VARIABLES
        Dim strHoraInicioOperaciones As String = ""
        Dim strMinInicioOperaciones As String = ""
        Dim strHoraFinOperaciones As String = ""
        Dim strMinFinOperaciones As String = ""
        Dim strMin_Timer As String = ""
        Dim strDebug As String = ""
        Dim bolIniciarServicio As Boolean = True

        Try
            'OBTENIENDO LOS VALORES DE INICIO DE TODAS LAS OPERACIONES
            strHoraInicioOperaciones = ConfigurationManager.AppSettings("HoraInicio_Operaciones").ToString()
            strMinInicioOperaciones = ConfigurationManager.AppSettings("MinInicio_Operaciones").ToString()
            strHoraFinOperaciones = ConfigurationManager.AppSettings("HoraFin_Operaciones").ToString()
            strMinFinOperaciones = ConfigurationManager.AppSettings("Minfin_Operaciones").ToString()
            strMin_Timer = ConfigurationManager.AppSettings("Min_Timer").ToString()
            strDebug = ConfigurationManager.AppSettings("Debug").ToString()

#Region "VALIDACION DE QUE LAS VARIABLES TENGAN DATOS"
            If strHoraInicioOperaciones IsNot "" AndAlso strHoraFinOperaciones IsNot "" Then
                intHoraInicioOperaciones = Convert.ToInt32(strHoraInicioOperaciones)
                intHoraFinOperaciones = Convert.ToInt32(strHoraFinOperaciones)
            Else
                EventViewerMonitor.addToEventViewer("MonitorProcesos-Start", "No se ha configurado una hora de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", EventLogEntryType.Error)
                anotaMensaje("MonitorProcesos-Start...No se ha configurado una hora de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", True)
                bolIniciarServicio = False
            End If

            If strMinInicioOperaciones IsNot "" AndAlso strMinFinOperaciones IsNot "" Then
                intMinInicioOperaciones = Convert.ToInt32(strMinInicioOperaciones)
                intMinFinOperaciones = Convert.ToInt32(strMinFinOperaciones)
            Else
                EventViewerMonitor.addToEventViewer("MonitorProcesos-Start", "No se ha configurado el Minuto de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", EventLogEntryType.Error)
                anotaMensaje("MonitorProcesos-Start... No se ha configurado el Minuto de Inicio o Finalización de las Operaciones. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", True)
                bolIniciarServicio = False
            End If

            If strMin_Timer IsNot "" Then
                intMin_Timer = Convert.ToInt32(strMin_Timer)
            Else
            End If
            If strDebug <> "" Then
                If strDebug = "S" Then
                    bolDebug = True
                Else
                    bolDebug = False
                End If
            Else
                EventViewerMonitor.addToEventViewer("MonitorProcesos-Start", "No se ha configurado la variable de Debug. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", EventLogEntryType.Error)
                anotaMensaje("MonitorProcesos-Start... No se ha configurado la variable de Debug. Por favor revisar el archivo de configuración del Monitor de Procesos de Telko", True)
                bolIniciarServicio = False
            End If

            ' NO OCURRIERON ERRORES
            If bolIniciarServicio Then
                timer.Interval = intMin_Timer * 1000 * 60
                AddHandler timer.Elapsed, AddressOf Timer_Procesos_Tick
                timer.Start()
                EventViewerMonitor.addToEventViewer("MonitorProcesos-Start", "Monitor de Procesos de Telko Iniciado, lapso de corrida configurado (min):" & strMin_Timer, EventLogEntryType.Information)
                anotaMensaje("Monitor de Procesos de Telko Iniciado, lapso de corrida configurado (min):" & strMin_Timer, True)
            Else
                Stop
            End If
#End Region
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Start", "Ha ocurrido un error iniciando el servicio del Monitor. Error:" & ex.Message, EventLogEntryType.Error)
            anotaMensaje("MonitorProcesos-Start... Ha ocurrido un error iniciando el servicio del Monitor. Error:" & ex.Message, True)
            bolIniciarServicio = False
        End Try
    End Sub

#Region "EJECUCION DEL TIMER DE PROCESOS"
    Private Sub Timer_Procesos_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
#Region "DECLARACION DE VARIABLES LOCALES"
        Dim dtFechaActual As Date = Date.Now
        Dim fechatemp As Date = Date.ParseExact("2000-01-01 12:00 am", "yyyy-dd-MM hh:mm tt", CultureInfo.InvariantCulture)
        Dim strFecha As String = dtFechaActual.Day.ToString().PadLeft(2, "0"c) + dtFechaActual.Month.ToString().PadLeft(2, "0"c) + dtFechaActual.Year.ToString() + dtFechaActual.Hour.ToString().PadLeft(2, "0"c) + dtFechaActual.Minute.ToString().PadLeft(2, "0"c) + dtFechaActual.Second.ToString().PadLeft(2, "0"c)
        Dim intHoraActual As Integer = Date.Now.Hour
        Dim intMinutoActual As Integer = Date.Now.Minute
        Dim strNombreArchivo As String = ""
        Dim bolInicioOperaciones As Boolean = False
        Dim bolNoCargar As Boolean = True
        Dim bolEntidadHija As Boolean = False
        Dim intTenantID As Integer
        Dim intProveedor As Integer
        Dim strCliente As String
        Dim dtfechaActualizacion As DateTime
        Dim intOrden As Integer
        Dim intEntityId As Integer
        Dim strNombreEntidad As String
        Dim strConexion_SV As String
        Dim strConexion_STS As String
        Dim entitiesDis As IEnumerable(Of EntitiyDistribucionEntity) = Nothing
        Dim entitiesDisAg As IEnumerable(Of Studio.Vision.Telko.Shared.Entity_EntiyAgregVM) = Nothing
        Dim entitiesTenant As IEnumerable(Of TenantEntity) = Nothing
        Dim jsonDTO As String = ""
        Dim JsonDTOs = New String() {}
        Dim JsonDTOsHija = New String() {}
        Dim ContadorRegistros As Integer = 0
        Dim ContadorAgregada As Integer = 0
#End Region

        ' SE OBTIENE LOS STRING DE CONEXION A LAS BASES DE DATOS
        strConexion_SV = ConfigurationManager.AppSettings("strConnDBStudio_Vision").ToString()
        strConexion_STS = ConfigurationManager.AppSettings("strConnDBStudio_Telko_Sync").ToString()

        EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Inicio de operaciones", EventLogEntryType.Information)
        anotaMensaje("MonitorProcesos-Timer... Inicio de operaciones", True)
        If bolInicio = False Then
            bolInicio = True
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Verificando archivos de distribución", EventLogEntryType.Information)
            anotaMensaje("MonitorProcesos-Timer... Verificando archivos de distribución", True)
            Try
                ' INSERTA EN EL EVENT VIEWER
                If bolDebug Then
                    EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Inicio del Timer de Procesos Telko", EventLogEntryType.Information)
                    anotaMensaje("MonitorProcesos-Timer... Inicio del Timer de Procesos Telko", True)
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
                        EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Inicio de operaciones", EventLogEntryType.Information)
                        anotaMensaje("MonitorProcesos-Timer... Inicio de operaciones", True)
                    End If

                    'EJECUTA EL PROCESO DE DISTRIBUCION
                    bolLoad = True

                    If bolLoad Then bolLoad = EntidadesADistribuir.VerificarEntidadesADistribuir(strConexion_STS, bolDebug, entitiesDis)
                    If bolLoad Then bolLoad = Tenant.VerificarTenant(strConexion_STS, bolDebug, entitiesTenant)

                    If bolLoad Then
                        'Recorro la Lista para consultar por cada cliente su ultima fecha de actualización
                        If entitiesTenant.Count() > 0 Then
                            For Each t As TenantEntity In entitiesTenant
                                intTenantID = t.Id
                                intProveedor = t.IdProveedorDrako
                                strCliente = t.Nombre
                                If (t.FechaActualizacion Is Nothing) Then
                                    dtfechaActualizacion = fechatemp
                                Else
                                    dtfechaActualizacion = t.FechaActualizacion
                                End If

                                'Recorro la Lista para consultar para consultar las tablas a distribuir
                                If entitiesDis.Count > 0 Then
                                    For Each et As EntitiyDistribucionEntity In entitiesDis
                                        intEntityId = et.Id
                                        intOrden = et.Orden
                                        strNombreEntidad = et.EntityName

                                        If intOrden >= 1 Then
                                            'Consulto si esta Entidad tiene Entidades Hijas a distribuir...
                                            If bolLoad Then bolLoad = DistribucionAgregada.FiltrarEntidadesADistribuirAgregadas(strConexion_STS, bolDebug, intEntityId, entitiesDisAg)
                                            If entitiesDisAg.Count > 0 Then
                                                bolEntidadHija = True
                                            Else
                                                bolEntidadHija = False
                                            End If

                                            ' SE PROCESAN LAS ENTIDADES A DISTRIBUIR Y SE SERIALIZA EL DTO A JSON
                                            bolLoad = ProcesarEntidades.ProcesarEntidadesADistribuir(strConexion_SV, strConexion_STS, bolDebug, strNombreEntidad, dtfechaActualizacion, bolEntidadHija, intEntityId, entitiesDisAg, jsonDTO, JsonDTOs, JsonDTOsHija)

                                            If bolLoad And jsonDTO <> "" Then
                                                ' SE INSERTA EL REGISTRO EN LA TABLA DistribucionRegistro DE LA BASE DE DATOS Studio_Telko_Sync
                                                bolLoad = Vision.Telko.Shared.DistribucionRegistro.InsertarDistribucionRegistro(strConexion_STS, bolDebug, intEntityId, jsonDTO, bolEntidadHija, JsonDTOs, JsonDTOsHija, intTenantID, ContadorAgregada)
                                                ContadorRegistros = ContadorRegistros + 1
                                                ContadorRegistros = ContadorRegistros + ContadorAgregada
                                            End If
                                        End If
                                    Next
                                Else
                                    EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "La tabla EntitiyDistribucion no posee información... Sin información de entidades a distribuir... ", EventLogEntryType.Information)
                                    anotaMensaje("MonitorProcesos-Timer... La tabla EntitiyDistribucion no posee información... Sin información de entidades a distribuir...", True)
                                End If

                                ' SE ACTUALIZA EL CAMPO FECHAACTUALIZACION EN LA TABLA Tenant DE LA BASE DE DATOS Studio_Telko_Sync
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Se procesaron " & ContadorRegistros & " Archivos para el TenantId: " & intTenantID, EventLogEntryType.Information)
                                anotaMensaje("MonitorProcesos-Timer... Se procesaron " & ContadorRegistros & " Archivos para el TenantId: " & intTenantID, True)
                                If ContadorRegistros > 0 Then
                                    If bolLoad Then bolLoad = Tenant.ActualizarFechaTenant(strConexion_STS, bolDebug, intTenantID)
                                    ContadorRegistros = 0
                                    ContadorAgregada = 0
                                End If
                            Next
                        Else
                            EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "La tabla DistribucionRegistro no posee información... Sin información de registros a distribuir... ", EventLogEntryType.Information)
                            anotaMensaje("MonitorProcesos-Timer... La tabla DistribucionRegistro no posee información... Sin información de registros a distribuir...", True)
                        End If ' FIN DE If entitiesTenant.Count() > 0 Then
                    End If

                    ' DETERMINA SI EL PROCESO CORRIO SIN ERRORES
                    If bolLoad Then
                        If bolDebug Then
                            EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Proceso ejecutado exitosamente", EventLogEntryType.Information)
                            anotaMensaje("MonitorProcesos-Timer... Proceso ejecutado exitosamente", True)
                        End If
                    Else
                        EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Falló el proceso de distribución de entidades", EventLogEntryType.Error)
                        anotaMensaje("MonitorProcesos-Timer...Falló el proceso de distribución de entidades", True)
                    End If
                Else
                    EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Horario fuera de corrida", EventLogEntryType.Information)
                    anotaMensaje("MonitorProcesos-Timer... Horario fuera de corrida", True)
                End If 'FIN DE bolInicioOperaciones

            Catch ex As Exception
                EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, EventLogEntryType.Error)
                anotaMensaje("MonitorProcesos-Timer... Ha ocurrido un error en el monitor de procesos. Error: " & ex.Message, True)
                bolInicio = False
            End Try
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "Archivos de distribución finalizada", EventLogEntryType.Information)
            anotaMensaje("MonitorProcesos-Timer...Archivos de distribución finalizada", True)
            bolInicio = False
        Else
            EventViewerMonitor.addToEventViewer("MonitorProcesos-Timer", "En proceso...", EventLogEntryType.Information)
            anotaMensaje("MonitorProcesos-Timer... En proceso...", True)
        End If 'FIN DE bolInicio = False
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        timer.Stop()
        EventViewerMonitor.addToEventViewer("MonitorProcesos-Stop", "Monitor de Procesos de Telko Detenido", EventLogEntryType.Information)
        anotaMensaje("MonitorProcesos-Stop... Monitor de Procesos de Telko Detenido", True)
    End Sub
#End Region
    Private Sub anotaMensaje(ByVal mensaje As String, ByVal log As Boolean)
        Dim evento As Studio.Vision.Telko.Shared.eventosLogs = New Studio.Vision.Telko.Shared.eventosLogs()
        Try
            evento.origen = "winEventos"           'Nombre de la aplicación o servicio que genera el evento
            evento.TipoOrigen = "EjemploEventos"   'Origen del evento (Application/System/Nombre personalizado)
            evento.Evento = "winEventos"           'Nombre del evento a auditar
            evento.Mensaje = mensaje
            evento.Archivo = "winLogs.log"

            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog(evento.Mensaje, log)

            'Añadimos el mensaje a lista
            'Creo un Thread nuevo para hacer la anotación del mensaje
            'Creamos una variable del tipo Thread
            Dim thread As New Thread(
              Sub()
                  Me.BeginInvoke(Sub() textBox1.Text += mensaje & vbCrLf)
              End Sub
            )
            thread.Start()

        Catch ex As Exception
            evento.Mensaje = ex.Message
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog(evento.Mensaje, log)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class