using TMPro;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public delegate void sumarPuntuacio();
    public static event sumarPuntuacio CauPlataforma;
    private bool sobreLaPlataforma;
    private Rigidbody plataformaActual;
    private Transform posicioEsfera;
    [SerializeField] private TMP_Text score;
    private void Start()
    {
        plataformaActual = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        if (sobreLaPlataforma && plataformaActual.isKinematic) 
        {
            //fem caure les plataformes un cop superades
            if(Vector3.Distance(transform.position, posicioEsfera.position) > 2f)
            {
                plataformaActual.isKinematic = false;
                //sumem puntuacio per plataforma eliminada
                CauPlataforma?.Invoke();
            }        
        }
        if (transform.position.y < -10f)
        {
           //eliminem les plataformes un cop no estan en pantalla
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
