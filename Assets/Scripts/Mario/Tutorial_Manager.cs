using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Manager : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public TextMeshProUGUI tutorialText;
    public bool tutorialActive;
    Vector3 tempVect;

    // Start is called before the first frame update
    void Start()
    {
        tutorialActive = true;
        tempVect = new Vector3(0, 10.0f, 0);
        tutorialText.text = "Interact with this object!";
        MoveUp();
    }

    public void MoveUp()
    {
        LeanTween.moveLocal(tutorialCanvas, tutorialCanvas.transform.up + tempVect, 1.0f);
        Invoke("MoveDown", 1.0f);
    }

    public void MoveDown()
    {
        LeanTween.moveLocal(tutorialCanvas, tutorialCanvas.transform.up - tempVect, 1.0f);
        Invoke("MoveUp", 1.0f);
    }

    private void Update()
    {
        Camera camera = Camera.main;
        tutorialCanvas.transform.LookAt(tutorialCanvas.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }

    public void Deactivate()
    {
        tutorialActive = false;
        tutorialCanvas.SetActive(false);
    }
}
