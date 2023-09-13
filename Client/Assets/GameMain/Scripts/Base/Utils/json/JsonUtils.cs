


using System;
using GameFramework;
using LitJson;
using UnityEngine;
using Object = System.Object;

namespace GameMain.Base
{
    
    // 需要先配置好 LitJsonHelper
    public static class JsonUtils
    {
        /// <summary>
        /// 将对象序列化为 JSON 字符串。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns>序列化后的 JSON 字符串。</returns>
        public static string ToJson(object obj)
        {
            return Utility.Json.ToJson(obj);
        }

        /// <summary>
        /// 将 JSON 字符串反序列化为对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="json">要反序列化的 JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T ToObject<T>(string json)
        {
            return Utility.Json.ToObject<T>(json);
        }


        /// <summary>
        ///   <para>Overwrite data in an object by reading from its JSON representation.</para>
        /// </summary>
        /// <param name="json">The JSON representation of the object.</param>
        /// <param name="objectToOverwrite">The object that should be overwritten.</param>
        public static void FromJsonOverwrite(string json, object objectToOverwrite)
        {
            object newObj = Utility.Json.ToObject(objectToOverwrite.GetType(), json);
            BeanUtil.CopyFromTarget(objectToOverwrite,newObj);
        }


    }
}




