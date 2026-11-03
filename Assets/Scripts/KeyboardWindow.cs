using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class KeyboardWindow : GenericWindow
{
    public int maxCharacters = 7;

    public TMP_Text inputField;
    public GameObject rootKeyboard;

    private Button[] keys;

    protected override void Awake()
    {
        base.Awake();

        keys = rootKeyboard.GetComponentsInChildren<Button>();
    }

    private void OnEnable()
    {
        inputField.text = "_";
        //StartCoroutine(Blink());
    }

    public void OnCancel()
    {
        Debug.Log("OnCancel");
        inputField.text = "_";
    }

    public void OnDelete()
    {
        Debug.Log("OnDelete");
        //Substring
        //inputField.text = inputField.text.Substring(0, inputField.text.Length - 2, 1);
        inputField.text = inputField.text.Remove(inputField.text.Length - 2, 1);
    }

    public void OnAccept()
    {
        Debug.Log("OnAccept");
        Debug.Log($"OnAccept: {inputField.text}");
        inputField.text = string.Empty;
        manager.Open(Windows.Start);

    }

    public void InputKey(string key)
    {
        //if(inputField.text.Length[0] == "_")
        //{
        //    inputField.text.Length[0] = string.Empty;
        //}
        inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        if (inputField.text.Length <= 7)
        {
            
            inputField.text += key;
        }
        inputField.text += "_";
    }

    private IEnumerator Blink()
    {
        Debug.Log("전");

        
        yield return new WaitForSeconds(1f);
        inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);

        yield return new WaitForSeconds(1f);
        inputField.text += "_";
        Debug.Log("깜빡");
        StopCoroutine(Blink());
        StartCoroutine(Blink());

        //while (true)
        //{
        //    Debug.Log($"현재 문자열: [{inputField.text}]");
        //    Debug.Log($"문자열 길이: {inputField.text.Length}");



        //}
    }




   
    
    
    void Update()
    {
        
    }
}
