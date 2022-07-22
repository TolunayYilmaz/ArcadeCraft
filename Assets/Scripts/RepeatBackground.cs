using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 startPos;
    private float repeatWidth;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;// tekrar eden arka planýn ölçüsü
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x < startPos.x - repeatWidth)//sýnýr ölçüye girince tekrar ilk konumuna gelsin
        {
            transform.position = startPos;
        }
    }
}

