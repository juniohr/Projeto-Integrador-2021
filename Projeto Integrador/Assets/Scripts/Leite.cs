using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leite : MonoBehaviour
{
    public static Leite instance;
    public Cafe cafe;
    public Animator anim;
    public Animator cafeLeite;
    public bool click, mover;
    public Vector3 target, inicioLeite;
    public string tagObj;
    public GameObject obj;

    private void Start()
    {
        anim = GetComponent<Animator>();
        inicioLeite = transform.position;
        instance = this;
    }

    public void FixedUpdate()
    {
        if (mover) {
            if (click) {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                transform.position = target;
            }
        }
    }

    public void OnMouseDown()
    {
        InterfaceUI.instancia.ativarTempo = true;

        if (mover) {
            click = !click;
        }

        if (obj != null && obj.CompareTag("Xicara")) {
            float XicaraX = obj.transform.position.x;
            float XicaraY = obj.transform.position.y;
            XicaraX += 0.2f;
            XicaraY += 0.4f;
            this.transform.position = new Vector2(XicaraX, XicaraY);
            anim.SetBool("Cheio", true);
            cafe.comLeite = true;
            obj.tag = "CafeComLeite";
            Invoke("Espera", 1.1f);
        }
    }

    public void Espera()
    {
        anim.SetBool("Cheio", false);
        mover = true;
        transform.position = inicioLeite;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision.gameObject;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}
