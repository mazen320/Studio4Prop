using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    //public ShopItemSO[] shopItemsSO;
    //public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    //public Button[] myPurchaseBtns;

    private void Start()
    {
        //for (int i = 0; i < shopItemsSO.Length; i++)
        //    shopPanelsGO[i].gameObject.SetActive(true);
        coinUI.text = "Coins: " + coins.ToString();
        ////LoadPanels();
        ////CheckPurchasable();
    }

    private void Update()
    {
        
    }

    public void AddCoins(int _noOfCoins)
    {
        coins = coins + _noOfCoins;
        coinUI.text = "Coins: " + coins.ToString();
        //CheckPurchasable();
    }


    //public void CheckPurchasable()
    //{
    //    for(int i = 0; i < shopItemsSO.Length; i++)
    //    {
    //        if (coins >= shopItemsSO[i].baseCost)
    //            myPurchaseBtns[i].interactable = true;
    //        else
    //            myPurchaseBtns[i].interactable=false;
    //    }
    //}

//public void PurchaseItem(int btnNo)
//{
//    if (coins >= shopItemsSO[btnNo].baseCost)
//        {
//            coins = coins - shopItemsSO[btnNo].baseCost;
//            coinUI.text = "Coins: " + coins.ToString();
//            CheckPurchasable();

//        }
//}

    //public void LoadPanels()
    //{
    //    for (int i = 0; i < shopItemsSO.Length; i++)
    //    {
    //        shopPanelsGO[i].titleTxt.text = shopItemsSO[i].title;
    //        shopPanelsGO[i].descriptionTxt.text = shopItemsSO[i].description;
    //        shopPanelsGO[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
    //    }
        
    //}

}

