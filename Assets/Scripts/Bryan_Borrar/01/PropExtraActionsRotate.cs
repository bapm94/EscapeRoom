using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PropExtraActionsRotate : ExtraActionsTemplate
{
    [SerializeField] float angleAmount;
    [SerializeField] bool rotationAxisY = true;
    [SerializeField] bool rotationAxisX = false;
    [SerializeField] bool rotationAxisZ = false;
    [SerializeField] GameObject water;
    [SerializeField] GameObject drinkMeBottle;
    [SerializeField] GameObject potMision;
    public Vector3 originalAngle { get; set; }
    

    // Start is called before the first frame update
    void Start()
    {
        originalAngle = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ExtraAction()
    {
        originalAngle = GetDefaultPos();
        if (rotationAxisY)
        {
            
            float angle = angleAmount + transform.localEulerAngles.y;
            if (angle > originalAngle.y + angleAmount)
            {
                angle = originalAngle.y;
                water.SetActive(false);
            }
            else { water.SetActive(true); OnActivatingWater(); }
            LeanTween.rotateLocal(gameObject, Vector3.up * angle, 1);
        }
        else if (rotationAxisX)
        {
            float angle = angleAmount + transform.localEulerAngles.x;
            if (angle > originalAngle.x + angleAmount)
            {
                angle = originalAngle.x; 
                water.SetActive(false);
            }
            else { water.SetActive(true); OnActivatingWater(); }
            LeanTween.rotateLocal(gameObject, Vector3.right * angle, 1);
            
        }
        else if (rotationAxisZ)
        {
            float angle = angleAmount + transform.localEulerAngles.z;
            if (angle > originalAngle.z + angleAmount)
            {
                angle = originalAngle.z;
                water.SetActive(false);
            }
            else { water.SetActive(true); OnActivatingWater(); }
            LeanTween.rotateLocal(gameObject, Vector3.forward * angle, 1);
            //Debug.Log("should rotate " + angle + " angles");
        }
        
        void OnActivatingWater()
        {
            if (drinkMeBottle != null && drinkMeBottle.GetComponent<PropGrabable>().restored)
            {
                drinkMeBottle.TryGetComponent<TakeOffCap>(out TakeOffCap script);
                script.isFilled = true;
                potMision.SetActive(true);
                Debug.Log("You've filled the botlle");

            }
        }
    }
}
