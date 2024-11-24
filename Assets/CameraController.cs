using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //�J�����I�u�W�F�N�g�̎擾
    private GameObject mainCamera;
    //�J�����̈ړ����x
    private float moveAmount = 0.05f;
    //�J�����̉�]�p�x
    private int cameraRotAngle = 0;
    //�^�[�Q�b�g�ƃJ�����̏����ʒu�̍���
    private float diffX;
    private float diffY;
    private float diffZ;

    // Start is called before the first frame update
    void Start()
    {
        this.mainCamera = GameObject.Find("Main Camera");
        this.diffX = transform.position.x - mainCamera.transform.position.x;
        this.diffY = transform.position.x - mainCamera.transform.position.y;
        this.diffZ = transform.position.z - mainCamera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�����^�[�Q�b�g��O�㍶�E�Ɉړ��i���L�[�j
        //cameraRotAngle = 0�̂Ƃ��i���F-X,�E�F+X�A�O�F+Z�A��F-Z�j
        if (cameraRotAngle == 0)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                this.transform.Translate(-moveAmount, 0, 0, Space.World);
            }
            else if ((Input.GetKey(KeyCode.RightArrow)))
            {
                this.transform.Translate(moveAmount, 0, 0, Space.World);
            }
            else if ((Input.GetKey(KeyCode.UpArrow)))
            {
                this.transform.Translate(0, 0, moveAmount, Space.World);
            }
            else if ((Input.GetKey(KeyCode.DownArrow)))
            {
                this.transform.Translate(0, 0, -moveAmount, Space.World);
            }
        }

        //cameraRotAngle = 90�̂Ƃ��i���F+Z,�E�F-Z�A�O�F+X�A��F-X�j
        else if (cameraRotAngle == 90)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                this.transform.Translate(0, 0, moveAmount, Space.World);
            }
            if ((Input.GetKey(KeyCode.RightArrow)))
            {
                this.transform.Translate(0, 0, -moveAmount, Space.World);
            }
            if ((Input.GetKey(KeyCode.UpArrow)))
            {
                this.transform.Translate(moveAmount, 0, 0, Space.World);
            }
            if ((Input.GetKey(KeyCode.DownArrow)))
            {
                this.transform.Translate(-moveAmount, 0, 0, Space.World);
            }
        }

        //cameraRotAngle = 180�̂Ƃ��i���F+X,�E�F-X�A�O�F-Z�A��F+Z�j
        else if (cameraRotAngle == 180)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                this.transform.Translate(moveAmount, 0, 0, Space.World);
            }
            if ((Input.GetKey(KeyCode.RightArrow)))
            {
                this.transform.Translate(-moveAmount, 0, 0, Space.World);
            }
            if ((Input.GetKey(KeyCode.UpArrow)))
            {
                this.transform.Translate(0, 0, -moveAmount, Space.World);
            }
            if ((Input.GetKey(KeyCode.DownArrow)))
            {
                this.transform.Translate(0, 0, moveAmount, Space.World);
            }
        }

        //cameraRotAngle = 270�̂Ƃ��i���F-Z,�E�F+Z�A�O�F-X�A��F+X�j
        else if (cameraRotAngle == 270)
        {
            if ((Input.GetKey(KeyCode.LeftArrow)))
            {
                this.transform.Translate(0, 0, -moveAmount, Space.World);
            }
            if ((Input.GetKey(KeyCode.RightArrow)))
            {
                this.transform.Translate(0, 0, moveAmount, Space.World);
            }
            if ((Input.GetKey(KeyCode.UpArrow)))
            {
                this.transform.Translate(-moveAmount, 0, 0, Space.World);
            }
            if ((Input.GetKey(KeyCode.DownArrow)))
            {
                this.transform.Translate(moveAmount, 0, 0, Space.World);
            }
        }

        //�^�[�Q�b�g�ɒǏ]�����J�����̈ʒu
        this.mainCamera.transform.position = this.transform.position - new Vector3(diffX,diffY,diffZ);

        //�J��������]�iA�F�����v���AS�F���v���j
        if ((Input.GetKeyDown(KeyCode.A)))
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
}
