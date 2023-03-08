using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim_Distance_Controller : MonoBehaviour
{
    public GameObject distanceChecker;
    [SerializeField] float offset;

    // Update is called once per frame
    void Update()
    {
        distanceChecker.transform.position = transform.position + transform.forward * offset;
        distanceChecker.transform.rotation = new Quaternion(0.0f, transform.rotation.y, 0.0f, transform.rotation.w);
    }
}
