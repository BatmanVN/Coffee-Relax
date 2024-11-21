using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : UICanvas
{
    public Image progressBar; // Gán hình ảnh sử dụng Fill Amount
    public float duration = 5f; // Thời gian tăng từ 0.1 đến 1
    private float targetFill = 1f;

    private Coroutine switchUi;
    private void OnEnable()
    {
        FillAndLoadScene();
        Observer.AddObserver(UiAction.MenuLoading, MenuToLoading);
        Observer.AddObserver(UiAction.WinLoading, WinToLoading);
    }

    private void FillAndLoadScene()
    {
        progressBar.fillAmount = 0.1f;
        StartCoroutine(FillProgressBar());
    }

    private IEnumerator FillProgressBar()
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = Mathf.Lerp(0.1f, targetFill, elapsedTime / duration);
            UIManager.Ins.CloseUI<Win_UI>();
            yield return null;
        }
    }

    private void WinToLoading(object[] datas)
    {
        switchUi = StartCoroutine(WaitLoading());
    }

    private void MenuToLoading(object[] datas)
    {
        switchUi = StartCoroutine(WaitAndSwitch());
    }

    private IEnumerator WaitAndSwitch()
    {
        yield return new WaitUntil(() => progressBar.fillAmount == targetFill);
        Close(0);
        UIManager.Ins.OpenUI<Swipe_UI>();
        StopCoroutine(switchUi);
    }
    private IEnumerator WaitLoading()
    {
        yield return new WaitUntil(() => progressBar.fillAmount == targetFill);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StopCoroutine(switchUi);
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(UiAction.MenuLoading, MenuToLoading);
        Observer.RemoveObserver(UiAction.WinLoading, WinToLoading);
    }
}
