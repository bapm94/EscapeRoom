using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVisibilityTest : MonoBehaviour
{
    //MeshRenderer _renderer;
    // Start is called before the first frame update

    GameObject obj;
    Collider objCollider;

    Camera cam;
    Plane[] planes = new Plane[6];


    void Start()
    {
        cam = Camera.main;
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        objCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            Debug.Log(gameObject.name + " has been detected!");
        }
        else
        {
            Debug.Log("Nothing has been detected");
        }
    }
}
