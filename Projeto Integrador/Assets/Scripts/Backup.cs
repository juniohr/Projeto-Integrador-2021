using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backup : MonoBehaviour
{
    public static Backup instance;
    public List<GameObject> pedidosAux;
    public List<Toggle> verificarPedidoPronto;
    public GameObject cliente;

    void Awake()
    {
        instance = this;
    }
}
