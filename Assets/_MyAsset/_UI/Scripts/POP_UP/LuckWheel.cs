using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class LuckWheel : UICanvas
{
    [SerializeField] private float rotationSpeed; // Thời gian quay
    [SerializeField] private int totalRounds = 20; // Số vòng quay
    [SerializeField] private int numberOfSegments = 8; // Số ô trên vòng quay
    public RectTransform wheel;
    public Button spinButton;
    public Button backButton;
    private bool isSpin;
    void Start()
    {
        spinButton.onClick?.AddListener(RotateWithRandomStop);
        backButton.onClick?.AddListener(CloseWheel);
    }

    void RotateWithRandomStop()
    {
        if (!isSpin)
        {
            // Tính góc mỗi ô
            float segmentAngle = 360f / numberOfSegments;

            // Chọn ô ngẫu nhiên
            int randomSegment = Random.Range(0, numberOfSegments);

            // Tính góc bắt đầu và kết thúc của ô
            float startAngle = randomSegment * segmentAngle;
            float endAngle = startAngle + segmentAngle;

            // Chọn một góc ngẫu nhiên bên trong ô
            float randomAngle = Random.Range(startAngle, endAngle);

            // Tổng góc quay (số vòng quay cố định + vị trí dừng ngẫu nhiên)
            float totalAngle = 360f * totalRounds + randomAngle;

            // Xoay vòng quay
            wheel.DORotate(new Vector3(0, 0, -totalAngle), rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad) // Chậm dần đều khi kết thúc
                .OnComplete(() =>
                {
                    isSpin = true;
                    Debug.Log($"Dừng tại góc: {randomAngle} độ, ô: {randomSegment + 1}");
                });
        }
    }
    public void CloseWheel()
    {
        UIManager.Ins.OpenUI<MainMenu_UI>();
        UIManager.Ins.CloseUI<LuckWheel>();
    }
}
