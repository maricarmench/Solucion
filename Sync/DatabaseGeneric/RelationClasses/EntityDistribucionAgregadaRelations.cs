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
	/// <summary>Implements the relations factory for the entity: EntityDistribucionAgregada. </summary>
	public partial class EntityDistribucionAgregadaRelations
	{
		/// <summary>CTor</summary>
		public EntityDistribucionAgregadaRelations()
		{
		}

		/// <summary>Gets all relations of the EntityDistribucionAgregadaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.EntitiyDistribucionEntityUsingEntityId);
			toReturn.Add(this.EntitiyDistribucionEntityUsingEntityAgregadaId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between EntityDistribucionAgregadaEntity and EntitiyDistribucionEntity over the m:1 relation they have, using the relation between the fields:
		/// EntityDistribucionAgregada.EntityId - EntitiyDistribucion.Id
		/// </summary>
		public virtual IEntityRelation EntitiyDistribucionEntityUsingEntityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EntitiyDistribucion", false);
				relation.AddEntityFieldPair(EntitiyDistribucionFields.Id, EntityDistribucionAgregadaFields.EntityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntitiyDistribucionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntityDistribucionAgregadaEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EntityDistribucionAgregadaEntity and EntitiyDistribucionEntity over the m:1 relation they have, using the relation between the fields:
		/// EntityDistribucionAgregada.EntityAgregadaId - EntitiyDistribucion.Id
		/// </summary>
		public virtual IEntityRelation EntitiyDistribucionEntityUsingEntityAgregadaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EntitiyDistribucion_", false);
				relation.AddEntityFieldPair(EntitiyDistribucionFields.Id, EntityDistribucionAgregadaFields.EntityAgregadaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntitiyDistribucionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EntityDistribucionAgregadaEntity", true);
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
	internal static class StaticEntityDistribucionAgregadaRelations
	{
		internal static readonly IEntityRelation EntitiyDistribucionEntityUsingEntityIdStatic = new EntityDistribucionAgregadaRelations().EntitiyDistribucionEntityUsingEntityId;
		internal static readonly IEntityRelation EntitiyDistribucionEntityUsingEntityAgregadaIdStatic = new EntityDistribucionAgregadaRelations().EntitiyDistribucionEntityUsingEntityAgregadaId;

		/// <summary>CTor</summary>
		static StaticEntityDistribucionAgregadaRelations()
		{
		}
	}
}
