using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Qc.MeadminSdk
{
    public class JsonHelper
    {
        public static string Serialize(object o)
        {
            var setting = new JsonSerializerSettings()
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            return o == null ? string.Empty : JsonConvert.SerializeObject(o, setting);
        }

        public static T Deserialize<T>(string input)
        {
            return string.IsNullOrEmpty(input) ? default(T) : JsonConvert.DeserializeObject<T>(input);
        }

        public static dynamic Deserialize(string input)
        {
            return JsonConvert.DeserializeObject(input);
        }

        /// <summary>
        /// 指定哪些属性不需要序列化
        /// </summary>
        /// <param name="o"></param>
        /// <param name="exceptProps">要排除不需要序列化的属性</param>
        /// <returns></returns>
        public static string Serialize(object o, string[] exceptProps)
        {
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new ExceptPropsContractResolver(exceptProps);
            return JsonConvert.SerializeObject(o, Formatting.None, settings);
        }
    }

    public class ExceptPropsContractResolver : DefaultContractResolver
    {
        private string[] props = null;

        public ExceptPropsContractResolver(string[] props)
        {
            //指定要排除序列化属性的清单
            this.props = props;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> list = base.CreateProperties(type, memberSerialization);
            //只保留清单没有列出的属性
            return list.Where(p => props.Contains(p.PropertyName) == false).ToList();
        }
    }
}
