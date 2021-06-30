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

	/// <summary>Entity class which represents the entity 'EntitiyDistribucion'.</summary>
	[Serializable]
	public partial class MyEntitiyDistribucionEntity : EntitiyDistribucionEntity, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		/// <summary> CTor</summary>
		public MyEntitiyDistribucionEntity()
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MyEntitiyDistribucionEntity(IEntityFields2 fields):base(fields)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EntitiyDistribucionEntity</param>
		public MyEntitiyDistribucionEntity(IValidator validator):base(validator)
		{
			InitClass();
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntitiyDistribucion which data should be fetched into this EntitiyDistribucion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyEntitiyDistribucionEntity(System.Int32 id):base(id)
		{
			InitClass();
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntitiyDistribucion which data should be fetched into this EntitiyDistribucion object</param>
		/// <param name="validator">The custom validator object for this EntitiyDistribucionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MyEntitiyDistribucionEntity(System.Int32 id, IValidator validator):base(id, validator)
		{
			InitClass();
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MyEntitiyDistribucionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			InitClass();
		}
		
		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return new MyEntitiyDistribucionEntityFactory();
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
					EntitiyDistribucionEntity.Relations.DistribucionRegistroEntityUsingEntityId, 
					(int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.DistribucionRegistroEntity, 0, null, null, null, null, "DistribucionRegistros", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntityDistribucionAgregada' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathEntitiesDistribucion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(new MyEntityDistribucionAgregadaEntityFactory()),
					EntitiyDistribucionEntity.Relations.EntityDistribucionAgregadaEntityUsingEntityId, 
					(int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, 0, null, null, null, null, "EntitiesDistribucion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary>
		/// Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntityDistribucionAgregada' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.
		/// </summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public new static IPrefetchPathElement2 PrefetchPathEntitiesDistribucionAgregada
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(new MyEntityDistribucionAgregadaEntityFactory()),
					EntitiyDistribucionEntity.Relations.EntityDistribucionAgregadaEntityUsingEntityAgregadaId, 
					(int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, 0, null, null, null, null, "EntitiesDistribucionAgregada", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
		/// Gets the EntityCollection with the related entities of type 'MyEntityDistribucionAgregadaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.
		/// </summary>
		[TypeContainedAttribute(typeof(MyEntityDistribucionAgregadaEntity))]
		public override EntityCollection<EntityDistribucionAgregadaEntity> EntitiesDistribucion
		{
			get
			{
				EntityCollection<EntityDistribucionAgregadaEntity> toReturn = base.EntitiesDistribucion;
				toReturn.EntityFactoryToUse = new MyEntityDistribucionAgregadaEntityFactory();
				return toReturn;
			}
		}

		/// <summary>
		/// Gets the EntityCollection with the related entities of type 'MyEntityDistribucionAgregadaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.
		/// </summary>
		[TypeContainedAttribute(typeof(MyEntityDistribucionAgregadaEntity))]
		public override EntityCollection<EntityDistribucionAgregadaEntity> EntitiesDistribucionAgregada
		{
			get
			{
				EntityCollection<EntityDistribucionAgregadaEntity> toReturn = base.EntitiesDistribucionAgregada;
				toReturn.EntityFactoryToUse = new MyEntityDistribucionAgregadaEntityFactory();
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
