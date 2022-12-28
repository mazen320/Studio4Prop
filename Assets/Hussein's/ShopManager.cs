using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private TMP_Text _coinUI;
 
    public ShopTemplate[] shopPanels;
   
    public static int Coins { get; private set; } = 0;


    private void Start()
    {
  
        _coinUI.text = "Coins: " + _coins.ToString();
     
    }

    private void Update()
    {
        
    }

    public void AddCoins(int coins)
    {
        Coins += coins;
        _coins = Coins;
        _coinUI.text = $"Coins: {Coins}";
        
    }



}

