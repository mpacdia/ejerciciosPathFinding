using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovimientoPuntos : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> listaVectores ;

    public NavMeshAgent agente;

    int actual = 0;

    private void Start()
    {
        /* TODO: Crear la lista de puntos (se puede hacer por código o desde la UI*/
        listaVectores.Add(new Vector3(-2, 0.283f, -2)); listaVectores.Add(new Vector3(-2, 0.823f, 2)); listaVectores.Add(new Vector3(2, 0.283f, 2)); listaVectores.Add(new Vector3(2, 0.283f, -2));

        /* TODO: Establecer el primer punto como destino */
        agente.destination = listaVectores[0];
    }

    // Update is called once per frame
    void Update()
    {
        Ray patrullaRay = new Ray(transform.position, transform.forward);
        RaycastHit hit;


       /* El algoritmo es algo así:
        *  1 - Si hemos llegado al destino (es decir, la x y z de mi transform es igual al destino establecido en el agente)
        *  2 - Busco cual es el siguiente punto, y lo establezco como destino. ¿Qué pasa si hemos llegado al último punto?
        */
       if (Physics.Raycast(patrullaRay, out hit, 3f))
        {
            agente.destination = hit.point;
        }
        else
        {
            ruta();
        }
    }

    void ruta()
    {
        if (agente.transform.position == listaVectores[0])
        {
            agente.destination = listaVectores[1];
        }
        else if (agente.transform.position == listaVectores[1])
        {
            agente.destination = listaVectores[2];

        }
        else if (agente.transform.position == listaVectores[2])
        {
            agente.destination = listaVectores[3];

        }
        else if (agente.transform.position == listaVectores[3])
        {
            agente.destination = listaVectores[0];
        }
    }
}
