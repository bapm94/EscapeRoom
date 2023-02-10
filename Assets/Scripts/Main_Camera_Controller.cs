using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Controller : MonoBehaviour
{
    public bool isFollowingCharacter;
    public GameObject mainCharacter;

    public static Main_Camera_Controller instance;

    // Start is called before the first frame update
    void Start()
    {
        if (Main_Camera_Controller.instance == null)
        {
            Main_Camera_Controller.instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangePos()
    {
        //transform.position = mainCharacter.transform.position;
        //transform.rotation = mainCharacter.transform.rotation;
        //transform.rotation = Quaternion.Euler(xRotation, 0, 0);
    }
    void FollowCharacter(GameObject character, bool isFollowing)
    {
        
        isFollowingCharacter = isFollowing;
        if (isFollowingCharacter)
        {
            transform.SetParent(character.transform);
        }
        else
        {
            transform.parent = null;
        }

    }

    public void ChangeFollowStatus(bool isFollowing)
    {
        isFollowingCharacter = isFollowing;
        GameObject player = Main_Character_Controller.instance.gameObject;
        if (isFollowingCharacter) { player.GetComponent<MeshRenderer>().enabled =true; }
        else { player.GetComponent<MeshRenderer>().enabled = false; }
        
    }

}
