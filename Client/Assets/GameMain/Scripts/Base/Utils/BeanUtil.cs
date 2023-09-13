using System.Collections.Generic;
using System.Reflection;
using System;
using UnityGameFramework.Runtime;

namespace GameMain.Base
{
	public class BeanUtil
	{

		//浅拷贝...
		public static void CopyFromTarget(object source, object target)
		{

			HashMap<string, FieldInfo> sourceFieldMap = ClassInfoUtil.GetFieldMap(source);
			HashMap<string, FieldInfo> targetFieldMap = ClassInfoUtil.GetFieldMap(target);

			foreach (FieldInfo targetField in targetFieldMap.GetAllValues())
			{
				string fieldName = targetField.Name;
				FieldInfo sourceField = sourceFieldMap.Get(fieldName);
				if (sourceField != null)
				{
					try
					{
						object value = targetField.GetValue(target);
						sourceField.SetValue(source, value);

					}
					catch (Exception ex)
					{
						Log.Info("CopyFromTarget Error:" + ex.ToString());
					}
				}
			}
		}

		public static void FieldPlus(object source, object target)
		{
			HashMap<string, FieldInfo> sourceFieldMap = ClassInfoUtil.GetFieldMap(source);
			HashMap<string, FieldInfo> targetFieldMap = ClassInfoUtil.GetFieldMap(target);

			foreach (FieldInfo targetField in targetFieldMap.GetAllValues())
			{
				string fieldName = targetField.Name;
				FieldInfo sourceField = sourceFieldMap.Get(fieldName);
				if (sourceField != null)
				{
					try
					{
						object sourceValue = sourceField.GetValue(source);
						object targetValue = targetField.GetValue(target);
						object result = FieldTypeHelper.ValuePlus(sourceValue, targetValue);
						if (result != null)
						{
							sourceField.SetValue(source, result);
						}
					}
					catch (Exception ex)
					{
						Log.Info("FieldPlus Error:" + ex.ToString());
					}
				}
			}
		}

		public static void FieldMinus(object source, object target)
		{
			HashMap<string, FieldInfo> sourceFieldMap = ClassInfoUtil.GetFieldMap(source);
			HashMap<string, FieldInfo> targetFieldMap = ClassInfoUtil.GetFieldMap(target);

			foreach (FieldInfo targetField in targetFieldMap.GetAllValues())
			{
				string fieldName = targetField.Name;
				FieldInfo sourceField = sourceFieldMap.Get(fieldName);
				if (sourceField != null)
				{
					try
					{
						object sourceValue = sourceField.GetValue(source);
						object targetValue = targetField.GetValue(target);
						object result = FieldTypeHelper.ValueMinus(sourceValue, targetValue);
						if (result != null)
						{
							sourceField.SetValue(source, result);
						}
					}
					catch (Exception ex)
					{
						Log.Info("FieldMinus Error:" + ex.ToString());
					}
				}
			}
		}
	}
}