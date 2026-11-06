using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public static class DataTableManager //아무데서나 .찍어서 사용할수 있게 (모노비헤이비어 상속안받는 스태틱 메서드)
{
    
    private static readonly Dictionary<string, DataTable> tables = 
        new Dictionary<string, DataTable>();


    static DataTableManager() //스태틱 생성자 (클래스가 처음 사용될때 한번만 호출됨)
    {
        //스테식 생성자로 초기화 실행
        Init();
    }

    private static void Init() //초기화함수 (이니셜라이즈)
    {
        // var stringTable = new StringTable();
        // stringTable.Load(DataTableIds.String);

        // tables.Add(DataTableIds.String, stringTable);
        // //초기화 = 데이터테이블 생성하고 덱셔너리에 집어넣음
    #if UNITY_EDITOR
        foreach (var id in DataTableIds.StringTableIds)
        {
            var stringTable = new StringTable();
            stringTable.Load(id);
            tables.Add(id, stringTable);
        }
    #else
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);

    #endif

        var csvTable = new CSVTable();
        csvTable.Load(DataTableIds.Item);
        tables.Add(DataTableIds.Item, csvTable);
    }


    public static StringTable StringTable => Get<StringTable>(DataTableIds.String);
    
    public static CSVTable ItemTable => Get<CSVTable>(DataTableIds.Item);

    public static T Get<T>(string id) where T : DataTable //제네릭 메서드 (타입을 매개변수로 받는 메서드)
    {
        if(!tables.ContainsKey(id))
        {
            Debug.LogError($"테이블 없음: {id}");
            return null;
        }
        //지나감 확정
        return tables[id] as T;

    }

    //public static StringTable StringTable => Get<StringTable>(DataTableIds.String);

    public static void OnChangedLanguage(Languages lang)
    {
        var newId = DataTableIds.StringTableIds[(int)lang];
        if(tables.ContainsKey(newId))
        {
            return;
        }

        string oldId = null;
        foreach(var id in DataTableIds.StringTableIds)
        {
            if(tables.ContainsKey(id))
            {
                oldId = id;
                break;
            }
        }

        if(oldId == null)
        {
            Debug.LogError("활성화된 스트링 테이블이 없음");

        }

        var table = tables[oldId] as StringTable;
        table.Load(newId);
        tables.Remove(oldId);
        tables.Add(newId, table);
        
    }

}
