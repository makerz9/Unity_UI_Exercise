using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocalizationText))]
public class LocaliztaionTextEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        //로컬라이젼 텍스트 개체
        var text = target as LocalizationText;

        var newId = EditorGUILayout.TextField("String ID", text.stringId);
        var newLang = (Languages)EditorGUILayout.EnumPopup("Language", text.editorLang);

        if(newId != text.stringId || newLang != text.editorLang)
        {
            text.stringId = newId;
            text.editorLang = newLang;
            text.OnChangedLanguage(text.editorLang);
            EditorUtility.SetDirty(text); //에디터에서 변경사항을 저장할수있게
        }
    }
    

}
