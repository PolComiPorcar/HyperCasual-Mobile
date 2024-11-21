using System;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public static PlayerController Instancia;
    public float vel;
    public bool dirALaDreta;
    public bool jocComencat;
    private bool viu = true;
    [SerializeField] private float IncrementVelocitat;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelActio;
    [SerializeField] private TMP_Text score;
    [SerializeField] private TMP_Text scoreTotal;
    [SerializeField] private TMP_Text TapToStart;
    private int numEscena = 0;
    private int puntuacio;
    private float velocitatMax = 12;

    private void OnEnable()
    {
        if (Instancia == null) Instancia = this;
        PlatformControl.CauPlataforma += AugmentarPuntuacio;

    }
    public void CanviarDireccio()
    {
        //per cada tap canviem la direccio
        if (!jocComencat)
        {
            jocComencat = true;
            TapToStart.text = "";
            TapToStart.enabled = false;
        }

        dirALaDreta = !dirALaDreta;
        if(vel < velocitatMax)
        {
            AugmentVelocitat();
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody> ();
        puntuacio = 0;
    }

    void Update()
    {
        //avançem la posicio del jugador en la direccio en la que esta
        if (jocComencat && viu)
        {
            if (dirALaDreta) rb.linearVelocity = (Vector3.right * vel) + Physics.gravity;
            else rb.linearVelocity = (Vector3.forward * vel) + Physics.gravity;
        }
        score.text = puntuacio.ToString();
        scoreTotal.text = puntuacio.ToString(); 
    }
    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador cau, mostrem el menu per reiniciar
        if (other.tag == "ZonaDeMort")
        {
            viu = false;
            rb.linearVelocity = Physics.gravity;
            panelGameOver.SetActive(true);
            panelActio.SetActive(false);
            score.enabled = false;
            Time.timeScale = 0;
        }
    }
    // sumem puntuacio
    private void AugmentarPuntuacio()
    {
        puntuacio++;
    }

    //reiniciar al clicar el boto
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(numEscena);
    }

    //augmentem dificultat 
    private void AugmentVelocitat()
    {
        vel = vel + IncrementVelocitat;
    }

}
