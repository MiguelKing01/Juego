using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void FinalScene()
    {
        SceneManager.LoadScene("Principal");
    }

    public void changeScene()
    {
        SceneManager.LoadScene("nivel1"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
