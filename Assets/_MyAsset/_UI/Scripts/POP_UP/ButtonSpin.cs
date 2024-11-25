using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // Thời gian quay
    [SerializeField] private int totalRounds; // Số vòng quay
    [SerializeField] private int numberOfSegments = 8; // Số ô trên vòng quay
    [SerializeField] private GameObject spinObject;
    [SerializeField] private GameObject timeCD;

    public float timeHours;
    public Text timerText; // Text UI để hiển thị thời gian
    private DateTime targetTime; // Thời gian kết thúc
    private TimeSpan timeRemaining; // Thời gian còn lại


    public RectTransform wheel;
    public Button spinButton;

    private bool isSpin;

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("TargetTime"))
        {
            // Lấy chuỗi đã lưu và chuyển lại thành DateTime
            string targetTimeString = PlayerPrefs.GetString("TargetTime");
            targetTime = DateTime.Parse(targetTimeString);
        }
        else
        {
            // Nếu không có "TargetTime", khởi tạo targetTime mặc định
            targetTime = DateTime.Now;
            PlayerPrefs.SetString("TargetTime", targetTime.ToString());
        }
    }
    private void Start()
    {
        spinButton.onClick?.AddListener(RotateWithRandomStop);
        StartCoroutine(UpdateTimer());
    }

    void RotateWithRandomStop()
    {
        if (!isSpin)
        {
            isSpin = true;
            // Tính góc mỗi ô
            float segmentAngle = 360f / numberOfSegments;

            // Chọn ô ngẫu nhiên
            int randomSegment = UnityEngine.Random.Range(0, numberOfSegments);

            // Tính góc bắt đầu và kết thúc của ô
            float startAngle = randomSegment * segmentAngle;
            float endAngle = startAngle + segmentAngle;

            // Chọn một góc ngẫu nhiên bên trong ô
            float randomAngle = UnityEngine.Random.Range(startAngle, endAngle);

            // Tổng góc quay (số vòng quay cố định + vị trí dừng ngẫu nhiên)
            float totalAngle = 360f * totalRounds + randomAngle;

            targetTime = DateTime.Now.AddHours(timeHours);
            PlayerPrefs.SetString("TargetTime", targetTime.ToString());

            // Xoay vòng quay
            wheel.DORotate(new Vector3(0, 0, -totalAngle), rotationSpeed, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad) // Chậm dần đều khi kết thúc
                .OnComplete(() =>
                {
                    isSpin = false;
                    foreach (BaseGift gift in GiftManager.Ins.gifts)
                    {
                        if (gift.prizeSegment == randomSegment)
                        {
                            gift.GetPrize();
                        }
                    }
                    Debug.Log($"Dừng tại góc: {randomAngle} độ, ô: {randomSegment + 1}");
                });
        }
    }
    private IEnumerator UpdateTimer()
    {
        while (PlayerPrefs.HasKey("TargetTime"))
        {
            // Tính thời gian còn lại
            timeRemaining = targetTime - DateTime.Now;

            if (timeRemaining.TotalSeconds > 0)
            {
                // Hiển thị thời gian còn lại
                timerText.text = string.Format("After: {0:D2}:{1:D2}:{2:D2}",
                                               timeRemaining.Hours,
                                               timeRemaining.Minutes,
                                               timeRemaining.Seconds);
                spinObject.SetActive(false);
                timeCD.SetActive(true);
            }
            else 
            {
                // Khi hết thời gian
                //timerText.enabled = false;
                spinObject.SetActive(true);
                timeCD.SetActive(false);
            }
            PlayerPrefs.SetString("TargetTime", targetTime.ToString());
            yield return new WaitForSeconds(1f);
        }
    }
}
