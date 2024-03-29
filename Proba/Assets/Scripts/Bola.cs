using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bola : MonoBehaviour
{
    private float speedMovBolas;
    // Start is called before the first frame update
    void Start()
    {
        speedMovBolas = UnityEngine.Random.Range(3f, 5f) * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
        speedMovBolas = UnityEngine.Random.Range(3f, 5f) * Time.deltaTime;
        transform.Translate(Vector2.down * speedMovBolas);
        if(transform.position.y<-5f)
        {
            Destroy(gameObject);
        }
    }
    
}
