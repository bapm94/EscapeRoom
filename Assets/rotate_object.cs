using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_object : MonoBehaviour
{
    [SerializeField] float rotateSpeed;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(new Vector3(0, rotateSpeed, 0));
    }
}
