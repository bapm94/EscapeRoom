using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBeamsBones : MonoBehaviour
{
    [SerializeField] float rotationTime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Rotate(bool x)
    {
        if (!LeanTween.isTweening(gameObject))
        {
            if (x)
            {
                Vector3 newRotation = Vector3.up * (transform.localEulerAngles.y - 36);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }
            else
            {
                Vector3 newRotation = Vector3.up * (transform.localEulerAngles.y + 36);
                LeanTween.rotateLocal(gameObject, newRotation, rotationTime);
            }
        }

    }
}
