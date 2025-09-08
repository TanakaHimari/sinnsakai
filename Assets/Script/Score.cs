using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI itemText;

    // Update is called once per frame
    void Update()
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        int itemCount = PlayerPrefs.GetInt("ItemCount", 0);
        moneyText.text = "Š‹àF" + money + " ‰~";
        itemText.text = "‚¨“yYF" + itemCount + " ŒÂ";

    }
}