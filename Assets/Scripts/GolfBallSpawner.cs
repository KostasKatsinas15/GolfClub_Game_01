using System.Collections.Generic;
using UnityEngine;

public class GolfBallSpawner : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private GameObject golfBall;
    [SerializeField] public List<GameObject> golfBalls;

    private void Start()
    {
        golfBalls = new List<GameObject>();
        SpawnBall();
    }

    private void Update()
    {
        if (golfBalls.Count <= 0)
        {
            SpawnBall();
        }

        if (golfBalls.Count > 2)
        {
            foreach (GameObject item in golfBalls) Destroy(item.gameObject);
            golfBalls.Clear();
        }
    }

    private void SpawnBall()
    {
        GameObject ball = Instantiate(golfBall, respawnPoint.position, respawnPoint.rotation, gameObject.transform);
        ball.GetComponent<MeshRenderer>().enabled = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;
        golfBalls.Add(ball);
    }
}
