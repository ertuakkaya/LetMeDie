using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private BloodController bloodController;
    public float counter = 5f; 

    void Start()
    {
        bloodController = player.GetComponent<BloodController>();
    }
     
    void FixedUpdate()
    {
        PeridocialBloodDecrease();
    }

    private void PeridocialBloodDecrease()
    {
        // {counter} saniyede bir -2 can azalt.
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            bloodController.ChangeBlood(-2);
            counter = 5f;
        }
    }
}
