using System;
using System.Reflection;

namespace GameMain.Base
{
	public class FieldTypeHelper
	{
		private static Type stringType = typeof(string);
		private static Type int32Type = typeof(Int32);
		private static Type floatType = typeof(float);
		private static Type doubleType = typeof(double);
		private static Type boolType = typeof(bool);
		private static Type longType = typeof(long);


		public static object ToPrimitiveValue(Type type, string value)
		{

			if (type == stringType)
			{
				return value;
			}
			else if (type == int32Type)
			{
				return Int32.Parse(value);
			}
			else if (type == floatType)
			{
				return float.Parse(value);
			}
			else if (type == doubleType)
			{
				return double.Parse(value);
			}
			else if (type == boolType)
			{
				return bool.Parse(value);
			}
			else if (type == longType)
			{
				return long.Parse(value);
			}

			return null;
		}

		public static object ValuePlus(object source, object target)
		{
			Type type = source.GetType();
			object result = null;
			if (type == typeof(int))
			{
				result = (int)source + (int)target;
			}
			else if (type == typeof(long))
			{
				result = (long)source + (long)target;
			}
			else if (type == typeof(float))
			{
				result = (float)source + (float)target;
			}
			else if (type == typeof(double))
			{
				result = (double)source + (double)target;
			}

			return result;
		}

		public static object ValueMinus(object source, object target)
		{
			Type type = source.GetType();
			object result = null;
			if (type == typeof(int))
			{
				result = (int)source - (int)target;
			}
			else if (type == typeof(long))
			{
				result = (long)source - (long)target;
			}
			else if (type == typeof(float))
			{
				result = (float)source - (float)target;
			}
			else if (type == typeof(double))
			{
				result = (double)source - (double)target;
			}

			return result;
		}

		public static bool IsPrimitive(Type type)
		{
			return type.IsEnum || type.IsPrimitive || type == stringType;
		}


	}

}