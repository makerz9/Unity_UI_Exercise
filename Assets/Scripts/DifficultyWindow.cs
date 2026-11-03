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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(CurrentDifficulty);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentDifficulty = Difficulty.Easy;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentDifficulty = Difficulty.Normal;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentDifficulty = Difficulty.Hard;
        }

    }

    public void OnClickEasy(bool value)
    {
        Debug.Log($"OnClickEasy: {value}");
    }

    public void OnClickNormal(bool value)
    {
        Debug.Log($"OnClickNormal: {value}");
    }

    public void OnClickHard(bool value)
    {
        Debug.Log($"OnClickHard: {value}");
    }





}
