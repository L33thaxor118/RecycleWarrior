using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform reticle;
    public float restingSize;
    public float maxSize;
    public float speed;
    public float currentSize;

    private void Start()
    {
        reticle = GetComponent<RectTransform>();
        currentSize = restingSize;
    }

    private void Update()
    {
        //if (isMoving)
       // {
        currentSize = Mathf.Lerp(restingSize, currentSize, Time.deltaTime * speed);
       // }
        // else
        // {
        //     currentSize = Mathf.Lerp(currentSize, restingSize, Time.deltaTime * speed);
        // }

        reticle.sizeDelta = new Vector2(currentSize, currentSize);
    }

}
