using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class CreacionObstaculos : MonoBehaviour
{
    public NavMeshSurface superficie;
    public GameObject obstaculo;
    public NavMeshAgent agent;
    Vector3 toGo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit rayHit;

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(cameraRay, out rayHit, Mathf.Infinity))
            {
                toGo = rayHit.point;
                agent.destination = toGo;
            }

            if (Input.GetMouseButtonDown(0))
            {
                /* TODO: Lanzar un rayo, e instanciar un obstáculo en el punto donde se golpee */
                /* Hay que reconstruir la superficie, busca un método que se encargue de ello */
                if (Physics.Raycast(cameraRay, out rayHit, Mathf.Infinity))
                {
                    Object.Instantiate(obstaculo, rayHit.point, obstaculo.transform.localRotation);
                    superficie.BuildNavMesh();
                    agent.ResetPath();
                    agent.destination = toGo;
                }
            }
        }

    }
}

