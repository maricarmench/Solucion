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
using System.Collections.Generic;
using Studio_Telko_Sync.EntityClasses;
using Studio_Telko_Sync.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	
	/// <summary>Factory to create new, empty MyDistribucionRegistroEntity objects.</summary>
	[Serializable]
	public partial class MyDistribucionRegistroEntityFactory : DistribucionRegistroEntityFactory
	{
		/// <summary>CTor</summary>
		public MyDistribucionRegistroEntityFactory()
		{
		}

		/// <summary>Creates a new MyDistribucionRegistroEntity instance and will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields)
		{
			IEntity2 toReturn = new MyDistribucionRegistroEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDistribucionRegistroUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
				
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<MyDistribucionRegistroEntity>(this);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
	}	
	/// <summary>Factory to create new, empty MyEntitiyDistribucionEntity objects.</summary>
	[Serializable]
	public partial class MyEntitiyDistribucionEntityFactory : EntitiyDistribucionEntityFactory
	{
		/// <summary>CTor</summary>
		public MyEntitiyDistribucionEntityFactory()
		{
		}

		/// <summary>Creates a new MyEntitiyDistribucionEntity instance and will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields)
		{
			IEntity2 toReturn = new MyEntitiyDistribucionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEntitiyDistribucionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
				
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<MyEntitiyDistribucionEntity>(this);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
	}	
	/// <summary>Factory to create new, empty MyEntityDistribucionAgregadaEntity objects.</summary>
	[Serializable]
	public partial class MyEntityDistribucionAgregadaEntityFactory : EntityDistribucionAgregadaEntityFactory
	{
		/// <summary>CTor</summary>
		public MyEntityDistribucionAgregadaEntityFactory()
		{
		}

		/// <summary>Creates a new MyEntityDistribucionAgregadaEntity instance and will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields)
		{
			IEntity2 toReturn = new MyEntityDistribucionAgregadaEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEntityDistribucionAgregadaUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
				
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<MyEntityDistribucionAgregadaEntity>(this);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
	}	
	/// <summary>Factory to create new, empty MySubTentantEntity objects.</summary>
	[Serializable]
	public partial class MySubTentantEntityFactory : SubTentantEntityFactory
	{
		/// <summary>CTor</summary>
		public MySubTentantEntityFactory()
		{
		}

		/// <summary>Creates a new MySubTentantEntity instance and will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields)
		{
			IEntity2 toReturn = new MySubTentantEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSubTentantUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
				
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<MySubTentantEntity>(this);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
	}	
	/// <summary>Factory to create new, empty MyTenantEntity objects.</summary>
	[Serializable]
	public partial class MyTenantEntityFactory : TenantEntityFactory
	{
		/// <summary>CTor</summary>
		public MyTenantEntityFactory()
		{
		}

		/// <summary>Creates a new MyTenantEntity instance and will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields)
		{
			IEntity2 toReturn = new MyTenantEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTenantUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
				
		/// <summary>Creates a new generic EntityCollection(Of T) for the entity to which this factory belongs.</summary>
		/// <returns>ready to use generic EntityCollection(Of T) with this factory set as the factory</returns>
		public override IEntityCollection2 CreateEntityCollection()
		{
			return new EntityCollection<MyTenantEntity>(this);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 CreateMy(Studio_Telko_Sync.EntityType entityTypeToCreate)
		{
			IEntityFactory2 factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case Studio_Telko_Sync.EntityType.DistribucionRegistroEntity:
					factoryToUse = new MyDistribucionRegistroEntityFactory();
					break;
				case Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity:
					factoryToUse = new MyEntitiyDistribucionEntityFactory();
					break;
				case Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity:
					factoryToUse = new MyEntityDistribucionAgregadaEntityFactory();
					break;
				case Studio_Telko_Sync.EntityType.SubTentantEntity:
					factoryToUse = new MySubTentantEntityFactory();
					break;
				case Studio_Telko_Sync.EntityType.TenantEntity:
					factoryToUse = new MyTenantEntityFactory();
					break;
			}
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}
	}
	
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class MyEntityFactoryFactory
	{
#if CF
		/// <summary>Gets the factory of the entity with the Studio_Telko_Sync.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Studio_Telko_Sync.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.CreateMy(typeOfEntity).GetEntityFactory();
		}
#else
		private static Dictionary<Type, IEntityFactory2> _factoryPerType = new Dictionary<Type, IEntityFactory2>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static MyEntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(Studio_Telko_Sync.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity2 dummy = GeneralEntityFactory.CreateMy((Studio_Telko_Sync.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Type typeOfEntity)
		{
			IEntityFactory2 toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the Studio_Telko_Sync.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory2 GetFactory(Studio_Telko_Sync.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.CreateMy(typeOfEntity).GetType());
		}
#endif		
	}
	
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class MyElementCreator : ElementCreator
	{
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the Studio_Telko_Sync.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return MyEntityFactoryFactory.GetFactory((Studio_Telko_Sync.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return MyEntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}

}
