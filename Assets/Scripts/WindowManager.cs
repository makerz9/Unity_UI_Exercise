using System.Collections.Generic;
using UnityEngine;


//하는일1. 시작할떄 모든 제네릭 윈도우 초기화
//하는일2. 
public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> windows;
    //제네릭윈도우 있는애만 받음

    public Windows defaultWindow;
    public Windows CurrentWindow { get; private set; }

    private void Start()
    {
        //초기화용 포이치
        foreach (var window in windows)
        {
            window.Init(this); //this 데이터형 - 윈도우 매니저 (this니까)
            window.gameObject.SetActive(false);
        }

        //defaultWindow를 Current에 할당하고 엶
        CurrentWindow = defaultWindow;
        windows[(int)CurrentWindow].Open();
    }

    public void Open(Windows id)
    {
        windows[(int)CurrentWindow].Close();
        CurrentWindow = id; //매개변수로 넘어온값으로 id에맞는 창을 엶
        windows[(int)CurrentWindow].Open();
    }
}
