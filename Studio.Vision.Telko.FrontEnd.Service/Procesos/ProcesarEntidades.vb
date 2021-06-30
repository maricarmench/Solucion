Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports System.Globalization
Imports Studio.Phone.DAL.DatabaseSpecific
Public Class ProcesarEntidades
    Public Shared Function CheckFechDBNull(fecha As Object, fechaMascara As Date) As Object
        If fecha.ToString() = String.Empty Then
            Return DateTime.MinValue
        Else
            If fecha = "#1/1/0001 12:00:00 AM#" Then
                Return fechaMascara
            Else
                Return DirectCast(fecha, DateTime)
            End If
        End If
    End Function
    Public Shared Function CheckDBNull(Variable As Object, Valor As Object) As Object
        If Valor IsNot Nothing Then
            Variable = Valor
        Else
            Variable = Nothing
            'Variable = vbNull
        End If
        Return Variable
    End Function
    Public Shared Function ProcesarEntidadesAActualizar(ByVal strConexion As String, ByVal strConexion2 As String, ByVal bolDebug As Boolean, ByVal RespuestaServicio As String, ByRef strGuids As String, ByRef ContadorGeneral As Integer) As Boolean
#Region "Declaracion de Variables"
        Dim fechatemp As Date = Date.ParseExact("2000-01-01 12:00 am", "yyyy-dd-MM hh:mm tt", CultureInfo.InvariantCulture)
        Dim strNombreEntidad As String = ""
        Dim strJsonEntidad As String = ""
        Dim CadenaGeneral As String
        Dim CadenaInterna As String
        Dim CadenaJson As String
        Dim strGuid As String = ""
        Dim strJsonGeneral As String = ""
        CadenaGeneral = Trim(RespuestaServicio.TrimEnd())
        Dim Contador As Integer = 0
        Dim ContadorInterno As Integer = 0
        Dim CuentaRegistros As Boolean = False
        Dim CuentaRegistrosInterno As Boolean = False
        Dim EncontroRegistro As Boolean = False
        Dim RespuestaFuncion As String = ""

        'Dimension variables and declare data types
        Dim ArrGeneral() As String
        Dim ArrInterno() As String
        Dim ArrJsonGeneral() As String
        Dim ArrJson() As String
        Dim Str As Object
        Dim StrJson As Object

        Dim IdRuboCliente As Integer
        Dim EncontroIdRubroCliente As Boolean = False
        Dim IdArtTipoCliente As Integer
        Dim EncontroIdArtTipoCliente As Boolean = False
        Dim IdProcedCliente As Integer
        Dim EncontroIdProcedCliente As Boolean = False
        Dim IdNivelCliente As Integer
        Dim EncontroIdNivelCliente As Boolean = False
        Dim IdMarcaCliente As Integer
        Dim EncontroIdMarcaCliente As Boolean = False
        Dim IdModeloCliente As Integer
        Dim EncontroIdModeloCliente As Boolean = False
        Dim IdUnidadCliente As Integer
        Dim EncontroIdunidadCliente As Boolean = False
        Dim IdArticuloCliente As Integer
        Dim EncontroIdArticuloCliente As Boolean = False
        Dim EncontroIdAAtributoPlantillaCliente = False
        Dim IdAAtributoPlantillaCliente As Integer
        Dim EncontroIdAAtributoPlantillaValorCliente = False
        Dim IdAAtributoPlantillaValorCliente As Integer

        Dim ObjArticuloTipoId As Object = Nothing
        Dim ObjProcedenciaId As Object = Nothing
        Dim ObjArticuloCategoriaId As Object = Nothing
        Dim ObjNivelId As Object = Nothing
        Dim ObjMarcaId As Object = Nothing
        Dim ObjArticuloClaseId As Object = Nothing
        Dim ObjArticuloEnvaseId As Object = Nothing
        Dim ObjArticuloRepresentanteId As Object = Nothing
        Dim ObjRubroId As Object = Nothing
        Dim ObjModeloId As Object = Nothing
        Dim ObjDiasAPerecer As Object = Nothing
        Dim ObjPorcentajeMerma As Object = Nothing
        Dim ObjProveedorIdCosto As Object = Nothing
        Dim ObjMargen As Object = Nothing
        Dim ObjUnidadId As Object = Nothing
        Dim ObjPeso As Object = Nothing
        Dim ObjLargo As Object = Nothing
        Dim ObjAncho As Object = Nothing
        Dim ObjAltura As Object = Nothing
        Dim ObjArticuloIdGuia As Object = Nothing
        Dim ObjCondicionId As Object = Nothing
        Dim ObjConsignadorId As Object = Nothing
        Dim ObjValorInteger As Object = Nothing
        Dim ObjValorDecimal As Object = Nothing
        Dim ObjValorBinario As Object = Nothing
        Dim ObjAAtributoPlantillaID As Object = Nothing
        Dim ObjArticuloId As Object = Nothing
        Dim ObjAAtributoPlantillaValorID As Object = Nothing
        Dim ObjOrden As Object = Nothing
        Dim ObjDocumentoTipoIdDefectoSalida As Object = Nothing
        Dim ObjDocumentoTipoIdDefectoEntrada As Object = Nothing
        Dim ObjImporteComisionVenta As Object = Nothing
        Dim ObjPorcentajeComisionVenta As Object = Nothing
        Dim ObjPageSize As Object = Nothing

        Dim RubroClasses As List(Of Studio.Vision.Telko.Shared.Rubro) = Nothing
        Dim MarcaClasses As List(Of Studio.Vision.Telko.Shared.Marca) = Nothing
        Dim ModeloClasses As List(Of Studio.Vision.Telko.Shared.Modelo) = Nothing
        Dim MarcModClasses As List(Of Studio.Vision.Telko.Shared.Marca_Modelo) = Nothing
        Dim NivelClasses As List(Of Studio.Vision.Telko.Shared.Nivel) = Nothing
        Dim ProcedenciaClasses As List(Of Studio.Vision.Telko.Shared.Procedencia) = Nothing
        Dim UnidadClasses As List(Of Studio.Vision.Telko.Shared.Unidad) = Nothing
        Dim ArtTipClasses As List(Of Studio.Vision.Telko.Shared.ArticuloTipo) = Nothing
        Dim ArtAtrPlantClasses As List(Of Studio.Vision.Telko.Shared.Articulo_AAtributoPlantilla) = Nothing
        Dim ArtVarComClasses As List(Of Studio.Vision.Telko.Shared.ArticuloVariante_Combinacion) = Nothing
        Dim ArtImpClasses As List(Of Studio.Vision.Telko.Shared.Articulo_Impuesto) = Nothing
        Dim ArticuloClaseClasses As List(Of Studio.Vision.Telko.Shared.ArticuloClase) = Nothing
        Dim ArticuloClasses As List(Of Studio.Vision.Telko.Shared.Articulo) = Nothing
        Dim AAtrbPlatClasses As List(Of Studio.Vision.Telko.Shared.AAtributoPlantilla) = Nothing
        Dim AAtrbPlatVClasses As List(Of Studio.Vision.Telko.Shared.AAtributoPlantillaValor) = Nothing
#End Region
        Try
            strGuids = ""
            ContadorGeneral = 0
            'Split value in variable Rng using delimiting character ↓
            ArrGeneral = Split(CadenaGeneral, "↓")
            'Iterate through each substring
            For Each Str In ArrGeneral
                If Contador > 0 Then
                    CadenaInterna = Trim(Str)
                    ArrInterno = Split(CadenaInterna, "↑")
                    strGuid = "'" & Trim(ArrInterno(0).TrimEnd()) & "'"
                    Dim strJsonGuid = JsonConvert.DeserializeObject(strGuid)
                    strJsonGuid = strJsonGuid.Remove(strJsonGuid.Length - 1)
                    strJsonGuid = strJsonGuid.Remove(0, 1)
                    If strGuids = "" Then
                        strGuids = UCase(strJsonGuid)
                    Else
                        strGuids = strGuids & ";" & UCase(strJsonGuid)
                    End If
                    strJsonGeneral = Trim(ArrInterno(1))
                    ArrJsonGeneral = Split(strJsonGeneral, "↔")

                    If (ArrGeneral.Count - 1) = Contador Then CuentaRegistros = True
                    ContadorInterno = 0
                    CuentaRegistrosInterno = False
                    'Iterate through each substring ArrJson
                    For Each StrJson In ArrJsonGeneral
                        If ContadorInterno > 0 Then
                            If (ArrJsonGeneral.Count - 1) = ContadorInterno Then CuentaRegistrosInterno = True

                            CadenaJson = StrJson
                            ArrJson = Split(CadenaJson, "=")
                            strNombreEntidad = Trim(ArrJson(0))
                            strJsonEntidad = "'" & Trim(ArrJson(1).TrimEnd()) & "'"

                            Select Case strNombreEntidad
                                 '// PROCESO DE ACTUALIZACION DE RUBRO
                                Case "Rubro"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    RubroClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Rubro))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1

                                 '// PROCESO DE ACTUALIZACION DE ArticuloTipo
                                Case "ArticuloTipo"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArtTipClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.ArticuloTipo))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION MARCA
                                Case "Marca"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    MarcaClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Marca))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION MODELO
                                Case "Modelo"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ModeloClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Modelo))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION ARTICULOCLASE
                                Case "ArticuloClase"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArticuloClaseClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.ArticuloClase))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION NIVEL
                                Case "Nivel"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    NivelClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Nivel))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION UNIDAD
                                Case "Unidad"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    UnidadClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Unidad))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION PROCEDENCIA
                                Case "Procedencia"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ProcedenciaClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Procedencia))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION AAtributoPlantilla
                                Case "AAtributoPlantilla"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    AAtrbPlatClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.AAtributoPlantilla))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION AAtributoPlantillaValor
                                Case "AAtributoPlantillaValor"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    AAtrbPlatVClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.AAtributoPlantillaValor))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION Articulo
                                Case "Articulo"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArticuloClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Articulo))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                 '// PROCESO DE ACTUALIZACION Articulo_Impuesto
                                Case "Articulo_Impuesto"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArtImpClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Articulo_Impuesto))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                '// PROCESO DE ACTUALIZACION Articulo_AAtributoPlantilla
                                Case "Articulo_AAtributoPlantilla"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArtAtrPlantClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Articulo_AAtributoPlantilla))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                '// PROCESO DE ACTUALIZACION ArticuloVariante_Combinacion
                                Case "ArticuloVariante_Combinacion"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad.TrimEnd())).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    ArtVarComClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.ArticuloVariante_Combinacion))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                                '// PROCESO DE ACTUALIZACION MARCA_MODELO
                                Case "Marca_Modelo"
                                    ' DesSerializing the object Json string to DTO
                                    Dim strJsonEnt = JsonConvert.DeserializeObject(Trim(strJsonEntidad)).ToString()
                                    If CuentaRegistros And CuentaRegistrosInterno Then
                                        strJsonEnt = strJsonEnt.Remove(strJsonEnt.Length - 1)
                                    End If
                                    MarcModClasses = JsonConvert.DeserializeObject(Of List(Of Studio.Vision.Telko.Shared.Marca_Modelo))(strJsonEnt)
                                    ContadorGeneral = ContadorGeneral + 1
                            End Select
                        End If
                        ContadorInterno = ContadorInterno + 1
                    Next

                    'Se procesa la tabla Rubro
                    If (RubroClasses IsNot Nothing) AndAlso (RubroClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In RubroClasses
                                EncontroRegistro = False
                                EncontroIdRubroCliente = False
                                IdRuboCliente = 0

                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Rubro(strConexion, item.RubId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim RubroRegistro As New RubroEntity()

                                    'RubroRegistro.RId = item.RubId
                                    If item.SngId.HasValue Then RubroRegistro.SignoId = item.SngId
                                    RubroRegistro.Descripcion = item.RubDsc
                                    If item.RubImpComVta Then RubroRegistro.ImporteComisionVenta = item.RubImpComVta
                                    If item.RubPctComVta.HasValue Then RubroRegistro.PorcentajeComisionVenta = item.RubPctComVta
                                    RubroRegistro.NumeroCuenta = item.RubNroCta 'If item.RubFct.HasValue Then RubroRegistro.NumeroCuenta = item.RubNroCta
                                    RubroRegistro.CodigoEmpresaOnLine = item.RubCodEmpOln
                                    'If item.ArtId.HasValue Then RubroRegistro.ArtId = item.ArtId 'asi lo tenia hasta el 15 de junio
                                    If item.ArtId.HasValue Then RubroRegistro.ArticuloId = item.ArtId
                                    RubroRegistro.ManejaImpuestos = item.RubManTax
                                    RubroRegistro.Sistema = item.RubSys
                                    RubroRegistro.UsrCreador = item.RubAudUsrIns
                                    RubroRegistro.FechaCreado = CheckFechDBNull(item.RubAudFchIns, fechatemp)
                                    RubroRegistro.UsrModificador = item.RubAudUsrUpd
                                    RubroRegistro.FechaModificado = CheckFechDBNull(item.RubAudFchUpd, fechatemp)
                                    RubroRegistro.Id = item.RubRid
                                    'If item.RubIdExt.HasValue Then RubroRegistro.IdExterno = item.RubIdExt
                                    RubroRegistro.IdExterno = item.RubId

                                    ' save it
                                    adapter.SaveEntity(RubroRegistro)
                                Else
                                    ObjImporteComisionVenta = Nothing
                                    ObjPorcentajeComisionVenta = Nothing

                                    EncontroIdRubroCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Rubro(strConexion, item.RubId, RespuestaFuncion, IdRuboCliente)
                                    Dim filterBucketRubro As RelationPredicateBucket = New RelationPredicateBucket(RubroFields.IdExterno = IdRuboCliente)
                                    Dim updateRegistroRubro As RubroEntity = New RubroEntity() With
                                        {
                                            .SignoId = item.SngId.GetValueOrDefault(),
                                            .Descripcion = item.RubDsc,
                                            .ImporteComisionVenta = CheckDBNull(ObjImporteComisionVenta, item.RubImpComVta),
                                            .PorcentajeComisionVenta = CheckDBNull(ObjPorcentajeComisionVenta, item.RubPctComVta),
                                            .NumeroCuenta = item.RubNroCta,
                                            .CodigoEmpresaOnLine = item.RubCodEmpOln,
                                            .ArticuloId = item.ArtId.GetValueOrDefault(),
                                            .ManejaImpuestos = item.RubManTax,
                                            .Sistema = item.RubSys,
                                            .UsrCreador = item.RubAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.RubAudFchIns, fechatemp),
                                            .UsrModificador = item.RubAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.RubAudFchUpd, fechatemp),
                                            .Id = item.RubRid
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroRubro, filterBucketRubro)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Marca
                    If (MarcaClasses IsNot Nothing) AndAlso (MarcaClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In MarcaClasses
                                EncontroRegistro = False
                                EncontroIdMarcaCliente = False
                                IdMarcaCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca(strConexion, item.MrcId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim MarcaRegistro As New MarcaEntity()

                                    MarcaRegistro.Id = item.MrcId
                                    MarcaRegistro.Descripcion = item.MrcDsc
                                    MarcaRegistro.UsrCreador = item.MrcAudUsrIns
                                    MarcaRegistro.FechaCreado = CheckFechDBNull(item.MrcAudFchIns, fechatemp)
                                    MarcaRegistro.UsrModificador = item.MrcAudUsrUpd
                                    MarcaRegistro.FechaModificado = CheckFechDBNull(item.MrcAudFchUpd, fechatemp)
                                    'MarcaRegistro.RId = item.MrcRid
                                    'If item.MrcIdExt.HasValue Then MarcaRegistro.IdExterno = item.MrcIdExt
                                    MarcaRegistro.IdExterno = item.MrcId

                                    ' save it
                                    adapter.SaveEntity(MarcaRegistro)
                                Else
                                    'convierte el Id de Telko (Marca) por el Id del Cliente
                                    EncontroIdMarcaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca(strConexion, item.MrcId, RespuestaFuncion, IdMarcaCliente)
                                    Dim filterBucketMarca As RelationPredicateBucket = New RelationPredicateBucket(MarcaFields.IdExterno = IdMarcaCliente)
                                    Dim updateRegistroMarca As MarcaEntity = New MarcaEntity() With
                                        {
                                            .Descripcion = item.MrcDsc,
                                            .UsrCreador = item.MrcAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.MrcAudFchIns, fechatemp),
                                            .UsrModificador = item.MrcAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.MrcAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroMarca, filterBucketMarca)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Modelo
                    If (ModeloClasses IsNot Nothing) AndAlso (ModeloClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ModeloClasses
                                EncontroRegistro = False
                                EncontroIdModeloCliente = False
                                IdModeloCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Modelo(strConexion, item.MdlId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ModeloRegistro As New ModeloEntity()

                                    ModeloRegistro.Id = item.MdlId
                                    ModeloRegistro.Descripcion = item.MdlDsc
                                    ModeloRegistro.UsrCreador = item.MdlAudUsrIns
                                    ModeloRegistro.FechaCreado = CheckFechDBNull(item.MdlAudFchIns, fechatemp)
                                    ModeloRegistro.UsrModificador = item.MdlAudUsrUpd
                                    ModeloRegistro.FechaModificado = CheckFechDBNull(item.MdlAudFchUpd, fechatemp)
                                    'ModeloRegistro.RId = item.MdlRid
                                    'If item.MdlIdExt.HasValue Then ModeloRegistro.IdExterno = item.MdlIdExt
                                    ModeloRegistro.IdExterno = item.MdlId

                                    ' save it
                                    adapter.SaveEntity(ModeloRegistro)
                                Else
                                    'convierte el Id de Telko (Modelo) por el Id del Cliente
                                    EncontroIdModeloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Modelo(strConexion, item.MdlId, RespuestaFuncion, IdModeloCliente)
                                    Dim filterBucketModelo As RelationPredicateBucket = New RelationPredicateBucket(ModeloFields.IdExterno = IdModeloCliente)
                                    Dim updateRegistroModelo As ModeloEntity = New ModeloEntity() With
                                        {
                                            .Descripcion = item.MdlDsc,
                                            .UsrCreador = item.MdlAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.MdlAudFchIns, fechatemp),
                                            .UsrModificador = item.MdlAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.MdlAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroModelo, filterBucketModelo)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Marca_Modelo 'PENDIENTE PORQUE NO SE COMO FILTRAR POR DOS CAMPOS
                    If (MarcModClasses IsNot Nothing) AndAlso (MarcModClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In MarcModClasses
                                EncontroRegistro = False
                                EncontroIdMarcaCliente = False
                                IdMarcaCliente = 0
                                EncontroIdModeloCliente = False
                                IdModeloCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca_Modelo(strConexion, item.MrcId, RespuestaFuncion)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim MarcModRegistro As New Marca_ModeloEntity()

                                    'convierte el Id de Telko (Marca) por el Id del Cliente
                                    EncontroIdMarcaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca(strConexion, item.MrcId, RespuestaFuncion, IdMarcaCliente)
                                    'MarcModRegistro.MarcaId = item.MrcId ' ASI ESTABA ORIGINALMENTE ANTES DEL 17-05-21
                                    MarcModRegistro.MarcaId = IdMarcaCliente 'item.MrcId

                                    'convierte el Id de Telko (Modelo) por el Id del Cliente
                                    EncontroIdModeloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Modelo(strConexion, item.MdlId, RespuestaFuncion, IdModeloCliente)
                                    'MarcModRegistro.ModeloId = item.MdlId ' ASI ESTABA ORIGINALMENTE ANTES DEL 17-05-21
                                    MarcModRegistro.ModeloId = IdModeloCliente

                                    MarcModRegistro.UsrCreador = item.MrcMdlAudUsrIns
                                    MarcModRegistro.FechaCreado = CheckFechDBNull(item.MrcMdlAudFchIns, fechatemp)
                                    MarcModRegistro.UsrModificador = item.MrcMdlAudUsrUpd
                                    MarcModRegistro.FechaModificado = CheckFechDBNull(item.MrcMdlAudFchUpd, fechatemp)
                                    'MarcModRegistro.RId = item.MrcMdlRid

                                    ' save it
                                    adapter.SaveEntity(MarcModRegistro)
                                Else
                                    '' PENDIENTE PORQUE NO SE COMO FILTRAR POR DOS CAMPOS
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Nivel
                    If (NivelClasses IsNot Nothing) AndAlso (NivelClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In NivelClasses
                                EncontroRegistro = False
                                EncontroIdNivelCliente = False
                                IdNivelCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Nivel(strConexion, item.NivId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim NivelRegistro As New NivelEntity()

                                    NivelRegistro.Id = item.NivId
                                    NivelRegistro.Descripcion = item.NivDsc
                                    NivelRegistro.Inferior = item.NivInf
                                    If item.NivLbl.HasValue Then NivelRegistro.Nivel = item.NivLbl
                                    NivelRegistro.IdSuperior = item.NivIdSup
                                    NivelRegistro.NumeroCuenta = item.NivNroCta
                                    NivelRegistro.UsrCreador = item.NivAudUsrIns
                                    NivelRegistro.FechaCreado = CheckFechDBNull(item.NivAudFchIns, fechatemp)
                                    NivelRegistro.UsrModificador = item.NivAudUsrUpd
                                    NivelRegistro.FechaModificado = CheckFechDBNull(item.NivAudFchUpd, fechatemp)
                                    If item.ImgId.HasValue Then NivelRegistro.ImagenId = item.ImgId
                                    NivelRegistro.PublicableWeb = item.NivPubWeb
                                    If item.NivOrd.HasValue Then NivelRegistro.Orden = item.NivOrd
                                    If item.NivPagSiz.HasValue Then NivelRegistro.PageSize = item.NivPagSiz
                                    NivelRegistro.PriceRange = item.NivPrcRgn
                                    NivelRegistro.ShowOnHomePage = item.NivShwHomPag
                                    'NivelRegistro.IdExterno = item.NivIdExt
                                    NivelRegistro.IdExterno = item.NivId

                                    ' save it
                                    adapter.SaveEntity(NivelRegistro)
                                Else
                                    ObjNivelId = Nothing
                                    ObjOrden = Nothing
                                    ObjPageSize = Nothing

                                    'convierte el Id de Telko (Nivel) por el Id del Cliente
                                    EncontroIdNivelCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Nivel(strConexion, item.NivId, RespuestaFuncion, IdNivelCliente)
                                    Dim filterBucketNivel As RelationPredicateBucket = New RelationPredicateBucket(NivelFields.IdExterno = IdNivelCliente)
                                    Dim updateRegistroNivel As NivelEntity = New NivelEntity() With
                                        {
                                            .Descripcion = item.NivDsc,
                                            .Inferior = item.NivInf,
                                            .Nivel = CheckDBNull(ObjNivelId, item.NivLbl),
                                            .IdSuperior = item.NivIdSup,
                                            .NumeroCuenta = item.NivNroCta,
                                            .UsrCreador = item.NivAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.NivAudFchIns, fechatemp),
                                            .UsrModificador = item.NivAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.NivAudFchUpd, fechatemp),
                                            .ImagenId = item.ImgId.GetValueOrDefault(),
                                            .PublicableWeb = item.NivPubWeb,
                                            .Orden = CheckDBNull(ObjOrden, item.NivOrd),
                                            .PageSize = CheckDBNull(ObjPageSize, item.NivPagSiz),
                                            .PriceRange = item.NivPrcRgn,
                                            .ShowOnHomePage = item.NivShwHomPag
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroNivel, filterBucketNivel)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Procedencia
                    If (ProcedenciaClasses IsNot Nothing) AndAlso (ProcedenciaClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ProcedenciaClasses
                                EncontroRegistro = False
                                EncontroIdProcedCliente = False
                                IdProcedCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Procedencia(strConexion, item.PrdId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ProcedenciaRegistro As New ProcedenciaEntity()

                                    ProcedenciaRegistro.Id = item.PrdId
                                    ProcedenciaRegistro.Descripcion = item.PrdDsc
                                    ProcedenciaRegistro.UsrCreador = item.PrdAudUsrIns
                                    ProcedenciaRegistro.FechaCreado = CheckFechDBNull(item.PrdAudFchIns, fechatemp)
                                    ProcedenciaRegistro.UsrModificador = item.PrdAudUsrUpd
                                    ProcedenciaRegistro.FechaModificado = CheckFechDBNull(item.PrdAudFchUpd, fechatemp)
                                    'ProcedenciaRegistro.RId = item.PrdRid
                                    'If item.PrdIdExt.HasValue Then ProcedenciaRegistro.IdExterno = item.PrdIdExt
                                    ProcedenciaRegistro.IdExterno = item.PrdId

                                    ' save it
                                    adapter.SaveEntity(ProcedenciaRegistro)
                                Else
                                    'convierte el Id de Telko (Procedencia) por el Id del Cliente
                                    EncontroIdProcedCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Procedencia(strConexion, item.PrdId, RespuestaFuncion, IdProcedCliente)
                                    Dim filterBucketProcedencia As RelationPredicateBucket = New RelationPredicateBucket(ProcedenciaFields.IdExterno = IdProcedCliente)
                                    Dim updateRegistroProcedencia As ProcedenciaEntity = New ProcedenciaEntity() With
                                        {
                                            .Descripcion = item.PrdDsc,
                                            .UsrCreador = item.PrdAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.PrdAudFchIns, fechatemp),
                                            .UsrModificador = item.PrdAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.PrdAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroProcedencia, filterBucketProcedencia)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla unidad
                    If (UnidadClasses IsNot Nothing) AndAlso (UnidadClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In UnidadClasses
                                EncontroRegistro = False
                                EncontroIdunidadCliente = False
                                IdUnidadCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Unidad(strConexion, item.UniId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim UnidadRegistro As New UnidadEntity()

                                    UnidadRegistro.Id = item.UniId
                                    UnidadRegistro.Descripcion = item.UniDsc
                                    UnidadRegistro.UsrCreador = item.UniAudUsrIns
                                    UnidadRegistro.FechaCreado = CheckFechDBNull(item.UniAudFchIns, fechatemp)
                                    UnidadRegistro.UsrModificador = item.UniAudUsrUpd
                                    UnidadRegistro.FechaModificado = CheckFechDBNull(item.UniAudFchUpd, fechatemp)
                                    'UnidadRegistro.RId = item.UniRId
                                    'If item.UniIdExt.HasValue Then UnidadRegistro.IdExterno = item.UniIdExt
                                    UnidadRegistro.IdExterno = item.UniId

                                    ' save it
                                    adapter.SaveEntity(UnidadRegistro)
                                Else
                                    'convierte el Id de Telko (Unidad) por el Id del Cliente
                                    EncontroIdunidadCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Unidad(strConexion, item.UniId, RespuestaFuncion, IdUnidadCliente)
                                    Dim filterBucketUnidad As RelationPredicateBucket = New RelationPredicateBucket(UnidadFields.IdExterno = IdUnidadCliente)
                                    Dim updateRegistroUnidad As UnidadEntity = New UnidadEntity() With
                                        {
                                            .Descripcion = item.UniDsc,
                                            .UsrCreador = item.UniAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.UniAudFchIns, fechatemp),
                                            .UsrModificador = item.UniAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.UniAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroUnidad, filterBucketUnidad)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla ArticuloTipo
                    If (ArtTipClasses IsNot Nothing) AndAlso (ArtTipClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArtTipClasses
                                EncontroRegistro = False
                                EncontroIdArtTipoCliente = False
                                IdArtTipoCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloTipo_IdExt(strConexion, item.ArtTipId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArticuloTipoRegistro As New ArticuloTipoEntity()

                                    ArticuloTipoRegistro.Id = item.ArtTipId
                                    ArticuloTipoRegistro.Descripcion = item.ArtTipDsc
                                    ArticuloTipoRegistro.UsrCreador = item.ArtTipAudUsrIns
                                    ArticuloTipoRegistro.FechaCreado = CheckFechDBNull(item.ArtTipAudFchIns, fechatemp)
                                    ArticuloTipoRegistro.UsrModificador = item.ArtTipAudUsrUpd
                                    ArticuloTipoRegistro.FechaModificado = CheckFechDBNull(item.ArtTipAudFchUpd, fechatemp)
                                    'ArticuloTipoRegistro.RId = item.ArtTipRid
                                    'If item.ArtTipIdExt.HasValue Then ArticuloTipoRegistro.IdExterno = item.ArtTipIdExt
                                    ArticuloTipoRegistro.IdExterno = item.ArtTipId 'Se asigna al IDEXTERNO el id de TELKO

                                    ' save it
                                    adapter.SaveEntity(ArticuloTipoRegistro)
                                Else
                                    'convierte el Id de Telko (ArticuloTipo) por el Id del Cliente
                                    EncontroIdArtTipoCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloTipo_IdExt(strConexion, item.ArtTipId, RespuestaFuncion, IdArtTipoCliente)
                                    Dim filterBucketArticuloTipo As RelationPredicateBucket = New RelationPredicateBucket(ArticuloTipoFields.IdExterno = IdArtTipoCliente)
                                    Dim updateRegistroArticuloTipo As ArticuloTipoEntity = New ArticuloTipoEntity() With
                                        {
                                            .Descripcion = item.ArtTipDsc,
                                            .UsrCreador = item.ArtTipAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.ArtTipAudFchIns, fechatemp),
                                            .UsrModificador = item.ArtTipAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.ArtTipAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroArticuloTipo, filterBucketArticuloTipo)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla ArticuloClase
                    If (ArticuloClaseClasses IsNot Nothing) AndAlso (ArticuloClaseClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArticuloClaseClasses
                                EncontroRegistro = False
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloClase(strConexion, item.ArtClsId, RespuestaFuncion)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArticuloClaseRegistro As New ArticuloClaseEntity()

                                    ArticuloClaseRegistro.Id = item.ArtClsId
                                    ArticuloClaseRegistro.Descripcion = item.ArtClsDsc
                                    'ArticuloClaseRegistro.RId = item.ArtClsRid
                                    If item.ArtClsOrd.HasValue Then ArticuloClaseRegistro.Orden = item.ArtClsOrd
                                    ArticuloClaseRegistro.PermiteAutoReposicion = item.ArtClsPerAutRpn
                                    If item.DocTpoIdSal.HasValue Then ArticuloClaseRegistro.DocumentoTipoIdDefectoSalida = item.DocTpoIdSal
                                    If item.DocTpoIdEnt.HasValue Then ArticuloClaseRegistro.DocumentoTipoIdDefectoEntrada = item.DocTpoIdEnt
                                    ArticuloClaseRegistro.OcultarArticulos = item.ArtClsOcu
                                    If item.RubId.HasValue Then ArticuloClaseRegistro.RubroId = item.RubId
                                    ArticuloClaseRegistro.UsrCreador = item.ArtClsAudUsrIns
                                    ArticuloClaseRegistro.FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp)
                                    ArticuloClaseRegistro.UsrModificador = item.ArtClsAudUsrUpd
                                    ArticuloClaseRegistro.FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp)
                                    ArticuloClaseRegistro.RequiereDatoExtra = item.ArtClsReqDatExt
                                    ArticuloClaseRegistro.MensajeDatoExtra = item.ArtClsDatExtMsj
                                    ArticuloClaseRegistro.ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp

                                    ' save it
                                    adapter.SaveEntity(ArticuloClaseRegistro)
                                Else
                                    ObjOrden = Nothing
                                    ObjDocumentoTipoIdDefectoSalida = Nothing
                                    ObjDocumentoTipoIdDefectoEntrada = Nothing

                                    ObjOrden = CheckDBNull(ObjOrden, item.ArtClsOrd)
                                    ObjDocumentoTipoIdDefectoSalida = CheckDBNull(ObjDocumentoTipoIdDefectoSalida, item.DocTpoIdSal)
                                    ObjDocumentoTipoIdDefectoEntrada = CheckDBNull(ObjDocumentoTipoIdDefectoEntrada, item.DocTpoIdEnt)
                                    'If item.DocTpoIdSal.HasValue Then
                                    '    ObjDocumentoTipoIdDefectoSalida = item.DocTpoIdSal
                                    'Else
                                    '    ObjDocumentoTipoIdDefectoSalida = Nothing
                                    'End If
                                    'If item.DocTpoIdEnt.HasValue Then
                                    '    ObjDocumentoTipoIdDefectoEntrada = item.DocTpoIdEnt
                                    'Else
                                    '    ObjDocumentoTipoIdDefectoEntrada = Nothing
                                    'End If
                                    'Dim isNullNotNullable = order.Fields.GetCurrentValue(CInt(OrderFields.ShippingDate)) Is Nothing
                                    Dim updateRegistroArticuloClase As ArticuloClaseEntity = Nothing
                                    Dim filterBucketArticuloClase As RelationPredicateBucket = New RelationPredicateBucket(ArticuloClaseFields.Id = item.ArtClsId)
                                    If (ObjDocumentoTipoIdDefectoSalida IsNot Nothing) And (ObjDocumentoTipoIdDefectoEntrada IsNot Nothing) And (ObjOrden IsNot Nothing) Then
                                        updateRegistroArticuloClase = New ArticuloClaseEntity() With
                                       {
                                           .Descripcion = item.ArtClsDsc,
                                           .Orden = ObjOrden,
                                           .PermiteAutoReposicion = item.ArtClsPerAutRpn,
                                           .DocumentoTipoIdDefectoSalida = ObjDocumentoTipoIdDefectoSalida,
                                           .DocumentoTipoIdDefectoEntrada = ObjDocumentoTipoIdDefectoEntrada,
                                           .OcultarArticulos = item.ArtClsOcu,
                                           .UsrCreador = item.ArtClsAudUsrIns,
                                           .FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp),
                                           .UsrModificador = item.ArtClsAudUsrUpd,
                                           .FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp),
                                           .RequiereDatoExtra = item.ArtClsReqDatExt,
                                           .MensajeDatoExtra = item.ArtClsDatExtMsj,
                                           .ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp
                                       }
                                    ElseIf (ObjDocumentoTipoIdDefectoSalida IsNot Nothing) And (ObjDocumentoTipoIdDefectoEntrada Is Nothing) And (ObjOrden Is Nothing) Then
                                        updateRegistroArticuloClase = New ArticuloClaseEntity() With
                                        {
                                          .Descripcion = item.ArtClsDsc,
                                          .PermiteAutoReposicion = item.ArtClsPerAutRpn,
                                          .DocumentoTipoIdDefectoSalida = ObjDocumentoTipoIdDefectoSalida,
                                          .OcultarArticulos = item.ArtClsOcu,
                                          .UsrCreador = item.ArtClsAudUsrIns,
                                          .FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp),
                                          .UsrModificador = item.ArtClsAudUsrUpd,
                                          .FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp),
                                          .RequiereDatoExtra = item.ArtClsReqDatExt,
                                          .MensajeDatoExtra = item.ArtClsDatExtMsj,
                                          .ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp
                                        }
                                    ElseIf (ObjDocumentoTipoIdDefectoSalida Is Nothing) And (ObjDocumentoTipoIdDefectoEntrada IsNot Nothing) And (ObjOrden Is Nothing) Then
                                        updateRegistroArticuloClase = New ArticuloClaseEntity() With
                                        {
                                          .Descripcion = item.ArtClsDsc,
                                          .PermiteAutoReposicion = item.ArtClsPerAutRpn,
                                          .DocumentoTipoIdDefectoEntrada = ObjDocumentoTipoIdDefectoEntrada,
                                          .OcultarArticulos = item.ArtClsOcu,
                                          .UsrCreador = item.ArtClsAudUsrIns,
                                          .FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp),
                                          .UsrModificador = item.ArtClsAudUsrUpd,
                                          .FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp),
                                          .RequiereDatoExtra = item.ArtClsReqDatExt,
                                          .MensajeDatoExtra = item.ArtClsDatExtMsj,
                                          .ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp
                                        }
                                    ElseIf (ObjDocumentoTipoIdDefectoSalida Is Nothing) And (ObjDocumentoTipoIdDefectoEntrada Is Nothing) And (ObjOrden IsNot Nothing) Then
                                        updateRegistroArticuloClase = New ArticuloClaseEntity() With
                                        {
                                          .Descripcion = item.ArtClsDsc,
                                          .PermiteAutoReposicion = item.ArtClsPerAutRpn,
                                          .Orden = ObjOrden,
                                          .OcultarArticulos = item.ArtClsOcu,
                                          .UsrCreador = item.ArtClsAudUsrIns,
                                          .FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp),
                                          .UsrModificador = item.ArtClsAudUsrUpd,
                                          .FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp),
                                          .RequiereDatoExtra = item.ArtClsReqDatExt,
                                          .MensajeDatoExtra = item.ArtClsDatExtMsj,
                                          .ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp
                                        }
                                    ElseIf (ObjDocumentoTipoIdDefectoSalida Is Nothing) And (ObjDocumentoTipoIdDefectoEntrada Is Nothing) And (ObjOrden Is Nothing) Then
                                        updateRegistroArticuloClase = New ArticuloClaseEntity() With
                                        {
                                          .Descripcion = item.ArtClsDsc,
                                          .PermiteAutoReposicion = item.ArtClsPerAutRpn,
                                          .OcultarArticulos = item.ArtClsOcu,
                                          .UsrCreador = item.ArtClsAudUsrIns,
                                          .FechaCreado = CheckFechDBNull(item.ArtClsAudFchIns, fechatemp),
                                          .UsrModificador = item.ArtClsAudUsrUpd,
                                          .FechaModificado = CheckFechDBNull(item.ArtClsAudFchUpd, fechatemp),
                                          .RequiereDatoExtra = item.ArtClsReqDatExt,
                                          .MensajeDatoExtra = item.ArtClsDatExtMsj,
                                          .ExpresionRegularDatoExtra = item.ArtClsDatExtRegExp
                                        }
                                    End If
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroArticuloClase, filterBucketArticuloClase)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Articulo
                    If (ArticuloClasses IsNot Nothing) AndAlso (ArticuloClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArticuloClasses
                                EncontroRegistro = False
                                EncontroIdRubroCliente = False
                                IdRuboCliente = 0
                                EncontroIdArtTipoCliente = False
                                IdArtTipoCliente = 0
                                EncontroIdProcedCliente = False
                                IdProcedCliente = 0
                                EncontroIdNivelCliente = False
                                IdNivelCliente = 0
                                EncontroIdMarcaCliente = False
                                IdMarcaCliente = 0
                                EncontroIdModeloCliente = False
                                IdModeloCliente = 0
                                EncontroIdunidadCliente = False
                                IdUnidadCliente = 0
                                EncontroIdArticuloCliente = False
                                IdArticuloCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArticuloRegistro As New ArticuloEntity()

                                    'ArticuloRegistro.Id = item.ArtId este campo es autoincremental

                                    'convierte el Id de Telko (ArticuloTipo) por el Id del Cliente
                                    If item.ArtTipId.HasValue Then
                                        EncontroIdArtTipoCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloTipo_IdExt(strConexion, item.ArtTipId, RespuestaFuncion, IdArtTipoCliente)
                                        ArticuloRegistro.ArticuloTipoId = IdArtTipoCliente 'item.ArtTipId
                                    End If

                                    'convierte el Id de Telko (Procedencia) por el Id del Cliente
                                    If item.PrdId.HasValue Then
                                        EncontroIdProcedCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Procedencia(strConexion, item.PrdId, RespuestaFuncion, IdProcedCliente)
                                        ArticuloRegistro.ProcedenciaId = IdProcedCliente 'item.PrdId
                                    End If

                                    If item.ArtCatId.HasValue Then ArticuloRegistro.ArticuloCategoriaId = item.ArtCatId

                                    'convierte el Id de Telko (Nivel) por el Id del Cliente
                                    If item.PrdId.HasValue Then
                                        EncontroIdNivelCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Nivel(strConexion, item.NivId, RespuestaFuncion, IdNivelCliente)
                                        ArticuloRegistro.NivelId = IdNivelCliente 'item.NivId 
                                    End If

                                    'convierte el Id de Telko (Marca) por el Id del Cliente
                                    If item.MrcId.HasValue Then
                                        EncontroIdMarcaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca(strConexion, item.MrcId, RespuestaFuncion, IdMarcaCliente)
                                        ArticuloRegistro.MarcaId = IdMarcaCliente 'item.MrcId
                                    End If

                                    If item.ArtClsId.HasValue Then ArticuloRegistro.ArticuloClaseId = item.ArtClsId ' NO TIENE ID EXTERNO
                                    If item.ArtEnvId.HasValue Then ArticuloRegistro.ArticuloEnvaseId = item.ArtEnvId ' NO SE A QUE TABLA CORRESPONDE
                                    If item.ArtRepId.HasValue Then ArticuloRegistro.ArticuloRepresentanteId = item.ArtRepId 'NO SE A QUE TABLA CORRESPONDE
                                    ArticuloRegistro.Comisionable = item.ArtCom

                                    'convierte el Id de Telko (Rubro) por el Id del Cliente
                                    EncontroIdRubroCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Rubro(strConexion, item.RubId, RespuestaFuncion, IdRuboCliente)
                                    ArticuloRegistro.RubroId = IdRuboCliente ' item.RubId

                                    'convierte el Id de Telko (Modelo) por el Id del Cliente
                                    If item.MdlId.HasValue Then
                                        EncontroIdModeloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Modelo(strConexion, item.MdlId, RespuestaFuncion, IdModeloCliente)
                                        ArticuloRegistro.ModeloId = IdModeloCliente 'item.MdlId
                                    End If

                                    ArticuloRegistro.Descripcion = item.ArtDsc
                                    ArticuloRegistro.DescripcionCorta = item.ArtDscCta
                                    If item.ArtPerDia.HasValue Then ArticuloRegistro.DiasAPerecer = item.ArtPerDia
                                    ArticuloRegistro.Imagen = item.ArtImg
                                    ArticuloRegistro.Override = item.ArtOvr
                                    ArticuloRegistro.Fraccionable = item.ArtFra
                                    ArticuloRegistro.Vendible = item.ArtVen
                                    ArticuloRegistro.Observacion = item.ArtObs
                                    If item.ArtMer.HasValue Then ArticuloRegistro.PorcentajeMerma = item.ArtMer
                                    ArticuloRegistro.RequeridoEnVenta = item.ArtExtVta
                                    ArticuloRegistro.Perecedero = item.ArtPer
                                    ArticuloRegistro.Exportable = item.ArtExp
                                    ArticuloRegistro.Seriado = item.ArtSer
                                    ArticuloRegistro.SerieOculta = item.ArtSerOcu
                                    ArticuloRegistro.DiaGarantia = item.ArtDiaGtia
                                    ArticuloRegistro.Activo = item.ArtAct
                                    ArticuloRegistro.ControlaStock = item.ArtCtrStk
                                    ArticuloRegistro.UPC = item.ArtUPC
                                    If item.ProvIdCst.HasValue Then ArticuloRegistro.ProveedorIdCosto = item.ProvIdCst
                                    If item.ArtMgr.HasValue Then ArticuloRegistro.Margen = item.ArtMgr
                                    ArticuloRegistro.CodigoAlterno = item.ArtIdAlt
                                    ArticuloRegistro.UsrCreador = item.ArtAudUsrIns
                                    'ArticuloRegistro.FechaCreado = item.ArtAudFchIns
                                    ArticuloRegistro.FechaCreado = CheckFechDBNull(item.ArtAudFchIns, fechatemp)
                                    ArticuloRegistro.UsrModificador = item.ArtAudUsrUpd
                                    'ArticuloRegistro.FechaModificado = item.ArtAudFchUpd
                                    ArticuloRegistro.FechaModificado = CheckFechDBNull(item.ArtAudFchUpd, fechatemp)
                                    'ArticuloRegistro.RId = item.ArtRid
                                    ArticuloRegistro.PublicableWeb = item.ArtWeb

                                    'convierte el Id de Telko (Unidad) por el Id del Cliente
                                    If item.UniId.HasValue Then
                                        EncontroIdunidadCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Unidad(strConexion, item.UniId, RespuestaFuncion, IdUnidadCliente)
                                        ArticuloRegistro.UnidadId = IdUnidadCliente 'item.UniId
                                    End If

                                    ArticuloRegistro.Enviable = item.ArtShp
                                    If item.ArtPso.HasValue Then ArticuloRegistro.Peso = item.ArtPso
                                    If item.ArtLng.HasValue Then ArticuloRegistro.Largo = item.ArtLng
                                    If item.ArtAnc.HasValue Then ArticuloRegistro.Ancho = item.ArtAnc
                                    If item.ArtAlt.HasValue Then ArticuloRegistro.Altura = item.ArtAlt
                                    ArticuloRegistro.GuiaDeVariante = item.ArtGiaVar

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    If item.ArtIdGia.HasValue Then
                                        EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtIdGia, RespuestaFuncion, IdArticuloCliente)
                                        ArticuloRegistro.ArticuloIdGuia = IdArticuloCliente 'item.ArtIdGia
                                    End If

                                    ArticuloRegistro.DescripcionVariante = item.ArtDscAtr
                                    ArticuloRegistro.CodigoExterno = item.ArtCodExt
                                    ArticuloRegistro.IsDeleted = item.IsDeleted
                                    If item.CndId.HasValue Then ArticuloRegistro.CondicionId = item.CndId
                                    If item.CsgId.HasValue Then ArticuloRegistro.ConsignadorId = item.CsgId
                                    'If item.ArtIdExt.HasValue Then ArticuloRegistro.IdExterno = item.ArtIdExt
                                    ArticuloRegistro.IdExterno = item.ArtId

                                    ' save it
                                    adapter.SaveEntity(ArticuloRegistro)
                                Else
                                    ObjArticuloTipoId = Nothing
                                    ObjProcedenciaId = Nothing
                                    ObjArticuloCategoriaId = Nothing
                                    ObjNivelId = Nothing
                                    ObjMarcaId = Nothing
                                    ObjArticuloClaseId = Nothing
                                    ObjArticuloEnvaseId = Nothing
                                    ObjArticuloRepresentanteId = Nothing
                                    ObjRubroId = Nothing
                                    ObjModeloId = Nothing
                                    ObjDiasAPerecer = Nothing
                                    ObjPorcentajeMerma = Nothing
                                    ObjProveedorIdCosto = Nothing
                                    ObjMargen = Nothing
                                    ObjUnidadId = Nothing
                                    ObjPeso = Nothing
                                    ObjLargo = Nothing
                                    ObjAncho = Nothing
                                    ObjAltura = Nothing
                                    ObjArticuloIdGuia = Nothing
                                    ObjCondicionId = Nothing
                                    ObjConsignadorId = Nothing

                                    'convierte el Id de Telko (ArticuloTipo) por el Id del Cliente
                                    If item.ArtTipId.HasValue Then
                                        EncontroIdArtTipoCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloTipo_IdExt(strConexion, item.ArtTipId, RespuestaFuncion, IdArtTipoCliente)
                                        ObjArticuloTipoId = IdArtTipoCliente
                                    Else
                                        ObjArticuloTipoId = Nothing
                                    End If
                                    'convierte el Id de Telko (Procedencia) por el Id del Cliente
                                    If item.PrdId.HasValue Then
                                        EncontroIdProcedCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Procedencia(strConexion, item.PrdId, RespuestaFuncion, IdProcedCliente)
                                        ObjProcedenciaId = IdProcedCliente 'item.PrdId
                                    Else
                                        ObjProcedenciaId = Nothing
                                    End If

                                    'convierte el Id de Telko (Nivel) por el Id del Cliente
                                    If item.PrdId.HasValue Then
                                        EncontroIdNivelCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Nivel(strConexion, item.NivId, RespuestaFuncion, IdNivelCliente)
                                        ObjNivelId = IdNivelCliente 'item.NivId 
                                    Else
                                        ObjNivelId = Nothing
                                    End If
                                    'convierte el Id de Telko (Marca) por el Id del Cliente
                                    If item.MrcId.HasValue Then
                                        EncontroIdMarcaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Marca(strConexion, item.MrcId, RespuestaFuncion, IdMarcaCliente)
                                        ObjMarcaId = IdMarcaCliente
                                    Else
                                        ObjMarcaId = Nothing
                                    End If

                                    'convierte el Id de Telko (Rubro) por el Id del Cliente
                                    EncontroIdRubroCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Rubro(strConexion, item.RubId, RespuestaFuncion, IdRuboCliente)
                                    ObjRubroId = IdRuboCliente ' item.RubId

                                    'convierte el Id de Telko (Modelo) por el Id del Cliente
                                    If item.MdlId.HasValue Then
                                        EncontroIdModeloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Modelo(strConexion, item.MdlId, RespuestaFuncion, IdModeloCliente)
                                        ObjModeloId = IdModeloCliente 'item.MdlId
                                    Else
                                        ObjModeloId = Nothing
                                    End If
                                    'convierte el Id de Telko (Unidad) por el Id del Cliente
                                    If item.UniId.HasValue Then
                                        EncontroIdunidadCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Unidad(strConexion, item.UniId, RespuestaFuncion, IdUnidadCliente)
                                        ObjUnidadId = IdUnidadCliente
                                    Else
                                        ObjUnidadId = Nothing
                                    End If
                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    If item.ArtIdGia.HasValue Then
                                        EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtIdGia, RespuestaFuncion, IdArticuloCliente)
                                        ObjArticuloIdGuia = IdArticuloCliente 'item.ArtIdGia
                                    Else
                                        ObjArticuloIdGuia = Nothing
                                    End If

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    Dim filterBucketArticulo As RelationPredicateBucket = New RelationPredicateBucket(ArticuloFields.IdExterno = IdArticuloCliente)
                                    Dim updateRegistroArticulo As ArticuloEntity = New ArticuloEntity() With
                                        {
                                            .ArticuloTipoId = ObjArticuloTipoId,
                                            .ProcedenciaId = ObjProcedenciaId,
                                            .ArticuloCategoriaId = CheckDBNull(ObjArticuloCategoriaId, item.ArtCatId),
                                            .NivelId = ObjNivelId,
                                            .MarcaId = ObjMarcaId,
                                            .ArticuloClaseId = CheckDBNull(ObjArticuloClaseId, item.ArtClsId), ' NO TIENE ID EXTERNO
                                            .ArticuloEnvaseId = CheckDBNull(ObjArticuloEnvaseId, item.ArtEnvId), ' NO SE A QUE TABLA CORRESPONDE
                                            .ArticuloRepresentanteId = CheckDBNull(ObjArticuloRepresentanteId, item.ArtRepId), 'NO SE A QUE TABLA CORRESPONDE
                                            .Comisionable = item.ArtCom,
                                            .RubroId = ObjRubroId,
                                            .ModeloId = ObjModeloId,
                                            .Descripcion = item.ArtDsc,
                                            .DescripcionCorta = item.ArtDscCta,
                                            .DiasAPerecer = CheckDBNull(ObjDiasAPerecer, item.ArtPerDia),
                                            .Imagen = item.ArtImg,
                                            .Override = item.ArtOvr,
                                            .Fraccionable = item.ArtFra,
                                            .Vendible = item.ArtVen,
                                            .Observacion = item.ArtObs,
                                            .PorcentajeMerma = CheckDBNull(ObjPorcentajeMerma, item.ArtMer),
                                            .RequeridoEnVenta = item.ArtExtVta,
                                            .Perecedero = item.ArtPer,
                                            .Exportable = item.ArtExp,
                                            .Seriado = item.ArtSer,
                                            .SerieOculta = item.ArtSerOcu,
                                            .DiaGarantia = item.ArtDiaGtia,
                                            .Activo = item.ArtAct,
                                            .ControlaStock = item.ArtCtrStk,
                                            .UPC = item.ArtUPC,
                                            .ProveedorIdCosto = CheckDBNull(ObjProveedorIdCosto, item.ProvIdCst),
                                            .Margen = CheckDBNull(ObjMargen, item.ArtMgr),
                                            .CodigoAlterno = item.ArtIdAlt,
                                            .UsrCreador = item.ArtAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.ArtAudFchIns, fechatemp),
                                            .UsrModificador = item.ArtAudUsrUpd,
                                            .PublicableWeb = item.ArtWeb,
                                            .UnidadId = ObjUnidadId,
                                            .Enviable = item.ArtShp,
                                            .Peso = CheckDBNull(ObjPeso, item.ArtPso),
                                            .Largo = CheckDBNull(ObjLargo, item.ArtLng),
                                            .Ancho = CheckDBNull(ObjAncho, item.ArtAnc),
                                            .Altura = CheckDBNull(ObjAltura, item.ArtAlt),
                                            .GuiaDeVariante = item.ArtGiaVar,
                                            .ArticuloIdGuia = ObjArticuloIdGuia,
                                            .DescripcionVariante = item.ArtDscAtr,
                                            .CodigoExterno = item.ArtCodExt,
                                            .IsDeleted = item.IsDeleted,
                                            .CondicionId = CheckDBNull(ObjCondicionId, item.CndId),
                                            .ConsignadorId = CheckDBNull(ObjConsignadorId, item.CsgId)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroArticulo, filterBucketArticulo)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla Articulo_Impuesto
                    If (ArtImpClasses IsNot Nothing) AndAlso (ArtImpClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArtImpClasses
                                EncontroRegistro = False
                                EncontroIdArticuloCliente = False
                                IdArticuloCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo_Impuesto(strConexion, item.ArtId, RespuestaFuncion)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArtImpRegistro As New Articulo_ImpuestoEntity()

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    EncontroRegistro = False
                                    EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo_Impuesto(strConexion, IdArticuloCliente, RespuestaFuncion)

                                    If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                        ArtImpRegistro.ArticuloId = IdArticuloCliente 'item.ArtId 

                                        ArtImpRegistro.ImpuestoId = item.TaxId
                                        ArtImpRegistro.UsrCreador = item.ArtTaxAudUsrIns
                                        ArtImpRegistro.FechaCreado = CheckFechDBNull(item.ArtTaxAudFchIns, fechatemp)
                                        ArtImpRegistro.UsrModificador = item.ArtTaxAudUsrUpd
                                        ArtImpRegistro.FechaModificado = CheckFechDBNull(item.ArtTaxAudFchUpd, fechatemp)
                                        'ArtImpRegistro.RId = item.ArtTaxRid

                                        ' save it
                                        adapter.SaveEntity(ArtImpRegistro)
                                    Else
                                        'convierte el Id de Telko (Articulo) por el Id del Cliente
                                        ''EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                        Dim filterBucketArticulo_Impuesto As RelationPredicateBucket = New RelationPredicateBucket(Articulo_ImpuestoFields.ArticuloId = IdArticuloCliente)
                                        Dim updateRegistroArticulo_Impuesto As Articulo_ImpuestoEntity = New Articulo_ImpuestoEntity() With
                                            {
                                                .ImpuestoId = item.TaxId,
                                                .UsrCreador = item.ArtTaxAudUsrIns,
                                                .FechaCreado = CheckFechDBNull(item.ArtTaxAudFchIns, fechatemp),
                                                .UsrModificador = item.ArtTaxAudUsrUpd,
                                                .FechaModificado = CheckFechDBNull(item.ArtTaxAudFchUpd, fechatemp)
                                            }
                                        Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                            ' update it
                                            adapterUpd.UpdateEntitiesDirectly(updateRegistroArticulo_Impuesto, filterBucketArticulo_Impuesto)
                                        End Using
                                    End If
                                Else

                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla AAtributoPlantilla
                    If (AAtrbPlatClasses IsNot Nothing) AndAlso (AAtrbPlatClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In AAtrbPlatClasses
                                EncontroIdAAtributoPlantillaCliente = False
                                IdAAtributoPlantillaCliente = 0
                                EncontroRegistro = False
                                'EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla(strConexion, item.AAtPlnID, RespuestaFuncion)
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim AAtrbPlatRegistro As New AAtributoPlantillaEntity()

                                    AAtrbPlatRegistro.ID = item.AAtPlnID
                                    AAtrbPlatRegistro.Nombre = item.AAtPlnNom
                                    AAtrbPlatRegistro.Sistema = item.AAtPlnSys
                                    AAtrbPlatRegistro.UsrCreador = item.AAtPlnAudUsrIns
                                    AAtrbPlatRegistro.FechaCreado = CheckFechDBNull(item.AAtPlnAudFchIns, fechatemp)
                                    AAtrbPlatRegistro.UsrModificador = item.AAtPlnAudUsrUpd
                                    AAtrbPlatRegistro.FechaModificado = CheckFechDBNull(item.AAtPlnAudFchUpd, fechatemp)
                                    'AAtrbPlatRegistro.RId = item.AAtPlnRId
                                    AAtrbPlatRegistro.Tipo = item.AAPlnTpo
                                    AAtrbPlatRegistro.Largo = item.AAPlnLar
                                    AAtrbPlatRegistro.Escala = item.AAPlnEsc
                                    AAtrbPlatRegistro.Formato = item.AAPlnFmt
                                    AAtrbPlatRegistro.FormatoVariante = item.AAPlnFmtVar
                                    AAtrbPlatRegistro.Mascara = item.AAPlnMsk
                                    AAtrbPlatRegistro.IdExterno = item.AAtPlnID 'Se asigna al IDEXTERNO el id de TELKO

                                    ' save it
                                    adapter.SaveEntity(AAtrbPlatRegistro)
                                Else
                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    Dim filterBucketAAtributoPlantilla As RelationPredicateBucket = New RelationPredicateBucket(AAtributoPlantillaFields.IdExterno = IdAAtributoPlantillaCliente)
                                    Dim updateRegistroAAtributoPlantilla As AAtributoPlantillaEntity = New AAtributoPlantillaEntity() With
                                        {
                                            .Nombre = item.AAtPlnNom,
                                            .Sistema = item.AAtPlnSys,
                                            .UsrCreador = item.AAtPlnAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.AAtPlnAudFchIns, fechatemp),
                                            .UsrModificador = item.AAtPlnAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.AAtPlnAudFchUpd, fechatemp),
                                            .Tipo = item.AAPlnTpo,
                                            .Largo = item.AAPlnLar,
                                            .Escala = item.AAPlnEsc,
                                            .Formato = item.AAPlnFmt,
                                            .FormatoVariante = item.AAPlnFmtVar,
                                            .Mascara = item.AAPlnMsk
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroAAtributoPlantilla, filterBucketAAtributoPlantilla)
                                    End Using
                                End If
                            Next
                            ' AAtrbPlatRegistro.AAtPlnIdExt = item. ' el ultimo campo
                        End Using
                    End If
                    'Se procesa la tabla AAtributoPlantillaValor
                    If (AAtrbPlatVClasses IsNot Nothing) AndAlso (AAtrbPlatVClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In AAtrbPlatVClasses
                                EncontroRegistro = False
                                EncontroIdAAtributoPlantillaCliente = False
                                IdAAtributoPlantillaCliente = 0
                                EncontroIdAAtributoPlantillaValorCliente = False
                                IdAAtributoPlantillaValorCliente = 0
                                'EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantillaValor(strConexion, item.AAtPlnValID, RespuestaFuncion)
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantillaValor_IdExt(strConexion, item.AAtPlnValID, RespuestaFuncion, 0)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim AAtrbPlatVRegistro As New AAtributoPlantillaValorEntity()

                                    AAtrbPlatVRegistro.ID = item.AAtPlnValID

                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    'AAtrbPlatVRegistro.AAtributoPlantillaID = item.AAtPlnID
                                    AAtrbPlatVRegistro.AAtributoPlantillaID = IdAAtributoPlantillaCliente

                                    AAtrbPlatVRegistro.UsrCreador = item.AAtPlnValAudUsrIns
                                    AAtrbPlatVRegistro.FechaCreado = CheckFechDBNull(item.AAtPlnValAudFchIns, fechatemp)
                                    AAtrbPlatVRegistro.UsrModificador = item.AAtPlnValAudUsrUpd
                                    AAtrbPlatVRegistro.FechaModificado = CheckFechDBNull(item.AAtPlnValAudFchUpd, fechatemp)
                                    AAtrbPlatVRegistro.IsDeleted = item.IsDeleted
                                    'AAtrbPlatVRegistro.RId = item.AAtPlnValRId
                                    If item.AAPlnValInt.HasValue Then AAtrbPlatVRegistro.ValorInteger = item.AAPlnValInt
                                    If item.AAPlnValDec.HasValue Then AAtrbPlatVRegistro.ValorDecimal = item.AAPlnValDec
                                    If item.AAPlnValBit.HasValue Then AAtrbPlatVRegistro.ValorBinario = item.AAPlnValBit
                                    AAtrbPlatVRegistro.ValorTexto = item.AAPlnValTxt
                                    AAtrbPlatVRegistro.IdExterno = item.AAtPlnValID 'Se asigna al IDEXTERNO el id de TELKO

                                    ' save it
                                    adapter.SaveEntity(AAtrbPlatVRegistro)
                                Else
                                    ObjValorInteger = Nothing
                                    ObjValorDecimal = Nothing
                                    ObjValorBinario = Nothing
                                    ObjAAtributoPlantillaID = Nothing

                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    ObjAAtributoPlantillaID = IdAAtributoPlantillaCliente

                                    EncontroIdAAtributoPlantillaValorCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantillaValor_IdExt(strConexion, item.AAtPlnValID, RespuestaFuncion, IdAAtributoPlantillaValorCliente)
                                    Dim filterBucketAAtributoPlantillaValor As RelationPredicateBucket = New RelationPredicateBucket(AAtributoPlantillaValorFields.IdExterno = IdAAtributoPlantillaValorCliente)
                                    Dim updateRegistroAAtributoPlantillaValor As AAtributoPlantillaValorEntity = New AAtributoPlantillaValorEntity() With
                                        {
                                            .AAtributoPlantillaID = ObjAAtributoPlantillaID,
                                            .UsrCreador = item.AAtPlnValAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.AAtPlnValAudFchIns, fechatemp),
                                            .UsrModificador = item.AAtPlnValAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.AAtPlnValAudFchUpd, fechatemp),
                                            .IsDeleted = item.IsDeleted,
                                            .ValorInteger = CheckDBNull(ObjValorInteger, item.AAPlnValInt),
                                            .ValorDecimal = CheckDBNull(ObjValorDecimal, item.AAPlnValDec),
                                            .ValorBinario = CheckDBNull(ObjValorBinario, item.AAPlnValBit),
                                            .ValorTexto = item.AAPlnValTxt
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroAAtributoPlantillaValor, filterBucketAAtributoPlantillaValor)
                                    End Using
                                End If
                            Next
                            ' AAtrbPlatVRegistro.AAtPlnValIdExt = item. al final de todo
                        End Using
                    End If
                    'Se procesa la tabla Articulo_AAtributoPlantilla
                    If (ArtAtrPlantClasses IsNot Nothing) AndAlso (ArtAtrPlantClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArtAtrPlantClasses
                                EncontroRegistro = False
                                EncontroIdArticuloCliente = False
                                IdArticuloCliente = 0
                                EncontroIdAAtributoPlantillaCliente = False
                                IdAAtributoPlantillaCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo_AAtributoPlantilla(strConexion, item.ArtAAtPlanID, RespuestaFuncion)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArtAtrPlantRegistro As New Articulo_AAtributoPlantillaEntity()

                                    ArtAtrPlantRegistro.ID = item.ArtAAtPlanID

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    ArtAtrPlantRegistro.ArticuloId = IdArticuloCliente 'item.ArtId

                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    'ArtAtrPlantRegistro.AAtributoPlantillaID = item.AAtPlnID ' ASI ESTABA ORIGINALMENTE ANTES DEL 17-05-21
                                    ArtAtrPlantRegistro.AAtributoPlantillaID = IdAAtributoPlantillaCliente

                                    ArtAtrPlantRegistro.UsrCreador = item.ArtAAtPlnAudUsrIns
                                    ArtAtrPlantRegistro.FechaCreado = CheckFechDBNull(item.ArtAAtPlnAudFchIns, fechatemp)
                                    ArtAtrPlantRegistro.UsrModificador = item.ArtAAtPlnAudUsrUpd
                                    ArtAtrPlantRegistro.FechaModificado = CheckFechDBNull(item.ArtAAtPlnAudFchUpd, fechatemp)
                                    'ArtAtrPlantRegistro.RId = item.ArtAAtPlaRId

                                    ' save it
                                    adapter.SaveEntity(ArtAtrPlantRegistro)
                                Else
                                    ObjArticuloId = Nothing
                                    ObjAAtributoPlantillaID = Nothing

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    ObjArticuloId = IdArticuloCliente 'item.ArtId

                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    ObjAAtributoPlantillaID = IdAAtributoPlantillaCliente

                                    Dim filterBucketArticulo_AAtributoPlantilla As RelationPredicateBucket = New RelationPredicateBucket(Articulo_AAtributoPlantillaFields.AAtributoPlantillaID = item.ArtAAtPlanID)
                                    Dim updateRegistroArticulo_AAtributoPlantilla As Articulo_AAtributoPlantillaEntity = New Articulo_AAtributoPlantillaEntity() With
                                        {
                                            .ArticuloId = ObjArticuloId,
                                            .AAtributoPlantillaID = ObjAAtributoPlantillaID,
                                            .UsrCreador = item.ArtAAtPlnAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.ArtAAtPlnAudFchIns, fechatemp),
                                            .UsrModificador = item.ArtAAtPlnAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.ArtAAtPlnAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroArticulo_AAtributoPlantilla, filterBucketArticulo_AAtributoPlantilla)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                    'Se procesa la tabla ArticuloVariante_Combinacion
                    If (ArtVarComClasses IsNot Nothing) AndAlso (ArtVarComClasses.Count > 0) Then
                        Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                            For Each item In ArtVarComClasses
                                EncontroRegistro = False
                                EncontroIdArticuloCliente = False
                                IdArticuloCliente = 0
                                EncontroIdAAtributoPlantillaCliente = False
                                IdAAtributoPlantillaCliente = 0
                                EncontroIdAAtributoPlantillaValorCliente = False
                                IdAAtributoPlantillaValorCliente = 0
                                EncontroRegistro = Studio.Vision.Telko.Shared.Funciones.GetRegistro_ArticuloVariante_Combinacion(strConexion, item.ArtVarCmbID, RespuestaFuncion)

                                If (EncontroRegistro = False And RespuestaFuncion = "") Then
                                    Dim ArtVarCom As New ArticuloVariante_CombinacionEntity()

                                    ArtVarCom.ID = item.ArtVarCmbID

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    ArtVarCom.ArticuloId = IdArticuloCliente 'item.ArtId

                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    'ArtVarCom.AAtributoPlantillaID = item.AAtPlnID ' ASI ESTABA ORIGINALMENTE ANTES DEL 17-05-21
                                    ArtVarCom.AAtributoPlantillaID = IdAAtributoPlantillaCliente

                                    'convierte el Id de Telko (AAtributoPlantillaValor) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaValorCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantillaValor_IdExt(strConexion, item.AAtPlnValID, RespuestaFuncion, IdAAtributoPlantillaValorCliente)
                                    'ArtVarCom.AAtributoPlantillaValorID = item.AAtPlnValID ' ASI ESTABA ORIGINALMENTE ANTES DEL 17-05-21
                                    ArtVarCom.AAtributoPlantillaValorID = IdAAtributoPlantillaValorCliente

                                    ArtVarCom.UsrCreador = item.ArtVarCmbAudUsrIns
                                    ArtVarCom.FechaCreado = CheckFechDBNull(item.ArtVarCmbAudFchIns, fechatemp)
                                    ArtVarCom.UsrModificador = item.ArtVarCmbAudUsrUpd
                                    ArtVarCom.FechaModificado = CheckFechDBNull(item.ArtVarCmbAudFchUpd, fechatemp)
                                    'ArtVarCom.RId = item.ArtVarCmbRId

                                    ' save it
                                    adapter.SaveEntity(ArtVarCom)
                                Else
                                    ObjArticuloId = Nothing
                                    ObjAAtributoPlantillaID = Nothing
                                    ObjAAtributoPlantillaValorID = Nothing

                                    'convierte el Id de Telko (Articulo) por el Id del Cliente
                                    EncontroIdArticuloCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_Articulo(strConexion, item.ArtId, RespuestaFuncion, IdArticuloCliente)
                                    ObjArticuloId = IdArticuloCliente 'item.ArtId
                                    'convierte el Id de Telko (AAtributoPlantilla) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantilla_IdExt(strConexion, item.AAtPlnID, RespuestaFuncion, IdAAtributoPlantillaCliente)
                                    ObjAAtributoPlantillaID = IdAAtributoPlantillaCliente
                                    'convierte el Id de Telko (AAtributoPlantillaValor) por el Id del Cliente
                                    EncontroIdAAtributoPlantillaValorCliente = Studio.Vision.Telko.Shared.Funciones.GetRegistro_AAtributoPlantillaValor_IdExt(strConexion, item.AAtPlnValID, RespuestaFuncion, IdAAtributoPlantillaValorCliente)
                                    ObjAAtributoPlantillaValorID = IdAAtributoPlantillaValorCliente

                                    Dim filterBucketArticuloVariante_Combinacion As RelationPredicateBucket = New RelationPredicateBucket(ArticuloVariante_CombinacionFields.ID = item.ArtVarCmbID)
                                    Dim updateRegistroArticuloVariante_Combinacion As ArticuloVariante_CombinacionEntity = New ArticuloVariante_CombinacionEntity() With
                                        {
                                            .ArticuloId = ObjArticuloId,
                                            .AAtributoPlantillaID = ObjAAtributoPlantillaID,
                                            .AAtributoPlantillaValorID = ObjAAtributoPlantillaValorID,
                                            .UsrCreador = item.ArtVarCmbAudUsrIns,
                                            .FechaCreado = CheckFechDBNull(item.ArtVarCmbAudFchIns, fechatemp),
                                            .UsrModificador = item.ArtVarCmbAudUsrUpd,
                                            .FechaModificado = CheckFechDBNull(item.ArtVarCmbAudFchUpd, fechatemp)
                                        }
                                    Using adapterUpd As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                                        ' update it
                                        adapterUpd.UpdateEntitiesDirectly(updateRegistroArticuloVariante_Combinacion, filterBucketArticuloVariante_Combinacion)
                                    End Using
                                End If
                            Next
                        End Using
                    End If
                End If
                Contador = Contador + 1
            Next
            Return True
        Catch ex As Exception
            EventViewerMonitor.addToEventViewer("MonitorCliente-ProcesarEntidades", "Ha ocurrido un error en el monitor de procesos de la entidad: " & strNombreEntidad & " Error: " & ex.Message, EventLogEntryType.Error)
            Studio.Vision.Telko.Shared.Funciones.RegistrarMsjLog("MonitorCliente-ProcesarEntidades... Ha ocurrido un error en el monitor de procesos de la entidad: " & strNombreEntidad & " Error: " & ex.Message, True)
            Return False
        End Try
    End Function
End Class
