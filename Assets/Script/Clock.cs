using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    [Header("ゲーム内での開始時間")]
    [Tooltip("Timerと数値そろえることをお忘れなく！")]
    [Range(0,23)] public int hour = 18;
    [Range(0, 59)] public int minute = 59;
    [Range(0, 59)] public int second = 0;

    private float startTime;

    private void OnValidate()
    {
        startTime = hour * 3600f + minute * 60f + second;
    }


    // Update is called once per frame
    void Update()
    {
        //ゲーム開始からの経過時間を加算
        float currentTime = startTime + Time.time;

        int hours = Mathf.FloorToInt(currentTime / 3600);
        int minutes = Mathf.FloorToInt((currentTime % 3600) / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        //時計表示を更新
        clockText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

    }
}
