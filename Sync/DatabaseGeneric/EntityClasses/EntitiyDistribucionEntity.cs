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

	/// <summary>Entity class which represents the entity 'EntitiyDistribucion'.<br/><br/></summary>
	[Serializable]
	public partial class EntitiyDistribucionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<DistribucionRegistroEntity> _distribucionRegistros;
		private EntityCollection<EntityDistribucionAgregadaEntity> _entitiesDistribucion;
		private EntityCollection<EntityDistribucionAgregadaEntity> _entitiesDistribucionAgregada;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name DistribucionRegistros</summary>
			public static readonly string DistribucionRegistros = "DistribucionRegistros";
			/// <summary>Member name EntitiesDistribucion</summary>
			public static readonly string EntitiesDistribucion = "EntitiesDistribucion";
			/// <summary>Member name EntitiesDistribucionAgregada</summary>
			public static readonly string EntitiesDistribucionAgregada = "EntitiesDistribucionAgregada";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static EntitiyDistribucionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public EntitiyDistribucionEntity():base("EntitiyDistribucionEntity")
		{
			InitClassEmpty(null, null);
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public EntitiyDistribucionEntity(IEntityFields2 fields):base("EntitiyDistribucionEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this EntitiyDistribucionEntity</param>
		public EntitiyDistribucionEntity(IValidator validator):base("EntitiyDistribucionEntity")
		{
			InitClassEmpty(validator, null);
		}
				
		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntitiyDistribucion which data should be fetched into this EntitiyDistribucion object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EntitiyDistribucionEntity(System.Int32 id):base("EntitiyDistribucionEntity")
		{
			InitClassEmpty(null, null);
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for EntitiyDistribucion which data should be fetched into this EntitiyDistribucion object</param>
		/// <param name="validator">The custom validator object for this EntitiyDistribucionEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public EntitiyDistribucionEntity(System.Int32 id, IValidator validator):base("EntitiyDistribucionEntity")
		{
			InitClassEmpty(validator, null);
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected EntitiyDistribucionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_distribucionRegistros = (EntityCollection<DistribucionRegistroEntity>)info.GetValue("_distribucionRegistros", typeof(EntityCollection<DistribucionRegistroEntity>));
				_entitiesDistribucion = (EntityCollection<EntityDistribucionAgregadaEntity>)info.GetValue("_entitiesDistribucion", typeof(EntityCollection<EntityDistribucionAgregadaEntity>));
				_entitiesDistribucionAgregada = (EntityCollection<EntityDistribucionAgregadaEntity>)info.GetValue("_entitiesDistribucionAgregada", typeof(EntityCollection<EntityDistribucionAgregadaEntity>));
				this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}


		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "DistribucionRegistros":
					this.DistribucionRegistros.Add((DistribucionRegistroEntity)entity);
					break;
				case "EntitiesDistribucion":
					this.EntitiesDistribucion.Add((EntityDistribucionAgregadaEntity)entity);
					break;
				case "EntitiesDistribucionAgregada":
					this.EntitiesDistribucionAgregada.Add((EntityDistribucionAgregadaEntity)entity);
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
				case "DistribucionRegistros":
					toReturn.Add(Relations.DistribucionRegistroEntityUsingEntityId);
					break;
				case "EntitiesDistribucion":
					toReturn.Add(Relations.EntityDistribucionAgregadaEntityUsingEntityId);
					break;
				case "EntitiesDistribucionAgregada":
					toReturn.Add(Relations.EntityDistribucionAgregadaEntityUsingEntityAgregadaId);
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
				case "DistribucionRegistros":
					this.DistribucionRegistros.Add((DistribucionRegistroEntity)relatedEntity);
					break;
				case "EntitiesDistribucion":
					this.EntitiesDistribucion.Add((EntityDistribucionAgregadaEntity)relatedEntity);
					break;
				case "EntitiesDistribucionAgregada":
					this.EntitiesDistribucionAgregada.Add((EntityDistribucionAgregadaEntity)relatedEntity);
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
				case "DistribucionRegistros":
					this.PerformRelatedEntityRemoval(this.DistribucionRegistros, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EntitiesDistribucion":
					this.PerformRelatedEntityRemoval(this.EntitiesDistribucion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EntitiesDistribucionAgregada":
					this.PerformRelatedEntityRemoval(this.EntitiesDistribucionAgregada, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		protected override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.DistribucionRegistros);
			toReturn.Add(this.EntitiesDistribucion);
			toReturn.Add(this.EntitiesDistribucionAgregada);
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
				info.AddValue("_distribucionRegistros", ((_distribucionRegistros!=null) && (_distribucionRegistros.Count>0) && !this.MarkedForDeletion)?_distribucionRegistros:null);
				info.AddValue("_entitiesDistribucion", ((_entitiesDistribucion!=null) && (_entitiesDistribucion.Count>0) && !this.MarkedForDeletion)?_entitiesDistribucion:null);
				info.AddValue("_entitiesDistribucionAgregada", ((_entitiesDistribucionAgregada!=null) && (_entitiesDistribucionAgregada.Count>0) && !this.MarkedForDeletion)?_entitiesDistribucionAgregada:null);
			}
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new EntitiyDistribucionRelations().GetAllRelations();
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'DistribucionRegistro' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDistribucionRegistros()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DistribucionRegistroFields.EntityId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'EntityDistribucionAgregada' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEntitiesDistribucion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EntityDistribucionAgregadaFields.EntityId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch the related entities of type 'EntityDistribucionAgregada' to this entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEntitiesDistribucionAgregada()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EntityDistribucionAgregadaFields.EntityAgregadaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}
		

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(EntitiyDistribucionEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._distribucionRegistros);
			collectionsQueue.Enqueue(this._entitiesDistribucion);
			collectionsQueue.Enqueue(this._entitiesDistribucionAgregada);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._distribucionRegistros = (EntityCollection<DistribucionRegistroEntity>) collectionsQueue.Dequeue();
			this._entitiesDistribucion = (EntityCollection<EntityDistribucionAgregadaEntity>) collectionsQueue.Dequeue();
			this._entitiesDistribucionAgregada = (EntityCollection<EntityDistribucionAgregadaEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			bool toReturn = false;
			toReturn |=(this._distribucionRegistros != null);
			toReturn |=(this._entitiesDistribucion != null);
			toReturn |=(this._entitiesDistribucionAgregada != null);
			return toReturn ? true : base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DistribucionRegistroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DistribucionRegistroEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EntityDistribucionAgregadaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EntityDistribucionAgregadaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EntityDistribucionAgregadaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EntityDistribucionAgregadaEntityFactory))) : null);
		}
#endif
		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("DistribucionRegistros", _distribucionRegistros);
			toReturn.Add("EntitiesDistribucion", _entitiesDistribucion);
			toReturn.Add("EntitiesDistribucionAgregada", _entitiesDistribucionAgregada);
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
			_fieldsCustomProperties.Add("Distribuir", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EntityName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Filtro", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Orden", fieldHashtable);
		}
		#endregion

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this EntitiyDistribucionEntity</param>
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
		public  static EntitiyDistribucionRelations Relations
		{
			get	{ return new EntitiyDistribucionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DistribucionRegistro' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDistribucionRegistros
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<DistribucionRegistroEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DistribucionRegistroEntityFactory))), (IEntityRelation)GetRelationsForField("DistribucionRegistros")[0], (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.DistribucionRegistroEntity, 0, null, null, null, null, "DistribucionRegistros", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntityDistribucionAgregada' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEntitiesDistribucion
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<EntityDistribucionAgregadaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EntityDistribucionAgregadaEntityFactory))), (IEntityRelation)GetRelationsForField("EntitiesDistribucion")[0], (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, 0, null, null, null, null, "EntitiesDistribucion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EntityDistribucionAgregada' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEntitiesDistribucionAgregada
		{
			get	{ return new PrefetchPathElement2( new EntityCollection<EntityDistribucionAgregadaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EntityDistribucionAgregadaEntityFactory))), (IEntityRelation)GetRelationsForField("EntitiesDistribucionAgregada")[0], (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity, (int)Studio_Telko_Sync.EntityType.EntityDistribucionAgregadaEntity, 0, null, null, null, null, "EntitiesDistribucionAgregada", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);	}
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

		/// <summary> The Distribuir property of the Entity EntitiyDistribucion<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntitiyDistribucion"."Distribuir"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> Distribuir
		{
			get { return (Nullable<System.Boolean>)GetValue((int)EntitiyDistribucionFieldIndex.Distribuir, false); }
			set	{ SetValue((int)EntitiyDistribucionFieldIndex.Distribuir, value); }
		}

		/// <summary> The EntityName property of the Entity EntitiyDistribucion<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntitiyDistribucion"."EntityName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 250<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EntityName
		{
			get { return (System.String)GetValue((int)EntitiyDistribucionFieldIndex.EntityName, true); }
			set	{ SetValue((int)EntitiyDistribucionFieldIndex.EntityName, value); }
		}

		/// <summary> The Filtro property of the Entity EntitiyDistribucion<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntitiyDistribucion"."Filtro"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Filtro
		{
			get { return (System.String)GetValue((int)EntitiyDistribucionFieldIndex.Filtro, true); }
			set	{ SetValue((int)EntitiyDistribucionFieldIndex.Filtro, value); }
		}

		/// <summary> The Id property of the Entity EntitiyDistribucion<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntitiyDistribucion"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)EntitiyDistribucionFieldIndex.Id, true); }
			set	{ SetValue((int)EntitiyDistribucionFieldIndex.Id, value); }
		}

		/// <summary> The Orden property of the Entity EntitiyDistribucion<br/><br/></summary>
		/// <remarks>Mapped on  table field: "EntitiyDistribucion"."Orden"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Orden
		{
			get { return (System.Int32)GetValue((int)EntitiyDistribucionFieldIndex.Orden, true); }
			set	{ SetValue((int)EntitiyDistribucionFieldIndex.Orden, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DistribucionRegistroEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(DistribucionRegistroEntity))]
		public virtual EntityCollection<DistribucionRegistroEntity> DistribucionRegistros
		{
			get { return GetOrCreateEntityCollection<DistribucionRegistroEntity, DistribucionRegistroEntityFactory>("Entitiy", true, false, ref _distribucionRegistros);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EntityDistribucionAgregadaEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(EntityDistribucionAgregadaEntity))]
		public virtual EntityCollection<EntityDistribucionAgregadaEntity> EntitiesDistribucion
		{
			get { return GetOrCreateEntityCollection<EntityDistribucionAgregadaEntity, EntityDistribucionAgregadaEntityFactory>("EntitiyDistribucion", true, false, ref _entitiesDistribucion);	}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EntityDistribucionAgregadaEntity' which are related to this entity via a relation of type '1:n'. If the EntityCollection hasn't been fetched yet, the collection returned will be empty.<br/><br/></summary>
		[TypeContainedAttribute(typeof(EntityDistribucionAgregadaEntity))]
		public virtual EntityCollection<EntityDistribucionAgregadaEntity> EntitiesDistribucionAgregada
		{
			get { return GetOrCreateEntityCollection<EntityDistribucionAgregadaEntity, EntityDistribucionAgregadaEntityFactory>("EntitiyDistribucion_", true, false, ref _entitiesDistribucionAgregada);	}
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
			get { return (int)Studio_Telko_Sync.EntityType.EntitiyDistribucionEntity; }
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

