using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public static PlatformGenerator Instancia;
    [SerializeField] private GameObject plataformaObj;
    [SerializeField] private Transform plataformaActual;
    [SerializeField] private int nPlataformes;
    private int direccio;
 

    private void OnEnable()
    {
        if (Instancia == null) Instancia = this;
    }

    void Start()
    {
        GenerarPlataformes();
    }
    
    void GenerarPlataformes()
    {
        for (int i = 0; i < nPlataformes; i++)
        {
            SeguentPlataforma();
        }
    }
    public void SeguentPlataforma()
    {
        direccio = Random.Range(0, 2);

        if (direccio == 1) plataformaActual = Instantiate(plataformaObj, plataformaActual.position + Vector3.right * 2, Quaternion.identity).transform;
        else plataformaActual = Instantiate(plataformaObj, plataformaActual.position + Vector3.forward * 2, Quaternion.identity).transform;

    }
}
