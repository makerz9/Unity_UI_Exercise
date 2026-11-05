using System.Globalization;
using System.IO;
using UnityEngine;
using CsvHelper;

public class CsvData
{
    public string Id {get; set;}
    public string String {get; set;}
}

public class CSVTest1 : MonoBehaviour
{
    public StringReader stringReader;
    public CsvReader csvReader;
    
    private StringTable stringTable;

    private void Start()
    {
        stringTable = new StringTable();
        stringTable.Load("StringTableKr");

        Debug.Log(stringTable.Get("HI"));
        Debug.Log(stringTable.Get("BYE"));

        Debug.Log(stringTable.Get("DIE"));
    }

    // void Start()
    // {

    //     TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTableKr");
    //     using(var reader = new StringReader(csv.text))
    //     using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
    //     {
    //         var records = csvReader.GetRecords<CsvData>();
    //         foreach(CsvData record in records)
    //         {
    //             Debug.Log($"Id: {record.Id}, String: {record.String}");
    //         }
    //     }



    //     //using (var reader = new StringReader(csv.text))
    //     // using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
    //     // {
    //     //     var records = csvReader.GetRecords<CsvData>();
    //     //     foreach (var record in records)
    //     //     {
    //     //         Debug.Log($"Id: {record.Id}, String: {record.String}");
    //     //     }
    //     // }   
    //     // {
            
    //     // }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
