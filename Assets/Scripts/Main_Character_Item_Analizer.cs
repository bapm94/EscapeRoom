using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Character_Item_Analizer : MonoBehaviour
{
    public GameObject targetObject { get; set; }
    Vector3 targetsOriginalPosition;
    Vector3 targetsOriginalScale;
    Quaternion targetsOriginalRotation;
    GameObject targetsOriginalParent;
    GameObject player;
    GameObject analizingSpot;
    Main_Character_Controller playerController;


    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        playerController = player.GetComponent<Main_Character_Controller>();
        analizingSpot = transform.GetChild(0).transform.GetChild(0).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PositioningItem(GameObject item)
    {
        targetObject = item;
        targetsOriginalPosition = item.transform.position;      //The original transform is set
        targetsOriginalRotation = item.transform.rotation;
        targetsOriginalParent = item.transform.parent.gameObject;
        targetsOriginalScale = item.transform.localScale;
        item.transform.SetParent(analizingSpot.transform);
        item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        item.transform.localScale = Vector3.one * 0.3f;
        /*item.transform.localScale = item.GetComponent<scriptObjeto>().analizingScale;*/ //Cuando se genere el item se le pondrá una escala de anbalizado
    }

    public void ReturnItem()
    {
        targetObject.transform.SetParent(targetsOriginalParent.transform);
        targetObject.transform.SetPositionAndRotation(targetsOriginalPosition, targetsOriginalRotation);
        targetObject.transform.localScale = targetsOriginalScale;
    }
}
