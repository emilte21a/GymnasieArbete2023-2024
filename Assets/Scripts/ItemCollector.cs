using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    string currentItemName;
    public Text currentItemElement;

    GameObject currentItemObject;

    bool isIntersecting;

    private string textValue;
    public Text pickupTextElement;

    public RawImage pickedUpRelics;

    Dictionary<string, GameObject> itemsInInventory;


    private void Start()
    {

        pickedUpRelics.enabled = false;

        pickupTextElement.text = textValue;
        itemsInInventory = new Dictionary<string, GameObject>();

    }

    private void Update()
    {
        pickupTextElement.text = textValue;
        if (isIntersecting)
        {
            textValue = "press F to pick up item";
            if (Input.GetKeyDown(KeyCode.F))
            {
                AddItemToInventory(currentItemName, currentItemObject);
                Destroy(currentItemObject);
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            pickedUpRelics.enabled = true;
        }
        else
        {
            pickedUpRelics.enabled = false;
        }
    }

    private void AddItemToInventory(string item, GameObject gameObject)
    {
        textValue = "";
        itemsInInventory.Add(item, gameObject);
        currentItemElement.text += item + "  ";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Relic"))
        {
            isIntersecting = true;
            currentItemName = other.gameObject.name;
            currentItemObject = other.gameObject;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Relic"))
        {
            isIntersecting = false;
            textValue = "";
        }
    }


}
