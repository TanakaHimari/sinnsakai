using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
   
    [SerializeField] 
    [Range(1,5)]private int rawPrice = 2;

    /// <summary>
    /// 商品の価格を500円単位で設定
    /// </summary>
    public int Price
    {
       get { return rawPrice * 500; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレイヤーに接触しなかったらこの処理はしない
        if (!other.CompareTag("Player")) return;

        //Coin.csを探してcoinSystemに格納している
        Coin coinSystem = other.GetComponent<Coin>();

        //所持金が足りればお土産が買える
        if (coinSystem != null && coinSystem.money >= Price)
        {
            //商品代分所持金を減らす
            coinSystem.money -= Price;
            //土産数を増やす
            coinSystem.AddItem();
            //UI更新
            coinSystem.UpdateUI();


            Debug.Log($"アイテム購入成功！{Price}円で購入しました！");
            //商品を消す
            Destroy(gameObject);
        }

        else
        {
            int shortage = Price - coinSystem.money;
            Debug.Log($"所持金が足りません！あと {shortage} 円必要です");

        }

    }

}
