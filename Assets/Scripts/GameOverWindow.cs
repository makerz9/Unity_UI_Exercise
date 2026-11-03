using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameOverWindow : GenericWindow
{
    public TMP_Text leftStatsLabel;
    public TMP_Text rightStatsLabel;
    public TMP_Text leftStatsValues;
    public TMP_Text rightStatsValues;


    public TMP_Text textTotalScore;

    private Coroutine routine;

    //리셋될떄 초기화되는스탯들
    private int[] scores = new int[6]; //초기화해서 쓰기

    private int totalScore;
    //
    public float startValue = 0f;
    float currentTime = 0;

    public override void Open()
    {
        base.Open();

        if(routine != null) //코루틴이 있다 = 실행중이다
        {
            StopCoroutine(routine); //그럼 중지시키고
            routine = null; //코루틴을 비움
        }
        routine = StartCoroutine(ResetScore()); //시작하는 코루틴을 변수에 담음

    }

    public override void Close()
    {
        base.Close();
        //닫힐때 돌고있는게 중지
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
    }

    private IEnumerator ResetScore()
    {
        currentTime = 0f;
        startValue = 0f;

        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(0, 1000);
        }
        

        leftStatsLabel.text = string.Empty;
        rightStatsLabel.text = string.Empty;
        leftStatsValues.text = string.Empty;
        rightStatsValues.text = string.Empty;
        textTotalScore.text = string.Empty;

        for (int i = 0; i < scores.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);

            TMP_Text label = i < 3 ? leftStatsLabel : rightStatsLabel;
            TMP_Text value = i < 3 ? leftStatsValues : rightStatsValues;

            label.text += $"STAT {i + 1}\n"; //:D 쓰면 숫자만큼 앞에 0으로 채움
            value.text += $"{scores[i % 3]:D4}\n";
        }
        yield return new WaitForSeconds(0.5f);



        totalScore = Random.Range(0, 100000000);

        float elapsed = 0f;

        float duration = 2f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 2f;
            int value = Mathf.RoundToInt(Mathf.Lerp(0, totalScore, t));
            textTotalScore.text = $"{value:D9}";
            // 진행률 0~1
            //float t = Mathf.Clamp01(elapsed / duration);

            // 시작 점수부터 최종 점수까지 보간
            //float currentValue = Mathf.Lerp(0f, totalScore, t);

            //int displayScore = Mathf.RoundToInt(currentValue);

            //Mathf.LerpUnclmap ????

            yield return null;
        }

        textTotalScore.text = $"{totalScore:D9}";

        
        


    }



    public void OnNext()
    {
        manager.Open(Windows.Start);
    }

    public void OnClickContinue()
    {
        manager.Open(Windows.GameOver);
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
