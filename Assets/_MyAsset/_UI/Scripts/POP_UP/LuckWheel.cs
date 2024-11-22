using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class LuckWheel : UICanvas
{
    [SerializeField] private float rotationSpeed = 1f; // Thời gian quay
    [SerializeField] private int totalRounds = 20; // Số vòng quay
    [SerializeField] private int numberOfSegments = 8; // Số ô trên vòng quay
    public RectTransform wheel;
    public Button spinButton;
    public Button backButton;
    void Start()
    {
        spinButton.onClick?.AddListener(RotateWithRandomStop);
        backButton.onClick?.AddListener(CloseWheel);
    }

    void RotateWithRandomStop()
    {
        // Tính góc ngẫu nhiên dừng (phần thưởng)
        float segmentAngle = 360f / numberOfSegments; // Góc mỗi ô
        float randomAngle = Random.Range(0, numberOfSegments) * segmentAngle; // Dừng tại ô ngẫu nhiên

        // Tổng góc quay (số vòng quay cố định + vị trí dừng ngẫu nhiên)
        float totalAngle = 360f * totalRounds + randomAngle;

        // Xoay vòng quay
        wheel.DORotate(new Vector3(0, 0, -totalAngle), rotationSpeed, RotateMode.FastBeyond360)
                 .SetEase(Ease.OutQuad) // Chậm dần đều khi kết thúc
                 .OnComplete(() => Debug.Log($"Dừng tại góc: {randomAngle} độ"));
    }
    public void CloseWheel()
    {
        UIManager.Ins.OpenUI<MainMenu_UI>();
        UIManager.Ins.CloseUI<LuckWheel>();
    }
}
