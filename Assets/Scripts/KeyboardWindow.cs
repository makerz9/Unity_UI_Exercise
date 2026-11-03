using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class KeyboardWindow : GenericWindow
{
    public int maxCharacters = 7;

    public TMP_Text inputField;
    public GameObject rootKeyboard;

    private Button[] keys;

    private string inputText = string.Empty;
    private string inputTextWithCursor = "_";

    private bool isCursorVisible;
    private float blinkTimer;
    private float blinkInterval = 0.5f;

    protected override void Awake()
    {
        base.Awake();

        keys = rootKeyboard.GetComponentsInChildren<Button>();

        foreach (var button in keys)
        {
            //GetComponentInChildren<TMP_Text>()가 각 버튼의 자식에서 TMP_Text를 찾아오고,
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();

            //text.text가 그 TMP_Text에 표시되는 문자열을 가져오는 거야.
            string key = text.text;
            button.onClick.AddListener(() => InputKey(key));
        }
    }


    private void Update()
    {
        blinkTimer += Time.deltaTime;
        if(blinkTimer > blinkInterval)
        {
            blinkTimer = 0f;
            isCursorVisible = !isCursorVisible;
            UpdateInputField();
        }
    }

    public override void Open()
    {
        blinkTimer = 0;
        isCursorVisible = true;
        SetText(string.Empty);
        base.Open();
    }


    private void SetText(string text)
    {
        if(text.Length > maxCharacters)
        {
            return;
        }
        inputText = text;
        inputTextWithCursor =
            inputText.Length < maxCharacters ? $"{inputText}_" : inputText;

        inputField.text = inputText;
    }

    private void UpdateInputField()
    {
        inputField.text = isCursorVisible ? inputTextWithCursor : inputText;
    }


    private void OnEnable()
    {
        SetText(string.Empty);
        //inputField.text = "_";
        //StartCoroutine(Blink());
    }

    public void OnCancel()
    {
        Debug.Log("OnCancel");
        //inputField.text = "_";
        SetText(string.Empty);
    }

    public void OnDelete()
    {
        Debug.Log("OnDelete");
        //Substring
        //inputField.text = inputField.text.Substring(0, inputField.text.Length - 2, 1);
        ////inputField.text = inputField.text.Remove(inputField.text.Length - 2, 1);
        ///
        if(inputText.Length > 0)
        {
            SetText(inputText.Substring(0, inputText.Length - 1));
        }
        
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
        SetText($"{inputText}{key}");

        //내 방법
        //inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        //if (inputField.text.Length <= 7)
        //{

        //    inputField.text += key;
        //}
        //inputField.text += "_";
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




   
    
    
    
}
