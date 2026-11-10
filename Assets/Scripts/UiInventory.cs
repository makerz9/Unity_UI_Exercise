using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class UiInventory : MonoBehaviour
{
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiItemSlotList uiItemSlotList;

    private List<SaveItemData> saveItemDataList = new List<SaveItemData>();


    public void OnEnable()
    {
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);
        //var path = Path.Combine(Application.persistentDataPath, "test.json");
        //Debug.Log(path);
    }



    public void OnChangeSorting(int index)
    {
        
        uiItemSlotList.Sorting = (UiItemSlotList.SortingOptions)index;
    }
    public void OnChangeFiltering(int index)
    {
        uiItemSlotList.Filtering = (UiItemSlotList.FilteringOptions)index;
    }

    public void OnSave()
    {
        SaveLoadManager.Data.ItemList = uiItemSlotList.GetSaveItemDataList();
    }

    public void OnLoad()
    {
        if(SaveLoadManager.Load())
        {
            uiItemSlotList.SetSaveItemDataList(SaveLoadManager.Data.ItemList);
        }

        
    }

    public void OnCreateItem()
    {
        uiItemSlotList.AddRandomItem();
    }
    public void OnRemoveItem()
    {
        uiItemSlotList.RemoveItem();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
