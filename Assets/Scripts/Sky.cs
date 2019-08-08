using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{

    // Basé sur le code d'Eloi

    public Material skyMaterial;
    public float offset;
    public float speed=2f;
    
    void Update()
    {
        Vector2 offset = skyMaterial.GetTextureOffset("_MainTex");
        offset.x += Time.deltaTime* speed;
        if (offset.x < 0)
            offset.x = 1f;
        if (offset.x > 1)
            offset.x = 0f;

        skyMaterial.SetTextureOffset("_MainTex", offset);
       
    }
}
