///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: martes, 13 de abril de 2021 10:57:24
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.DatabaseSpecific
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass((5 + 0));
			InitDistribucionRegistroEntityMappings();
			InitEntitiyDistribucionEntityMappings();
			InitEntityDistribucionAgregadaEntityMappings();
			InitSubTentantEntityMappings();
			InitTenantEntityMappings();

		}


		/// <summary>Inits DistribucionRegistroEntity's mappings</summary>
		private void InitDistribucionRegistroEntityMappings()
		{
			this.AddElementMapping( "DistribucionRegistroEntity", @"Studio_Telko_Sync", @"dbo", "DistribucionRegistro", 6 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "Datos", "Datos", false, "NVarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "EntityId", "EntityId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "FechayHora", "FechayHora", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "Id", "Id", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "PaqueteGuid", "PaqueteGuid", true, "UniqueIdentifier", 0, 0, 0, false, "", null, typeof(System.Guid), 4 );
			this.AddElementFieldMapping( "DistribucionRegistroEntity", "TenantId", "TenantId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
		}
		/// <summary>Inits EntitiyDistribucionEntity's mappings</summary>
		private void InitEntitiyDistribucionEntityMappings()
		{
			this.AddElementMapping( "EntitiyDistribucionEntity", @"Studio_Telko_Sync", @"dbo", "EntitiyDistribucion", 5 );
			this.AddElementFieldMapping( "EntitiyDistribucionEntity", "Distribuir", "Distribuir", true, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 0 );
			this.AddElementFieldMapping( "EntitiyDistribucionEntity", "EntityName", "EntityName", false, "VarChar", 250, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "EntitiyDistribucionEntity", "Filtro", "Filtro", true, "VarChar", 1500, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "EntitiyDistribucionEntity", "Id", "Id", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "EntitiyDistribucionEntity", "Orden", "Orden", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits EntityDistribucionAgregadaEntity's mappings</summary>
		private void InitEntityDistribucionAgregadaEntityMappings()
		{
			this.AddElementMapping( "EntityDistribucionAgregadaEntity", @"Studio_Telko_Sync", @"dbo", "EntityDistribucionAgregada", 3 );
			this.AddElementFieldMapping( "EntityDistribucionAgregadaEntity", "EntityAgregadaId", "EntityAgregadaId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "EntityDistribucionAgregadaEntity", "EntityId", "EntityId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "EntityDistribucionAgregadaEntity", "Id", "Id", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 2 );
		}
		/// <summary>Inits SubTentantEntity's mappings</summary>
		private void InitSubTentantEntityMappings()
		{
			this.AddElementMapping( "SubTentantEntity", @"Studio_Telko_Sync", @"dbo", "SubTentant", 5 );
			this.AddElementFieldMapping( "SubTentantEntity", "ClienteDrakoId", "ClienteDrakoId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "SubTentantEntity", "DepositoDestinoId", "DepositoDestinoId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "SubTentantEntity", "Descripcion", "Descripcion", false, "VarChar", 250, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "SubTentantEntity", "Id", "Id", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "SubTentantEntity", "TentantId", "TentantId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
		}
		/// <summary>Inits TenantEntity's mappings</summary>
		private void InitTenantEntityMappings()
		{
			this.AddElementMapping( "TenantEntity", @"Studio_Telko_Sync", @"dbo", "Tenant", 6 );
			this.AddElementFieldMapping( "TenantEntity", "Activo", "Activo", true, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 0 );
			this.AddElementFieldMapping( "TenantEntity", "FechaActualizacion", "FechaActualizacion", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "TenantEntity", "Id", "Id", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 2 );
			this.AddElementFieldMapping( "TenantEntity", "IdProveedorDrako", "IdProveedorDrako", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "TenantEntity", "Nombre", "Nombre", false, "VarChar", 250, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "TenantEntity", "Rut", "RUT", false, "VarChar", 25, 0, 0, false, "", null, typeof(System.String), 5 );
		}

	}
}