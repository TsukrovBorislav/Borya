using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;
    [SerializeField] private GameObject _turretPrefab;

    public static void UpdateUI()
    {
        bool boolPlayerNumber = Convert.ToBoolean(CurrentPlayer.CurrentPlayerNumber);

        StartGame.Money1.text = PlayersContainer.Players[0].CountCoins.ToString();
        StartGame.Money2.text = PlayersContainer.Players[1].CountCoins.ToString();
        StartGame.BuildingPanel1.SetActive(boolPlayerNumber);
        StartGame.BuildingPanel2.SetActive(!boolPlayerNumber);
    }

    public void BuyButton(Object type, GameObject prefab)
    {

        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];

        if (player.CountCoins >= type.Cost)
        {
            CurrentPlayer.OperatingMode = "buy_object";
            CurrentPlayer.TypePurchasedObject = type;
            CurrentPlayer.PurchasedObject = prefab;
            print("bought");
        }
        else
        {
            print("insufficient money");
        }
    }

    public void BuyTurretButton()
    {
        Object turret = new Turret(CurrentPlayer.CurrentPlayerNumber, new Point(0, 1));
        BuyButton(turret, _turretPrefab);
    } 
    
    public void BuyBlockButton()
    {
        Object block = new Block(CurrentPlayer.CurrentPlayerNumber);
        BuyButton(block, _blockPrefab);
    }

    public void BuyRocketButton()
    {
        Player player = PlayersContainer.Players[CurrentPlayer.CurrentPlayerNumber];

        if (player.CountCoins >= 0)
        {
            CurrentPlayer.OperatingMode = "rocket_attack";
            print("bought!");
        } 
        else
        {
            CurrentPlayer.OperatingMode = "expectation";
            print("insufficient money");
        }
    }
}
