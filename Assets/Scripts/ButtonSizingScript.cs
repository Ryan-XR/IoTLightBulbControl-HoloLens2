using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSizingScript : MonoBehaviour
{
    public bool lookingAtLight = false;
    public bool lookingAtButton = false;
    public bool hidden = true;
    private float scale = 0.0f;

    void Start()
    {
        // hide button initially
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // animate button scale down until hidden
        if (hidden && scale > 0)
        {
            scale -= Time.deltaTime * 8;
            if (scale < 0)
            {
                scale = 0.0f;
            }
        } 
        // animate button scale up until fully visible
        else if(!hidden && scale < 1)
        {
            scale += Time.deltaTime * 8;
            if (scale > 1.0)
            {
                scale = 1.0f;
            }
        }

        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void LookAtLight()
    {
        lookingAtLight = true;
        hidden = false;
    }

    public void LookAwayFromLight()
    {
        lookingAtLight = false;
        StartCoroutine(HideAfterSeconds(3));
    }

    public void LookAtButton()
    {
        lookingAtButton = true;
        hidden = false;
    }

    public void LookAwayButton()
    {
        lookingAtButton = false;
        StartCoroutine(HideAfterSeconds(3));
    }


    public void HideButton()
    {
        if(!lookingAtLight && !lookingAtButton)
        {
            hidden = true;
            Renderer m_ObjectRenderer;
            m_ObjectRenderer = GetComponent<Renderer>();
            Color color = m_ObjectRenderer.material.color;
            color.a = 0.1f;
            m_ObjectRenderer.material.color = color;
        }
    }

    IEnumerator HideAfterSeconds(float t)
    {
        yield return new WaitForSeconds(t);

        // hide button after t seconds
        HideButton();
    }
}
