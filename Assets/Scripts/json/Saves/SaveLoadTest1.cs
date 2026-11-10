
using UnityEngine;
using UnityEngine.UI;


public class SaveLoadTest1 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button btn;

    private void Start()
    {
        btn.interactable = false;
    }


    public void CreateItem()
    {
        SaveLoadManager.Data.ItemList.Add(SaveItemData.GetRandomItem());
    }


    public void Save()  

    {
        SaveLoadManager.Data = new SaveDataV5();
        SaveLoadManager.Data.FirstName = $"HyunKu";
        SaveLoadManager.Data.LastName = $"Kang";
        SaveLoadManager.Data.Gold = Random.Range(10, 200);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
    }

    // Update is called once per frame
    public void Load()
    {
        //SaveLoadManager.Load();
        //Debug.Log(SaveLoadManager.Data.PlayerName);
        //if(SaveLoadManager.Data.PlayerName == "TEST 1")
        //{
        //    btn.interactable = true;
        //}
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");

        foreach (var data in SaveLoadManager.Data.ItemList)
        {
            Debug.Log(data);
        }



    }
}
