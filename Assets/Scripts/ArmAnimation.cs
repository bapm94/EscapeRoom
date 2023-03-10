using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArmAnimation : MonoBehaviour
{
    Animator animator;

    [SerializeField] int valueTest;
    public GameObject[] objects;
    public string[] animationNames;
    
    public static ArmAnimation instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) { ArmAnimation.instance = this; }
        else { Destroy(this); }

        animator = GetComponent<Animator>();
    }

    //private void Update()
    //{
    //    if (Keyboard.current.fKey.wasPressedThisFrame)
    //    {
    //        PlayInventoryItemAnimation(valueTest);
    //    }
    //    if (Keyboard.current.gKey.wasPressedThisFrame)
    //    {
    //        PlayArmAwayAnimation();
    //    }

    //    if (Keyboard.current.hKey.wasPressedThisFrame)
    //    {
    //        valueTest++;
    //    }
    //}

    /// <summary>
    /// 0 Bottle, 1 Cherrapple, 2 Cherrapple seed, 3 Faucet, 4 Mandrake, 5 Pot, 6 Sugar
    /// </summary>
    /// <param name="item"></param>
    public void PlayInventoryItemAnimation(string objectName)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].name == objectName)
            {
                objects[i].SetActive(true);
                animator.Play(animationNames[i], 1);
                animator.Play("ArmOut", 0);
            }
        }


        //for (int i = 0; i < objects.Length; i++)
        //{ 
        //    if (i != item) { objects[i].SetActive(false); }
        //    else { objects[i].SetActive(true); }
        //}

    }

    public void PlayArmAwayAnimation()
    {
        animator.SetTrigger("Out");
    }
}
