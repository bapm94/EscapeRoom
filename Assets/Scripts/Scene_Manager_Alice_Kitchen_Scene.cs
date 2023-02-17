using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager_Alice_Kitchen_Scene : MonoBehaviour
{

    private bool sceneCompleted = false;
    public bool SceneCompleted { get => sceneCompleted; }
    // Start is called before the first frame update
    void Start()
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
