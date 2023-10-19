using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private DepthOfField depthOfField;

    private bool eIsPressed;
    void Start()
    {
        postProcessVolume.GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out depthOfField);
        depthOfField.active = false;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            eIsPressed = true;
        }

        else{
            eIsPressed = false;
        }

        if (eIsPressed)
        {
            depthOfField.active = true;
        }
        else
        {
            depthOfField.active = false;
        }
    }
}
