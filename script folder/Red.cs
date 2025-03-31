using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MakeURPTransparentRed : MonoBehaviour
{
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer == null) return;

        Material mat = renderer.material;
        if (mat == null) return;

        
        mat.color = new Color(1f, 0f, 0f, 0.1f);

        
        mat.SetFloat("_Surface", 1); 
        mat.SetFloat("_Blend", 0);   
        mat.SetFloat("_ZWrite", 0);
        mat.SetFloat("_AlphaClip", 0); 

        mat.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
        mat.renderQueue = (int)RenderQueue.Transparent;
    }
}


