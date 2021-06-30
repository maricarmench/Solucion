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
using System.Collections;
using System.Collections.Generic;
using Studio_Telko_Sync;
using Studio_Telko_Sync.FactoryClasses;
using Studio_Telko_Sync.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: EntitiyDistribucion. </summary>
	public partial class EntitiyDistribucionRelations
	{
		/// <summary>CTor</summary>
		public EntitiyDistribucionRelations()
		{
		}

		/// <summary>Gets all relations of the EntitiyDistribucionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DistribucionRegistroEntityUsingEntityId);
			toReturn.Add(this.EntityDistribucionAgregadaEntityUsingEntityId);
			toReturn.Add(this.EntityDistribucionAgregadaEntityUsingEntityAgregadaId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EntitiyDistribucionEntity and DistribucionRegistroEntity over the 1:n relation they have, using the relation between the fields:
		/// EntitiyDistribucion.Id - DistribucionRegistro.EntityId
		/// </summary>
		public virtual IEntityRelation DistribucionRegistroEntityUsingEntityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DistribucionRegistros" , true);
				relation.AddEntityFieldPair(EntitiyDistribucionFields.Id, DistribucionRegistroFields.EntityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntitiyDistribucionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DistribucionRegistroEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EntitiyDistribucionEntity and EntityDistribucionAgregadaEntity over the 1:n relation they have, using the relation between the fields:
		/// EntitiyDistribucion.Id - EntityDistribucionAgregada.EntityId
		/// </summary>
		public virtual IEntityRelation EntityDistribucionAgregadaEntityUsingEntityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EntitiesDistribucion" , true);
				relation.AddEntityFieldPair(EntitiyDistribucionFields.Id, EntityDistribucionAgregadaFields.EntityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntitiyDistribucionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntityDistribucionAgregadaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EntitiyDistribucionEntity and EntityDistribucionAgregadaEntity over the 1:n relation they have, using the relation between the fields:
		/// EntitiyDistribucion.Id - EntityDistribucionAgregada.EntityAgregadaId
		/// </summary>
		public virtual IEntityRelation EntityDistribucionAgregadaEntityUsingEntityAgregadaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EntitiesDistribucionAgregada" , true);
				relation.AddEntityFieldPair(EntitiyDistribucionFields.Id, EntityDistribucionAgregadaFields.EntityAgregadaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntitiyDistribucionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntityDistribucionAgregadaEntity", false);
				return relation;
			}
		}


		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticEntitiyDistribucionRelations
	{
		internal static readonly IEntityRelation DistribucionRegistroEntityUsingEntityIdStatic = new EntitiyDistribucionRelations().DistribucionRegistroEntityUsingEntityId;
		internal static readonly IEntityRelation EntityDistribucionAgregadaEntityUsingEntityIdStatic = new EntitiyDistribucionRelations().EntityDistribucionAgregadaEntityUsingEntityId;
		internal static readonly IEntityRelation EntityDistribucionAgregadaEntityUsingEntityAgregadaIdStatic = new EntitiyDistribucionRelations().EntityDistribucionAgregadaEntityUsingEntityAgregadaId;

		/// <summary>CTor</summary>
		static StaticEntitiyDistribucionRelations()
		{
		}
	}
}
