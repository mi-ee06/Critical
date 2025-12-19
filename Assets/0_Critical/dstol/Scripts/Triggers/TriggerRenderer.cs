using UnityEngine;

public class TriggerRenderer : MonoBehaviour
{
    private Renderer thisRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleRenderer()
    {
        if(thisRenderer.enabled)
        {
            thisRenderer.enabled = false;
        }
        else { thisRenderer.enabled = true; }
    }
}
