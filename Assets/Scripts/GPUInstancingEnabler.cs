using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class GPUInstancingEnabler : MonoBehaviour
{
    private void Awake()
    {
        MaterialPropertyBlock _property_Block = new MaterialPropertyBlock();
        MeshRenderer _mesh_Renderer = GetComponent<MeshRenderer>();
        _mesh_Renderer.SetPropertyBlock(_property_Block);
    }
}
