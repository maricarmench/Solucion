Imports Newtonsoft.Json
Imports SD.LLBLGen.Pro.QuerySpec
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Imports System.Globalization
Imports Studio.Phone.DAL.Linq
Public Class ProcesarEntidades
    Public Class SQLFunctionMappings
        Public Class ParseFunctionMappings
            Inherits FunctionMappingStore
            Public Sub New()
                ' define the mapping. SQLServer 2000 needs the schema to be present for the function call, 
                ' so we specify that as well.
                Me.Add(New FunctionMapping(GetType(SQLFunctions), "FullTextSearch", 2, "isnull({0},{1})"))
                Me.Add(New FunctionMapping(GetType(SQLFunctions), "NullSearch", 1, "String.IsNullOrEmpty({0})"))
            End Sub
        End Class
    End Class
    Public Class SQLFunctions
        Public Shared Function FullTextSearch(ByVal column As DateTime, ByVal Fechas As DateTime) As DateTime
            'Dim dateTime As Date
            Return column
        End Function
        Public Shared Function NullSearch(ByVal column As DateTime) As Boolean
            Dim bnlNull As Boolean = True
            Return bnlNull
        End Function
    End Class
    Public Shared Function ProcesarEntidadesADistribuir(ByVal strConexion As String, ByVal strConexion2 As String, ByVal bolDebug As Boolean, ByVal strNombreEntidad As String, ByVal dtFechaAct As DateTime, ByVal bnlPoseeHija As Boolean, ByVal intEntityIdMadre As Integer, entitiesDisAg As IEnumerable(Of Studio.Vision.Telko.Shared.Entity_EntiyAgregVM), ByRef jsonDTO As String, ByRef JsonDTOs() As String, ByRef JsonDTOsHija() As String) As Boolean
        Try
            Dim bnlResult As Boolean = True
            Dim intEntityId_Ag As Integer
            Dim intEntityId_AgID As Integer
            Dim strEntityName_AgHija As String = ""

            Dim filter As New PredicateExpression()
            'Dim entitiesDisAg As IEnumerable(Of Studio.Vision.Telko.Shared.Entity_EntiyAgregVM) = Nothing

            Select Case strNombreEntidad
                '// -----------------------------------------------------------//
                '// PROCESO DE DISTRIBUCION DE RUBRO
                Case "Rubro"
                    ' Linq,  VB.NET
                    'Where If(IsDBNull(RubroFields.FechaModificado), fechatemp, c.FechaModificado) >= dtFechaAct
                    'filter.Add(RubroFields.FechaModificado)
                    Dim fechatemp As Date = Date.ParseExact("2000-01-01 12:00 am", "yyyy-dd-MM hh:mm tt", CultureInfo.InvariantCulture)
                    Dim RubroClasses As List(Of Studio.Vision.Telko.Shared.Rubro) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Rubro
                                     Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Rubro With
                                     {
                                         .RubId = c.RId,
                                         .SngId = c.SignoId,
                                         .RubDsc = c.Descripcion,
                                         .RubImpComVta = c.ImporteComisionVenta,
                                         .RubPctComVta = c.PorcentajeComisionVenta,
                                         .RubFct = c.FactorComisionVenta,
                                         .RubNroCta = c.NumeroCuenta,
                                         .RubCodEmpOln = c.CodigoEmpresaOnLine,
                                         .ArtId = c.ArticuloId,
                                         .RubManTax = c.ManejaImpuestos,
                                         .RubSys = c.Sistema,
                                         .RubAudUsrIns = c.UsrCreador,
                                         .RubAudFchIns = c.FechaCreado,
                                         .RubAudUsrUpd = c.UsrModificador,
                                         .RubAudFchUpd = c.FechaModificado,
                                         .RubRid = c.Id,
                                         .RubIdExt = c.IdExterno
                                     }
                            RubroClasses = q2.ToList()
                        End Using
                        '.ArtId = c.ArtId, este lo tenia antes del 15-06-21
                    End If
                    jsonDTO = ""
                    If RubroClasses IsNot Nothing Then
                        If RubroClasses.Count > 0 Then
                            ' Serializing the object DTO to Json string
                            'jsonDTO = JsonConvert.SerializeObject(RubroClasses)
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(RubroClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If
                '// PROCESO DE DISTRIBUCION ARTICULOTIPO
                Case "ArticuloTipo"
                    ' Linq,  VB.NET
                    Dim ArtTipClasses As List(Of Studio.Vision.Telko.Shared.ArticuloTipo) = Nothing
                    filter.Add(ArticuloTipoFields.FechaModificado = DBNull.Value)
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim fechas As Nullable(Of DateTime) = Nothing
                            Dim DateString As String = "2000-01-01 12:00"
                            Dim Format As String = "yyyy-MM-dd HH:mm"
                            Dim fechatemp As Date = Date.ParseExact("2000-01-01 12:00 am", "yyyy-dd-MM hh:mm tt", CultureInfo.InvariantCulture)

                            Dim q2 = From c In metaData.ArticuloTipo
                                     Where c.FechaModificado >= dtFechaAct OrElse ArticuloTipoFields.FechaModificado.IsNull() = False
                                     Select New Studio.Vision.Telko.Shared.ArticuloTipo With
                                     {
                                         .ArtTipId = c.Id,
                                         .ArtTipDsc = c.Descripcion,
                                         .ArtTipAudUsrIns = c.UsrCreador,
                                         .ArtTipAudFchIns = c.FechaCreado,
                                         .ArtTipAudUsrUpd = c.UsrModificador,
                                         .ArtTipRid = c.RId,
                                         .ArtTipIdExt = c.IdExterno,
                                         .ArtTipAudFchUpd = c.FechaModificado
                                    }
                            ArtTipClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""

                    If ArtTipClasses IsNot Nothing Then
                        If (ArtTipClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            'jsonDTO = JsonConvert.SerializeObject(ArtTipClasses, Formatting.Indented)
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(ArtTipClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If
                 '// PROCESO DE DISTRIBUCION MARCA
                Case "Marca"
                    ' Linq,  VB.NET
                    Dim MarcClasses As List(Of Studio.Vision.Telko.Shared.Marca) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Marca Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Marca With
                                 {
                                     .MrcId = c.Id,
                                     .MrcDsc = c.Descripcion,
                                     .MrcAudUsrIns = c.UsrCreador,
                                     .MrcAudFchIns = c.FechaCreado,
                                     .MrcAudUsrUpd = c.UsrModificador,
                                     .MrcAudFchUpd = c.FechaModificado,
                                     .MrcRid = c.RId,
                                     .MrcIdExt = c.IdExterno
                                 }
                            MarcClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If MarcClasses IsNot Nothing Then
                        If (MarcClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(MarcClasses)
                            'jsonDTO = JsonConvert.SerializeObject(MarcClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION MODELO
                Case "Modelo"
                    ' Linq,  VB.NET
                    Dim ModClasses As List(Of Studio.Vision.Telko.Shared.Modelo) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Modelo Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Modelo With
                                     {
                                         .MdlId = c.Id,
                                         .MdlDsc = c.Descripcion,
                                         .MdlAudUsrIns = c.UsrCreador,
                                         .MdlAudFchIns = c.FechaCreado,
                                         .MdlAudUsrUpd = c.UsrModificador,
                                         .MdlAudFchUpd = c.FechaModificado,
                                         .MdlRid = c.RId,
                                         .MdlIdExt = c.IdExterno
                                     }
                            ModClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If ModClasses IsNot Nothing Then
                        If (ModClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(ModClasses)
                            'jsonDTO = JsonConvert.SerializeObject(ModClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION ARTICULOCLASE
                Case "ArticuloClase"
                    ' Linq,  VB.NET
                    filter.Add(ArticuloClaseFields.FechaModificado = DBNull.Value)
                    Dim ArtClsClasses As List(Of Studio.Vision.Telko.Shared.ArticuloClase) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.ArticuloClase
                                     Where c.FechaModificado >= dtFechaAct OrElse
                                     ArticuloClaseFields.FechaModificado.IsNull() = False
                                     Select New Studio.Vision.Telko.Shared.ArticuloClase With
                                     {
                                         .ArtClsId = c.Id,
                                         .ArtClsDsc = c.Descripcion,
                                         .ArtClsRid = c.RId,
                                         .ArtClsOrd = c.Orden,
                                         .ArtClsPerAutRpn = c.PermiteAutoReposicion,
                                         .DocTpoIdSal = c.DocumentoTipoIdDefectoSalida,
                                         .DocTpoIdEnt = c.DocumentoTipoIdDefectoEntrada,
                                         .ArtClsOcu = c.OcultarArticulos,
                                         .RubId = c.RubroId,
                                         .ArtClsAudUsrIns = c.UsrCreador,
                                         .ArtClsAudFchIns = c.FechaCreado,
                                         .ArtClsAudUsrUpd = c.UsrModificador,
                                         .ArtClsAudFchUpd = c.FechaModificado,
                                         .ArtClsReqDatExt = c.RequiereDatoExtra,
                                         .ArtClsDatExtMsj = c.MensajeDatoExtra,
                                         .ArtClsDatExtRegExp = c.ExpresionRegularDatoExtra
                                     }
                            ArtClsClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If ArtClsClasses IsNot Nothing Then
                        If (ArtClsClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(ArtClsClasses)
                            'jsonDTO = JsonConvert.SerializeObject(ArtClsClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION NIVEL
                Case "Nivel"
                    ' Linq,  VB.NET
                    Dim NivClasses As List(Of Studio.Vision.Telko.Shared.Nivel) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Nivel Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Nivel With
                                     {
                                         .NivId = c.Id,
                                         .NivDsc = c.Descripcion,
                                         .NivInf = c.Inferior,
                                         .NivLbl = c.Nivel,
                                         .NivIdSup = c.IdSuperior,
                                         .NivNroCta = c.NumeroCuenta,
                                         .NivAudUsrIns = c.UsrCreador,
                                         .NivAudFchIns = c.FechaCreado,
                                         .NivAudUsrUpd = c.UsrModificador,
                                         .NivAudFchUpd = c.FechaModificado,
                                         .NivRid = c.RId,
                                         .ImgId = c.ImagenId,
                                         .NivPubWeb = c.PublicableWeb,
                                         .NivOrd = c.Orden,
                                         .NivPagSiz = c.PageSize,
                                         .NivPrcRgn = c.PriceRange,
                                         .NivShwHomPag = c.ShowOnHomePage,
                                         .NivIdExt = c.IdExterno
                                     }
                            NivClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If NivClasses IsNot Nothing Then
                        If (NivClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(NivClasses)
                            'jsonDTO = JsonConvert.SerializeObject(NivClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION UNIDAD
                Case "Unidad"
                    ' Linq,  VB.NET
                    Dim UndClasses As List(Of Studio.Vision.Telko.Shared.Unidad) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Unidad Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Unidad With
                                     {
                                         .UniId = c.Id,
                                         .UniDsc = c.Descripcion,
                                         .UniAudUsrIns = c.UsrCreador,
                                         .UniAudFchIns = c.FechaCreado,
                                         .UniAudUsrUpd = c.UsrModificador,
                                         .UniAudFchUpd = c.FechaModificado,
                                         .UniRId = c.RId,
                                         .UniIdExt = c.IdExterno
                                     }
                            UndClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If UndClasses IsNot Nothing Then
                        If (UndClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(UndClasses)
                            'jsonDTO = JsonConvert.SerializeObject(UndClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION PROCEDENCIA
                Case "Procedencia"
                    ' Linq,  VB.NET
                    Dim ProcdClasses As List(Of Studio.Vision.Telko.Shared.Procedencia) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Procedencia Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Procedencia With
                                     {
                                         .PrdId = c.Id,
                                         .PrdDsc = c.Descripcion,
                                         .PrdAudUsrIns = c.UsrCreador,
                                         .PrdAudFchIns = c.FechaCreado,
                                         .PrdAudUsrUpd = c.UsrModificador,
                                         .PrdAudFchUpd = c.FechaModificado,
                                         .PrdRid = c.RId,
                                         .PrdIdExt = c.IdExterno
                                     }
                            ProcdClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If ProcdClasses IsNot Nothing Then
                        If (ProcdClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(ProcdClasses)
                            'jsonDTO = JsonConvert.SerializeObject(ProcdClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION AAtributoPlantilla
                Case "AAtributoPlantilla"
                    ' Linq,  VB.NET
                    Dim AAPllaClasses As List(Of Studio.Vision.Telko.Shared.AAtributoPlantilla) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.AAtributoPlantilla Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.AAtributoPlantilla With
                                     {
                                         .AAtPlnID = c.ID,
                                         .AAtPlnNom = c.Nombre,
                                         .AAtPlnSys = c.Sistema,
                                         .AAtPlnAudUsrIns = c.UsrCreador,
                                         .AAtPlnAudFchIns = c.FechaCreado,
                                         .AAtPlnAudUsrUpd = c.UsrModificador,
                                         .AAtPlnAudFchUpd = c.FechaModificado,
                                         .AAtPlnRId = c.RId,
                                         .AAPlnTpo = c.Tipo,
                                         .AAPlnLar = c.Largo,
                                         .AAPlnEsc = c.Escala,
                                         .AAPlnFmt = c.Formato,
                                         .AAPlnFmtVar = c.FormatoVariante,
                                         .AAPlnMsk = c.Mascara,
                                         .AAtPlnIdExt = c.IdExterno
                                     }
                            AAPllaClasses = q2.ToList()
                            '.AAtPlnIdExt = c. ' el ultimo campo
                        End Using
                    Else
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)

                            If entitiesDisAg.Count > 0 Then 'Esta Entidad tiene Entidades Hijas a distribuir...
                                JsonDTOs = New String() {}
                                ReDim JsonDTOs(entitiesDisAg.Count - 1)
                                Dim Contador As Integer = 0

                                JsonDTOsHija = New String() {}
                                ReDim JsonDTOsHija(entitiesDisAg.Count - 1)

                                For Each et_ag As Studio.Vision.Telko.Shared.Entity_EntiyAgregVM In entitiesDisAg
                                    intEntityId_Ag = et_ag.EntityMadreID
                                    intEntityId_AgID = et_ag.EntityHijaID
                                    strEntityName_AgHija = et_ag.EntityName

                                    Select Case strEntityName_AgHija
                                         '// PROCESO DE DISTRIBUCION AAtributoPlantillaValor
                                        Case "AAtributoPlantillaValor"
                                            Dim AAPVClasses As List(Of Studio.Vision.Telko.Shared.AAtributoPlantillaValor) = Nothing
                                            Dim qAI = From c In metaData.AAtributoPlantillaValor Where c.FechaModificado >= dtFechaAct
                                                      Select New Studio.Vision.Telko.Shared.AAtributoPlantillaValor With
                                                    {
                                                          .AAtPlnValID = c.ID,
                                                          .AAtPlnID = c.AAtributoPlantillaID,
                                                          .AAtPlnValAudUsrIns = c.UsrCreador,
                                                          .AAtPlnValAudFchIns = c.FechaCreado,
                                                          .AAtPlnValAudUsrUpd = c.UsrModificador,
                                                          .AAtPlnValAudFchUpd = c.FechaModificado,
                                                          .IsDeleted = c.IsDeleted,
                                                          .AAtPlnValRId = c.RId,
                                                          .AAPlnValInt = c.ValorInteger,
                                                          .AAPlnValDec = c.ValorDecimal,
                                                          .AAPlnValBit = c.ValorBinario,
                                                          .AAPlnValTxt = c.ValorTexto,
                                                          .AAtPlnValIdExt = c.IdExterno
                                                    }
                                            AAPVClasses = qAI.ToList()
                                            ' .AAtPlnValIdExt = c. al final de todo

                                            If AAPVClasses IsNot Nothing Then
                                                If (AAPVClasses.Count > 0) Then
                                                    ' Serializing the object DTO to Json string
                                                    JsonDTOs(Contador) = intEntityId_AgID & "↑" & "↔" & strEntityName_AgHija & "=" & JsonConvert.SerializeObject(AAPVClasses)
                                                    JsonDTOsHija(Contador) = JsonConvert.SerializeObject(AAPVClasses)
                                                    If bolDebug Then
                                                        EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), EventLogEntryType.Information)
                                                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), True)
                                                    End If
                                                End If
                                            End If
                                            '// PROCESO DE CARGA DE ARCHIVOS NO IDENTIFICADOS
                                        Case Else
                                            EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "El Archivo: " + strEntityName_AgHija & " no tiene proceso de distribución asociado", EventLogEntryType.Warning)
                                            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... El Archivo: " + strEntityName_AgHija & " no tiene proceso de distribución asociado", True)
                                            Return False
                                    End Select
                                Next
                            End If

                            Dim q2 = From c In metaData.AAtributoPlantilla Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.AAtributoPlantilla With
                                     {
                                         .AAtPlnID = c.ID,
                                         .AAtPlnNom = c.Nombre,
                                         .AAtPlnSys = c.Sistema,
                                         .AAtPlnAudUsrIns = c.UsrCreador,
                                         .AAtPlnAudFchIns = c.FechaCreado,
                                         .AAtPlnAudUsrUpd = c.UsrModificador,
                                         .AAtPlnAudFchUpd = c.FechaModificado,
                                         .AAtPlnRId = c.RId,
                                         .AAPlnTpo = c.Tipo,
                                         .AAPlnLar = c.Largo,
                                         .AAPlnEsc = c.Escala,
                                         .AAPlnFmt = c.Formato,
                                         .AAPlnFmtVar = c.FormatoVariante,
                                         .AAPlnMsk = c.Mascara
                                     }
                            AAPllaClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""

                    If AAPllaClasses IsNot Nothing Then
                        If AAPllaClasses.Count > 0 Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(AAPllaClasses)
                            'jsonDTO = JsonConvert.SerializeObject(AAPllaClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION Articulo
                Case "Articulo"
                    ' Linq,  VB.NET
                    Dim ArtClasses As List(Of Studio.Vision.Telko.Shared.Articulo) = Nothing
                    Dim ArtImpClasses As List(Of Studio.Vision.Telko.Shared.Articulo_Impuesto) = Nothing

                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Articulo Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Articulo With
                                 {
                                     .ArtId = c.Id,
                                     .ArtTipId = CType(c.ArticuloTipoId, Integer?),
                                     .PrdId = CType(c.ProcedenciaId, Integer?),
                                     .ArtCatId = CType(c.ArticuloCategoriaId, Integer?),
                                     .NivId = c.NivelId,
                                     .MrcId = CType(c.MarcaId, Integer?),
                                     .ArtClsId = CType(c.ArticuloClaseId, Integer?),
                                     .ArtEnvId = c.ArticuloEnvaseId,
                                     .ArtRepId = c.ArticuloRepresentanteId,
                                     .ArtCom = c.Comisionable,
                                     .RubId = c.RubroId,
                                     .MdlId = c.ModeloId,
                                     .ArtDsc = c.Descripcion,
                                     .ArtDscCta = c.DescripcionCorta,
                                     .ArtPerDia = c.DiasAPerecer,
                                     .ArtImg = c.Imagen,
                                     .ArtOvr = c.Override,
                                     .ArtFra = c.Fraccionable,
                                     .ArtVen = c.Vendible,
                                     .ArtObs = c.Observacion,
                                     .ArtMer = c.PorcentajeMerma,
                                     .ArtExtVta = c.RequeridoEnVenta,
                                     .ArtPer = c.Perecedero,
                                     .ArtExp = c.Exportable,
                                     .ArtSer = c.Seriado,
                                     .ArtSerOcu = c.SerieOculta,
                                     .ArtDiaGtia = c.DiaGarantia,
                                     .ArtAct = c.Activo,
                                     .ArtCtrStk = c.ControlaStock,
                                     .ArtUPC = c.UPC,
                                     .ProvIdCst = c.ProveedorIdCosto,
                                     .ArtMgr = c.Margen,
                                     .ArtIdAlt = c.CodigoAlterno,
                                     .ArtAudUsrIns = c.UsrCreador,
                                     .ArtAudFchIns = c.FechaCreado,
                                     .ArtAudUsrUpd = c.UsrModificador,
                                     .ArtAudFchUpd = c.FechaModificado,
                                     .ArtRid = c.RId,
                                     .ArtWeb = c.PublicableWeb,
                                     .UniId = c.UnidadId,
                                     .ArtShp = c.Enviable,
                                     .ArtPso = c.Peso,
                                     .ArtLng = c.Largo,
                                     .ArtAnc = c.Ancho,
                                     .ArtAlt = c.Altura,
                                     .ArtGiaVar = c.GuiaDeVariante,
                                     .ArtIdGia = c.ArticuloIdGuia,
                                     .ArtDscAtr = c.DescripcionVariante,
                                     .ArtCodExt = c.CodigoExterno,
                                     .IsDeleted = c.IsDeleted,
                                     .CndId = c.CondicionId,
                                     .CsgId = c.ConsignadorId,
                                     .ArtIdExt = c.IdExterno
                                 }
                            ArtClasses = q2.ToList()
                        End Using
                    Else
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)

                            If entitiesDisAg.Count > 0 Then 'Esta Entidad tiene Entidades Hijas a distribuir...
                                JsonDTOs = New String() {}
                                ReDim JsonDTOs(entitiesDisAg.Count - 1)
                                Dim Contador As Integer = 0

                                JsonDTOsHija = New String() {}
                                ReDim JsonDTOsHija(entitiesDisAg.Count - 1)

                                'Recorro la Lista para agregar al DTO las tablas hijas a distribuir
                                For Each et_ag As Studio.Vision.Telko.Shared.Entity_EntiyAgregVM In entitiesDisAg
                                    intEntityId_Ag = et_ag.EntityMadreID
                                    intEntityId_AgID = et_ag.EntityHijaID
                                    strEntityName_AgHija = et_ag.EntityName

                                    Select Case strEntityName_AgHija
                                        '// PROCESO DE DISTRIBUCION Articulo_Impuesto
                                        Case "Articulo_Impuesto"
                                            Dim qAI = From c In metaData.Articulo_Impuesto Where c.FechaModificado >= dtFechaAct
                                                      Select New Studio.Vision.Telko.Shared.Articulo_Impuesto With
                                                    {
                                                        .ArtId = c.ArticuloId,
                                                        .TaxId = c.ImpuestoId,
                                                        .ArtTaxAudUsrIns = c.UsrCreador,
                                                        .ArtTaxAudFchIns = c.FechaCreado,
                                                        .ArtTaxAudUsrUpd = c.UsrModificador,
                                                        .ArtTaxAudFchUpd = c.FechaModificado,
                                                        .ArtTaxRid = c.RId
                                                    }
                                            ArtImpClasses = qAI.ToList()

                                            If ArtImpClasses IsNot Nothing Then
                                                If (ArtImpClasses.Count > 0) Then
                                                    ' Serializing the object DTO to Json string
                                                    JsonDTOs(Contador) = intEntityId_AgID & "↑" & "↔" & strEntityName_AgHija & "=" & JsonConvert.SerializeObject(ArtImpClasses)
                                                    JsonDTOsHija(Contador) = JsonConvert.SerializeObject(ArtImpClasses)
                                                    If bolDebug Then
                                                        EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), EventLogEntryType.Information)
                                                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), True)
                                                    End If
                                                End If
                                            End If

                                        '// PROCESO DE DISTRIBUCION Articulo_AAtributoPlantilla
                                        Case "Articulo_AAtributoPlantilla"
                                            Dim AAAPltClasses As List(Of Studio.Vision.Telko.Shared.Articulo_AAtributoPlantilla) = Nothing
                                            Dim qAAPlt = From c In metaData.Articulo_AAtributoPlantilla Where c.FechaModificado >= dtFechaAct
                                                         Select New Studio.Vision.Telko.Shared.Articulo_AAtributoPlantilla With
                                                    {
                                                       .ArtAAtPlanID = c.ID,
                                                       .ArtId = c.ArticuloId,
                                                       .AAtPlnID = c.AAtributoPlantillaID,
                                                       .ArtAAtPlnAudUsrIns = c.UsrCreador,
                                                       .ArtAAtPlnAudFchIns = c.FechaCreado,
                                                       .ArtAAtPlnAudUsrUpd = c.UsrModificador,
                                                       .ArtAAtPlnAudFchUpd = c.FechaModificado,
                                                       .ArtAAtPlaRId = c.RId
                                                    }
                                            AAAPltClasses = qAAPlt.ToList()

                                            If AAAPltClasses IsNot Nothing Then
                                                If (AAAPltClasses.Count > 0) Then
                                                    ' Serializing the object DTO to Json string
                                                    JsonDTOs(Contador) = intEntityId_AgID & "↑" & "↔" & strEntityName_AgHija & "=" & JsonConvert.SerializeObject(AAAPltClasses)
                                                    JsonDTOsHija(Contador) = JsonConvert.SerializeObject(AAAPltClasses)
                                                    If bolDebug Then
                                                        EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), EventLogEntryType.Information)
                                                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), True)
                                                    End If
                                                End If
                                            End If

                                        '// PROCESO DE DISTRIBUCION ArticuloVariante_Combinacion
                                        Case "ArticuloVariante_Combinacion"
                                            Dim AVCClasses As List(Of Studio.Vision.Telko.Shared.ArticuloVariante_Combinacion) = Nothing
                                            Dim qAV = From c In metaData.ArticuloVariante_Combinacion Where c.FechaModificado >= dtFechaAct
                                                      Select New Studio.Vision.Telko.Shared.ArticuloVariante_Combinacion With
                                                    {
                                                          .ArtVarCmbID = c.ID,
                                                          .ArtId = c.ArticuloId,
                                                          .AAtPlnID = c.AAtributoPlantillaID,
                                                          .AAtPlnValID = c.AAtributoPlantillaValorID,
                                                          .ArtVarCmbAudUsrIns = c.UsrCreador,
                                                          .ArtVarCmbAudFchIns = c.FechaCreado,
                                                          .ArtVarCmbAudUsrUpd = c.UsrModificador,
                                                          .ArtVarCmbAudFchUpd = c.FechaModificado,
                                                          .ArtVarCmbRId = c.RId
                                                    }
                                            AVCClasses = qAV.ToList()

                                            If AVCClasses IsNot Nothing Then
                                                If (AVCClasses.Count > 0) Then
                                                    ' Serializing the object DTO to Json string
                                                    JsonDTOs(Contador) = intEntityId_AgID & "↑" & "↔" & strEntityName_AgHija & "=" & JsonConvert.SerializeObject(AVCClasses)
                                                    JsonDTOsHija(Contador) = JsonConvert.SerializeObject(AVCClasses)
                                                    If bolDebug Then
                                                        EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), EventLogEntryType.Information)
                                                        Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad Hija: " & strNombreEntidad & "/" & strEntityName_AgHija & " convertida a DTO serializado a Json: " & JsonDTOs(Contador), True)
                                                    End If
                                                End If
                                            End If

                                            '// PROCESO DE CARGA DE ARCHIVOS NO IDENTIFICADOS
                                        Case Else
                                            EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "El Archivo: " + strEntityName_AgHija & " no tiene proceso de distribución asociado", EventLogEntryType.Warning)
                                            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... El Archivo: " + strEntityName_AgHija & " no tiene proceso de distribución asociado", True)
                                            Return False
                                    End Select
                                    'End If
                                    Contador = Contador + 1
                                Next
                            End If

                            Dim q2 = From c In metaData.Articulo Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Articulo With
                                 {
                                     .ArtId = c.Id,
                                     .ArtTipId = CType(c.ArticuloTipoId, Integer?),
                                     .PrdId = CType(c.ProcedenciaId, Integer?),
                                     .ArtCatId = CType(c.ArticuloCategoriaId, Integer?),
                                     .NivId = c.NivelId,
                                     .MrcId = CType(c.MarcaId, Integer?),
                                     .ArtClsId = CType(c.ArticuloClaseId, Integer?),
                                     .ArtEnvId = CType(c.ArticuloEnvaseId, Integer?),
                                     .ArtRepId = CType(c.ArticuloRepresentanteId, Integer?),
                                     .ArtCom = c.Comisionable,
                                     .RubId = c.RubroId,
                                     .MdlId = CType(c.ModeloId, Integer?),
                                     .ArtDsc = c.Descripcion,
                                     .ArtDscCta = c.DescripcionCorta,
                                     .ArtPerDia = CType(c.DiasAPerecer, Integer?),
                                     .ArtImg = c.Imagen,
                                     .ArtOvr = c.Override,
                                     .ArtFra = c.Fraccionable,
                                     .ArtVen = c.Vendible,
                                     .ArtObs = c.Observacion,
                                     .ArtMer = CType(c.PorcentajeMerma, Decimal?),
                                     .ArtExtVta = c.RequeridoEnVenta,
                                     .ArtPer = c.Perecedero,
                                     .ArtExp = c.Exportable,
                                     .ArtSer = c.Seriado,
                                     .ArtSerOcu = c.SerieOculta,
                                     .ArtDiaGtia = c.DiaGarantia,
                                     .ArtAct = c.Activo,
                                     .ArtCtrStk = c.ControlaStock,
                                     .ArtUPC = c.UPC,
                                     .ProvIdCst = CType(c.ProveedorIdCosto, Integer?),
                                     .ArtMgr = CType(c.Margen, Decimal?),
                                     .ArtIdAlt = c.CodigoAlterno,
                                     .ArtAudUsrIns = c.UsrCreador,
                                     .ArtAudFchIns = c.FechaCreado,
                                     .ArtAudUsrUpd = c.UsrModificador,
                                     .ArtAudFchUpd = c.FechaModificado,
                                     .ArtRid = c.RId,
                                     .ArtWeb = c.PublicableWeb,
                                     .UniId = CType(c.UnidadId, Integer?),
                                     .ArtShp = c.Enviable,
                                     .ArtPso = CType(c.Peso, Decimal?),
                                     .ArtLng = CType(c.Largo, Decimal?),
                                     .ArtAnc = CType(c.Ancho, Decimal?),
                                     .ArtAlt = CType(c.Altura, Decimal?),
                                     .ArtGiaVar = c.GuiaDeVariante,
                                     .ArtIdGia = CType(c.ArticuloIdGuia, Integer?),
                                     .ArtDscAtr = c.DescripcionVariante,
                                     .ArtCodExt = c.CodigoExterno,
                                     .IsDeleted = c.IsDeleted,
                                     .CndId = CType(c.CondicionId, Integer?),
                                     .CsgId = CType(c.ConsignadorId, Integer?),
                                     .ArtIdExt = CType(c.IdExterno, Integer?)
                                 }
                            ArtClasses = q2.ToList()
                        End Using
                    End If

                    jsonDTO = ""
                    If ArtClasses IsNot Nothing Then
                        If (ArtClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(ArtClasses)
                            'jsonDTO = JsonConvert.SerializeObject(ArtClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                '// PROCESO DE DISTRIBUCION MARCA_MODELO
                Case "Marca_Modelo"
                    ' Linq,  VB.NET
                    Dim MarcModClasses As List(Of Studio.Vision.Telko.Shared.Marca_Modelo) = Nothing
                    If bnlPoseeHija = False Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            Dim metaData As New Phone.DAL.Linq.LinqMetaData(adapter)
                            Dim q2 = From c In metaData.Marca_Modelo Where c.FechaModificado >= dtFechaAct
                                     Select New Studio.Vision.Telko.Shared.Marca_Modelo With
                                 {
                                     .MrcId = c.MarcaId,
                                     .MdlId = c.ModeloId,
                                     .MrcMdlAudUsrIns = c.UsrCreador,
                                     .MrcMdlAudFchIns = c.FechaCreado,
                                     .MrcMdlAudUsrUpd = c.UsrModificador,
                                     .MrcMdlAudFchUpd = c.FechaModificado,
                                     .MrcMdlRid = c.RId
                                 }
                            MarcModClasses = q2.ToList()
                        End Using
                    End If
                    jsonDTO = ""
                    If MarcModClasses IsNot Nothing Then
                        If (MarcModClasses.Count > 0) Then
                            ' Serializing the object DTO to Json string
                            jsonDTO = "↔" & strNombreEntidad & "=" & JsonConvert.SerializeObject(MarcModClasses)
                            'jsonDTO = JsonConvert.SerializeObject(MarcModClasses)
                            If bolDebug Then
                                EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, EventLogEntryType.Information)
                                Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Entidad: " & strNombreEntidad & " convertida a DTO serializado a Json: " & jsonDTO, True)
                            End If
                        End If
                    End If

                    '// PROCESO DE CARGA DE ARCHIVOS NO IDENTIFICADOS
                Case Else
                    EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "El Archivo: " + strNombreEntidad & " no tiene proceso de distribución asociado", EventLogEntryType.Warning)
                    Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... El Archivo: " + strNombreEntidad & " no tiene proceso de distribución asociado", True)
                    Return False
            End Select
            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorProcesos-ProcesarEntidades", "Ha ocurrido un error en el monitor de procesos de la entidad: " & strNombreEntidad & " Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorProcesos-ProcesarEntidades... Ha ocurrido un error en el monitor de procesos de la entidad: " & strNombreEntidad & " Error: " & ex.Message, True)
            Return False
        End Try
    End Function
End Class
