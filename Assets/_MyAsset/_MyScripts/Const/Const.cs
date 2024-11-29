
using System.Collections.Generic;

public class Const
{
    //String player Anim
    public const string idleAnim = "Idle";
    public const string walkAnim = "Walk";
    public const string runAnim = "Run";
    public const string flyAnim = "Fly";
    public const string victoryAnim = "Victory";
    public const string byeAnim = "Bye";
    public const string walkModelAnim = "WalkModel";
    public const string flyIdleAnim = "FlyIdle";
    public const string reiAnim = "Rei";
    public const string thinkAnim = "Think";
    public const string cuteAnim = "Cute";
    public const string angryAnim = "Angry";
    public const string cryAnim = "Cry";
    public const string stunAnim = "Stun";

    //String trap anim
    public const string throwTrapAnim = "Disable";
    public const string crashTrapAnim = "Crash";

    //Anim Duba Traps
    public const string wakeAnim = "Wake";

    //String Tag
    public const string playerTag = "Player";
    public const string cupTag = "Cup";
    public const string cupMapTag = "CupMap";
    public const string cupSellTag = "CupSell";
    public const string groundTag = "Ground";
    public const string bonusStage = "Bonus Stage";
    public const string thornTag = "ThornObstacle";


    //Layer Camera
    public const string canSee = "Obstacle";
    public const string cantSee = "IgnoreCamera";
}

public class ConstDanceAnim
{
    public const string waveHiphop = "WaveHH";
    public const string danceAnim = "Dance";
    public const string hiphopDance = "HHDance";
    public const string dance1Anim = "Dance1";
    public const string snakeDance = "SnakeDance";
    public const string swingDance = "SwingDance";
    public const string maraschinoDance = "Maraschino";
    public const string twerkAnim = "Victory";

    public static readonly List<string> DanceList = new List<string>
    {
        waveHiphop,
        danceAnim,
        hiphopDance,
        dance1Anim,
        snakeDance,
        swingDance,
        maraschinoDance,
        twerkAnim
    };
}