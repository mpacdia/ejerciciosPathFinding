using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ComportamientoCamara : MonoBehaviour
{
    public NavMeshAgent agent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayHit;

        /* TODO: Lanzar un rayo al pulsar el botón, y modificar el destino de nuestro agente */
        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(cameraRay, out rayHit, Mathf.Infinity))
            {

                agent.destination = rayHit.point;


            }
        }

       
    }
}
