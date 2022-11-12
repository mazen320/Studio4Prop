using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private TMP_Text _coinUI;
    //public ShopItemSO[] shopItemsSO;
    //public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    //public Button[] myPurchaseBtns;
    public static int Coins { get; private set; } = 0;


    private void Start()
    {
        //for (int i = 0; i < shopItemsSO.Length; i++)
        //    shopPanelsGO[i].gameObject.SetActive(true);
        _coinUI.text = "Coins: " + _coins.ToString();
        ////LoadPanels();
        ////CheckPurchasable();
    }

    private void Update()
    {
        
    }

    public void AddCoins(int coins)
    {
        Coins += coins;
        _coins = Coins;
        _coinUI.text = $"Coins: {Coins}";
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

