using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material selectedMaterial;

    bool isSelected = false;

    private new Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponentInChildren<Renderer>();
        defaultMaterial = renderer.material;
    }

    public void SetHoverMaterial()
    {
        renderer.material = hoverMaterial;
    }

    public void SetSelectedMaterial()
    {
        isSelected = true;
        renderer.material = selectedMaterial;
    }

    public void SetDefaultMaterialFromHover()
    {
        if (!isSelected)
        {
            renderer.material = defaultMaterial;
        }
    }

    public void SetDefaultMaterialFromSelected()
    {
        isSelected = false;
        renderer.material = defaultMaterial;
    }
}
