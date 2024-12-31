using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CameraController : MonoBehaviour
{
    //�J�����I�u�W�F�N�g�̎擾
    private GameObject mainCamera;
    //�J�����̈ړ����x
    private float moveAmount = 0.50f;
    //�J�����̉�]�p�x
    private int cameraRotAngle = 0;
    //�^�[�Q�b�g�ƃJ�����̏����ʒu�̍���
    private float diffX;
    private float diffY;
    private float diffZ;

    // �ړ��͈͂̐ݒ�
    private float minX = -500f; // �ړ��͈͂̍ŏ�X
    private float maxX = 500f;  // �ړ��͈͂̍ő�X
    private float minY = -70f; // �ړ��͈͂̍ŏ�Y
    private float maxY = 200f;  // �ړ��͈͂̍ő�Y
    private float minZ = -500f; // �ړ��͈͂̍ŏ�Z
    private float maxZ = 500f;  // �ړ��͈͂̍ő�Z

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera");
        this.diffX = transform.position.x - mainCamera.transform.position.x;
        this.diffY = transform.position.y - mainCamera.transform.position.y;
        this.diffZ = transform.position.z - mainCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = transform.position;

        //�J�����^�[�Q�b�g��O�㍶�E�Ɉړ��i���L�[�j�A�Y�[���C��(Z)�A�E�g(X)
        if (cameraRotAngle == 0)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                newPosition += new Vector3(-moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.RightArrow)))
            {
                newPosition += new Vector3(moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.UpArrow)))
            {
                newPosition += new Vector3(0, 0, moveAmount);
            }
            else if ((Input.GetKey(KeyCode.DownArrow)))
            {
                newPosition += new Vector3(0, 0, -moveAmount);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                newPosition += new Vector3(0, -moveAmount, moveAmount * Mathf.Tan(Mathf.PI / 4));
            }
            else if (Input.GetKey(KeyCode.X))
            {
                newPosition += new Vector3(0, moveAmount, -moveAmount * Mathf.Tan(Mathf.PI / 4));
            }
        }
        else if (cameraRotAngle == 90)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                newPosition += new Vector3(0, 0, moveAmount);
            }
            else if ((Input.GetKey(KeyCode.RightArrow)))
            {
                newPosition += new Vector3(0, 0, -moveAmount);
            }
            else if ((Input.GetKey(KeyCode.UpArrow)))
            {
                newPosition += new Vector3(moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.DownArrow)))
            {
                newPosition += new Vector3(-moveAmount, 0, 0);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                newPosition += new Vector3(moveAmount * Mathf.Tan(Mathf.PI / 4), -moveAmount, 0);
            }
            else if (Input.GetKey(KeyCode.X))
            {
                newPosition += new Vector3(-moveAmount * Mathf.Tan(Mathf.PI / 4), moveAmount, 0);
            }
        }
        else if (cameraRotAngle == 180)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                newPosition += new Vector3(moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.RightArrow)))
            {
                newPosition += new Vector3(-moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.UpArrow)))
            {
                newPosition += new Vector3(0, 0, -moveAmount);
            }
            else if ((Input.GetKey(KeyCode.DownArrow)))
            {
                newPosition += new Vector3(0, 0, moveAmount);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                newPosition += new Vector3(0, -moveAmount, -moveAmount * Mathf.Tan(Mathf.PI / 4));
            }
            else if (Input.GetKey(KeyCode.X))
            {
                newPosition += new Vector3(0, moveAmount, moveAmount * Mathf.Tan(Mathf.PI / 4));
            }
        }
        else if (cameraRotAngle == 270)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                newPosition += new Vector3(0, 0, -moveAmount);
            }
            else if ((Input.GetKey(KeyCode.RightArrow)))
            {
                newPosition += new Vector3(0, 0, moveAmount);
            }
            else if ((Input.GetKey(KeyCode.UpArrow)))
            {
                newPosition += new Vector3(-moveAmount, 0, 0);
            }
            else if ((Input.GetKey(KeyCode.DownArrow)))
            {
                newPosition += new Vector3(moveAmount, 0, 0);
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                newPosition += new Vector3(-moveAmount * Mathf.Tan(Mathf.PI / 4), -moveAmount, 0);
            }
            else if (Input.GetKey(KeyCode.X))
            {
                newPosition += new Vector3(moveAmount * Mathf.Tan(Mathf.PI / 4), moveAmount, 0);
            }
        }

        // �V�����ʒu��͈͓��ɐ���
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // �I�u�W�F�N�g�̈ʒu���X�V
        transform.position = newPosition;

        //�^�[�Q�b�g�ɒǏ]�����J�����̈ʒu
        this.mainCamera.transform.position = this.transform.position - new Vector3(diffX, diffY, diffZ);

        //�J��������]
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.cameraRotAngle += 90;
            //360���������0���ɖ߂�
            if (cameraRotAngle == 360)
            {
                cameraRotAngle = 0;
            }
            this.mainCamera.transform.Rotate(0, 90, 0, Space.World);
        }

        //�^�[�Q�b�g�̈ʒu�𒆐S�Ƃ��ăJ�����̊p�x�ɍ��킹�ăJ�������ړ�
        if (cameraRotAngle == 0)
        {
            this.mainCamera.transform.position = transform.position + new Vector3(0, -diffY, -diffZ);
        }
        else if (cameraRotAngle == 90)
        {
            this.mainCamera.transform.position = transform.position + new Vector3(-diffZ, -diffY, 0);
        }
        else if (cameraRotAngle == 180)
        {
            this.mainCamera.transform.position = transform.position + new Vector3(0, -diffY, diffZ);
        }
        else if (cameraRotAngle == 270)
        {
            this.mainCamera.transform.position = transform.position + new Vector3(diffZ, -diffY, 0);
        }
    }

    public void ViewReset()
    {
        this.transform.position = new Vector3(0, 0, 0);
        this.mainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
        this.cameraRotAngle = 0;
    }
}
