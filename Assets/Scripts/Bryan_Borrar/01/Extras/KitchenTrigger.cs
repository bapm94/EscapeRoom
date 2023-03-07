using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTrigger : MonoBehaviour
{
    [SerializeField] GameObject cluesController;
    private void OnTriggerEnter(Collider other)
    {
        cluesController.SetActive(true);
        LeanTween.delayedCall(0.002f, () => cluesController.GetComponent<CluesController>().ChangeClue(1));
        LeanTween.delayedCall(0.0021f, () => cluesController.SetActive(false));

        //cluesController.SetActive(false);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
