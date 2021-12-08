using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pivotObject;
    public float rotationSpeed;
    public Vector3 axis;
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        if (pivotObject != null)
            transform.RotateAround(pivotObject.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
