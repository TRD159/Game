using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaskedMischiefNamespace
{
  public class GetMeshSize : MonoBehaviour
  {
    private SkinnedMeshRenderer meshRenderer;

    private void Awake()
    {
      meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }
    private void Start()
    {
      Debug.Log("size: " + meshRenderer.bounds.size);
    }
  }
}
