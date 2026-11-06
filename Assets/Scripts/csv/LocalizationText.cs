using UnityEngine;
using TMPro;


[RequireComponent(typeof(TMP_Text))] //무조건 쌍으로 동작해야하는 기능이 있을때
[ExecuteInEditMode]
public class LocalizationText : MonoBehaviour
{
    //private TextMeshProUGUI textMeshProUGUI;
    public string stringId; 

// #if DEF_EDITOR
// //edit가 포함이 안되있으면
//     //컴파일 전에 호출 - 전처리기
//     public Languages editorLang;
// #endif
#if UNITY_EDITOR
//edit가 포함이 안되있으면
    //컴파일 전에 호출 - 전처리기
    public Languages editorLang;
#endif

    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying)
        {
            OnChangedLanguage(editorLang);
            return;
        }
#endif
        Variable.OnLanguageChanged += OnChangedLanguage;
        OnChangedLanguage();

    }

    private void OnDisable()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying)
        {

            return;
        }
#endif

        Variable.OnLanguageChanged -= OnChangedLanguage;
    }

    public void OnChangedLanguage()
    {
        text.text = DataTableManager.StringTable.Get(stringId);

    }

    #if UNITY_EDITOR

    public void OnChangedLanguage(Languages lang)
    {
        var tableId = DataTableIds.StringTableIds[(int)lang];
        var stringTable = DataTableManager.Get<StringTable>(tableId);
        text.text = stringTable.Get(stringId);

    }

    [ContextMenu("Apply Editor Lang To All Active")]



    //!@#
    //컴포넌트 누르면 호출해주는 기능
    //모든 텍스트 바꾸기
    private void ApplyEditorLangToAllActive()
    {
        //Debug.Log("ApplyEditorLangToAllActive");
        var all = FindObjectsByType<LocalizationText>(FindObjectsSortMode.None); //씬에 있는 모든 LocalizationText를 찾아서 배열로 반환

        foreach(var item in all)
        {
            item.editorLang = editorLang;
            item.OnChangedLanguage(editorLang);
        }
    }

    #endif

}
