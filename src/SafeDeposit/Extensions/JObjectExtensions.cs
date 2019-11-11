using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace SafeDeposit.Extensions
{
    public struct JsonValue
    {
        public string Path;
        public string Value;

        public override string ToString()
        {
            return Value;
        }
    }

    public static class JArrayExtensions
    {
        public static IEnumerable<JsonValue> GetLeafValues(this JArray jArray)
        {
            return jArray.Children().SelectMany(child => child.GetLeafValues()).Select(j => new JsonValue { Path = j.Path, Value = j.Value.ToString()});
        }
    }

    public static class JObjectExtensions
    {
        public static IEnumerable<JsonValue> GetLeafValues(this JObject jObject)
        {
            return jObject.Children().SelectMany(jToken => jToken.GetLeafValues());
        }
    }

    public static class JPropertyExtensions
    {
        public static IEnumerable<JsonValue> GetLeafValues(this JProperty jProperty)
        {
            return jProperty.Value.GetLeafValues();
        }
    }

    public static class JTokenExtensions
    {
        public static IEnumerable<JsonValue> GetLeafValues(this JToken jToken)
        {
            switch (jToken)
            {
                case JValue j:
                    yield return new JsonValue {Path = j.Path, Value = j.Value.ToString()};
                    break;
                case JProperty p:
                    foreach (var val in p.GetLeafValues())
                    {
                        yield return val;
                    }
                    break;
                case JArray a:
                    foreach (var val in a.GetLeafValues())
                    {
                        yield return val;
                    }
                    break;
                case JObject o:
                    foreach (var val in o.GetLeafValues())
                    {
                        yield return val;
                    }

                    break;
            }
        }

    }
}
