using Newtonsoft.Json;
using System;
using UnityEngine;

public interface IVector3Converter
{
    Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer);
    void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer);
}