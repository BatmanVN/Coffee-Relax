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
    SetAimmator,
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
    SpawnPlayer,
    SetCamFollow,
    NextLevel
}
public enum UiAction
{
    DestroySkin,
    GetIdSkin,
    ChangeTextCoin,
    StatusUsed,
    StatusBuy,
    UpdateUsedObject,
    //DestroyModel,
    SpawnModel,
    SetSkinEnable
}

public enum ActionInGame
{
    SpawnRoad,
    DisableRoad
}

public class Const
{
    //String Anim
    public const string runAnim = "Run";
    public const string victoryAnim = "Victory";

    //String Tag
    public const string playerTag = "Player";
    public const string cupTag = "Cup";
    public const string groundTag = "Ground";
}
