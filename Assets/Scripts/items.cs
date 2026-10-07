using UnityEngine;

public class items : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum TipoItem { Cigarrillo, Encendedor }
    public TipoItem tipo;
    public bool isPlayer2 = false;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerInventory inventario = collider.GetComponent<PlayerInventory>();
        if (inventario == null)
        {
            Debug.LogWarning("El objeto Player no tiene el script PlayerInventory.");
            return;
        }
        switch (tipo)
        {
            case TipoItem.Cigarrillo:
                inventario.RecogerCigarrillo();
                break;
            case TipoItem.Encendedor:
                inventario.RecogerEncendedor();
                break;
        }

        gameObject.SetActive(false); // el item desaparece de la escena
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
