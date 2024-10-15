using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatPieContainerBehaviour : MonoBehaviour
{
    [SerializeField] int capacity = 4;
    public int currentCapacity = 0;
    public bool isFull;
    // Start is called before the first frame update
    void Start()
    {
        isFull = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCapacity >= capacity)
        {
            isFull = true;
        } else
        {
            isFull = false;
        }
    }

}
