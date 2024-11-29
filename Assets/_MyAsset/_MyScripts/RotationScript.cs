using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RotationAxis
{
    X,
    Y,
    Z
}
public class RotationScript : MonoBehaviour
{

    public RotationAxis rotationAxis = RotationAxis.Y;
    public float rotationSpeed = 50.0f;
    public float duration = 5.0f; // Thời gian quay mỗi lần

    void Start()
    {
        // Bắt đầu Coroutine để quay đối tượng
        StartCoroutine(RotateCoroutine());
    }

    private IEnumerator RotateCoroutine()
    {
        // Thực hiện quay trong khoảng thời gian duration
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float rotationValue = rotationSpeed * Time.deltaTime;

            Vector3 axis = Vector3.zero;
            switch (rotationAxis)
            {
                case RotationAxis.X:
                    axis = Vector3.right;
                    break;
                case RotationAxis.Y:
                    axis = Vector3.up;
                    break;
                case RotationAxis.Z:
                    axis = Vector3.forward;
                    break;
            }

            transform.Rotate(axis, rotationValue);
            elapsedTime += Time.deltaTime;

            yield return null; // Chờ đến frame tiếp theo
        }
    }
}

