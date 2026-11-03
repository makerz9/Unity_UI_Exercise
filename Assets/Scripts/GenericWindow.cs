using UnityEngine;
using UnityEngine.EventSystems;

//모든 윈도우 클래스의 부모스크립트
public class GenericWindow : MonoBehaviour
{
    protected WindowManager manager; //기능이 오픈밖에 없음

    public GameObject firstSeleted;

    private EventSystem eventSystem;

    protected virtual void Awake()
    {
        eventSystem = EventSystem.current;
    }

    public void Init(WindowManager manager)
    {
        this.manager = manager;
    }

    public void OnFocus()
    {
        eventSystem.SetSelectedGameObject(firstSeleted);
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
