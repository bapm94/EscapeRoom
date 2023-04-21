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
    [SerializeField] GameObject cherrappleSeeds;
    [SerializeField] ApearingTree tree;
    [SerializeField] GameObject finalBrewMision;

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
    public override void ExtraActionOnRestoring()
    {
        CluesController.instance.AddInsigth(10);
        CluesController.instance.ChangeClue(3);
    }
    public override void ExtraAction()
    {
        originalAngle = GetDefaultPos();
        if (rotationAxisY && water != null)
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
        else if (rotationAxisX && water != null)
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
        else if (rotationAxisZ && water != null)
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
            if (cherrappleSeeds != null && cherrappleSeeds.GetComponent<PropGrabable>().restored)
            {
                tree.gameObject.SetActive(true);
                LeanTween.delayedCall(2, ()=> tree.StartGrowingTree());
                Destroy(water, 2);
                GetComponent<PropGrabable>().enabled = false;
                gameObject.layer = 0;
                gameObject.tag = "111";
            }
            else if (drinkMeBottle != null && drinkMeBottle.GetComponent<PropGrabable>().restored)
            {
                drinkMeBottle.TryGetComponent<TakeOffCap>(out TakeOffCap script);
                drinkMeBottle.transform.parent.parent.gameObject.GetComponent<Collider>().enabled = false;
                //Change visualy the bottle so the player knows is filled

                LeanTween.delayedCall(2, () => FilledBottle(script));

                
                //Debug.Log("You've filled the botlle");
            }


            void FilledBottle(TakeOffCap script)
            {
                drinkMeBottle.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(0, 0, 1, 1);
                script.isFilled = true;
                drinkMeBottle.GetComponent<PropGrabable>().canBeCollectedAgain = true;
                potMision.SetActive(true);
                finalBrewMision.SetActive(true);
                drinkMeBottle.GetComponent<PropGrabable>().restored = false;
                water.SetActive(false);
            }
        }

    }

}
