using UnityEngine;

public static class CurrentPlayer
{
    private static int playersCount = 2;
    public static int CurrentPlayerNumber { get; private set; } = 0;

    //==========================================================================
    public static string OperatingMode { get; set; } = "expectation";

    // "movement_chip"
    public static Movement MovementChip { get; set; } = null;

    // "buy_object"
    public static GameObject PurchasedObject { get; set; } = null;
    public static Object TypePurchasedObject { get; set; } = null;

    // "rocket_attack"

    //==========================================================================


    public static void NextPlayer()
    {
        UIManager.UpdateUI();
        CurrentPlayerNumber = (CurrentPlayerNumber + 1) % playersCount;
    }
}
