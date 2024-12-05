using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Rotate3D : MonoBehaviour
{
    [SerializeField] private ButtonPlayerShop buttonPlayer;
    public float smooth = 20f;
    private float rotationSpeed = 25f;      // Tốc độ xoay model
    private float inertiaDamping = 5f;     // Lực cản giảm tốc độ xoay
    public float maxRotationSpeed = 100f;   // Tốc độ xoay tối đa khi nhả tay ra

    private float currentRotationSpeed;   // Tốc độ xoay hiện tại
    private bool isDragging;              // Kiểm tra nếu người chơi đang kéo
    private Vector3 lastMousePosition;    // Lưu vị trí chuột cuối cùng khi bắt đầu kéo

    private bool isMouseDown;

    private Coroutine rotate3D;

    private void OnValidate()
    {
        buttonPlayer = GetComponent<ButtonPlayerShop>();
    }

    private void OnEnable()
    {
        rotate3D = StartCoroutine(TouchModel());
    }

    IEnumerator TouchModel()
    {
        while (true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                if (IsTouchOnUI())
                {
                    yield return null;
                    continue;
                }
                isMouseDown = true;
                buttonPlayer.isTouch = true;
                buttonPlayer.spawnPoint.enabled = false;
                if (buttonPlayer.player.currentSkin != null)
                {
                    buttonPlayer.player.currentSkin.GetComponent<Animator>().SetTrigger(Const.idleAnim);
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDown = false;
            }

            // Kiểm tra nếu người chơi giữ nút chuột trái
            if (Input.GetMouseButton(0) && isMouseDown)
            {
                // Nếu bắt đầu kéo chuột, lưu lại vị trí chuột ban đầu
                if (!isDragging)
                {
                    isDragging = true;
                    lastMousePosition = Input.mousePosition; // Lưu vị trí chuột ban đầu
                }

                // Tính toán delta position giữa vị trí chuột hiện tại và lần cuối
                Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
                lastMousePosition = Input.mousePosition; // Cập nhật vị trí chuột mới

                // Chỉ lấy giá trị delta theo trục X để xoay model
                float deltaX = mouseDelta.x;

                // Cập nhật tốc độ xoay dựa trên delta position
                //currentRotationSpeed = deltaX * rotationSpeed;    // old
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, deltaX * rotationSpeed, smooth * Time.deltaTime);
                // Xoay model quanh trục Y
                buttonPlayer.spawnRect.Rotate(Vector3.up, -currentRotationSpeed * Time.deltaTime);

            }
            else
            {
                // Ngừng kéo chuột
                isDragging = false;
                buttonPlayer.isTouch = false;
                buttonPlayer.spawnPoint.enabled = true;
            }

            // Nếu người chơi thả chuột, dần giảm tốc độ xoay (quán tính)
            if (!isDragging && currentRotationSpeed != 0)
            {
                // Giới hạn tốc độ xoay tối đa khi nhả tay ra
                currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, -maxRotationSpeed, maxRotationSpeed);

                // Giảm tốc độ xoay dần dần theo thời gian (quán tính)
                currentRotationSpeed = Mathf.Lerp(currentRotationSpeed, 0, inertiaDamping * Time.deltaTime);

                // Xoay model quanh trục Y
                buttonPlayer.spawnRect.Rotate(Vector3.up, -currentRotationSpeed * Time.deltaTime);
                //ResetRotationY();
            }
            yield return null;
        }

    }

    public void ResetRotationY()
    {
        // Lấy rotation hiện tại và chỉ thay đổi trục Y
        Vector3 currentRotation = buttonPlayer.spawnRect.eulerAngles;

        // Đặt trục Y về giá trị 30f
        buttonPlayer.spawnRect.eulerAngles = new Vector3(currentRotation.x, 34f, currentRotation.z);
    }

    // Hàm kiểm tra xem touch có đang chạm vào UI không
    private bool IsTouchOverUI(Touch touch)
    {
        return EventSystem.current.IsPointerOverGameObject(touch.fingerId);
    }
    private bool IsTouchOnUI()
    {
        // Kiểm tra trên thiết bị cảm ứng
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Kiểm tra nếu touch đang chạm vào UI
            if (IsTouchOverUI(touch))
            {
                return true;
            }
        }
        return false;
    }

    private void OnDisable()
    {
        StopCoroutine(rotate3D);
    }
}
