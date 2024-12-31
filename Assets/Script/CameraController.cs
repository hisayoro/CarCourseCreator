using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class CameraController : MonoBehaviour
{
    //カメラオブジェクトの取得
    private GameObject mainCamera;
    //カメラの移動速度
    private float moveAmount = 0.50f;
    //カメラの回転角度
    private int cameraRotAngle = 0;
    //ターゲットとカメラの初期位置の差分
    private float diffX;
    private float diffY;
    private float diffZ;

    // 移動範囲の設定
    private float minX = -500f; // 移動範囲の最小X
    private float maxX = 500f;  // 移動範囲の最大X
    private float minY = -70f; // 移動範囲の最小Y
    private float maxY = 200f;  // 移動範囲の最大Y
    private float minZ = -500f; // 移動範囲の最小Z
    private float maxZ = 500f;  // 移動範囲の最大Z

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

        //カメラターゲットを前後左右に移動（矢印キー）、ズームイン(Z)アウト(X)
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

        // 新しい位置を範囲内に制限
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // オブジェクトの位置を更新
        transform.position = newPosition;

        //ターゲットに追従したカメラの位置
        this.mainCamera.transform.position = this.transform.position - new Vector3(diffX, diffY, diffZ);

        //カメラを回転
        if (Input.GetKeyDown(KeyCode.A))
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

    public void ViewReset()
    {
        this.transform.position = new Vector3(0, 0, 0);
        this.mainCamera.transform.localEulerAngles = new Vector3(45, 0, 0);
        this.cameraRotAngle = 0;
    }
}
