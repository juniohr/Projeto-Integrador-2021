using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pao : MonoBehaviour
{
    public static Pao instance;
    public bool click, mover;
    public Vector3 target, paoInicio;
    public List<GameObject> obj;

    void Awake()
    {
        paoInicio = transform.position;
        instance = this;
    }

    void FixedUpdate()
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
        InterfaceUI.instancia.ativarTempo = true;
        click = !click;
    }
}
