using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapa : MonoBehaviour
{
    public GameObject obj;

    public void FixedUpdate()
    {
        //if (obj != null)
        //{
        //    if (Pao.instance.click == false && obj.CompareTag("Pao") && Pao.instance.obj[0].activeInHierarchy)
        //    {
        //        Pao.instance.obj[0].SetActive(false);
        //        Pao.instance.obj[1].SetActive(true);
        //       // Pao.instance.mover = false;
        //    }
        //}
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
