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
	/// <summary>Implements the relations factory for the entity: Tenant. </summary>
	public partial class TenantRelations
	{
		/// <summary>CTor</summary>
		public TenantRelations()
		{
		}

		/// <summary>Gets all relations of the TenantEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DistribucionRegistroEntityUsingTenantId);
			toReturn.Add(this.SubTentantEntityUsingTentantId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TenantEntity and DistribucionRegistroEntity over the 1:n relation they have, using the relation between the fields:
		/// Tenant.Id - DistribucionRegistro.TenantId
		/// </summary>
		public virtual IEntityRelation DistribucionRegistroEntityUsingTenantId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DistribucionRegistros" , true);
				relation.AddEntityFieldPair(TenantFields.Id, DistribucionRegistroFields.TenantId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TenantEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DistribucionRegistroEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TenantEntity and SubTentantEntity over the 1:n relation they have, using the relation between the fields:
		/// Tenant.Id - SubTentant.TentantId
		/// </summary>
		public virtual IEntityRelation SubTentantEntityUsingTentantId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SubTentants" , true);
				relation.AddEntityFieldPair(TenantFields.Id, SubTentantFields.TentantId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TenantEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SubTentantEntity", false);
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
	internal static class StaticTenantRelations
	{
		internal static readonly IEntityRelation DistribucionRegistroEntityUsingTenantIdStatic = new TenantRelations().DistribucionRegistroEntityUsingTenantId;
		internal static readonly IEntityRelation SubTentantEntityUsingTentantIdStatic = new TenantRelations().SubTentantEntityUsingTentantId;

		/// <summary>CTor</summary>
		static StaticTenantRelations()
		{
		}
	}
}
