using UnityEngine;

public class envMove : MonoBehaviour
{
    private Rigidbody rig;
    private float speed = 10f;

    public GameObject ground;
    public GameObject[] grounds = new GameObject[2];
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;

    public GameObject[] enemies;
    public GameObject[] sky;

    private float timer = 0f;
    private float timer2 = 0f;
    private float timer3 = 0f;

    private int lastObject;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.velocity = Vector3.left * speed;
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        timer3 += Time.deltaTime;
        if (timer >= 3.7f)
        {
            grounds[0] = grounds[1];
            grounds[1] = Instantiate(ground, spawn2);
            grounds[1].transform.parent = transform;
            GenEnemie();
            timer = 0f;
        }
        if (timer2 >= 2f / GameManager.GM.level)
        {
            GenEnemie();
            timer2 = 0f;
        }

        if (timer3 >= 0.4f)
        {
            GenSky();
            timer3 = 0f;
        }
    }

    private void GenEnemie()
    {
        int id = Random.Range(0, 4);
        if (lastObject == 0) id = Random.Range(1, 4);
        GameObject enemie = Instantiate(enemies[id], spawn1);
        lastObject = id;
        float z = Random.Range(1.5f, -4.5f);
        if (id != 0)
        {
            enemie.transform.position = new Vector3(enemie.transform.position.x, enemie.transform.position.y, z);
        }
        enemie.transform.parent = transform;
    }

    private void GenSky()
    {
        int id = Random.Range(0, 4);
        GameObject sky2 = Instantiate(sky[id], spawn3);
        float z = Random.Range(40f, -40f);
        sky2.transform.position = new Vector3(sky2.transform.position.x, sky2.transform.position.y, z);
        sky2.transform.parent = transform;
    }
}
