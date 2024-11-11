using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    private bool sobreLaPlataforma;
    private Rigidbody plataformaActual;
    private Transform posicioEsfera;

    private void Start()
    {
        plataformaActual = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (sobreLaPlataforma && plataformaActual.isKinematic) 
        {
            if(Vector3.Distance(transform.position, posicioEsfera.position) > 2f)
            {
                plataformaActual.isKinematic = false;  
            }        
        }
        if (transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            posicioEsfera = collision.transform;
            if (!sobreLaPlataforma)
            {
                PlatformGenerator.Instancia.SeguentPlataforma();
                sobreLaPlataforma = true;

            }
        }
    }
}
