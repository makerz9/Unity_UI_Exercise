using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

public class PlayerState
{
    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;
    public Quaternion rotation;
    public Color color;


    public override string ToString()
    {
        //position.normalized

        return $"{playerName} / {lives} / {health} / {position} / {rotation} / {color}";
    }
}

public class JsonTest1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var obj = new PlayerState
        {
            playerName = "ABC",
            lives = 10,
            health = 10.999f,
            position = new Vector3(1f, 2f, 3f),
            rotation = new Quaternion(1f, 2f, 3f, 4f),
            color = new Color(0.5f, 0.6f, 0.7f, 0.8f)
        };

        //컨버터를 만들었으면 직렬화, 역직렬화 양쪽에 등록해야 합니다.
        var path = Path.Combine(Application.persistentDataPath, "test.json");
        Debug.Log(path);
        string json = JsonConvert.SerializeObject(
            obj, Formatting.Indented, 
            new Vector3Converter(), 
            new QuaternionConverter(),
            new ColorConvertor());
        File.WriteAllText(path, json);

        var json2 = File.ReadAllText(path);
        var obj2 = JsonConvert.DeserializeObject<PlayerState>(json2, 
        new Vector3Converter(), 
        new QuaternionConverter(),
        new ColorConvertor());
        Debug.Log(obj2);
    }


}
