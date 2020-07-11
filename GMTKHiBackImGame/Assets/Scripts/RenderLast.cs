using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;

public class RenderLast : MonoBehaviour
{
    void Start()
    {
       
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Handles.zTest = UnityEngine.Rendering.CompareFunction.Always;
    }
}
