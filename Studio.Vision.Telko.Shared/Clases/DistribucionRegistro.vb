Imports Newtonsoft.Json
Imports SD.LLBLGen.Pro.ORMSupportClasses
'27/10/2021 Imports Studio_Telko_Sync.EntityClasses
'27/10/2021 Imports Studio_Telko_Sync.HelperClasses
Imports Studio.Phone.DAL.HelperClasses
Imports Studio.Phone.DAL.EntityClasses
Public Class DistribucionRegistro
    'Funcion para ingresar registros en la tabla DistribucionRegistro de STS
    Public Shared Function InsertarDistribucionRegistro(ByVal strConexion As String, ByVal bolDebug As Boolean, ByVal intEntityId As Integer, ByVal jsonDTO As String, ByVal bnlTieneHija As Boolean, ByVal JsonDTOs() As String, ByVal JsonDTOsHija() As String, ByVal intTenantID As Integer, ByRef Contador As Integer) As Boolean
        Try
            Contador = 0
            '27/10/2021 Using adapterDisReg As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterDisReg As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                'SE INSERTA EN LA TABLA DistribucionRegistro de STS
                Dim DistribucionRegistro As New DistribucionRegistroEntity()

                DistribucionRegistro.EntityId = intEntityId
                DistribucionRegistro.Datos = jsonDTO
                DistribucionRegistro.FechayHora = DateTime.Now
                DistribucionRegistro.TenantId = intTenantID

                ' save it
                adapterDisReg.SaveEntity(DistribucionRegistro)
            End Using

            If (bnlTieneHija = True And JsonDTOs.Length > 0) Then
                For i = 0 To JsonDTOs.Length - 1
                    ' Obtener valores del array
                    Dim CadenaList = JsonDTOs(i)
                    Dim Cadena = Split(CadenaList, "↑")
                    jsonDTO = ""
                    intEntityId = 0
                    intEntityId = Convert.ToUInt16(Cadena(0))
                    jsonDTO = Cadena(1)

                    '27/10/2021 Using adapterDisReg As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
                    Using adapterDisReg As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                        'SE INSERTA EN LA TABLA DistribucionRegistro de STS
                        Dim DistribucionRegistro As New DistribucionRegistroEntity()
                        DistribucionRegistro.EntityId = intEntityId
                        DistribucionRegistro.Datos = jsonDTO
                        DistribucionRegistro.FechayHora = DateTime.Now
                        DistribucionRegistro.TenantId = intTenantID

                        ' save it
                        adapterDisReg.SaveEntity(DistribucionRegistro)
                        Contador = Contador + 1
                    End Using
                Next
            End If
            Return True
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase DistribucionRegistro... Ha ocurrido un error al insertar en la función InsertarDistribucionRegistro del proyecto Shared: " & ex.Message, True)
            Return False
        End Try
    End Function

    'Funcion que devuelve los registros en la tabla DistribucionRegistro de STS a actualizar solicitados por el Tenant
    'Se asigna el número GUID a los paquetes a distribuir
    Public Shared Function GetDistribucionRegistro(ByVal strConexion As String, ByVal idTenant As Integer, ByVal Tope As Integer) As String
        Dim Paquete As String = String.Empty
        Dim Paquetes As String = String.Empty
        Dim Empaquetado As String = String.Empty
        Dim strGuid As String = String.Empty
        Dim ContadorRegistros As Integer = 0
        Dim Contador As Integer = 0

        Try
            ' setup filter. 
            Dim filter As New RelationPredicateBucket(DistribucionRegistroFields.TenantId = idTenant)
            '27/10/2021 Dim DistReg As New Studio_Telko_Sync.HelperClasses.EntityCollection(Of DistribucionRegistroEntity)()
            Dim DistReg As New Studio.Phone.DAL.HelperClasses.EntityCollection(Of DistribucionRegistroEntity)()
            Dim gudNumeroGuid As Guid = Nothing
            gudNumeroGuid = Guid.NewGuid()

            ' fetch them using a DataAccessAdapter instance
            '27/10/2021 Using adapterDisReg As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterDisReg As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                adapterDisReg.FetchEntityCollection(DistReg, filter)
            End Using

            ' Display for each record fetched the TenanId and the DistribucionRegistro.
            For Each c As DistribucionRegistroEntity In DistReg
                If (Paquete = "") Then
                    Paquete = c.Datos.Trim()
                Else
                    Paquete = Paquete.Trim() + c.Datos.Trim()
                End If

                If (Tope = 1) Then
                    ContadorRegistros = 0
                    gudNumeroGuid = Guid.NewGuid()
                End If
                If ((DistReg.Count > Tope) And (Tope > 0)) Then
                    If (ContadorRegistros < Tope) Then
                        UpdateDistribucionRegistro(strConexion, c.Id, gudNumeroGuid)
                        If (ContadorRegistros = Tope - 1) Then
                            strGuid = JsonConvert.SerializeObject(gudNumeroGuid)
                            Paquetes = "↓" & strGuid & "↑" & Paquete.Trim()
                            If (Empaquetado = "") Then
                                Empaquetado = Paquetes.Trim()
                            Else
                                Empaquetado = Empaquetado.Trim() + Paquetes.Trim()
                            End If
                            Paquete = ""
                        End If
                    Else
                        ContadorRegistros = 0
                        gudNumeroGuid = Guid.NewGuid()
                        UpdateDistribucionRegistro(strConexion, c.Id, gudNumeroGuid)

                        'Se valida que se haya llegado al final del ciclo
                        If (Contador = DistReg.Count - 1) Then
                            strGuid = JsonConvert.SerializeObject(gudNumeroGuid)
                            Paquetes = "↓" & strGuid & "↑" & Paquete.Trim()
                            Empaquetado = Empaquetado.Trim() + Paquetes.Trim()
                        End If
                    End If
                Else
                    UpdateDistribucionRegistro(strConexion, c.Id, gudNumeroGuid)

                    'Se valida que se haya llegado al final del ciclo
                    If (Contador = DistReg.Count - 1) Then
                        strGuid = JsonConvert.SerializeObject(gudNumeroGuid)
                        Paquetes = "↓" & strGuid & "↑" & Paquete.Trim()
                        Empaquetado = Paquetes.Trim()
                    End If
                End If
                ContadorRegistros = ContadorRegistros + 1
                Contador = Contador + 1
            Next
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase DistribucionRegistro... Ha ocurrido un error en la función GetDistribucionRegistro del proyecto Shared: " & ex.Message, True)
        End Try
        Return Empaquetado.Trim()
    End Function

    ''Función para actualizar el campo PaqueteGuid EN LA TABLA DistribucionRegistro de STS
    Public Shared Function UpdateDistribucionRegistro(ByVal strConexion As String, ByVal intID As Integer, ByVal gudNumeroGuid As Guid) As Boolean
        Try
            Dim filterBucket As RelationPredicateBucket = New RelationPredicateBucket(DistribucionRegistroFields.Id = intID)
            Dim updateRegistro As DistribucionRegistroEntity = New DistribucionRegistroEntity()
            updateRegistro.PaqueteGuid = gudNumeroGuid

            '27/10/2021 Using adapterDisReg As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterDisReg As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                ' update it
                adapterDisReg.UpdateEntitiesDirectly(updateRegistro, filterBucket)
            End Using

            Return True
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase DistribucionRegistro... Ha ocurrido un error en la función UpdateDistribucionRegistro del proyecto Shared: " & ex.Message, True)
            Return False
        End Try
    End Function

    ''Función para eliminar registros EN LA TABLA DistribucionRegistro de STS
    Public Shared Sub DeleteDistribucionRegistro(ByVal strConexion As String, ByVal gudNumeroGuid As Guid)
        Try
            Dim filterBucket As RelationPredicateBucket = New RelationPredicateBucket(DistribucionRegistroFields.PaqueteGuid = gudNumeroGuid)
            '27/10/2021 Using adapterDisReg As New Studio_Telko_Sync.DatabaseSpecific.DataAccessAdapter(strConexion)
            Using adapterDisReg As New Studio.Phone.DAL.DatabaseSpecific.DataAccessAdapter(strConexion)
                ' delete it
                adapterDisReg.DeleteEntitiesDirectly("DistribucionRegistroEntity", filterBucket)
            End Using
        Catch ex As Exception
            Funciones.RegistrarMsjLog("Clase DistribucionRegistro... Ha ocurrido un error en la función DeleteDistribucionRegistro del proyecto Shared: " & ex.Message, True)
        End Try
    End Sub
End Class
