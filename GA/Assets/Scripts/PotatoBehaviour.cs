using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoBehaviour : MonoBehaviour
{
    private GameObject deepFryer;
    public float cutTime = 5f;
    private float timer;
    [SerializeField] bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        deepFryer = GameObject.Find("Cookware/DeepFryer");
        timer = cutTime;
    }

    // Update is called once per frame
    void Update()
    {
        // If user hold left mouse button and deep fryer is empty, cut the potato with in 5 sec and put it into deep fryer
        if (isHolding && deepFryer.GetComponent<DeepFryerBehaviour>().isEmpty)
        {
            timer -= Time.deltaTime;
            Debug.Log("Time left: " + timer + " seconds");

            if (timer <= 0f)
            {
                CountdownFinished();
            }
        } else
        {
            timer = cutTime;
        }
    }

    private void OnMouseDown()
    {
        isHolding = true;
    }

    private void OnMouseUp()
    {
        isHolding = false;
    }

    // This function exceute after potato has been cuted
    // Put potato into the deep fryer
    void CountdownFinished()
    {
        deepFryer.GetComponent<DeepFryerBehaviour>().isEmpty = false;
    }

}
