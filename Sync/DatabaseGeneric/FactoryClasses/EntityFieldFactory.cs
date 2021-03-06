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

using Studio_Telko_Sync;
using Studio_Telko_Sync.HelperClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Studio_Telko_Sync.FactoryClasses
{
	/// <summary>Factory class for IEntityField2 instances, used in IEntityFields2 instances.</summary>
	public static partial class EntityFieldFactory
	{
		/// <summary>Creates a new IEntityField2 instance for usage in the EntityFields object for the entity related to the field index specified.</summary>
		/// <param name="fieldIndex">The field which IEntityField2 instance should be created</param>
		/// <returns>The IEntityField2 instance for the field specified in fieldIndex</returns>
		public static IEntityField2 Create(Enum fieldIndex)
		{
			return new EntityField2(FieldInfoProviderSingleton.GetInstance().GetFieldInfo(fieldIndex));
		}

		/// <summary>Creates a new IEntityField2 instance, which represents the field objectName.fieldName</summary>
		/// <param name="objectName">the name of the object the field belongs to, like CustomerEntity or OrdersTypedView</param>
		/// <param name="fieldName">the name of the field to create</param>
		public static IEntityField2 Create(string objectName, string fieldName)
        {
			return new EntityField2(FieldInfoProviderSingleton.GetInstance().GetFieldInfo(objectName, fieldName));
        }

		#region Included Code

		#endregion
	}
}
