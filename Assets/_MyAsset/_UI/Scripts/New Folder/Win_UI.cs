using UnityEngine.UI;


public class Win_UI : UICanvas
{
    public Text txt_multi;
    public Text coinTextConner;
    public Button nextButton;
    public Button adsButton;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.FinishGame,show_multiplication);
        coinTextConner.text = GameControllManager.Ins.getcoin().ToString();
    }
    public void Start()
    {
        nextButton.onClick?.AddListener(btn_next);
        adsButton.onClick?.AddListener(AdsButton);
    }

    protected virtual void AdsButton()
    {
        
    }

    protected virtual void btn_next()
    {
        GameControllManager.Ins.setLevel(GameControllManager.Ins.getlevel() + 1);
        Observer.Notify(ListAction.NextLevel);
        //Observer.Notify(ActionInGame.DisableRoad);
        Close(0);
        UIManager.Ins.OpenUI<Loading>();
        Observer.Notify(UiAction.WinLoading);
    }
    protected virtual void show_multiplication(object[] datas)
    {
        if(datas == null || datas.Length < 1 || !(datas[0] is int nbr)) return;
        txt_multi.text = nbr + " �";
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.FinishGame, show_multiplication);
    }
}
