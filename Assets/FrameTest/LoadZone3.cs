using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadZone3 : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //GameManager.Instance.LoadScene3();
        }
    }
}
