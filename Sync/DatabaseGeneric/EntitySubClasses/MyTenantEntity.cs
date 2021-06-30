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
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Studio_Telko_Sync;
using Studio_Telko_Sync.HelperClasses;
using Studio_Telko_Sync.FactoryClasses;
using Studio_Telko_Sync.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.EntityClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Tenant'.</summary>
	[Serializable]
	public partial class MyTenantEntity : TenantEntity, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		/// <summary> CTor</summary>
		public MyTenantEntity()
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MyTenantEntity(IEntityFields2 fields):base(fields)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TenantEntity</param>
		public MyTenantEntity(IValidator validator):base(validator)
		{
			InitClass();
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for Tenant which data should be fetched into this Tenant object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyTenantEntity(System.Int32 id):base(id)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Tenant which data should be fetched into this Tenant object</param>
		/// <param name="validator">The custom validator object for this TenantEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyTenantEntity(System.Int32 id, IValidator validator):base(id, validator)
		{
			InitClass();
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MyTenantEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitClass();
		}
		
		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return new MyTenantEntityFactory();
		}
		
		/// <summary>Initialization routine for class</summary>
		private void InitClass()
		{
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		#region Class Property Declarations

		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DistribucionRegistro' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathDistribucionRegistros
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(new MyDistribucionRegistroEntityFactory()),
					TenantEntity.Relations.DistribucionRegistroEntityUsingTenantId, 
					(int)Studio_Telko_Sync.EntityType.TenantEntity, (int)Studio_Telko_Sync.EntityType.DistribucionRegistroEntity, 0, null, null, null, null, "DistribucionRegistros", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SubTentant' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathSubTentants
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(new MySubTentantEntityFactory()),
					TenantEntity.Relations.SubTentantEntityUsingTentantId, 
					(int)Studio_Telko_Sync.EntityType.TenantEntity, (int)Studio_Telko_Sync.EntityType.SubTentantEntity, 0, null, null, null, null, "SubTentants", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}




		/// <summary>
		/// Gets the EntityCollection with the related entities of type 'MyDistribucionRegistroEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.
		/// </summary>
		[TypeContainedAttribute(typeof(MyDistribucionRegistroEntity))]
		public override EntityCollection<DistribucionRegistroEntity> DistribucionRegistros
		{
			get
			{
				EntityCollection<DistribucionRegistroEntity> toReturn = base.DistribucionRegistros;
				toReturn.EntityFactoryToUse = new MyDistribucionRegistroEntityFactory();
				return toReturn;
			}
		}

		/// <summary>
		/// Gets the EntityCollection with the related entities of type 'MySubTentantEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.
		/// </summary>
		[TypeContainedAttribute(typeof(MySubTentantEntity))]
		public override EntityCollection<SubTentantEntity> SubTentants
		{
			get
			{
				EntityCollection<SubTentantEntity> toReturn = base.SubTentants;
				toReturn.EntityFactoryToUse = new MySubTentantEntityFactory();
				return toReturn;
			}
		}



		#endregion

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
	}
}
