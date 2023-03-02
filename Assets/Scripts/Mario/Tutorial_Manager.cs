using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour
{
    public GameObject[] tutorialCanvas;
    public TextMeshProUGUI tutorialText;
    public bool tutorialActive1;
    public bool tutorialActive2;
    public Vector3 tempVect1;
    public GameObject wasd;
    public TextMeshProUGUI tuto2Text;
    public GameObject arrows;
    public Sprite[] rotatingSpritesWASD;
    public Sprite[] rotatingSpritesARROWS;
    int currentSprite;

    bool movedForWasd = false;
    bool lookedForArrows = false;

    private Controlls _controls;
    public Vector2 movement;
    public Vector2 rotation;

    // Start is called before the first frame update
    void Start()
    {
        _controls = new Controlls();
        _controls.CharacterControl.Enable();

        tutorialActive1 = true;
        tempVect1 = new Vector3(0, 0.175f, 0);
        tutorialText.text = "Interact with this object!";
        MoveUpTutorial1();
        RotateSprites();
        wasd.SetActive(true);
        arrows.SetActive(false);
    }

    private void Update()
    {
        movement = _controls.CharacterControl.Walk.ReadValue<Vector2>() * Time.deltaTime;
        rotation = _controls.CharacterControl.Cam_Rotation.ReadValue<Vector2>() * Time.deltaTime;
        if (!movedForWasd && (Mathf.Abs(movement.normalized.x) > 0 || Mathf.Abs(movement.normalized.y) > 0)) { movedForWasd = true; StartCoroutine(WasdCompleted()); }
        if (movedForWasd && !lookedForArrows && (Mathf.Abs(rotation.normalized.x) > 0 || Mathf.Abs(rotation.normalized.y) > 0)) { lookedForArrows = true; StartCoroutine(ArrowsCompleted()); }

        Camera camera = Camera.main;
        tutorialCanvas[0].transform.LookAt(tutorialCanvas[0].transform.position + camera.GetComponent<Camera>().transform.rotation * Vector3.forward, camera.GetComponent<Camera>().transform.rotation * Vector3.up);
    }

    #region Tutorial1
    public void MoveUpTutorial1()
    {
        LeanTween.move(tutorialCanvas[0], tutorialCanvas[0].transform.localPosition + tempVect1, 1.0f);
        Invoke("MoveDownTutorial1", 1.0f);
    }

    public void MoveDownTutorial1()
    {
        LeanTween.move(tutorialCanvas[0], tutorialCanvas[0].transform.localPosition - tempVect1, 1.0f);
        Invoke("MoveUpTutorial1", 1.0f);
    }

    public void DeactivateTutorial1()
    {
        tutorialActive1 = false;
        tutorialCanvas[0].SetActive(false);
    }
    #endregion

    #region Tutorial2
    public void RotateSprites()
    {
        wasd.GetComponent<Image>().sprite = rotatingSpritesWASD[currentSprite];
        arrows.GetComponent<Image>().sprite = rotatingSpritesARROWS[currentSprite];
        if (currentSprite < 3) { currentSprite++; }
        else { currentSprite = 0; }
        Invoke("RotateSprites", 0.66f);
    }

    IEnumerator WasdCompleted()
    {
        tuto2Text.text = "Great!";
        yield return new WaitForSeconds(1.0f);
        tuto2Text.text = "To Look!";
        wasd.SetActive(false);
        arrows.SetActive(true);
    }

    IEnumerator ArrowsCompleted()
    {
        tuto2Text.text = "Awesome!";
        yield return new WaitForSeconds(1.0f);
        arrows.SetActive(false);
        tutorialCanvas[1].SetActive(false);
    }
    
    #endregion
}
