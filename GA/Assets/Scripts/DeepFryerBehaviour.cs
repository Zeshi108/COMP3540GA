using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeepFryerBehaviour : MonoBehaviour
{
    public bool isEmpty = true;
    public bool isReady = false;
    public bool isOverCooked = false;
    public int fryTime = 20;
    public SpriteRenderer objectRenderer;

    private float overCookedTime = 40f;
    private float timer;
    private float positiveTimer = 0f;
    private GameObject fries;

    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
        fries = GameObject.Find("FoodRack/Fries");
        timer = overCookedTime;
    }

    // Update is called once per frame
    void Update()
    {
        // If the machine have potato in it, start fry for 'fryTime' seconds automatclly
        if (!isEmpty)
        {
            objectRenderer.color = Color.yellow;
            positiveTimer += Time.deltaTime;
            timer -= Time.deltaTime;
            if (positiveTimer >= fryTime)
            {
                // The fries is ready
                isReady = true;
                positiveTimer = 0f;
            }
            Debug.Log("Time left: " + timer + " seconds to fire");
            if (timer <= 0f)
            {
                isOverCooked = true;
                isReady = false;
                Debug.Log("ITS ON FIRE!!!!!!!!!!!");
            }
        } else
        {
            timer = overCookedTime;
        }
    }


    private void OnMouseDown()
    {
        // Clean up the deep fryer if it's overcooked
        if (!isEmpty && isOverCooked)
        {
            isEmpty = true;
            isReady = false;
            isOverCooked = false;
            Debug.Log("Clean up the deep fryer! Current status: Deep fryer: " + isEmpty + ", isReady: " + isReady + "isOvercooked: " + isOverCooked + ", timer set to: " + timer);
        } else if (!isEmpty && !isOverCooked && isReady)
        {
            // Put fries into fries box
            fries.GetComponent<FoodRack>().stockUp(50);
            isEmpty = true;
            isReady = false;
            isOverCooked = false;
            objectRenderer.color = Color.black;
        }
    }
}
