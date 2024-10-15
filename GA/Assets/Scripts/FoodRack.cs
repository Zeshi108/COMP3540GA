using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRack : MonoBehaviour
{
    [SerializeField] int capacity = 100;
    public int currentCapacity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function for adding foods to foodrack
    // If remains reach the limit, it will not increase the amount
    public void stockUp(int quantity)
    {
        if (currentCapacity < capacity)
        {
            if (currentCapacity + quantity > capacity)
            {
                currentCapacity = capacity;
                Debug.Log("current capacity increase: " + currentCapacity + " remains");
            }
            else
            {
                currentCapacity += quantity;
                Debug.Log("current capacity increase: " + currentCapacity + " remains");
            }
        }
    }
}
