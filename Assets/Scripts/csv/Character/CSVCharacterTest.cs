
using System.Globalization;
using System.IO;
using UnityEngine;
using CsvHelper;

public class CsvDataT
{
    public string Id {get; set;}
    public string String {get; set;}
}

public class CSVCharacterTest : MonoBehaviour
{
    public StringReader stringReader;
    public CsvReader csvReader;
    
    private StringTable stringTable;

    public UiCharacterButton[] charcterButton;
    public UiCharacterInfo characterInfo;

    private void Start()
    {
        charcterButton[0].SetCharacter("CHAR_1");   
        charcterButton[0].button.onClick.AddListener(()=> characterInfo.SetCharacter("CHAR_1"));
        charcterButton[1].SetCharacter("CHAR_2");   
        charcterButton[1].button.onClick.AddListener(()=> characterInfo.SetCharacter("CHAR_2"));
        charcterButton[2].SetCharacter("CHAR_3");  
        charcterButton[2].button.onClick.AddListener(()=> characterInfo.SetCharacter("CHAR_3"));
        charcterButton[3].SetCharacter("CHAR_4");   
        charcterButton[3].button.onClick.AddListener(()=> characterInfo.SetCharacter("CHAR_4"));
    }
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            //itemButton.SetEmpty();
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            charcterButton[0].SetCharacter("CHAR_1"); 
            //Debug.Log(itemButton.SetItem("ITEM_1"));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            charcterButton[1].SetCharacter("CHAR_2");   
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            charcterButton[2].SetCharacter("CHAR_3"); 
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            charcterButton[3].SetCharacter("CHAR_4");  
        }
    }

}