using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInventory : MonoBehaviour
{
    private static bool tieneCigarrillo = false;
    private static bool tieneEncendedor = false;

    public TextMeshProUGUI cigarrilloText;
    public TextMeshProUGUI encendedorText;

    public bool isPlayer2 = false;

    private void Awake()
    {
        tieneCigarrillo = false;
        tieneEncendedor = false;
    }
    public void RecogerCigarrillo()
    {
        if (isPlayer2)
        {
            tieneCigarrillo = true;
        }
    }

    public void RecogerEncendedor()
    {
        if (!isPlayer2)
        {
            tieneEncendedor = true;
        }
    }

    public void Ganaste()
    {
        if (tieneCigarrillo && tieneEncendedor)
        {
            SceneManager.LoadScene("Nivel2");
        }
    }

    public void GanasteScene()
    {
        if (tieneCigarrillo && tieneEncendedor)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Nivel1")
            {
                Ganaste();
            }
            if (SceneManager.GetActiveScene().name == "Nivel2")
            {
                GanasteScene();
            }
        }
    }

    private void Update()
    {
        if (cigarrilloText != null)
            cigarrilloText.text = tieneCigarrillo ? "1" : "0";

        if (encendedorText != null)
            encendedorText.text = tieneEncendedor ? "1" : "0";
    }
}