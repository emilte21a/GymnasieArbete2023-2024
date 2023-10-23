using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    string currentItemName;

    GameObject currentItemObject;

    private string textValue;

    [Header("Text and image")]
    public Text pickupTextElement;

    public RawImage pickedUpRelics;


    Dictionary<string, GameObject> itemsInInventory;

    bool isIntersecting;

    public Canvas canvas;


    [Header("Image positions")]
    public Transform voodooImagePos;
    public Transform SpellbookImagePos;
    public Transform CandleImagePos;
    public Transform ScrollImagePos;
    public Transform NecklaceImagePos;
    public Transform CrucifixImagePos;

    [Header("Checkmark Image")]

    public Texture checkmark;

    private bool eIsPressed;

    List<GameObject> checkMarks;

    //private Dictionary<GameObject, Vector2> imagePositionInHud;

    private void Start()
    {
        pickedUpRelics.enabled = false;
        pickupTextElement.text = textValue;
        itemsInInventory = new Dictionary<string, GameObject>();
        
        checkMarks = new();

    }

    private void Update()
    {
        pickupTextElement.text = textValue;
        if (isIntersecting)
        {
            textValue = "press F to pick up item";
            if (Input.GetKeyDown(KeyCode.F))
            {
                itemsInInventory.Clear();
                AddItemToInventory(currentItemName, currentItemObject);
                AddCheckMark();
                Destroy(currentItemObject);
                isIntersecting = false;
            }
        }
        if (Input.GetKey(KeyCode.E))
        {
            pickedUpRelics.enabled = true;
            eIsPressed = true;
        }
        else
        {
            pickedUpRelics.enabled = false;
            eIsPressed = false;
        }
        foreach (var item in checkMarks)
        {
            if (eIsPressed)
            {
                item.SetActive(true);
            }
            else
            {
                item.SetActive(false);
            }
        }
    }

    private void AddItemToInventory(string item, GameObject gameObject)
    {
        textValue = "";
        itemsInInventory.Add(item, gameObject);
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

    private void AddCheckMark()
    {
        foreach (KeyValuePair<string, GameObject> item in itemsInInventory)
        {
            if (itemsInInventory.ContainsKey(item.Key))
            {
                if (item.Key == "Voodoo")
                {
                    PlaceImage(checkmark, voodooImagePos.position);
                }

                else if (item.Key == "Book")
                {
                    PlaceImage(checkmark, SpellbookImagePos.position);
                }

                else if (item.Key == "CandleBundle")
                {
                    PlaceImage(checkmark, CandleImagePos.position);
                }

                else if (item.Key == "Necklace")
                {
                    PlaceImage(checkmark, NecklaceImagePos.position);
                }

                else if (item.Key == "Crucifix")
                {
                    PlaceImage(checkmark, CrucifixImagePos.position);
                }

                else if (item.Key == "Scroll")
                {
                    PlaceImage(checkmark, ScrollImagePos.position);
                }
            }
        }
    }

    private void PlaceImage(Texture image, Vector3 position)
    {
        var go = new GameObject();
        go.transform.SetParent(canvas.transform);
        go.name = "CheckMark";
        var spriteRenderer = go.AddComponent<RawImage>();
        spriteRenderer.texture = image;
        go.transform.position = position;
        checkMarks.Add(go);
    }
}
