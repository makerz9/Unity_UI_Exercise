using UnityEngine;


public abstract class SaveData
{
    public int Version { get; protected set; }

    public abstract SaveData VersionUp();


}

public class SaveDataV2 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;


    public SaveDataV2()
    {
        Version = 2;
    }

    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }

}


public class SaveDataV3 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int Gold { get; set; } = 100;

    public int EXP { get; set; } = 0;

    public SaveDataV3()
    {
        Version = 3;
    }

    public override SaveData VersionUp()
    {
        throw new System.NotImplementedException();
    }

}

public class SaveDataV1 : SaveData
{
    public string PlayerName { get; set; } = string.Empty;
    public int EXP { get; set; } = 0;
    public SaveDataV1()
    {
        Version = 1;
    }

    public override SaveData VersionUp()
    {
        //throw new System.NotImplementedException();
        var data = new SaveDataV3();
        data.PlayerName = PlayerName;
        data.EXP = EXP;
        return data;
    }
}