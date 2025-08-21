using UnityEngine;
using TMPro;

public class Coin : MonoBehaviour
{
    [Tooltip("所持金を表示するテキスト")]
    [SerializeField] private TextMeshProUGUI moneyText;

    [Tooltip("お土産数を表示するテキスト")]
    [SerializeField] private TextMeshProUGUI itemText;

    public  int money = 0;
    public int itemCount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //コインに触れたら所持金を増やす
        if (other.CompareTag("Coin"))
        {
            money += 500;
            UpdateUI();
            //触れたコインは消える
            Destroy(other.gameObject); 
        }
    }

    public void UpdateUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"所持金:\n{money} 円";
        }
        else
        {
            Debug.LogWarning("moneyText が設定されていません！");
        }

        if (itemText != null)
        {
            itemText.text = $"お土産:\n{itemCount}個";
        }
        else
        {
            Debug.LogWarning("ItemText が設定されていません！");
        }

    }
   /// <summary>
   /// アイテム数更新
   /// </summary>
    public void AddItem()
    {
        itemCount++;
        UpdateUI();
    }
}