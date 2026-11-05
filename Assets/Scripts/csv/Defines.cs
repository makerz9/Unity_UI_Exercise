

public enum Languages
{
    None = -1,
    Korean,
    English,
    Japanese,
}

public static class DataTableIds
{
    public static readonly string[] StringTableIds =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };

    public static string String => StringTableIds[(int)Variable.languages];
}

public static class Variable
{
    public static Languages languages;


}