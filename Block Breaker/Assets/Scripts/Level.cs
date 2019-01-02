using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] int breakableObjects; // serializing just for debugging through inspector

    public void CountBreakableObjects()
    {
        breakableObjects++;
    }
}
