using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearingTree : MonoBehaviour
{
    MeshRenderer[] meshes;
    [SerializeField] float timeToGrow = 5f;
    [SerializeField] float refreshTime = 0.05f;
    List<Material> materials = new List<Material>();
    GameObject[] childs;
    [SerializeField] GameObject cherrapple;
    bool fullGrow = false;
    // Start is called before the first frame update
    void Start()
    {
        cherrapple.SetActive(false);
        childs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childs[i] = transform.GetChild(i).gameObject;

            for (int x = 0; x < childs[i].GetComponent<MeshRenderer>().materials.Length; x++)
            {
                if (childs[i].GetComponent<MeshRenderer>().materials[x].HasFloat("_Grow"))
                {
                    materials.Add(childs[i].GetComponent<MeshRenderer>().materials[x]);
                }
            }
                
        }
        //meshes = gameObject.GetComponent<MeshRenderer>();
        //materials = meshes.material;

        StartGrowingTree();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(materials[0].GetFloat("_Grow").ToString());
        //Debug.Log(materials[1].GetFloat("_Grow").ToString());
        //Debug.Log(materials[2].GetFloat("_Grow").ToString());
    }
    public IEnumerator growTree(Material mat)
    {
        float growValue = mat.GetFloat("_Grow");
        while (growValue < 1)
        {
            growValue += 1/ (timeToGrow/refreshTime);
            mat.SetFloat("_Grow", growValue);

            yield return new WaitForSeconds(refreshTime);
        }
        if (!cherrapple.activeSelf) { cherrapple.SetActive(true); }
    }
    public void StartGrowingTree()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            StartCoroutine(growTree(materials[i]));
        }
    }
}
