using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suco : MonoBehaviour
{
    public Animator anim;
    public static Suco instancia;
    public bool click, mover, entregarCliente;
    public Vector3 target, inicioCopo;
    public string tagObj;
    public GameObject obj;
    public bool cupFilled = false;
    public GameObject objectToIgnoreCollider;
    private void Start()
    {
        InterfaceUI.instancia.ativarTempo = true;
        inicioCopo = transform.position;
        anim = GetComponent<Animator>();
        tagObj = gameObject.tag.ToString();
        instancia = this;

    }

    public void FixedUpdate()
    {
        if (click) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = target;
        }

        if (this.click == false && obj != null && obj.gameObject.CompareTag("MaquinaUva")) {
            gameObject.tag = "SucoUva";
            this.transform.position = new Vector2(-5.33f, -0.15f);
            if (this.transform.position.x == -5.33f && this.transform.position.y == -0.15f) {
                StartCoroutine(WaitToStartAnimation());
                this.anim.SetBool("SucoUva", true);
                Invoke("CopoCheio", 1.1f);
            }
        }

        if (this.click == false && obj != null && obj.gameObject.CompareTag("MaquinaLimao")) {
            gameObject.tag = "SucoLimao";
            gameObject.transform.position = new Vector2(-5.96f, -0.81f);
            if (this.transform.position.x == -5.96f && this.transform.position.y == -0.81f) {
                StartCoroutine(WaitToStartAnimation());
                this.anim.SetBool("SucoLimao", true);
                Invoke("CopoCheio", 1.1f);
            }
        }

        if (this.click == false && obj != null && obj.gameObject.CompareTag("MaquinaMorango")) {
            gameObject.tag = "SucoMorango";
            gameObject.transform.position = new Vector2(-6.69f, -1.53f);
            if (this.transform.position.x == -6.69f && this.transform.position.y == -1.53f) {
                StartCoroutine(WaitToStartAnimation());
                this.anim.SetBool("SucoMorango", true);
                Invoke("CopoCheio", 1.1f);
            }
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

    public void CopoCheio()
    {
        mover = true;
        entregarCliente = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        obj = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}