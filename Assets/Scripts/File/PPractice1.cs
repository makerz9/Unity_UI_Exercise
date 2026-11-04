using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PPractice1 : MonoBehaviour
{
    private string folder;
    private string path;

    private Dictionary<string, string> settings = new Dictionary<string, string>();
    string savedata1 = "volume=100\nresolution=1920x1080\nfullscreen=true";
    string savedata2 = "volume=80\nresolution=1920x1080\nfullscreen=false";
    string savedata3 = "volume=60\nresolution=1280x720\nfullscreen=true";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);//경로 확인용
        //folder = Path.Combine(Application.persistentDataPath, "SaveData");
        //if(!Directory.Exists(folder))
        //{
        //    Directory.CreateDirectory(folder);
        //}
        ////경로만들기
        //path = Path.Combine(folder, "SaveData.cfg");

        folder = Path.Combine(Application.persistentDataPath, "SaveData");

        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        for (int i = 0; i < 3; i++)
        {
            string path = Path.Combine(folder, $"save{i + 1}.txt");
            File.WriteAllText(path, "AABCDE");
        }

        // 폴더 내 파일 목록
        string[] files = Directory.GetFiles(folder);

        foreach (string file in files)
        {
            Debug.Log($"파일명: {Path.GetFileName(file)}");
            Debug.Log($"확장자: {Path.GetExtension(file)}");
        }

    }

    //File.WriteAllText로 테스트용 파일 3개를 생성할 것


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WriteFile();
        }

    }

    private void WriteFile()
    {
        // 문자열 전체를 파일에 쓰기

        //File.WriteAllText(path, savedata1);
        //File.WriteAllText(path, savedata2);
        //File.WriteAllText(path, savedata3);
        //File.WriteAllText(Path.Combine(folder, "save1.txt"), savedata1);
        //File.WriteAllText(Path.Combine(folder, "save2.txt"), savedata2);
        //File.WriteAllText(Path.Combine(folder, "save3.txt"), savedata3);




    }

    private void ReadFile()
    {
        // 파일 전체를 문자열로 읽기
        string loaded = File.ReadAllText(path);
        Debug.Log($"읽은 내용:\n{loaded}");
    }


}
