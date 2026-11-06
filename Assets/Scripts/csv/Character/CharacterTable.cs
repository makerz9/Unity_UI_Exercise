

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CharacterTable : DataTable
{
    //물려받은 컬렉션 넣기
    private readonly Dictionary<string, CharacterData> table = new Dictionary<string, CharacterData>();

    public override void Load(string filename)
    {
        table.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<CharacterData>(textAsset.text);

        foreach(var item in list)
        {
            if(!table.ContainsKey(item.Id))
            {
                table.Add(item.Id, item);
            }
            else
            {
                Debug.LogError($"아이템 아이디 중복");
            }
        }

    }

    public CharacterData Gets(string id)
    {
        if(!table.ContainsKey(id))
        {
            Debug.LogError($"{id}: 아이템 없음");
            return null;
        }
        return table[id];
    }

    public CharacterData GetRandom()
    {


        var itemList = table.Values.ToList();
        return itemList[Random.Range(0, itemList.Count)];
    }

}
