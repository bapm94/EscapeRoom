using System.Collections;
using System.Collections.Generic;
//using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OutlineController : MonoBehaviour
{
    [SerializeField] private UniversalRendererData _renderer;
    string _featureName;
    string _secondFeatureName;
    [SerializeField] bool changeDefaultColor = false;
    [SerializeField] Color defaultOutlineColor;
    [SerializeField] bool changeInteractionColor = false;
    [SerializeField] Color interactionOutlineColor;
    public static OutlineController instance;

    Color defaultColor = new Color (0.3971164f, 0.6270968f, 0.8679245f, 1f);
    Color defaultInteractionColor = new Color(1, 0.5498703f, 0, 1);
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
        _featureName = "ScreenSpaceOutlines";
        _secondFeatureName = "InteractableOutlines";
        ChangeDefaultOutlineColor();
        ChangeInteractionColor();
    }
    private void ChangeDefaultOutlineColor()
    {
        if (TryGetFeature(out var feature))
        {
            Color color0 = Color.white;
            if (changeDefaultColor) { color0 = defaultOutlineColor; }
            else { color0 = defaultColor; }
            var blitFeature = feature as ScreenSpaceOutlines;
            blitFeature.SetColor(color0);
            _renderer.SetDirty();
        }        
    }
    private void ChangeInteractionColor()
    {
        if (TryGetFeature2(out var feature2))
        {
            Color color1 = Color.white; 
            if (changeInteractionColor) { color1 = interactionOutlineColor; }
            else { color1 = defaultInteractionColor; }
            var blitFeature = feature2 as ScreenSpaceOutlines;
            blitFeature.SetColor(color1);
            _renderer.SetDirty();
        }
    }
    bool TryGetFeature(out ScriptableRendererFeature feature)
    {
        feature = _renderer.rendererFeatures.Where((f) => f.name == _featureName).FirstOrDefault();
        return feature != null;
    }
    bool TryGetFeature2(out ScriptableRendererFeature feature)
    {
        feature = _renderer.rendererFeatures.Where((f) => f.name == _secondFeatureName).FirstOrDefault();
        return feature != null;
    }
    public void ChangeDefaultOutlineColor(Color color)
    {
        if (TryGetFeature(out var feature) && changeDefaultColor)
        {
            var blitFeature = feature as ScreenSpaceOutlines;
            blitFeature.SetColor(color);
            _renderer.SetDirty();
        }
    }
    public void ChangeInteractionColor(Color color)
    {
        if (TryGetFeature2(out var feature2) && changeInteractionColor)
        {
            var blitFeature = feature2 as ScreenSpaceOutlines;
            blitFeature.SetColor(color);
            _renderer.SetDirty();
        }
    }
}
