using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PJControl : MonoBehaviour
{
    private Vector2 mov;
    private Rigidbody2D rb;
    private float distancia=1.1f;
    private int cantidadJump;
    private Animator anim;

    public AudioClip coin;
    public int points;
    public GameObject pointX1, pointX2;
    public GameObject bolas;
    public float speedMovPj;
    public float fuerzajump;
    public bool suelo;
    public TextMeshProUGUI textPoint;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Invoke("instBolas", UnityEngine.Random.Range(0.2f,2));
        anim=transform.GetChild(0).GetComponent<Animator>();
        points = PlayerPrefs.GetInt("pointsOvillos");
        textPoint.text = "Contador de Ovillos: " + points;

    }
    void Update()
    {
        movPJControl();
    }
    void instBolas()
    {
        float posRandom = UnityEngine.Random.Range(pointX1.transform.position.x, pointX2.transform.position.x);
       GameObject newBall= Instantiate(bolas,new Vector2(posRandom, pointX1.transform.position.y),Quaternion.identity);
       Invoke("instBolas", UnityEngine.Random.Range(0.2f, 2));

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="ball")
        {
            AudioSource.PlayClipAtPoint(coin,new Vector3(0,0,0),1);
            Destroy(collision.gameObject);
            points += 1;
            PlayerPrefs.SetInt("pointsOvillos", points);
            textPoint.text = "Contador de Ovillos: " + points;
        }
    }
    void movPJControl()
    {
        float movimientoLateral = Input.GetAxis("Horizontal");
        mov = new Vector2(movimientoLateral, 0f) * speedMovPj * Time.deltaTime;
        transform.Translate(mov);
        if(transform.position.x>8.25)
        {
            transform.position = new Vector3(8.25f, transform.position.y,90);
        }
        else if(transform.position.x < -8.25)
        {
            transform.position = new Vector3(-8.25f, transform.position.y, 90);
        }
        if(movimientoLateral>0)
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.transform.localEulerAngles = new Vector3(0, 0, 0);
            changeAnim("Mov", true);
        }
        else if (movimientoLateral < 0)
        {
            GameObject child = transform.GetChild(0).gameObject;
            child.transform.localEulerAngles = new Vector3(0, 180, 0);
            changeAnim("Mov", true);
        }
        else
        {
            changeAnim("Mov", false);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distancia);
        if (hit.collider!=null&&hit.collider.tag =="Suelo")
        {
            suelo = true;
            cantidadJump = 1;
        }
        else
        {
            suelo = false;
        }
        if (Input.GetButtonDown("Jump") && cantidadJump>0)
        {
            cantidadJump -= 1;
            rb.velocity = new Vector2(rb.velocity.x, fuerzajump);
            changeAnim("Jump", true);
        }
    }
    void changeAnim(string name, bool active)
    {
        anim.SetBool(name, active);
    }
}
