using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static ScreenSpaceOutlines;

public class Scene_Manager_Alice_Kitchen_Scene : MonoBehaviour
{

    private bool sceneCompleted = false;
    //[SerializeField] ScreenSpaceOutlines outlines;
   
    public bool SceneCompleted { get => sceneCompleted; }



    
    // Start is called before the first frame update
    //void Start()
    //{
    //    outlines.GetComponent<ScreenSpaceOutlineSettings>().outlineColor = outlineColor;
    //}
    private void Awake()
    {
        


    }
    // Update is called once per frame
    void Update()
    {

    }



    public void SetAlice1AsComplete()
    {
        sceneCompleted = true;
        Debug.Log("You completed the scene. " + "Bool Value = " + sceneCompleted);
    }


}
