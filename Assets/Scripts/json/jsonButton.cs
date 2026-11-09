using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

//SaveData 클래스 = 저장할 값만 골라서 담아두는 "스냅샷 상자"
//적은 목록만 가져가서 새집에서 그대로 재현

//JSON에 아무리 잘 적어도, 읽어 들인 결과는 "글자에서 만든 C# 객체"이지 씬에 존재하는 오브젝트가 아닙니다.
//씬에 오브젝트를 만드는 일은 반드시 Instantiate가 해야함

public class JsonTest2SaveData //!@# 왜 쓰지 데이터를 왜 따로 담지 -> 필요한 값만 SaveData에 복사
//저장:  GameObject -> (값만 복사) -> SaveData -> JSON 글자
//복원: JSON 글자 -> SaveData-> (값을 읽어서) Instantiate->새 GameObject

//SaveData는 오브젝트를 다시 만들 때 필요한 재료만 들고 있는 순수한 숫자와 글자 덩어리라서 JSON으로 안전하게 오갈 수 있습니다
//즉 오브젝트를 다시 만들기 위한 숫자 메모지입니다. 오브젝트 자체는 저장이 안 됩니다.
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;

    public override string ToString()//!@# 왜필요하지 -> 디버그 출력용 편의 기능
                                     //저장/불러오기와 무관. Debug.Log(data) 했을 때 클래스 이름 대신 값이 보이게 하는 용도.
    {
        //position.normalized

        return $"{position} / {rotation} / {scale} / {color}";
    }
}



public class jsonButton : MonoBehaviour
{
    [SerializeField] private Button save;
    [SerializeField] private Button load;
    [SerializeField] private Button clear;
    [SerializeField] private Button create;

    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private List<GameObject> prefabPool = new List<GameObject>();
    private JsonSerializerSettings jsonSettings;

    private void Awake()
    {
        jsonSettings = new JsonSerializerSettings();
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.Converters.Add(new Vector3Converter());
        jsonSettings.Converters.Add(new QuaternionConverter());
        jsonSettings.Converters.Add(new ColorObjectConverter());
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        save.onClick.AddListener(()=> OnSave());
        load.onClick.AddListener(()=> OnLoad());
        clear.onClick.AddListener(()=> OnClear());
        create.onClick.AddListener(()=> OnCreate());


    }


    private void OnSave()
    {
        //생성된 프리팹 정보를 json저장
        //각 오브젝트들의 위치 회전 크기 json으로 다 저장?
        Debug.Log("저장");
        List<JsonTest2SaveData> saveDatas = new List<JsonTest2SaveData>();
        foreach (GameObject obj in prefabPool)
        {
            JsonTest2SaveData data = new JsonTest2SaveData();
            data.name = obj.name;
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.scale = obj.transform.localScale;
            data.color = obj.GetComponent<Renderer>().material.color;
            saveDatas.Add(data);
        }

        //직렬화?
        string json = JsonConvert.SerializeObject(
            saveDatas, 
            Formatting.Indented,
            new Vector3ObjectConverter(),
            new QuaternionObjectConverter(),
            new ScaleConverter(),
            new ColorObjectConverter()
            );
        string path = Path.Combine(Application.persistentDataPath, "JsonTest2.json");
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    private void OnLoad()
    {
        //json에 저장된 대로 불러오기
        //json에 저장된 각 오브젝트들의 위치 회전 크기 그대로 불러오면 뭐 생성하는건가
        Debug.Log("로드");
        OnClear();
        //배치된 블럭 싹 없앰

        string path = Path.Combine(Application.persistentDataPath, "JsonTest2.json");
        if (!File.Exists(path)) return;
        string json = File.ReadAllText(path);

        var saveDatas = JsonConvert.DeserializeObject<List<JsonTest2SaveData>>(json, jsonSettings);

        ////역직렬화
        //List<JsonTest2SaveData> saveDatas = JsonConvert.DeserializeObject<List<JsonTest2SaveData>>
        //    (json,
        //    new Vector3ObjectConverter(),
        //    new QuaternionObjectConverter()
        //    );

        foreach (var data in saveDatas)
        {
            int prefabsIndex = -1;
            for (int i = 0; i< prefabs.Length; ++i)
            {
                if (data.name.Contains(prefabs[i].name))
                {
                    prefabsIndex = i;
                    break;

                }
            }
            var newGo = Instantiate(prefabs[prefabsIndex]);
            newGo.transform.position = data.position;
            newGo.transform.rotation = data.rotation;
            newGo.transform.localScale = data.scale;
            newGo.GetComponent<Renderer>().material.color = data.color;
            prefabPool.Add(newGo);
        }


    }

    private void OnClear()
    {
        //프리팹 모두 제거
        Debug.Log("제거");
        //for (int i = 0; i < prefabPool.Count; i++)
        //{
        //    Destroy(prefabPool[i]);

        //}
        //prefabPool.Clear();
        foreach (GameObject prefab in prefabPool)
        {
            Destroy(prefab);
        }
        prefabPool.Clear(); //리스트 목록까지 제거
    }

    private void OnCreate()
    {
        //프리팹 생성하기
        Debug.Log("생성");
        //for (int i = 0; i < prefabs.Length; i++)
        //{
        //    int statRand = Random.Range(-4, 5);
        //    //Instantiate(prefabs[i], new Vector3(0,0,0), Quaternion.identity);
        //    GameObject obj = Instantiate(prefabs[i], new Vector3(statRand, statRand, statRand), Quaternion.Euler(statRand * 30, 0, 0));
        //    prefabPool.Add(obj);
        //}             
        int randomIndex = Random.Range(0, prefabs.Length);
        Vector3 randomPosition = Random.insideUnitSphere * 10f;
        Quaternion randomRotation = Random.rotation;
        Vector3 randomScale = Vector3.one * Random.Range(0.5f, 2f);
        Color color = Random.ColorHSV();

        GameObject newGo = Instantiate(prefabs[randomIndex]);
        newGo.transform.position = randomPosition;
        newGo.transform.rotation = randomRotation;
        newGo.transform.localScale = randomScale;
        newGo.GetComponent<Renderer>().material.color = color;

        prefabPool.Add(newGo);


        //
        //var obj = new JsonTest2SaveData
        //{
        //    position = randomPosition, 
        //    rotation = randomRotation,
        //    scale = randomScale,
        //};

        ////컨버터를 만들었으면 직렬화, 역직렬화 양쪽에 등록해야 합니다.
        //var path = Path.Combine(Application.persistentDataPath, "test.json");
        //Debug.Log(path);
        //string json = JsonConvert.SerializeObject(
        //    obj, Formatting.Indented,
        //    new Vector3Converter(),
        //    new QuaternionConverter(),
        //    new ScaleConverter(),
        //    new ColorObjectConverter()
        //    );
        //File.WriteAllText(path, json);

        //var json2 = File.ReadAllText(path);
        //var obj2 = JsonConvert.DeserializeObject<PlayerState>(json2,
        //new Vector3Converter(),
        //new QuaternionConverter(),
        //new ScaleConverter(),
        //new ColorObjectConverter()
        //);
        //Debug.Log(obj2);



    }
}
