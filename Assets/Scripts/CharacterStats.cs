using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private float Speed;
    [SerializeField] private int startMaxCapacity = 10;
    private int currentMaxCapacity;
    public static Action<int> SetPlayerMaxCapacity;

    void Start()
    {
        currentMaxCapacity = startMaxCapacity;
        SetPlayerMaxCapacity(currentMaxCapacity);
    }
}
