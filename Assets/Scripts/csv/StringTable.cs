using UnityEngine;
using System.Collections.Generic;

public class StringTable : DataTable
{
    public class Data //내부에서 쓰려고 안에 구현했다?
    {
        public string Id { get; set; }
        public string String { get; set; }
    }

    //딕셔너리
    private readonly Dictionary<string, string> dictionary = new Dictionary<string, string>();

    public override void Load(string filename)
    {
        dictionary.Clear();
        string path = string.Format(FormatPath, filename);
        TextAsset textAsset = Resources.Load<TextAsset>(path);
        List<Data> list = LoadCSV<Data>(textAsset.text);
        //Debug.Log($"스 트 링 테 이 블 {textAsset.text}");
        foreach (var item in list)
        {
            if(!dictionary.ContainsKey(item.Id))
            {
                dictionary.Add(item.Id, item.String);
            }
            else
            {
                Debug.LogError($"키 중복: {item.Id}");
            }
        }

    }
    
    public static readonly string Unknown = "키 없음";

    public string Get(string id)
    {
        if(!dictionary.ContainsKey(id))
        {
            return "키 없음";
        }
        return dictionary[id];

    }
}
