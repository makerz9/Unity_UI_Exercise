using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class UICharacter : MonoBehaviour
{
    public readonly string[] SortingOptionNames =
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC",
    };

    public readonly string[] FilteringOptionNames =
    {
        "FILTER_ALL",
        "FILTER_TANKER",
        "FILTER_DEALER",
        "FILTER_SUPPORTER",
    };

    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public //UiItemSlotList uiItemSlotList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
