using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
            int victoryCon = victoryCondition * 36;
            
            Vector3 newRotation = Vector3.one;
            rotating = true;
            LeanTween.delayedCall(rotationTime + 0.01f, () => Delayed());
            if (x)
            {
                float angle = transform.localEulerAngles.y - 36f;
                if (angle < 0) { angle = 360 + angle; }
                newRotation = Vector3.up * (angle);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }
            else
            {
                float angle = transform.localEulerAngles.y + 36;
                if (angle > 360) { angle = angle - 360; }
                newRotation = Vector3.up * (transform.localEulerAngles.y + 36f);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }

            if ((victoryCon - 15) <= newRotation.y && newRotation.y < (victoryCon + 15))
            {
                gameObject.GetComponent<RotationOnDrag>().victory = true;
            }
            
        }

    }

    void Delayed()
    {
        rotating = false; codePuzzleParent.CheckForVictory();
    }
}
