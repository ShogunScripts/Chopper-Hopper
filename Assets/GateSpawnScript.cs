using UnityEngine;

public class GateSpawnScript : MonoBehaviour
{
    public GameObject gate;
    public float spawnRate = 2;  // how many seconds it should be between spawns
    private float timer = 0;
    public float heightOffset = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnGate();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            spawnGate();
            timer = 0;
        }
    }

    void spawnGate()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(gate, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
