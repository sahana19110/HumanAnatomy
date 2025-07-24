using UnityEngine;
using UnityEngine.UI;

public class BodyTransparencyController : MonoBehaviour
{
    public Renderer bodyRenderer;
    public Slider transparencySlider;

    private Material bodyMaterial;

    void Start()
    {
        // Use the instantiated material
        bodyMaterial = bodyRenderer.material;

        // Add listener for slider
        transparencySlider.onValueChanged.AddListener(SetTransparency);
    }

    public void SetTransparency(float value)
    {
        Color baseColor = bodyMaterial.GetColor("_BaseColor");
        baseColor.a = 1f - value; // 0 = visible, 1 = invisible
        bodyMaterial.SetColor("_BaseColor", baseColor);
    }
}
