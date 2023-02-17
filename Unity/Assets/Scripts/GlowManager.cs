using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GlowManager : MonoBehaviour
{
    TextMeshProUGUI Glow2;
    private void Start()
    {
        Glow2 = GetComponent<TextMeshProUGUI>();
    }
    public void EnableGlow()
    { 
        Glow2.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(200, 200, 200, 255));
        Glow2.fontSharedMaterial.EnableKeyword(TMPro.ShaderUtilities.Keyword_Glow);
    }    
    public void DisableGlow()
    {
        Glow2.fontSharedMaterial.DisableKeyword(TMPro.ShaderUtilities.Keyword_Glow);
    }

    public void ClickGlow()
    {
        Glow2.color = new Color(255, 62, 200, 255);
        Glow2.material.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 62, 200, 255));
        Glow2.fontSharedMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 62, 200, 255));
    }
}
