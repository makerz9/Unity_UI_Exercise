
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterInfo : MonoBehaviour
{
    public TMP_Text textName;
    public Image icon;
    public TMP_Text textHP; 
    public TMP_Text textAttack; 
    public TMP_Text textDefense; 
    public TMP_Text textSpeed; 

    private ItemData data;

    public void SetEmpty()
    {
        data=null;
        textName.text = string.Empty;
        icon.sprite = null;
        textHP.text = string.Empty;
        textAttack.text = string.Empty;
        textDefense.text = string.Empty;
        textSpeed.text = string.Empty;
    }

    public void SetCharacter(ItemData id)
    {
        SetCharacter(DataTableManager.ItemTable.Get(id));

    }

    public void SetCharacter(CharacterData data)
    {
        if(data == null)
        {
            SetEmpty(); 
            return;
        }

        this.data = data;
        textName.text = data.StringName;
        icon.sprite = data.SpriteIcon;
        textHP.text = data.Type.ToString();
        textAttack.text = data.Atk.ToString();
        textDefense.text = data.Def.ToString();
        textSpeed.text = data.Speed.ToString();
    }
}
