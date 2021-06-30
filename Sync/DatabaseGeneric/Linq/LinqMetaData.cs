///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated on: martes, 13 de abril de 2021 10:57:23
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using Studio_Telko_Sync;
using Studio_Telko_Sync.EntityClasses;
using Studio_Telko_Sync.FactoryClasses;
using Studio_Telko_Sync.HelperClasses;
using Studio_Telko_Sync.RelationClasses;

namespace Studio_Telko_Sync.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData: ILinqMetaData
	{
		#region Class Member Declarations
		private IDataAccessAdapter _adapterToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the IDataAccessAdapter object to use empty. To be able to execute the query, an IDataAccessAdapter instance
		/// is required, and has to be set on the LLBLGenProProvider2 object in the query to execute. </summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse) : this (adapterToUse, null)
		{
		}

		/// <summary>CTor which accepts an IDataAccessAdapter implementing object, which will be used to execute queries created with this metadata class.</summary>
		/// <param name="adapterToUse">the IDataAccessAdapter to use in queries created with this meta data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(IDataAccessAdapter adapterToUse, FunctionMappingStore customFunctionMappings)
		{
			_adapterToUse = adapterToUse;
			_customFunctionMappings = customFunctionMappings;
		}
	
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((Studio_Telko_Sync.EntityType)typeOfEntity)
			{
				case Studio_Telko_Sync.EntityType.DistribucionRegistroEntity:
					toReturn = this.DistribucionRegistro;
					break;
				case Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity:
					toReturn = this.EntitiyDistribucion;
					break;
				case Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity:
					toReturn = this.EntityDistribucionAgregada;
					break;
				case Studio_Telko_Sync.EntityType.SubTentantEntity:
					toReturn = this.SubTentant;
					break;
				case Studio_Telko_Sync.EntityType.TenantEntity:
					toReturn = this.Tenant;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting MyDistribucionRegistroEntity instances in the database.</summary>
		public DataSource2<MyDistribucionRegistroEntity> DistribucionRegistro
		{
			get { return new DataSource2<MyDistribucionRegistroEntity>(_adapterToUse, new MyElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MyEntitiyDistribucionEntity instances in the database.</summary>
		public DataSource2<MyEntitiyDistribucionEntity> EntitiyDistribucion
		{
			get { return new DataSource2<MyEntitiyDistribucionEntity>(_adapterToUse, new MyElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MyEntityDistribucionAgregadaEntity instances in the database.</summary>
		public DataSource2<MyEntityDistribucionAgregadaEntity> EntityDistribucionAgregada
		{
			get { return new DataSource2<MyEntityDistribucionAgregadaEntity>(_adapterToUse, new MyElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MySubTentantEntity instances in the database.</summary>
		public DataSource2<MySubTentantEntity> SubTentant
		{
			get { return new DataSource2<MySubTentantEntity>(_adapterToUse, new MyElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		/// <summary>returns the datasource to use in a Linq query when targeting MyTenantEntity instances in the database.</summary>
		public DataSource2<MyTenantEntity> Tenant
		{
			get { return new DataSource2<MyTenantEntity>(_adapterToUse, new MyElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		
		#region Class Property Declarations
		/// <summary> Gets / sets the IDataAccessAdapter to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the IDataAccessAdapter object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public IDataAccessAdapter AdapterToUse
		{
			get { return _adapterToUse;}
			set { _adapterToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}