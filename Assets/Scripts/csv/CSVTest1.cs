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

    public UiItemButton[] itemButton;
    public UiItemInfo itemInfo;

    private void Start()
    {
        itemButton[0].SetItem("ITEM_1");   
        itemButton[0].button.onClick.AddListener(()=> itemInfo.SetItem("ITEM_1"));
        itemButton[1].SetItem("ITEM_2");   
        itemButton[1].button.onClick.AddListener(()=> itemInfo.SetItem("ITEM_2"));
        itemButton[2].SetItem("ITEM_3");  
        itemButton[2].button.onClick.AddListener(()=> itemInfo.SetItem("ITEM_3"));
        itemButton[3].SetItem("ITEM_4");   
        itemButton[3].button.onClick.AddListener(()=> itemInfo.SetItem("ITEM_4"));
    }
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            //itemButton.SetEmpty();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemButton[0].SetItem("ITEM_1"); 
            //Debug.Log(itemButton.SetItem("ITEM_1"));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemButton[1].SetItem("ITEM_2");   
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemButton[2].SetItem("ITEM_3"); 
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemButton[3].SetItem("ITEM_4");  
        }
    }

    // private void Start()
    // {

    //     // Debug.Log(stringTable.Get("안녕"));
    //     // Debug.Log(stringTable.Get("잘가"));

    //     // Debug.Log(stringTable.Get("너 죽음"));

    //     //stringTable = new StringTable();
    //     //stringTable.Load("StringTableKr");
    //     //stringTable.Load("StringTableEn");
    //     //stringTable.Load("StringTableJp");
    //     // var itemData = DataTableManager.ItemTable.Get("ITEM_1");
    //     // Debug.Log($"{itemData.StringName}, {itemData.StringDesc}");
    // }
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


