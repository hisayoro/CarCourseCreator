using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCameraController : MonoBehaviour
{
    private float moveSpeed = 0.1f;
    private float rotSpeed = 5.8f;
    private float rotRadi = 200f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0,200,-200);
        this.transform.rotation = Quaternion.Euler(new Vector3(45, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3 (rotRadi * Mathf.Sin(Time.time * moveSpeed),200, -rotRadi * Mathf.Cos(Time.time * moveSpeed));
        this.transform.Rotate(0, - rotSpeed*Time.deltaTime, 0, Space.World);
    }
}
