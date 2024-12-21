using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cameraParent; // �J�����̐e�I�u�W�F�N�g
    public float rotationSpeed = 50f; // ��]���x

    void Update()
    {
        // �}�E�X�̓��͂��擾
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        // �J�����̐e�I�u�W�F�N�g����]������
        cameraParent.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime, Space.World);
        cameraParent.Rotate(Vector3.right, -verticalInput * rotationSpeed * Time.deltaTime, Space.Self);
    }
}