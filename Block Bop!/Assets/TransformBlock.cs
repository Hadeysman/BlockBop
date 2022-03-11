using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBlock : MonoBehaviour
{

    public float maxSize;
    public float growFactor;
    public float waitTime;

    

    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true) 
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(.5f, .5f, .5f) * Time.deltaTime * growFactor;
                yield return null;
            }
            

            yield return new WaitForSeconds(waitTime);

            
            
        
        }
    }
}


