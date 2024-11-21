using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_type
{
    Cup,
    Coffee,
    IceCream,
    LidCoffee,
    ice7Color,
    Milk,
    LidMilk
    //LidCream
}

public enum ListAction
{
    SetAimmator,
    ChangeAnim,
    GameRun,
    GetPrefabCupID,
    SpawnObject,
    SpawnCupIns,
    FinishGame,
    Vibrate,
    IncreaseMoney,
    SetUpCupTypes,
    ShowIce7,
    SpawnPlayer,
    SetCamFollow,
    NextLevel,
    EndRoad,
    FinishMove
}
public enum UiAction
{
    DestroySkin,
    GetIdSkin,
    GetIdSkinCup,
    ChangeTextCoin,
    StatusUsed,
    StatusBuy,
    UpdateUsedObject,
    SpawnModel,
    SetSkinEnable,
    GetCoinReward,
    MenuLoading,
    WinLoading
}

public enum ActionInGame
{
    SpawnRoad,
    DisableRoad
}

public class Const
{
    //String player Anim
    public const string idleAnim = "Idle";
    public const string walkAnim = "Walk";
    public const string runAnim = "Run";
    public const string victoryAnim = "Victory";
    public const string byeAnim = "Bye";

    //String trap anim
    public const string throwTrapAnim = "Disable";
    public const string crashTrapAnim = "Crash";

    //String Tag
    public const string playerTag = "Player";
    public const string cupTag = "Cup";
    public const string groundTag = "Ground";
    public const string bonusStage = "Bonus Stage";
    public const string thornTag = "ThornObstacle";
}
