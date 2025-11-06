using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ObjectInteractionManager : MonoBehaviour
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private Material selectedMaterial;

    bool isSelected = false;

    private new Renderer renderer;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

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

    void OnCollisionEnter(Collision collision)
    {
        float speed = collision.relativeVelocity.magnitude;

        if (speed > 1f)
        {
            audioSource.volume = Mathf.Clamp01(speed / 10f);
            audioSource.Play();
        }
    }
}