using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatBehaviour : MonoBehaviour
{

    public bool isTurn = false;
    public bool isOverCooked = false;
    public bool isReady = false;

    public float cookingTime;
    public float overCookTime;
    private float increaseCounter;
    public SpriteRenderer objectRenderer;

    private GameObject container;

    // Start is called before the first frame update
    void Start()
    {
        cookingTime = 8f;
        overCookTime = cookingTime * 2;
        objectRenderer = GetComponent<SpriteRenderer>();
        increaseCounter = 0;
        container = GameObject.Find("Cookware/BakingPan/MeatPieContainer");
    }

    // Update is called once per frame
    void Update()
    {
        // Start cooking once the meat pie is placed on the baking tray
        if (this.gameObject.activeSelf)
        {
            increaseCounter += Time.deltaTime;
            Debug.Log("Increase counter: " + increaseCounter + ", isTurn = " + isTurn + ", isOverCooked: " + isOverCooked + ", isReady: " + isReady);
            // If the time is up and the meat pie can turn, set it to true
            if (increaseCounter >= cookingTime && isTurn == false)
            {
                objectRenderer.color = Color.green;
            }
            // If the time is up and meat pie cannot turn, means it's ready
            if (increaseCounter >= cookingTime && isTurn == true)
            {
                isReady = true;
                objectRenderer.color = Color.blue;
            }
            // Check if it's overcooked
            if (increaseCounter >= overCookTime)
            {
                isOverCooked = true;
                objectRenderer.color = Color.red;
            }
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("TEEESSST");
        // Turn the meat pie if it can turn and reset the timer to start a new count down
        if (isTurn == false && increaseCounter >= cookingTime)
        {
            isTurn = true;
            objectRenderer.color = Color.white;
            increaseCounter = 0;
        }
        if (isTurn == true && isReady == true)
        {
            // If the meat pie is ready, put it into the container and reset all properties
            // If it's not, the timer is still going and it will overcook
            if (!container.GetComponent<MeatPieContainerBehaviour>().isFull)
            {
                container.GetComponent<MeatPieContainerBehaviour>().currentCapacity += 1;
                isTurn = false;
                isOverCooked = false;
                isReady = false;
                // This is the test code, will delete after use
                objectRenderer.color = Color.white;
                increaseCounter = 0;
                //this.gameObject.SetActive(false);
            }
            
        }

        // Reset the meat pie if it's overcooked
        if (isOverCooked)
        {
            isTurn = false;
            isOverCooked = false;
            isReady = false;
            //this.gameObject.SetActive(false);
        }
    }
}
