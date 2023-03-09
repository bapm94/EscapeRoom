using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Sensibility : MonoBehaviour
{
    [SerializeField] Slider movementSlider;
    [SerializeField] Slider cameraSlider;
    public GameObject settingsMenu;
    //public float movementSpeed; //Values should come from actual movement speed
    //public float cameraSpeed; //Values should come from actual camera speed

    void Update()
    {
        if (settingsMenu.activeSelf == true && SceneManager.GetActiveScene().name != "InitialMenu")
        {
            //movementSpeed = movementSlider.value;
            //cameraSpeed = cameraSlider.value;

            Main_Character_Controller_v2.instance.walkSpeed = movementSlider.value * 2 + 2;
            Main_Character_Controller_v2.instance.turnSpeed = cameraSlider.value * 2 + 2;
        }
    }
}
