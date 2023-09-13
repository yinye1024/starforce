using System.Collections.Generic;
using System.Collections;


namespace GameMain.Base
{
	public class HashMap<T, TD>
	{
		// private Hashtable _hashTable = new Hashtable();
		
		private readonly Dictionary<T, TD> _dictionary = new();

		public void Put(T key, TD value)
		{
			_dictionary.Add(key, value);
		}

		public TD Get(T key)
		{
			if (_dictionary.TryGetValue(key, out var value))
			{
				return (TD)value;
			}

			// default(T)会返回类型T的默认值
			// 对于引用类型（如类、接口、委托等），default(T) 返回 null。
			// 对于值类型（如整数、浮点数、结构体等），default(T) 返回该类型的默认值。例如，对于int，这是0；对于bool，这是false等。
			return default(TD);
		}

		public bool HasKey(T key)
		{
			return this._dictionary.ContainsKey(key);
		}

		public void Remove(T key)
		{
			if (key != null && _dictionary.ContainsKey(key))
			{
				_dictionary.Remove(key);
			}
		}

		public List<TD> GetAllValues()
		{
			List<TD> list = new List<TD>();
			foreach (TD tmp in this._dictionary.Values)
			{
				list.Add(tmp);
			}

			return list;
		}

		public int Count()
		{
			return this._dictionary.Count;
		}

		public void Clear()
		{
			_dictionary.Clear();
		}
	}
}
