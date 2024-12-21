using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cameraParent; // カメラの親オブジェクト
    public float rotationSpeed = 50f; // 回転速度

    void Update()
    {
        // マウスの入力を取得
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        // カメラの親オブジェクトを回転させる
        cameraParent.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        cameraParent.Rotate(Vector3.right, -verticalInput * rotationSpeed * Time.deltaTime, Space.Self);
    }
}