using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceLockAnimation1 : MonoBehaviour
{
    [SerializeField] GameObject _lock;
    [SerializeField] GameObject _buttonsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hideLock()
    {
        _lock.SetActive(false);
    }
    void hideButtons()
    {
        _buttonsCanvas.SetActive(false);
    }
}
