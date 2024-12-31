using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //�O�����̑��x
    private float velocityZ = 0;
    private bool OnOff = false;
    private bool driverView = false;

    //�ړ�������R���|�[�l���g������
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
            velocityZ = 30.0f;
            //�d�͂�ON�ɂ���
            this.carObject.GetComponent<Rigidbody>().useGravity = true;
            //Constraints��Rotation��XYZ���ׂĉ�������
            //this.carObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            this.carObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

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
