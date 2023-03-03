using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBeamsBones : MonoBehaviour
{
    [SerializeField] float rotationTime = 0.5f;
    bool rotating = false;
    [Range(0,9)]
    [SerializeField] int victoryCondition;
    [SerializeField] PropCodePuzzle codePuzzleParent;
    // Start is called before the first frame update

    private void Start()
    {
        
        if (victoryCondition == 0)
        {
            gameObject.GetComponent<RotationOnDrag>().victory = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate(bool x)
    {
        
        if (!rotating)
        {
            victoryCondition = victoryCondition * 36;
            Debug.Log("Rotate");
            Vector3 newRotation = Vector3.one;
            rotating = true;
            LeanTween.delayedCall(rotationTime + 0.01f, () => rotating = false);
            if (x)
            {

                newRotation = Vector3.up * (transform.localEulerAngles.y - 36);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }
            else
            {
                newRotation = Vector3.up * (transform.localEulerAngles.y + 36);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }
            if (victoryCondition - 10 <= newRotation.y && newRotation.y < victoryCondition + 10)
            {
                gameObject.GetComponent<RotationOnDrag>().victory = true;
            }
            codePuzzleParent.CheckForVictory();
        }

    }
}
