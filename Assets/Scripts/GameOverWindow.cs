using UnityEngine;
using TMPro;

public class GameOverWindow : GenericWindow
{
    public TMP_Text leftStatsLabel;
    public TMP_Text rightStatsLabel;
    public TMP_Text leftStatsValues;
    public TMP_Text rightStatsValues;


    public TMP_Text textTotalScore;



    //리셋될떄 초기화되는스탯들
    private int[] scores = new int[6]; //초기화해서 쓰기

    private int totalScore;
    //


    public override void Open()
    {
        base.Open();
        ResetScores();

    }

    private void ResetScores()
    {
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(0, 1000);
        }
        totalScore = Random.Range(0, 100000000);

        leftStatsLabel.text = string.Empty;
        rightStatsLabel.text = string.Empty;
        leftStatsValues.text = string.Empty;
        rightStatsValues.text = string.Empty;

        for(int i = 0;i < scores.Length; i++)
        {
            TMP_Text label = i < 3 ? leftStatsLabel : rightStatsLabel;
            TMP_Text value = i < 3 ? leftStatsValues : rightStatsValues;

            label.text += $"STAT {i + 1}\n"; //:D 쓰면 숫자만큼 앞에 0으로 채움
            value.text += $"{scores[i % 3]:D4}\n";
        }

        textTotalScore.text = $"{totalScore:D9}\n";
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
