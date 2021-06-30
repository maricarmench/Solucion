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

	/// <summary>Entity class which represents the entity 'EntityDistribucionAgregada'.</summary>
	[Serializable]
	public partial class MyEntityDistribucionAgregadaEntity : EntityDistribucionAgregadaEntity, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		/// <summary> CTor</summary>
		public MyEntityDistribucionAgregadaEntity()
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MyEntityDistribucionAgregadaEntity(IEntityFields2 fields):base(fields)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EntityDistribucionAgregadaEntity</param>
		public MyEntityDistribucionAgregadaEntity(IValidator validator):base(validator)
		{
			InitClass();
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntityDistribucionAgregada which data should be fetched into this EntityDistribucionAgregada object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyEntityDistribucionAgregadaEntity(System.Int32 id):base(id)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntityDistribucionAgregada which data should be fetched into this EntityDistribucionAgregada object</param>
		/// <param name="validator">The custom validator object for this EntityDistribucionAgregadaEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyEntityDistribucionAgregadaEntity(System.Int32 id, IValidator validator):base(id, validator)
		{
			InitClass();
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MyEntityDistribucionAgregadaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitClass();
		}
		
		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return new MyEntityDistribucionAgregadaEntityFactory();
		}
		
		/// <summary>Initialization routine for class</summary>
		private void InitClass()
		{
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClass
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		#region Class Property Declarations



		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntitiyDistribucion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathEntitiyDistribucion
		{
			get
			{
				return new PrefetchPathElement2(
					new EntityCollection(new MyEntitiyDistribucionEntityFactory()),
					EntityDistribucionAgregadaEntity.Relations.EntitiyDistribucionEntityUsingEntityId, 
					(int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, 0, null, null, null, null, "EntitiyDistribucion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntitiyDistribucion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathEntitiyDistribucion_
		{
			get
			{
				return new PrefetchPathElement2(
					new EntityCollection(new MyEntitiyDistribucionEntityFactory()),
					EntityDistribucionAgregadaEntity.Relations.EntitiyDistribucionEntityUsingEntityAgregadaId, 
					(int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, 0, null, null, null, null, "EntitiyDistribucion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}




		/// <summary>
		/// Gets / sets related entity of type 'MyEntitiyDistribucionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(false)]
		public new virtual MyEntitiyDistribucionEntity EntitiyDistribucion
		{
			get	{ return (MyEntitiyDistribucionEntity)base.EntitiyDistribucion; }
			set	{ base.EntitiyDistribucion = value;	}
		}

		/// <summary>
		/// Gets / sets related entity of type 'MyEntitiyDistribucionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned.<br/><br/>
		/// </summary>
		[Browsable(false)]
		public new virtual MyEntitiyDistribucionEntity EntitiyDistribucion_
		{
			get	{ return (MyEntitiyDistribucionEntity)base.EntitiyDistribucion_; }
			set	{ base.EntitiyDistribucion_ = value;	}
		}

		#endregion

		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
	}
}
