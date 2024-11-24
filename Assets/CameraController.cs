using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //カメラオブジェクトの取得
    private GameObject mainCamera;
    //カメラの移動速度
    private float moveAmount = 0.05f;
    //カメラの回転角度
    private int cameraRotAngle = 0;
    //ターゲットとカメラの初期位置の差分
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
        //カメラターゲットを前後左右に移動（矢印キー）
        //cameraRotAngle = 0のとき（左：-X,右：+X、前：+Z、後：-Z）
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

        //cameraRotAngle = 90のとき（左：+Z,右：-Z、前：+X、後：-X）
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

        //cameraRotAngle = 180のとき（左：+X,右：-X、前：-Z、後：+Z）
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

        //cameraRotAngle = 270のとき（左：-Z,右：+Z、前：-X、後：+X）
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

        //ターゲットに追従したカメラの位置
        this.mainCamera.transform.position = this.transform.position - new Vector3(diffX,diffY,diffZ);

        //カメラを回転（A：反時計回り、S：時計回り）
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            this.cameraRotAngle += 90;
            //360°回ったら0°に戻す
            if (cameraRotAngle == 360)
            {
                cameraRotAngle = 0;
            }
            this.mainCamera.transform.Rotate(0, 90, 0, Space.World);

        }

        //ターゲットの位置を中心としてカメラの角度に合わせてカメラを移動
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
