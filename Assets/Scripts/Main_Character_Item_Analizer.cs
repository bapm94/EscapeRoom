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
    public GameObject analizingSpot { get; set; }
    Main_Character_Controller playerController;


    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        playerController = player.GetComponent<Main_Character_Controller>();
        analizingSpot = transform.GetChild(0).GetChild(0).gameObject;
        
    }


    public void PositioningItem(GameObject item)
    {
        targetObject = item;
        targetObject.layer = 9;
        Main_Character_Controller_v2.instance.ChangeSubmeshesLayer(targetObject, 9);
        targetsOriginalPosition = item.transform.position;      //The original transform is set
        targetsOriginalRotation = item.transform.rotation;
        targetsOriginalParent = item.transform.parent.gameObject;
        targetsOriginalScale = item.transform.localScale;
        item.transform.SetParent(analizingSpot.transform);
        item.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        
        item.TryGetComponent<Prop_Controller>(out Prop_Controller controller);
        if (controller != null)
        {
           
            item.transform.localScale = Vector3.one * controller.AnalyzingScale;

        }
        else
        {
            item.transform.localScale = Vector3.one * 1f;
        }
        
        /*item.transform.localScale = item.GetComponent<scriptObjeto>().analizingScale;*/ //Cuando se genere el item se le pondr? una escala de anbalizado
    }

    public void ReturnItem()
    {
        if (targetsOriginalParent != null)
        {
            targetObject.TryGetComponent<ExtraActionsTemplate>(out ExtraActionsTemplate extraActions);
            if (extraActions != null) { extraActions.ExtraActionOnStopAnalizing(); }
            targetObject.layer = 6;
            Main_Character_Controller_v2.instance.ChangeSubmeshesLayer(targetObject, 6);
            targetObject.transform.SetParent(targetsOriginalParent.transform);
            targetObject.transform.SetPositionAndRotation(targetsOriginalPosition, targetsOriginalRotation);
            targetObject.transform.localScale = targetsOriginalScale;
            targetObject.GetComponent<PropAnalizable>().isBeingAnalized = false;
        } 
    }
}
