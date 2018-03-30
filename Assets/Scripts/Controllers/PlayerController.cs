using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int MaxLife = 10;
    public int currentLife;

    private void Start()
    {
        currentLife = MaxLife;
    }

    public void GetDamage(int damage)
    {
        currentLife -= damage;
        if(currentLife < 1)
        {
            Destroy(gameObject);
        }
    }
}
