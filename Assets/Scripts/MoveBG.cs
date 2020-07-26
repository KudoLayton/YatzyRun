using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    MeshRenderer renderer;
    [SerializeField]
    [Range(0.0f, 1.0f)]
    float speed;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        renderer.material.SetTextureOffset("_MainTex",
            renderer.material.GetTextureOffset("_MainTex") + new Vector2(speed, 0) * Time.deltaTime);
    }
}
