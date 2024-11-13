using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_type
{
    Cup,
    IceCream,
    Lid
}

public enum ListAction
{
    ChangeAnim,
    GameRun,
    SpawnObject,
    FinishGame,
    Vibrate,
    IncreaseMoney,
    ShowCoffee,
    ShowIceCream,
    ShowLidCup
}

public class Const
{
    //String Anim
    public const string runAnim = "Run";
    public const string victoryAnim = "Victory";

    //String Tag
    public const string playerTag = "Player";
    public const string cupTag = "Cup";
}
