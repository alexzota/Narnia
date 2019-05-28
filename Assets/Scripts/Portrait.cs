using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour
{
    private static Portrait instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
            Destroy(gameObject);
    }
}
