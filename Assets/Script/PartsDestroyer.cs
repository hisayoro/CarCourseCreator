using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsDestroyer : MonoBehaviour
{
    private bool isSelected = false;
    private PartsGenerator partsGenerator;


    // Start is called before the first frame update
    void Start()
    {
        partsGenerator =FindAnyObjectByType<PartsGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //���C���쐬
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); RaycastHit hit;

            // ���C�L���X�g�����s���ăI�u�W�F�N�g�����o
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    isSelected = true;
                    DestroyObject();
                }
                else
                {
                    isSelected = false;
                }
            }
        }
        
        if (this.transform.position.y < -30)
        {
            Destroy(this.gameObject);

            if (partsGenerator != null)
            {
                partsGenerator.carAmount++;
            }
        }
    }
    void DestroyObject()
    {
        if (isSelected && this.gameObject.name == "carPrefab(Clone)")
        {
            Destroy(this.gameObject);

            if (partsGenerator != null)
            {
                partsGenerator.carAmount++;
            }
        }

        else if (isSelected && this.gameObject.name == "StraightPrefab(Clone)")
        {
            Destroy(this.gameObject);

            if(partsGenerator != null)
            {
                partsGenerator.straightAmount++;
            }
        }

        else if (isSelected && this.gameObject.name == "CurvePrefab(Clone)")
        {
            Destroy(this.gameObject);

            if (partsGenerator != null)
            {
                partsGenerator.curveAmount++;
            }
        }
    }
}
