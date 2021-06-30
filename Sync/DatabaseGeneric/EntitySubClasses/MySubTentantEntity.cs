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

	/// <summary>Entity class which represents the entity 'SubTentant'.</summary>
	[Serializable]
	public partial class MySubTentantEntity : SubTentantEntity, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		/// <summary> CTor</summary>
		public MySubTentantEntity()
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MySubTentantEntity(IEntityFields2 fields):base(fields)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SubTentantEntity</param>
		public MySubTentantEntity(IValidator validator):base(validator)
		{
			InitClass();
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for SubTentant which data should be fetched into this SubTentant object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MySubTentantEntity(System.Int32 id):base(id)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for SubTentant which data should be fetched into this SubTentant object</param>
		/// <param name="validator">The custom validator object for this SubTentantEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MySubTentantEntity(System.Int32 id, IValidator validator):base(id, validator)
		{
			InitClass();
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MySubTentantEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitClass();
		}
		
		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return new MySubTentantEntityFactory();
		}
		
		/// <summary>Initialization routine for class</summary>
		private void InitClass()
		{
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		#region Class Property Declarations



		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Tenant' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathTenant
		{
			get
			{
				return new PrefetchPathElement2(
					new EntityCollection(new MyTenantEntityFactory()),
					SubTentantEntity.Relations.TenantEntityUsingTentantId, 
					(int)Studio_Telko_Sync.EntityType.SubTentantEntity, (int)Studio_Telko_Sync.EntityType.TenantEntity, 0, null, null, null, null, "Tenant", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}




		/// <summary>
		/// Gets / sets related entity of type 'MyTenantEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(false)]
		public new virtual MyTenantEntity Tenant
		{
			get	{ return (MyTenantEntity)base.Tenant; }
			set	{ base.Tenant = value;	}
		}

		#endregion

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
	}
}
