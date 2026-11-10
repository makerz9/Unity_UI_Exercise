using UnityEngine;
using System;

//public enum CharacterTypes
//{
//    Tanker,
//    Dealer,
//    Supporter,

//}

public class CharacterData
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public string Speed { get; set; }
    public string Icon { get; set; }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public string StringDesc => DataTableManager.StringTable.Get(Desc);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");
}
