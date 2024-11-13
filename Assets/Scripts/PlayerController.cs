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
        if (!jocComencat) jocComencat = true;

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
        if (other.tag == "ZonaDeMort")
        {
            viu = false;
            rb.linearVelocity = Physics.gravity;
            panelGameOver.SetActive(true);
            panelActio.SetActive(false);
            score.enabled = false;
        }
    }
    private void AugmentarPuntuacio()
    {
        puntuacio++;
    }

    public void Restart()
    {
        SceneManager.LoadScene(numEscena);
    }

    private void AugmentVelocitat()
    {
        vel = vel + IncrementVelocitat;
    }

}
