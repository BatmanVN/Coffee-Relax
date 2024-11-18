using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_type
{
    Cup,
    Coffee,
    IceCream,
    Lid,
    ice7Color,
    Milk
    //LidCream
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
    public const string idleAnim = "Idle";
    public const string runAnim = "Run";
    public const string victoryAnim = "Victory";

    //String Tag
    public const string playerTag = "Player";
    public const string cupTag = "Cup";
    public const string groundTag = "Ground";
    public const string bonusStage = "Bonus Stage";
    public const string thornTag = "ThornObstacle";
}
