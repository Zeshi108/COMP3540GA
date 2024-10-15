using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject lettuce;
    private GameObject cheese;
    private GameObject meat;
    private GameObject fries;
    // Start is called before the first frame update
    void Start()
    {
        lettuce = GameObject.Find("FoodRack/LettuceSlice");
        cheese = GameObject.Find("FoodRack/CheeseSlice");
        meat = GameObject.Find("FoodRack/MeatSlice");
        fries = GameObject.Find("FoodRack/Fries");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // This statement handles what happens after user click the material
            if (hit.collider != null && hit.collider.tag == "Ingredient")
            {
                // When the user clicks on the raw material, five copies are added to the food rack.
                Debug.Log("CLICKED " + hit.collider.name);
                switch (hit.collider.name)
                {
                    case "Lettuce":
                        lettuce.GetComponent<FoodRack>().stockUp(5);
                        break;
                    case "Cheese":
                        cheese.GetComponent<FoodRack>().stockUp(5);
                        break;
                    case "Meat":
                        meat.GetComponent<FoodRack>().stockUp(5);
                        break;
                    case "DeepFryer":
                        // Check if there are fries ready in deep fryer
                        fries.GetComponent<FoodRack>().stockUp(50);
                        break;
                    // If user click bread, bread will appears at the wrapping machine and wait to be served.
                    case "Bread":

                        break;
                }
            }
            else
            {
                Debug.Log("NOOOOOOOOOOOOOO");
            }
        }
    }

    void addIngredient(int value)
    {
        
    }
}
