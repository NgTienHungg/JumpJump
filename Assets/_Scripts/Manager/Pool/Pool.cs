using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Pool
{
    public GameObject Prefab;

    public int Size;

    public bool Expandable = true;

    [HideInInspector]
    public List<GameObject> ListObject;
}