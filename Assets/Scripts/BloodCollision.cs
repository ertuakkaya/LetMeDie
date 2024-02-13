using UnityEngine;

public class BloodCollision : MonoBehaviour
{
    // Bu script kan alýnacak yerlere takýlacak.

    public int bloodAmount = -1;
    private BloodController bloodController; 

    private void Start()
    {
        if (bloodAmount == -1)
        {
            Debug.LogError($"{this.gameObject.name} nesnesindeki kan deðeri set edilmemiþ! Arayüzden set edin.");
        }

        bloodController = (BloodController)FindObjectOfType<BloodController>();
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bloodController.ChangeBlood(bloodAmount);
            Destroy(this.gameObject);
        }
    }
}
