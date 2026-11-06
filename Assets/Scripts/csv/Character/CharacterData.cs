

using UnityEngine;

public enum CharacterTypes
{
    Weapon,
    Equip,
    Consumable,
}


public class CharacterData
{
    public string Id {get; set;}
    public CharacterData Type {get; set;}
    public string Name {get; set;}
    public string HP {get; set;}
    public int Atk {get; set;}
    public int Def {get; set;}
    public int Speed {get; set;}
    public string Icon {get; set;}  

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(HP);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

}
