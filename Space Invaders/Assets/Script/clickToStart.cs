using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickToStart : MonoBehaviour
{
    float maxSize = 1.2f;
    float minSize = 0.8f;
    float speed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float range = maxSize - minSize;
        Vector3 lTemp = transform.localScale;
        lTemp.y = (Mathf.Sin(Time.time*speed) + 1.0f) / 2.0f * range + minSize;
        lTemp.x = (Mathf.Sin(Time.time*speed) + 1.0f) / 2.0f * range + minSize;

        transform.localScale = lTemp;
    }
}
