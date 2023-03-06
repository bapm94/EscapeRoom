using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bob_Controller : MonoBehaviour
{
    private Controlls _controls;
    public CinemachineVirtualCamera playerCam;
    public Vector2 movement;
    public bool canBob;
    public AudioSource[] footsteps;
    int doesSfx;

    public static Bob_Controller instance;

    // Start is called before the first frame update
    void Start()
    {
        canBob = true;
        if (instance == null) { Bob_Controller.instance = this; }
        else { Destroy(this); }

        _controls = new Controlls();
        _controls.CharacterControl.Enable();
    }


    public void HeadBob()
    {
        if (canBob)
        {
            movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime;
            if (Mathf.Abs(movement.normalized.x) > 0 || Mathf.Abs(movement.normalized.y) > 0) 
            {
                playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1;
                doesSfx++;
                if (doesSfx > 24) { footsteps[Random.Range(0, 2)].Play(); doesSfx = 0; }
            }
            else { playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0; }
        }
        else { playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0; }   
    }

    public void cantBob()
    {
        if (canBob) { canBob = false; }
        else { canBob = true; }
        HeadBob();
    }
}
