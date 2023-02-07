using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Manager_Intro : MonoBehaviour
{
    [SerializeField] float waitingTime = 2;
    private float timer;
    private void OnEnable()
    {
        timer = waitingTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Main_Game_Manager.instance.ChangeToScene("InitialMenu");
        }
    }
}
