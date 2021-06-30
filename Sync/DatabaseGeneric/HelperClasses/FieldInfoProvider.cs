///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: martes, 13 de abril de 2021 10:57:23
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (5 + 0));
			InitDistribucionRegistroEntityInfos();
			InitEntitiyDistribucionEntityInfos();
			InitEntityDistribucionAgregadaEntityInfos();
			InitSubTentantEntityInfos();
			InitTenantEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits DistribucionRegistroEntity's FieldInfo objects</summary>
		private void InitDistribucionRegistroEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DistribucionRegistroFieldIndex), "DistribucionRegistroEntity");
			this.AddElementFieldInfo("DistribucionRegistroEntity", "Datos", typeof(System.String), false, false, false, false,  (int)DistribucionRegistroFieldIndex.Datos, 2147483647, 0, 0);
			this.AddElementFieldInfo("DistribucionRegistroEntity", "EntityId", typeof(System.Int32), false, true, false, false,  (int)DistribucionRegistroFieldIndex.EntityId, 0, 0, 10);
			this.AddElementFieldInfo("DistribucionRegistroEntity", "FechayHora", typeof(System.DateTime), false, false, false, false,  (int)DistribucionRegistroFieldIndex.FechayHora, 0, 0, 0);
			this.AddElementFieldInfo("DistribucionRegistroEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)DistribucionRegistroFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("DistribucionRegistroEntity", "PaqueteGuid", typeof(Nullable<System.Guid>), false, false, false, true,  (int)DistribucionRegistroFieldIndex.PaqueteGuid, 0, 0, 0);
			this.AddElementFieldInfo("DistribucionRegistroEntity", "TenantId", typeof(System.Int32), false, true, false, false,  (int)DistribucionRegistroFieldIndex.TenantId, 0, 0, 10);
		}
		/// <summary>Inits EntitiyDistribucionEntity's FieldInfo objects</summary>
		private void InitEntitiyDistribucionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EntitiyDistribucionFieldIndex), "EntitiyDistribucionEntity");
			this.AddElementFieldInfo("EntitiyDistribucionEntity", "Distribuir", typeof(Nullable<System.Boolean>), false, false, false, true,  (int)EntitiyDistribucionFieldIndex.Distribuir, 0, 0, 0);
			this.AddElementFieldInfo("EntitiyDistribucionEntity", "EntityName", typeof(System.String), false, false, false, false,  (int)EntitiyDistribucionFieldIndex.EntityName, 250, 0, 0);
			this.AddElementFieldInfo("EntitiyDistribucionEntity", "Filtro", typeof(System.String), false, false, false, true,  (int)EntitiyDistribucionFieldIndex.Filtro, 1500, 0, 0);
			this.AddElementFieldInfo("EntitiyDistribucionEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)EntitiyDistribucionFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("EntitiyDistribucionEntity", "Orden", typeof(System.Int32), false, false, false, false,  (int)EntitiyDistribucionFieldIndex.Orden, 0, 0, 10);
		}
		/// <summary>Inits EntityDistribucionAgregadaEntity's FieldInfo objects</summary>
		private void InitEntityDistribucionAgregadaEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(EntityDistribucionAgregadaFieldIndex), "EntityDistribucionAgregadaEntity");
			this.AddElementFieldInfo("EntityDistribucionAgregadaEntity", "EntityAgregadaId", typeof(System.Int32), false, true, false, false,  (int)EntityDistribucionAgregadaFieldIndex.EntityAgregadaId, 0, 0, 10);
			this.AddElementFieldInfo("EntityDistribucionAgregadaEntity", "EntityId", typeof(System.Int32), false, true, false, false,  (int)EntityDistribucionAgregadaFieldIndex.EntityId, 0, 0, 10);
			this.AddElementFieldInfo("EntityDistribucionAgregadaEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)EntityDistribucionAgregadaFieldIndex.Id, 0, 0, 10);
		}
		/// <summary>Inits SubTentantEntity's FieldInfo objects</summary>
		private void InitSubTentantEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SubTentantFieldIndex), "SubTentantEntity");
			this.AddElementFieldInfo("SubTentantEntity", "ClienteDrakoId", typeof(System.Int32), false, false, false, false,  (int)SubTentantFieldIndex.ClienteDrakoId, 0, 0, 10);
			this.AddElementFieldInfo("SubTentantEntity", "DepositoDestinoId", typeof(System.Int32), false, false, false, false,  (int)SubTentantFieldIndex.DepositoDestinoId, 0, 0, 10);
			this.AddElementFieldInfo("SubTentantEntity", "Descripcion", typeof(System.String), false, false, false, false,  (int)SubTentantFieldIndex.Descripcion, 250, 0, 0);
			this.AddElementFieldInfo("SubTentantEntity", "Id", typeof(System.Int32), true, false, false, false,  (int)SubTentantFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("SubTentantEntity", "TentantId", typeof(System.Int32), false, true, false, false,  (int)SubTentantFieldIndex.TentantId, 0, 0, 10);
		}
		/// <summary>Inits TenantEntity's FieldInfo objects</summary>
		private void InitTenantEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TenantFieldIndex), "TenantEntity");
			this.AddElementFieldInfo("TenantEntity", "Activo", typeof(Nullable<System.Boolean>), false, false, false, true,  (int)TenantFieldIndex.Activo, 0, 0, 0);
			this.AddElementFieldInfo("TenantEntity", "FechaActualizacion", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)TenantFieldIndex.FechaActualizacion, 0, 0, 0);
			this.AddElementFieldInfo("TenantEntity", "Id", typeof(System.Int32), true, false, true, false,  (int)TenantFieldIndex.Id, 0, 0, 10);
			this.AddElementFieldInfo("TenantEntity", "IdProveedorDrako", typeof(Nullable<System.Int32>), false, false, false, true,  (int)TenantFieldIndex.IdProveedorDrako, 0, 0, 10);
			this.AddElementFieldInfo("TenantEntity", "Nombre", typeof(System.String), false, false, false, false,  (int)TenantFieldIndex.Nombre, 250, 0, 0);
			this.AddElementFieldInfo("TenantEntity", "Rut", typeof(System.String), false, false, false, false,  (int)TenantFieldIndex.Rut, 25, 0, 0);
		}
		
	}
}




