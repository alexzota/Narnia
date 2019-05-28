using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    private static DoNotDestroyOnLoad instance;

    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else Destroy(gameObject);
    }
}
