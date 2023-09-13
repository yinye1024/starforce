using System.Reflection;
using System;


namespace GameMain.Base
{
	public class ClassInfoUtil
	{

		private static BindingFlags _bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

		private static HashMap<Type, HashMap<string, FieldInfo>> _fieldInfoMap =
			new HashMap<Type, HashMap<string, FieldInfo>>();

		public static HashMap<string, FieldInfo> GetFieldMap(object original)
		{

			Type type = original.GetType();
			return GetFieldMap(type);
		}

		public static HashMap<string, FieldInfo> GetFieldMap(Type type)
		{

			HashMap<string, FieldInfo> fieldmap = _fieldInfoMap.Get(type);

			if (fieldmap == null)
			{
				fieldmap = new HashMap<string, FieldInfo>();
				FieldInfo[] fieldArray = type.GetFields(_bindingFlags);
				foreach (FieldInfo fieldtmp in fieldArray)
				{
					fieldmap.Put(fieldtmp.Name, fieldtmp);
				}

				_fieldInfoMap.Put(type, fieldmap);

			}

			return fieldmap;
		}

	}
}
