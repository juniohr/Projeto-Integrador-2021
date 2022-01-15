using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cliente : MonoBehaviour
{
    public Backup backup;
    public Cafe cafe;
    public Leite leite;
    public byte contador, contAux;
    public GameObject obj;
    public static Cliente instancia;
    public List<SpriteRenderer> cliente;
    public List<GameObject> clientes;
    public int clienteAleatorio, pedidosAleatorio;
    public List<bool> pedidos;
    public List<GameObject> pedidosAux;
    public List<Toggle> verificarPedidoPronto;
    public Vector3 posInicio;
    public GameObject clienteinstancia;
    public List<Toggle> _activeOrders;
    public bool nextOrder = true;
    public bool click;
    public InterfaceUI InterfaceUI;

    void Start()
    {
        instancia = this;
        posInicio = transform.position;
        backup = Backup.instance;

        for (byte i = 0; i < backup.pedidosAux.Count; i++) {
            pedidosAux[i] = backup.pedidosAux[i].gameObject;
        }

        for (byte i = 0; i < backup.pedidosAux.Count; i++) {
            verificarPedidoPronto[i] = backup.verificarPedidoPronto[i].GetComponent<Toggle>();
        }

        Respaw();
    }

    private void FixedUpdate()
    {
        FadeInOut();
        DestroyCliente();
    }

    public void FadeInOut()
    {
        if (cliente[clienteAleatorio] != null) {
            cliente[clienteAleatorio].sortingOrder = -9;
        }

        if (InterfaceUI.instancia.fade && InterfaceUI.instancia.fade != false && cliente[clienteAleatorio] != null) {
            cliente[clienteAleatorio].color = Color.Lerp(cliente[clienteAleatorio].color, new Color(1, 1, 1, 0), 0.05f);
        } else {
            if (cliente[clienteAleatorio] != null) {
                cliente[clienteAleatorio].color = Color.Lerp(cliente[clienteAleatorio].color, new Color(1, 1, 1, 1), 0.05f);
            }
        }
    }

    public void DestroyCliente()
    {
        if (cliente[0].color.a <= 0.01f) {
            clientes[clienteAleatorio].SetActive(false);
        }
    }

    /**
     * verificarPedidoPronto
     * Pão Francês      [0]
     * Suco de Uva      [1]
     * Suco de Morango  [2]
     * Suco de Limão    [3]
     * Café             [4]
     * Café com Leite   [5]
     */
    public void VerificarPedido()
    {
        if (obj != null && obj.CompareTag("SucoUva")) {
            Suco.instancia.click = false;
            Suco.instancia.cupFilled = false;
            obj.GetComponent<Animator>().SetBool("SucoUva", false);
            verificarPedidoPronto[1].isOn = true;
            verificarTodosPedidos();
            
            if (Suco.instancia.name == "Copo (1)") {
                Suco.instancia.tag = "Copo_1";
                Suco.instancia.transform.position = new Vector2(-7.53f, 1.96f);
            }

            //if (obj.name == "Copo (2)") {
            //    obj.tag = "Copo_2";
            //    obj.transform.position = new Vector2(-7.21f, 2.29f);
            //}

            //    if (obj.name == "Copo (3)") {
            //        obj.transform.position = new Vector2(-8.38f, 1.13f);
            //    }

            //    if (obj.name == "Copo (4)") {
            //        obj.transform.position = new Vector2(-7.99f, 1.56f);
            //    }
        }

        if (obj != null && obj.CompareTag("SucoLimao")) {
            Suco.instancia.click = false;
            Suco.instancia.cupFilled = false;
            obj.GetComponent<Animator>().SetBool("SucoLimao", false);
            verificarPedidoPronto[3].isOn = true;
            verificarTodosPedidos();

            if (Suco.instancia.name == "Copo (1)") {
                Suco.instancia.tag = "Copo_1";
                Suco.instancia.transform.position = new Vector2(-7.53f, 1.96f);
            }

            //if (obj.name == "Copo (2)") {
            //    obj.tag = "Copo_2";
            //    obj.transform.position = new Vector2(-7.21f, 2.29f);
            //}

            //    if (obj.name == "Copo (3)") {
            //        obj.transform.position = new Vector2(-8.38f, 1.13f);
            //    }

            //    if (obj.name == "Copo (4)") {
            //        obj.transform.position = new Vector2(-7.99f, 1.56f);
            //    }
        }

        if (obj != null && obj.CompareTag("SucoMorango") && Suco.instancia.click == false) {
            Suco.instancia.click = false;
            Suco.instancia.cupFilled = false;
            obj.GetComponent<Animator>().SetBool("SucoMorango", false);
            verificarPedidoPronto[2].isOn = true;
            verificarTodosPedidos();

            if (Suco.instancia.name == "Copo (1)") {
                Suco.instancia.tag = "Copo_1";
                Suco.instancia.transform.position = new Vector2(-7.53f, 1.96f);
            }

            //if (obj.name == "Copo (2)") {
            //    obj.transform.position = new Vector2(-7.21f, 2.29f);
            //}

            //if (obj.name == "Copo (3)") {
            //    obj.transform.position = new Vector2(-8.38f, 1.13f);
            //}

            //if (obj.name == "Copo (4)") {
            //    obj.transform.position = new Vector2(-7.99f, 1.56f);
            //}
        }
        //}

        if (obj != null && obj.CompareTag("Pao") && Pao.instance.click == false) {
            verificarPedidoPronto[0].isOn = true;
            Pao.instance.obj[0].SetActive(true);
            Pao.instance.transform.position = Pao.instance.paoInicio;
            verificarTodosPedidos();
        }

        if (obj != null && obj.CompareTag("Xicara") && Cafe.instance.click == false) {
            verificarPedidoPronto[4].isOn = true;
            Cafe.instance.transform.position = Cafe.instance.inicioXicara;
            Cafe.instance.anim.SetBool("Cheio", false);
            verificarTodosPedidos();
        }

        if (obj != null && obj.CompareTag("CafeComLeite") && Cafe.instance.click == false) {
            verificarPedidoPronto[5].isOn = true;
            Cafe.instance.anim.SetBool("Cheio", false);
            Cafe.instance.anim.SetBool("CafeComLeite", false);
            Leite.instance.anim.SetBool("Cheio", false);
            Cafe.instance.tag = "Xicara";
            Cafe.instance.comLeite = false;
            Cafe.instance.transform.position = Cafe.instance.inicioXicara;
            verificarTodosPedidos();
        }

        //if (obj != null && obj.CompareTag("Pao") && Pao.instance.click == false && Pao.instance.obj[0].activeInHierarchy) {
        //    verificarPedidoPronto[0].isOn = true;
        //    Pao.instance.obj[2].SetActive(false);
        //    Pao.instance.obj[0].SetActive(true);
        //    Pao.instance.transform.position = Pao.instance.paoInicio;

        //    if (pedidos[0]) {
        //    }
        //} 
        //else if (obj != null && obj.CompareTag("Pao") && Pao.instance.click == false && Pao.instance.obj[0].activeInHierarchy) {
        //    verificarPedidoPronto[6].isOn = true;
        //    Pao.instance.transform.position = Pao.instance.paoInicio;

        //    if (pedidos[6]) {
        //        verificarTodosPedidos();
        //    }

    }

    public void OnMouseDown()
    {
        click = !click;
    }

    public void verificarTodosPedidos()
    {
        nextOrder = true;
        for (byte i = 0; i < _activeOrders.Count; i++) {
            if (_activeOrders[i].isOn == false) {
                nextOrder = false;
            }
        }

        if (nextOrder) {
            for (byte i = 0; i < _activeOrders.Count; i++) {
                if (_activeOrders[i] != null) {
                    _activeOrders[i].isOn = false;
                    pedidosAux[i].SetActive(false);
                    verificarPedidoPronto[i].isOn = false;
                }
            }

            InterfaceUI.instancia.contarPontos = true;
            Instantiate(backup.cliente, new Vector3(posInicio.x, posInicio.y, posInicio.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void Respaw()
    {
        clienteAleatorio = Random.Range(0, clientes.Count);
        clientes[clienteAleatorio].SetActive(true);

        int delivery = Random.Range(1, backup.pedidosAux.Count);
        for (byte i = 0; i < delivery; i++) {
            pedidosAleatorio = Random.Range(0, backup.pedidosAux.Count);
            pedidosAux[pedidosAleatorio].SetActive(true);
            if (pedidosAux[pedidosAleatorio].activeSelf) {
                _activeOrders.Add(verificarPedidoPronto[pedidosAleatorio]);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        obj = collision.gameObject;
        VerificarPedido();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        obj = null;
    }

}
