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

	/// <summary>Entity class which represents the entity 'EntityDistribucionAgregada'.<br/><br/></summary>
	[Serializable]
	public partial class EntityDistribucionAgregadaEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntitiyDistribucionEntity _entitiyDistribucion;
		private EntitiyDistribucionEntity _entitiyDistribucion_;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name EntitiyDistribucion</summary>
			public static readonly string EntitiyDistribucion = "EntitiyDistribucion";
			/// <summary>Member name EntitiyDistribucion_</summary>
			public static readonly string EntitiyDistribucion_ = "EntitiyDistribucion_";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EntityDistribucionAgregadaEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EntityDistribucionAgregadaEntity():base("EntityDistribucionAgregadaEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EntityDistribucionAgregadaEntity(IEntityFields2 fields):base("EntityDistribucionAgregadaEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EntityDistribucionAgregadaEntity</param>
		public EntityDistribucionAgregadaEntity(IValidator validator):base("EntityDistribucionAgregadaEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntityDistribucionAgregada which data should be fetched into this EntityDistribucionAgregada object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EntityDistribucionAgregadaEntity(System.Int32 id):base("EntityDistribucionAgregadaEntity")
		{
			InitClassEmpty(null, null);
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntityDistribucionAgregada which data should be fetched into this EntityDistribucionAgregada object</param>
		/// <param name="validator">The custom validator object for this EntityDistribucionAgregadaEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EntityDistribucionAgregadaEntity(System.Int32 id, IValidator validator):base("EntityDistribucionAgregadaEntity")
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EntityDistribucionAgregadaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_entitiyDistribucion = (EntitiyDistribucionEntity)info.GetValue("_entitiyDistribucion", typeof(EntitiyDistribucionEntity));
				if(_entitiyDistribucion!=null)
				{
					_entitiyDistribucion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_entitiyDistribucion_ = (EntitiyDistribucionEntity)info.GetValue("_entitiyDistribucion_", typeof(EntitiyDistribucionEntity));
				if(_entitiyDistribucion_!=null)
				{
					_entitiyDistribucion_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((EntityDistribucionAgregadaFieldIndex)fieldIndex)
			{
				case EntityDistribucionAgregadaFieldIndex.EntityAgregadaId:
					DesetupSyncEntitiyDistribucion_(true, false);
					break;
				case EntityDistribucionAgregadaFieldIndex.EntityId:
					DesetupSyncEntitiyDistribucion(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "EntitiyDistribucion":
					this.EntitiyDistribucion = (EntitiyDistribucionEntity)entity;
					break;
				case "EntitiyDistribucion_":
					this.EntitiyDistribucion_ = (EntitiyDistribucionEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "EntitiyDistribucion":
					toReturn.Add(Relations.EntitiyDistribucionEntityUsingEntityId);
					break;
				case "EntitiyDistribucion_":
					toReturn.Add(Relations.EntitiyDistribucionEntityUsingEntityAgregadaId);
					break;
				default:
					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it/ will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		protected override bool CheckOneWayRelations(string propertyName)
		{
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));
				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "EntitiyDistribucion":
					SetupSyncEntitiyDistribucion(relatedEntity);
					break;
				case "EntitiyDistribucion_":
					SetupSyncEntitiyDistribucion_(relatedEntity);
					break;
				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "EntitiyDistribucion":
					DesetupSyncEntitiyDistribucion(false, true);
					break;
				case "EntitiyDistribucion_":
					DesetupSyncEntitiyDistribucion_(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		protected override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_entitiyDistribucion!=null)
			{
				toReturn.Add(_entitiyDistribucion);
			}
			if(_entitiyDistribucion_!=null)
			{
				toReturn.Add(_entitiyDistribucion_);
			}
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			return toReturn;
		}

		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_entitiyDistribucion", (!this.MarkedForDeletion?_entitiyDistribucion:null));
				info.AddValue("_entitiyDistribucion_", (!this.MarkedForDeletion?_entitiyDistribucion_:null));
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new EntityDistribucionAgregadaRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'EntitiyDistribucion' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEntitiyDistribucion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EntitiyDistribucionFields.Id, null, ComparisonOperator.Equal, this.EntityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entity of type 'EntitiyDistribucion' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEntitiyDistribucion_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EntitiyDistribucionFields.Id, null, ComparisonOperator.Equal, this.EntityAgregadaId));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(EntityDistribucionAgregadaEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
		}
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("EntitiyDistribucion", _entitiyDistribucion);
			toReturn.Add("EntitiyDistribucion_", _entitiyDistribucion_);
			return toReturn;
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}


		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EntityAgregadaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EntityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Id", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _entitiyDistribucion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEntitiyDistribucion(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _entitiyDistribucion, new PropertyChangedEventHandler( OnEntitiyDistribucionPropertyChanged ), "EntitiyDistribucion", Studio_Telko_Sync.RelationClasses.StaticEntityDistribucionAgregadaRelations.EntitiyDistribucionEntityUsingEntityIdStatic, true, signalRelatedEntity, "EntitiesDistribucion", resetFKFields, new int[] { (int)EntityDistribucionAgregadaFieldIndex.EntityId } );
			_entitiyDistribucion = null;
		}

		/// <summary> setups the sync logic for member _entitiyDistribucion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEntitiyDistribucion(IEntityCore relatedEntity)
		{
			if(_entitiyDistribucion!=relatedEntity)
			{
				DesetupSyncEntitiyDistribucion(true, true);
				_entitiyDistribucion = (EntitiyDistribucionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _entitiyDistribucion, new PropertyChangedEventHandler( OnEntitiyDistribucionPropertyChanged ), "EntitiyDistribucion", Studio_Telko_Sync.RelationClasses.StaticEntityDistribucionAgregadaRelations.EntitiyDistribucionEntityUsingEntityIdStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEntitiyDistribucionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _entitiyDistribucion_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEntitiyDistribucion_(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _entitiyDistribucion_, new PropertyChangedEventHandler( OnEntitiyDistribucion_PropertyChanged ), "EntitiyDistribucion_", Studio_Telko_Sync.RelationClasses.StaticEntityDistribucionAgregadaRelations.EntitiyDistribucionEntityUsingEntityAgregadaIdStatic, true, signalRelatedEntity, "EntitiesDistribucionAgregada", resetFKFields, new int[] { (int)EntityDistribucionAgregadaFieldIndex.EntityAgregadaId } );
			_entitiyDistribucion_ = null;
		}

		/// <summary> setups the sync logic for member _entitiyDistribucion_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEntitiyDistribucion_(IEntityCore relatedEntity)
		{
			if(_entitiyDistribucion_!=relatedEntity)
			{
				DesetupSyncEntitiyDistribucion_(true, true);
				_entitiyDistribucion_ = (EntitiyDistribucionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _entitiyDistribucion_, new PropertyChangedEventHandler( OnEntitiyDistribucion_PropertyChanged ), "EntitiyDistribucion_", Studio_Telko_Sync.RelationClasses.StaticEntityDistribucionAgregadaRelations.EntitiyDistribucionEntityUsingEntityAgregadaIdStatic, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEntitiyDistribucion_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EntityDistribucionAgregadaEntity</param>
		/// <param name="fields">Fields of this entity</param>
		private void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			this.Fields = fields ?? CreateFields();
			this.Validator = validator;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();

		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static EntityDistribucionAgregadaRelations Relations
		{
			get	{ return new EntityDistribucionAgregadaRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntitiyDistribucion' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEntitiyDistribucion
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EntitiyDistribucionEntityFactory))),	(IEntityRelation)GetRelationsForField("EntitiyDistribucion")[0], (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, 0, null, null, null, null, "EntitiyDistribucion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntitiyDistribucion' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEntitiyDistribucion_
		{
			get	{ return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EntitiyDistribucionEntityFactory))),	(IEntityRelation)GetRelationsForField("EntitiyDistribucion_")[0], (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, 0, null, null, null, null, "EntitiyDistribucion_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The EntityAgregadaId property of the Entity EntityDistribucionAgregada<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntityDistribucionAgregada"."EntityAgregadaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EntityAgregadaId
		{
			get { return (System.Int32)GetValue((int)EntityDistribucionAgregadaFieldIndex.EntityAgregadaId, true); }
			set	{ SetValue((int)EntityDistribucionAgregadaFieldIndex.EntityAgregadaId, value); }
		}

		/// <summary> The EntityId property of the Entity EntityDistribucionAgregada<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntityDistribucionAgregada"."EntityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EntityId
		{
			get { return (System.Int32)GetValue((int)EntityDistribucionAgregadaFieldIndex.EntityId, true); }
			set	{ SetValue((int)EntityDistribucionAgregadaFieldIndex.EntityId, value); }
		}

		/// <summary> The Id property of the Entity EntityDistribucionAgregada<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntityDistribucionAgregada"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)EntityDistribucionAgregadaFieldIndex.Id, true); }
			set	{ SetValue((int)EntityDistribucionAgregadaFieldIndex.Id, value); }
		}

		/// <summary> Gets / sets related entity of type 'EntitiyDistribucionEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual EntitiyDistribucionEntity EntitiyDistribucion
		{
			get	{ return _entitiyDistribucion; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncEntitiyDistribucion(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "EntitiesDistribucion", "EntitiyDistribucion", _entitiyDistribucion, true); 
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EntitiyDistribucionEntity' which has to be set using a fetch action earlier. If no related entity is set for this property, null is returned..<br/><br/></summary>
		[Browsable(false)]
		public virtual EntitiyDistribucionEntity EntitiyDistribucion_
		{
			get	{ return _entitiyDistribucion_; }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncEntitiyDistribucion_(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "EntitiesDistribucionAgregada", "EntitiyDistribucion_", _entitiyDistribucion_, true); 
				}
			}
		}
	
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the Studio_Telko_Sync.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity; }
		}

		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}

