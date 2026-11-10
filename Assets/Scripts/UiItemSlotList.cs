using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiItemSlotList : MonoBehaviour
{
    public enum SortingOptions
    {
        CreationTimeAsscending,
        CreationTimeDesscending,
        NameAsscending,
        NameDesscending,
    }

    public enum FilteringOptions
    {
        None,
        Weapon,
        Equip,
        Consumable,
    }


    public readonly System.Comparison<SaveItemData>[] comparisons =
    {
        (lhs,  rhs) => lhs.CreationTime.CompareTo(rhs.CreationTime), //오름차순
        (rhs,  lhs) => rhs.CreationTime.CompareTo(lhs.CreationTime), //내림차순
    };
    public readonly System.Predicate<SaveItemData>[] filterings =
    {
        (x) => true,
        (x) => x.ItemData.Type == ItemTypes.Weapon,
        (x) => x.ItemData.Type == ItemTypes.Equip,
        (x) => x.ItemData.Type == ItemTypes.Consumable,
    };


    private SortingOptions sorting = SortingOptions.CreationTimeAsscending;
    private FilteringOptions filtering = FilteringOptions.None;


    public FilteringOptions Filtering
    {
        get => filtering;
        set
        {
            if (filtering != value)
            {
                filtering = value;
                UpdateSlot();
            }
        }
    }

    public SortingOptions Sorting
    {
        get => sorting;
        set
        {
            if(sorting != value)
            {
                sorting = value;
                UpdateSlot();
            }
        }
    }

    private int selectedSlot = -1;
    public UnityEvent OnupdateSlots;
    public UnityEvent<SaveItemData> OnSelectSlot;

    public UIItemSlot prefab;

    public ScrollRect scrollRect; 

    public List<UIItemSlot> uiSlotList = new List<UIItemSlot>();

    private List<SaveItemData> saveItemDataList;

    private void Start()
    {
        OnSelectSlot.AddListener((x) => Debug.Log(x));
    }

    private void OnDisable()
    {
        saveItemDataList = null;
    }

    public void SetSaveItemDataList(List<SaveItemData> source)
    {
        saveItemDataList = new List<SaveItemData>(source);
        UpdateSlot();
    }

    public List<SaveItemData> GetSaveItemDataList()
    {
        return saveItemDataList;
    }

    private void UpdateSlot()
    {
        var list = saveItemDataList.FindAll(filterings[(int)filtering]);
        list.Sort(comparisons[(int)sorting]); //소팅부분

        if(uiSlotList.Count < list.Count)
        {
            for(int i = uiSlotList.Count; i < list.Count; i++)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.SlotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);

                newSlot.gameObject.SetActive(false);

                newSlot.button.onClick.AddListener(() =>
                {
                    selectedSlot = newSlot.SlotIndex;
                    if(newSlot.ItemData != null)
                    {
                        OnSelectSlot.Invoke(newSlot.ItemData);
                    }
                    
                });

                uiSlotList.Add(newSlot);
            }
        }

        for(int i = 0; i < uiSlotList.Count; ++i)
        {
            if(i < list.Count)
            {
                uiSlotList[i].gameObject.SetActive(true);
                uiSlotList[i].SetItem(list[i]);

            }
            else
            {
                uiSlotList[i].gameObject.SetActive(false);
                uiSlotList[i].SetEmpty();
            }


        }
        selectedSlot = -1;
        OnupdateSlots.Invoke();
    }

    public void AddRandomItem()
    {
        saveItemDataList.Add(SaveItemData.GetRandomItem());
        UpdateSlot();
    }

    public void RemoveItem()
    {
        Debug.Log("RemoveItem");
        if(selectedSlot == -1)
        {
            return;
        }
        saveItemDataList.Remove(uiSlotList[selectedSlot].ItemData);
        UpdateSlot();
    }


}
