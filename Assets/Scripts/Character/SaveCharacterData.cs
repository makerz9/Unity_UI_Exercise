using Newtonsoft.Json;
using System;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class SaveCharacterData : MonoBehaviour
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]

    public CharacterData charaData { get; set; }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
