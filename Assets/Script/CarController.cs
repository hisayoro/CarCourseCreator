using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //前方向の速度
    private float velocityZ = 0;
    private bool OnOff = false;
    private bool driverView = false;

    //移動させるコンポーネントを入れる
    private GameObject carObject;

    // Update is called once per frame
    void Update()
    {
        if (carObject != null)
        {
            this.carObject.GetComponent<Rigidbody>().velocity = this.carObject.transform.TransformDirection(new Vector3(0, 0, this.velocityZ));
        }
    }

    public void EngineOnOff()
    {
        this.carObject =  GameObject.Find("CarPrefab(Clone)");

        if (carObject != null && OnOff == false)
        {
            velocityZ = 50.0f;
            this.carObject.GetComponent<Rigidbody>().useGravity = true;
            OnOff = true;
        }
        else if (carObject != null && OnOff == true)
        {
            velocityZ = 0;
            this.carObject.GetComponent<Rigidbody>().useGravity = false;
            OnOff = false;
        }
    }

    public void ViewChange()
    {
        this.carObject = GameObject.Find("CarPrefab(Clone)");
        Transform driverViewTransform = this.carObject.transform.Find("DriverView");


        if (driverViewTransform != null)
        {
            Camera driverViewCamera = driverViewTransform.GetComponent<Camera>();

            if (driverViewCamera != null && driverView == false)
            {
                driverViewCamera.enabled = true;
                driverView = true;
            }
            else if (driverViewCamera != null && driverView == true)
            {
                driverViewCamera.enabled = false;
                driverView = false;
            }
        }
        else 
        {
            return;
        }
    }
}
