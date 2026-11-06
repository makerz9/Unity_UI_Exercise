

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

    public static string String => StringTableIds[(int)Variable.Languages]; //프로퍼티로 바꿔서 

    public static readonly string Item = "ItemTable"; 
}

public static class Variable
{
    public  static event System.Action OnLanguageChanged;
    private static Languages languages = Languages.English;

    //백킹필드로 받는 프로퍼티
    public static Languages Languages
    {
        get => languages; //위에 랭귀지 리턴
        set
        {
            if(languages == value) //languages = 현재 설정되어있는 언어
            {
                return; //같으면 그냥 리턴
            }
            else
            {
                languages = value;
                OnLanguageChanged?.Invoke(); //이벤트가 null이 아니면 실행해라
            }
        }
    }


}