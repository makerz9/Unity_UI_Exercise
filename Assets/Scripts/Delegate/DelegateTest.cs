using UnityEngine;
using System;

public class DelegateTest : MonoBehaviour
{
    private event Func<int, int> aTest;
    private int t = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aTest += AddTest;
        aTest?.Invoke(t);
    }

    // Update is called once per frame
    private int AddTest(int value)
    {
        t += t;
        
        Debug.Log($"t: {t}");
        return t;
    }
}
