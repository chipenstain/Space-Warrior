using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private float timer = 0f;
    public GameObject bullet;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.9f)
        {
            Instantiate(bullet, transform);
            timer = 0f;
        }
    }
}
