using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bob_Controller : MonoBehaviour
{
    private Controlls _controls;
    public CinemachineVirtualCamera playerCam;
    public Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        _controls = new Controlls();
        _controls.CharacterControl.Enable();
    }


    public void HeadBob()
    {
        movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime;
        if (Mathf.Abs(movement.normalized.x) > 0 || Mathf.Abs(movement.normalized.y) > 0) { playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 1; }
        else { playerCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0; }
    }
}
