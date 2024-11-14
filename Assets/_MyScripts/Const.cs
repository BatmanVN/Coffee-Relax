using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_type
{
    Cup,
    IceCream,
    Lid,
    ice7Color
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
    ShowLidCup,
    ShowIce7,
    SpawnPlayer
}
public enum UiAction
{
    DestroySkin
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
