using UnityEngine;
using System.IO;

public class PPractice2 : MonoBehaviour
{
    private const byte Key = 0xAB;

    private string folder;
    private string srcPath;
    private string encPath;
    private string decPath;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "Secret");
        if(!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }

        srcPath = Path.Combine(folder, "original.txt");
        encPath = Path.Combine(folder, "encrypted.txt");
        decPath = Path.Combine(folder, "decrypted.txt");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void WriteOriginal()
    {
        File.WriteAllText(srcPath, "Hello Unity World!!");
    }

    private void Encrypt()
    {
        using(Stream input = new FileStream(srcPath, FileMode.Open))
        using(Stream output = new FileStream(encPath, FileMode.Open))
        {
            //int형 리턴?!
            int b;
            while ((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b ^ Key));
            }
        }
    }

    //복호화
    //암호화의 역순으로
    private void Decrypt()
    {
        //var 써도 유효
        using (Stream input = new FileStream(encPath, FileMode.Open))
        using (Stream output = new FileStream(decPath, FileMode.Open))
        {
            
            int b;
            while ((b = input.ReadByte()) != -1)
            {
                output.WriteByte((byte)(b ^ Key));
            }
        }

        string result = File.ReadAllText(decPath);
        bool equal = result == File.ReadAllText(srcPath);
    }


}
