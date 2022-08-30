using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatChange : MonoBehaviour
{

    Color[] color_list;
    Renderer  thisRend;
    private float transitionTime = 5f;
    private bool visible;
    private Color initial_color;
    // Start is called before the first frame update
    void Start()
    {
        thisRend = GetComponent<Renderer>();
        color_list = new Color[6];
        initial_color = thisRend.material.color;

        color_list[0] = Color.white;
        color_list[1] = Color.black;
        color_list[2] = Color.red;
        color_list[3] = Color.green;
        color_list[4] = Color.blue;
        color_list[5] = Color.magenta;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Debug.Log(thisRend.material.color);
        if(visible)
        {
            Color newColor = color_list[(Random.Range(0,5))];
            float transitionRate = 0;

            while(transitionRate < 1)
            {
                thisRend.material.SetColor("_Color" , Color.Lerp(thisRend.material.color , newColor , transitionRate * Time.deltaTime));
                transitionRate += Time.deltaTime / transitionTime;
                // Debug.Log(transitionRate);
            }
        }
        else
        {
            thisRend.material.SetColor("_Color" , initial_color);
        }
        
    }

    void OnBecameVisible()
    {
        visible = true;
        // Debug.Log(visible);
        
    }

    void OnBecameInvisible()
    {
        visible = false;
        // Debug.Log("Not visible");
    }
}
