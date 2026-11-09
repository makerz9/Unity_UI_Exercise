using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

//Vector3를 글자로 바꿔주는 번역기이고
public class Vector3ObjectConverter : JsonConverter<Vector3>
{
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);
        Vector3 v = Vector3.zero;

        v.x = (float)jObj["X"];
        v.y = (float)jObj["Y"];
        v.z = (float)jObj["Z"];

        return v;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);

        writer.WriteEndObject();
    }
}

public class QuaternionObjectConverter : JsonConverter<Quaternion>
{


    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        //Vector3 v = Vector3.zero; !@# 왜 vector처럼 그게 없지
        JObject jObj = JObject.Load(reader);
        Quaternion q = Quaternion.identity;

        q.x = (float)jObj["X"];
        q.y = (float)jObj["Y"];
        q.z = (float)jObj["Z"];
        q.w = (float)jObj["W"]; //!@# w나 W 따로 선언 안했는데 왜 괜찮은지?
        return q;
        //return new Quaternion(x, y, z, w);
    }

    public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
        writer.WritePropertyName("W");
        writer.WriteValue(value.w);
        writer.WriteEndObject();

    }
}


public class ScaleConverter : JsonConverter<Vector3>
{
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);
        Vector3 s = Vector3.zero;

        s.x = (float)jObj["X"];
        s.y = (float)jObj["Y"];
        s.z = (float)jObj["Z"];

        return s;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);

        writer.WriteEndObject();
    }
}





public class JsonObjectConverters : MonoBehaviour
{


}
