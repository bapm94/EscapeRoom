using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resolution_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    //public TextMeshProUGUI resolutionText;
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        Debug.Log("RefreshRate " + currentRefreshRate); //PRUEBA SIN BUILD
        
        for(int i = 0; i < resolutions.Length; i++)
        {
            Debug.Log("Resolution: " + resolutions[i]); //PRUEBA SIN BUILD

            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
            options.Add(resolutionOption);
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    
    public void AssignResolution() //int resolutionIndex
    {

        int resolutionIndex = resolutionDropdown.value;
        //resolutionText.text = Screen.width + " x " + Screen.height;
        Resolution resolution = filteredResolutions[resolutionIndex];
        // (resolutionIndex < filteredResolutions.Count)Screen.fullScreen = false;
        bool screenIsFull = false;
        if (resolutionIndex == filteredResolutions.Count - 1) screenIsFull = true;
        Screen.SetResolution(resolution.width, resolution.height, screenIsFull);

        
    }
    //[System.Serializable]
    //public class ResolutionItem
    //{
    //    public int horizontal, vertical;
    //}
}
