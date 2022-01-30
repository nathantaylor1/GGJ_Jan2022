using UnityEngine;

public class BananaCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bananas"))
        {
            int number = col.gameObject.GetComponent<NumBananas>().GetNumBananas();
            Inventory.instance.AddBananas(number);
            Destroy(col.gameObject);
        }
    }
    
}
