using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Margarina : MonoBehaviour
{
    public bool click;
    public Vector3 target;
    public GameObject obj;
    public Vector3 inicioMarg;

    void Start()
    {
        InterfaceUI.instancia.ativarTempo = true;
        inicioMarg = transform.position;
    }

    public void FixedUpdate()
    {
        if (click)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            transform.position = target;
        }

       
    }

    public void OnMouseDown()
    {
        click = !click;
        if (obj != null)
        {
            if (Pao.instance.click == false && obj.CompareTag("Pao") && Pao.instance.obj[1].activeInHierarchy)
            {
                Pao.instance.obj[1].SetActive(false);
                Pao.instance.obj[2].SetActive(true);
                Pao.instance.mover = true;

                transform.position = inicioMarg;
            }
            else if (Pao.instance.click == false && obj.CompareTag("Chapa") && Pao.instance.obj[1].activeInHierarchy)
            {
                Pao.instance.obj[1].SetActive(false);
                Pao.instance.obj[2].SetActive(true);
                Pao.instance.mover = true;

                transform.position = inicioMarg;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        obj = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }
}
