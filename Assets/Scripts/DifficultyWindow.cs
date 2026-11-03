using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public enum Difficulty
    {
        None = -1,
        Easy,
        Normal,
        Hard,
    }

    int intDifficulty = 1;

    public Toggle[] toggles;

    public Difficulty CurrentDifficulty
    {
        get
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if(toggles[i].isOn)
                {
                    return (Difficulty)i;
                }
            }
            return Difficulty.None;
        }

        set
        {
            toggles[(int)value].isOn = true;

        }
    }



    private void OnEnable()
    {
        intDifficulty = PlayerPrefs.GetInt("CurrentDifficulty", intDifficulty);

    }
    //private void Start()
    //{
    //    intDifficulty = 1;
    //}


    private void Update()
    {


        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(intDifficulty > 0)
            {
                intDifficulty--;
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (intDifficulty < 2)
            {
                intDifficulty++;
            }
        }

        if(intDifficulty == 0)
        {
            CurrentDifficulty = Difficulty.Easy;
        }
        else if(intDifficulty == 1)
        {
            CurrentDifficulty = Difficulty.Normal;
        }
        else if (intDifficulty == 2)
        {
            CurrentDifficulty = Difficulty.Hard;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentDifficulty = Difficulty.Easy;
            intDifficulty = 0;

        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentDifficulty = Difficulty.Normal;
            intDifficulty = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentDifficulty = Difficulty.Hard;
            intDifficulty = 2;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            manager.Open(Windows.Start);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(CurrentDifficulty);
            Debug.Log(intDifficulty);
            //저장
            PlayerPrefs.SetInt("CurrentDifficulty", intDifficulty);

        }
    }

    public void OnClickEasy(bool value)
    {
        intDifficulty = 0;
        Debug.Log($"OnClickEasy: {value}");
    }

    public void OnClickNormal(bool value)
    {
        intDifficulty = 1;
        Debug.Log($"OnClickNormal: {value}");
    }

    public void OnClickHard(bool value)
    {
        intDifficulty = 2;
        Debug.Log($"OnClickHard: {value}");
    }





}
