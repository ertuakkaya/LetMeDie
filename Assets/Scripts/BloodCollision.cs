using UnityEngine;

public class BloodCollision : MonoBehaviour
{
    // Bu script kan al�nacak yerlere tak�lacak.

    public int bloodAmount = -1;
    private BloodController bloodController; 

    private void Start()
    {
        if (bloodAmount == -1)
        {
            Debug.LogError($"{this.gameObject.name} nesnesindeki kan de�eri set edilmemi�! Aray�zden set edin.");
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
