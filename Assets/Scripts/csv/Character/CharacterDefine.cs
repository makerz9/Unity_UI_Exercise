
public static class CharacterDataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };


    public static string String => StringTableIds[(int)Variable.Languages]; //프로퍼티로 바꿔서 

    public static readonly string Character = "CharacterTable"; 
}

