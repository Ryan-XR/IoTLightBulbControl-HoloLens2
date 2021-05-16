using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevicePlaceholder : MonoBehaviour
{

    void Start()
    {
        // hide light bulb placeholder after time
        StartCoroutine(ScaleDownAfter(20.0f));
    }

    IEnumerator ScaleDownAfter(float s)
    {
        yield return new WaitForSecondsRealtime(s);

        transform.localScale = new Vector3(
            transform.localScale.x * 0.0f, 
            transform.localScale.y * 0.0f, 
            transform.localScale.z * 0.0f
            );
    }
}
