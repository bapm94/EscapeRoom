using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sensibility : MonoBehaviour
{
    [SerializeField] Slider movementSlider;
    [SerializeField] Slider cameraSlider;
    public GameObject settingsMenu;
    public float movementSpeed; //Values should come from actual movement speed
    public float cameraSpeed; //Values should come from actual camera speed

    void Update()
    {
        if (settingsMenu.activeSelf == true)
        {
            movementSpeed = movementSlider.value;
            cameraSpeed = cameraSlider.value;
        }
    }
}
