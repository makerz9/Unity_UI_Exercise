
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

    public void Save()
    {
        SaveLoadManager.Data = new SaveDataV3();
        SaveLoadManager.Data.PlayerName = $"HyunKu Kang";
        SaveLoadManager.Data.Gold = Random.Range(10, 200);
        SaveLoadManager.Data.EXP = Random.Range(0, 100);
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
        Debug.Log($"{SaveLoadManager.Data.PlayerName}");
        Debug.Log($"골드 개수: {SaveLoadManager.Data.Gold}");
        Debug.Log($"경험치 량:{SaveLoadManager.Data.EXP}");


    }
}
