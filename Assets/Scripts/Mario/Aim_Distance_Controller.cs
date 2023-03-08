using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim_Distance_Controller : MonoBehaviour
{
    public List<GameObject> props = new List<GameObject>();
    float distance = 1000.0f;
    [SerializeField] GameObject nearestGO;
    Camera cam;
    public Image crosshair;
    Color colorAlpha;

    private void Start()
    {
        //var propList = FindObjectsOfType<Prop>();
        //props = new GameObject[propList.Length];
        //for(int i = 0; i < propList.Length; i++)
        //{
        //    props[i] = propList[i].gameObject;
        //}
        colorAlpha = crosshair.color;
        cam = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<Prop>(out Prop p);
        if (p != null) { if (!props.Contains(p.gameObject)) { props.Add(p.gameObject); } }
    }

    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent<Prop> (out Prop p);
        if (p != null) { props.Remove(p.gameObject); if (other.gameObject == nearestGO) { distance = 1000.0f; nearestGO = null; } }
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestGO == null)
        {
            colorAlpha.a = 0.0f;
        }

        foreach (GameObject g in props)
        {
            var gDistanceV2 = new Vector2(cam.WorldToViewportPoint(g.transform.position).x, cam.WorldToViewportPoint(g.transform.position).y);
            var tDistanceV2 = new Vector2(cam.WorldToViewportPoint(transform.position).x, cam.WorldToViewportPoint(transform.position).y);
            var gDistance = (gDistanceV2 - tDistanceV2).magnitude;
            if (gDistance < distance) { distance = gDistance; nearestGO = g; }

            colorAlpha.a = Mathf.Abs(1.0f - gDistance * 2);

            Debug.Log(colorAlpha.a + " ALPHA VALUE");

            if (nearestGO != null) { Debug.Log(nearestGO.name + " || Distance: " + gDistance); }
        }

        crosshair.color = colorAlpha;
    }
}
