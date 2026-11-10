using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiIurmInfo2 : MonoBehaviour
{
    public static readonly string FormatString = "{0}, {0}";

    public Image icon;

    public TMP_Text textName;
    public TMP_Text textType;
    public TMP_Text textValue;
    public TMP_Text textCost;
    public TMP_Text textDesc;

    public void SetEmpty()
    {
        icon.sprite = null;
        icon.enabled = false;
        textName.text = string.Empty;
        textType.text = string.Empty;
        textValue.text = string.Empty;
        textCost.text = string.Empty;
        textDesc.text = string.Empty;
    }

    public void SetItem(SaveItemData saveItemData)
    {
        Debug.Log("셋아");
        var data = saveItemData.ItemData;

        var st = DataTableManager.StringTable;
        icon.sprite = data.SpriteIcon;
        icon.enabled = true;

        icon.sprite = saveItemData.ItemData.SpriteIcon;
        icon.enabled = true;
        textName.text = string.Format(FormatString, st.Get("NAME"), data.StringName);
        textType.text = string.Format(FormatString, st.Get("TYPE"), data.StringName);
        textValue.text = string.Format(FormatString, st.Get("VALUE"), data.StringName);
        textCost.text = string.Format(FormatString, st.Get("NAME"), data.StringName);
        textDesc.text = string.Format(FormatString, st.Get("NAME"), data.StringName);
    }
}
