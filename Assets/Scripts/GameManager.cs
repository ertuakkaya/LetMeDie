using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public float counter = 5f;
    private BloodController bloodController;

    private void Start()
    { 
        bloodController = BloodController.Instance;
    }

    private void FixedUpdate()
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
