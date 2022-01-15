using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    public static Cafe instancia;
    public Leite leite;
    public Animator anim;
    public bool click, mover, podeEntregar, comLeite;
    public Vector3 target, inicioXicara;
    public string tagObj;
    public GameObject obj;
    public static Cafe instance;

    private void Start()
    {
        InterfaceUI.instancia.ativarTempo = true;
        anim = GetComponent<Animator>();
        inicioXicara = transform.position;
        instance = this;
    }

    public void FixedUpdate()
    {
        if (click) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = target;
        }

        if (obj != null && click == false && obj.CompareTag("MaquinaCafe")) {
            gameObject.transform.position = new Vector2(-3.22f, 0f);
            if (this.transform.position.x == -3.22f && this.transform.position.y == 0f) {
                StartCoroutine(WaitToStartAnimation());
                anim.SetBool("Cheio", true);
                Invoke("Espera", 1.1f);
            }
        }

        if (obj != null && click == false && obj.CompareTag("MaquinaCafeAzul")) {
            this.transform.position = new Vector2(-1.26f, 0f);
            if (this.transform.position.x == -1.26f && this.transform.position.y == 0f) {
                StartCoroutine(WaitToStartAnimation());
                anim.SetBool("Cheio", true);
                Invoke("Espera", 1.1f);
            }
        }

        if (obj != null && obj.CompareTag("Leite") && podeEntregar && comLeite == true) {
            anim.SetBool("CafeComLeite", true);
        }

        if (obj != null && obj.CompareTag("CafeComLeite")) {
            Debug.Log(obj.tag);
        }

        if (obj != null && click == false && obj.CompareTag("Xicara") && podeEntregar && comLeite == false) {
            anim.SetBool("Cheio", false);
            anim.SetBool("CafeComLeite", false);
            transform.position = inicioXicara;
            Cliente.instancia.verificarPedidoPronto[4].isOn = true;
            Cliente.instancia.verificarTodosPedidos();
        }

        if (obj != null && click == false && obj.CompareTag("CafeComLeite") && podeEntregar && comLeite) {
            leite.anim.SetBool("Cheio", false);
            anim.SetBool("Cheio", false);
            anim.SetBool("CafeComLeite", false);
            comLeite = false;
            transform.position = inicioXicara;
            Cliente.instancia.verificarPedidoPronto[5].isOn = true;
            Cliente.instancia.verificarTodosPedidos();
        }
    }

    IEnumerator WaitToStartAnimation()
    {
        yield return new WaitForSeconds(1);

        //If normalizedTime is 0 to 1 means animation is playing, if greater than 1 means finished
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1) {
            obj = null;
        }
    }

    public void OnMouseDown()
    {
        click = !click;
    }

    public void Espera()
    {
        mover = true;
        podeEntregar = true;
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
