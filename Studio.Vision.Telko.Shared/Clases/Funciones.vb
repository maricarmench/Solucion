Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Phone.DAL.EntityClasses
Imports Studio.Phone.DAL.HelperClasses
Imports System.Threading
Imports System.Configuration
Imports System.IO

Public Class Funciones
    'Funcion que devuelve True si el id consultado existe en la tabla Rubro de SV Cliente 
    Public Shared Function GetRegistro_Rubro(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdRubroCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(RubroFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of RubroEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As RubroEntity In Reg
                Encontro = True
                IdRubroCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Rubro del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
#Region "Proceso ArticuloTipo"
    'Funcion que devuelve True si el id consultado existe en la tabla ArticuloTipo de SV Cliente 
    Public Shared Function GetRegistro_ArticuloTipo_IdExt(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdArtTipoCliente As Integer) As Boolean
        Dim EncontroExt As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filterExt As New RelationPredicateBucket(ArticuloTipoFields.IdExterno = id)
            Dim RegExt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ArticuloTipoEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegExt, filterExt)
            End Using
            For Each c As ArticuloTipoEntity In RegExt
                EncontroExt = True
                IdArtTipoCliente = c.Id
                Exit For
            Next

            If EncontroExt = False Then
                'En caso de existir el registro se actualiza el campo IdExterno con el id de telko
                EncontroExt = GetRegistro_ArticuloTipoID(strConexion, id, Respuesta)
                If EncontroExt Then
                    EncontroExt = UpdateArticuloTipo(strConexion, id)
                Else
                    Respuesta = "Error"
                End If

            End If

        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_ArticuloTipo_IdExt del proyecto Shared: " & ex.Message, True)
            EncontroExt = False
            Respuesta = "Error"
        End Try
        Return EncontroExt
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla ArticuloTipo de SV Cliente 
    Public Shared Function GetRegistro_ArticuloTipoID(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim EncontroId As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filterInt As New RelationPredicateBucket(ArticuloTipoFields.Id = id)
            Dim RegInt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ArticuloTipoEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegInt, filterInt)
            End Using

            For Each c As ArticuloTipoEntity In RegInt
                If c.IdExterno <= 0 Then
                    EncontroId = True
                End If
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_ArticuloTipoID del proyecto Shared: " & ex.Message, True)
            EncontroId = False
            Respuesta = "Error"
        End Try
        Return EncontroId
    End Function
    ''Función para actualizar el campo ArtTipIdExt EN LA TABLA ArticuloTipo de STS
    Public Shared Function UpdateArticuloTipo(ByVal strConexion As String, ByVal intID As Integer) As Boolean
        Try
            Dim filterBucket As RelationPredicateBucket = New RelationPredicateBucket(ArticuloTipoFields.Id = intID)
            Dim updateRegistro As ArticuloTipoEntity = New ArticuloTipoEntity()
            updateRegistro.IdExterno = intID

            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                ' update it
                adapter.UpdateEntitiesDirectly(updateRegistro, filterBucket)
            End Using

            Return True
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función UpdateArticuloTipo del proyecto Shared: " & ex.Message, True)
            Return False
        End Try
    End Function
#End Region
    'Funcion que devuelve True si el id consultado existe en la tabla Marca de SV Cliente 
    Public Shared Function GetRegistro_Marca(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdMarcaCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(MarcaFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of MarcaEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As MarcaEntity In Reg
                Encontro = True
                IdMarcaCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Marca del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla Modelo de SV Cliente 
    Public Shared Function GetRegistro_Modelo(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdModeloCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(ModeloFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ModeloEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As ModeloEntity In Reg
                Encontro = True
                IdModeloCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Modelo del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla ArticuloClase de SV Cliente 
    Public Shared Function GetRegistro_ArticuloClase(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(ArticuloClaseFields.Id = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ArticuloClaseEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As ArticuloClaseEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_ArticuloClase del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla Nivel de SV Cliente 
    Public Shared Function GetRegistro_Nivel(ByVal strConexion As String, ByVal id As String, ByRef Respuesta As String, ByRef IdNivelCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(NivelFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of NivelEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As NivelEntity In Reg
                Encontro = True
                IdNivelCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Nivel del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function

    'Funcion que devuelve True si el id consultado existe en la tabla Unidad de SV Cliente 
    Public Shared Function GetRegistro_Unidad(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdUnidadCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(UnidadFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of UnidadEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As UnidadEntity In Reg
                Encontro = True
                IdUnidadCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Unidad del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla Procedencia de SV Cliente 
    Public Shared Function GetRegistro_Procedencia(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdProcedCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(ProcedenciaFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ProcedenciaEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As ProcedenciaEntity In Reg
                Encontro = True
                IdProcedCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Procedencia del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
#Region "Proceso AAtributoPlantilla"
    'Funcion que devuelve True si el id consultado existe en la tabla AAtributoPlantilla de SV Cliente 
    Public Shared Function GetRegistro_AAtributoPlantilla_IdExt(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdAAtributoPlantilla As Integer) As Boolean
        Dim EncontroExt As Boolean = False
        Respuesta = String.Empty
        Try

            ' setup filter. 
            Dim filterExt As New RelationPredicateBucket(AAtributoPlantillaFields.IdExterno = id)
            Dim RegExt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of AAtributoPlantillaEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegExt, filterExt)
            End Using
            For Each c As AAtributoPlantillaEntity In RegExt
                EncontroExt = True
                IdAAtributoPlantilla = c.ID
                Exit For
            Next

            If EncontroExt = False Then
                'En caso de existir el registro se actualiza el campo IdExterno con el id de telko
                EncontroExt = GetRegistro_AAtributoPlantillaID(strConexion, id, Respuesta)
                If EncontroExt Then
                    EncontroExt = UpdateAAtributoPlantilla(strConexion, id)
                Else
                    Respuesta = "Error"
                End If
            End If
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_AAtributoPlantilla_IdExt del proyecto Shared: " & ex.Message, True)
            EncontroExt = False
            Respuesta = "Error"
        End Try
        Return EncontroExt
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla AAtributoPlantilla de SV Cliente 
    Public Shared Function GetRegistro_AAtributoPlantillaID(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim EncontroId As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filterInt As New RelationPredicateBucket(AAtributoPlantillaFields.ID = id)
            Dim RegInt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of AAtributoPlantillaEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegInt, filterInt)
            End Using

            For Each c As AAtributoPlantillaEntity In RegInt
                If c.IdExterno <= 0 Then
                    EncontroId = True
                End If
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_AAtributoPlantillaID del proyecto Shared: " & ex.Message, True)
            EncontroId = False
            Respuesta = "Error"
        End Try
        Return EncontroId
    End Function
    ''Función para actualizar el campo IdExt EN LA TABLA AAtributoPlantilla de STS
    Public Shared Function UpdateAAtributoPlantilla(ByVal strConexion As String, ByVal intID As Integer) As Boolean
        Try
            Dim filterBucket As RelationPredicateBucket = New RelationPredicateBucket(AAtributoPlantillaFields.ID = intID)
            Dim updateRegistro As AAtributoPlantillaEntity = New AAtributoPlantillaEntity()
            updateRegistro.IdExterno = intID

            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                ' update it
                adapter.UpdateEntitiesDirectly(updateRegistro, filterBucket)
            End Using

            Return True
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función UpdateAAtributoPlantilla del proyecto Shared: " & ex.Message, True)
            Return False
        End Try
    End Function
#End Region

    'Funcion que devuelve True si el id consultado existe en la tabla AAtributoPlantillaValor de SV Cliente 
    Public Shared Function GetRegistro_AAtributoPlantillaValor(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(AAtributoPlantillaValorFields.ID = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of AAtributoPlantillaValorEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As AAtributoPlantillaValorEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_AAtributoPlantillaValor del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function

#Region "Proceso AAtributoPlantillaValor"
    'Funcion que devuelve True si el id consultado existe en la tabla AAtributoPlantilla de SV Cliente 
    Public Shared Function GetRegistro_AAtributoPlantillaValor_IdExt(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdAAtributoPlantillaValor As Integer) As Boolean
        Dim EncontroExt As Boolean = False
        Respuesta = String.Empty
        Try

            ' setup filter. 
            Dim filterExt As New RelationPredicateBucket(AAtributoPlantillaValorFields.IdExterno = id)
            Dim RegExt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of AAtributoPlantillaValorEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegExt, filterExt)
            End Using
            For Each c As AAtributoPlantillaValorEntity In RegExt
                EncontroExt = True
                IdAAtributoPlantillaValor = c.ID
                Exit For
            Next

            If EncontroExt = False Then
                'En caso de existir el registro se actualiza el campo IdExterno con el id de telko
                EncontroExt = GetRegistro_AAtributoPlantillaValorID(strConexion, id, Respuesta)
                If EncontroExt Then
                    EncontroExt = UpdateAAtributoPlantillaValor(strConexion, id)
                Else
                    Respuesta = "Error"
                End If
            End If
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_AAtributoPlantillaValor_IdExt del proyecto Shared: " & ex.Message, True)
            EncontroExt = False
            Respuesta = "Error"
        End Try
        Return EncontroExt
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla AAtributoPlantilla de SV Cliente 
    Public Shared Function GetRegistro_AAtributoPlantillaValorID(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim EncontroId As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filterInt As New RelationPredicateBucket(AAtributoPlantillaValorFields.ID = id)
            Dim RegInt As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of AAtributoPlantillaValorEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(RegInt, filterInt)
            End Using

            For Each c As AAtributoPlantillaValorEntity In RegInt
                If c.IdExterno <= 0 Then
                    EncontroId = True
                End If
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_AAtributoPlantillaValorID del proyecto Shared: " & ex.Message, True)
            EncontroId = False
            Respuesta = "Error"
        End Try
        Return EncontroId
    End Function
    ''Función para actualizar el campo IdExt EN LA TABLA AAtributoPlantilla de STS
    Public Shared Function UpdateAAtributoPlantillaValor(ByVal strConexion As String, ByVal intID As Integer) As Boolean
        Try
            Dim filterBucket As RelationPredicateBucket = New RelationPredicateBucket(AAtributoPlantillaValorFields.ID = intID)
            Dim updateRegistro As AAtributoPlantillaValorEntity = New AAtributoPlantillaValorEntity()
            updateRegistro.IdExterno = intID

            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                ' update it
                adapter.UpdateEntitiesDirectly(updateRegistro, filterBucket)
            End Using

            Return True
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función UpdateAAtributoPlantillaValor del proyecto Shared: " & ex.Message, True)
            Return False
        End Try
    End Function
#End Region
    'Funcion que devuelve True si el id consultado existe en la tabla Articulo de SV Cliente 
    Public Shared Function GetRegistro_Articulo(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String, ByRef IdArticuloCliente As Integer) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(ArticuloFields.IdExterno = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ArticuloEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As ArticuloEntity In Reg
                Encontro = True
                IdArticuloCliente = c.Id
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Articulo del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla Articulo_Impuesto de SV Cliente 
    Public Shared Function GetRegistro_Articulo_Impuesto(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(Articulo_ImpuestoFields.ArticuloId = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of Articulo_ImpuestoEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As Articulo_ImpuestoEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Articulo_Impuesto del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function

    'Funcion que devuelve True si el id consultado existe en la tabla Articulo_AAtributoPlantilla de SV Cliente 
    Public Shared Function GetRegistro_Articulo_AAtributoPlantilla(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(Articulo_AAtributoPlantillaFields.ID = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of Articulo_AAtributoPlantillaEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As Articulo_AAtributoPlantillaEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Articulo_AAtributoPlantilla del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla ArticuloVariante_Combinacion de SV Cliente 
    Public Shared Function GetRegistro_ArticuloVariante_Combinacion(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(ArticuloVariante_CombinacionFields.ID = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of ArticuloVariante_CombinacionEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As ArticuloVariante_CombinacionEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_ArticuloVariante_Combinacion del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function
    'Funcion que devuelve True si el id consultado existe en la tabla Marca_Modelo de SV Cliente 
    Public Shared Function GetRegistro_Marca_Modelo(ByVal strConexion As String, ByVal id As Integer, ByRef Respuesta As String) As Boolean
        Dim Encontro As Boolean = False
        Respuesta = String.Empty
        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(Marca_ModeloFields.MarcaId = id)
            Dim Reg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of Marca_ModeloEntity)()

            ' fetch them using a DataAccessAdapter instance
            Using adapter As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapter.FetchEntityCollection(Reg, filter)
            End Using

            For Each c As Marca_ModeloEntity In Reg
                Encontro = True
                Exit For
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función GetRegistro_Marca_Modelo del proyecto Shared: " & ex.Message, True)
            Encontro = False
            Respuesta = "Error"
        End Try
        Return Encontro
    End Function

    Public Shared Sub RegistrarMsjLog(ByVal mensaje As String, ByVal log As Boolean)
        Dim evento As eventosLogs = New eventosLogs()
        Try
            evento.origen = "winEventos"           'Nombre de la aplicación o servicio que genera el evento
            evento.TipoOrigen = "EjemploEventos"   'Origen del evento (Application/System/Nombre personalizado)
            evento.Evento = "winEventos"           'Nombre del evento a auditar
            evento.Mensaje = mensaje
            'evento.TipoEntrada = tipo              '1 =Error/2=FailureAudit/3=Information/4=SuccessAudit/5=Warning
            evento.Archivo = "winLogs.log"

            If log Then
                Dim dir As String = ConfigurationManager.AppSettings("dirLogsTelko")
                If Not Directory.Exists(dir) Then
                    Directory.CreateDirectory(dir)
                End If
                'Anota el evento en el archivo de logs
                escribirArchivoLog(evento)
            End If

        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función RegistrarMsjLog del proyecto Shared: " & ex.Message, True)
            'escribirArchivoLog(evento)
        End Try
    End Sub

    Private Shared Sub escribirArchivoLog(ByVal evento As Studio.Vision.Telko.Shared.eventosLogs)
        Try
            'Recupera el directorio de los archivos de logs del App.config;
            Dim dirArchivos As String = ConfigurationManager.AppSettings("dirLogsTelko")

            'Recuperamos la ruta completa de los archivos logs
            Dim dirArchivosCompleta As String = dirArchivos & "\" + evento.Archivo
            'Configuramos el Listener para que escriba en el archivo de salida
            Trace.Listeners.Add(New TextWriterTraceListener(dirArchivos & "\" + evento.Archivo))
            Trace.AutoFlush = True
            Trace.Indent()
            Dim cadena As String = Environment.NewLine + Date.Now.ToLocalTime().ToString() & " -- "
            Trace.Write(cadena & evento.Mensaje)
            Trace.Unindent()
            Trace.Close()
            'Borramos todos los archivos que genera y que no son el de logs indicado.
            For Each item As String In Directory.GetFiles(Path.GetDirectoryName(dirArchivosCompleta), "*.log")
                If item <> dirArchivosCompleta Then
                    File.Delete(item)
                End If
            Next
        Catch ex As Exception
            evento.Mensaje = ex.Message
            Funciones.RegistrarMsjLog("Clase Funciones... Ha ocurrido un error en la función RegistrarMsjLog del proyecto Shared: " & ex.Message, True)
        End Try
    End Sub
End Class
