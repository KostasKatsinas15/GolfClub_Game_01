using UnityEngine;
using System.Collections;

public class GolfBall : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float hitForceMultiplier;
    [SerializeField] private Transform shootDirection;
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private GolfBallSpawner spawner;
    private bool hasPlayed = false;
    [SerializeField] private GolfClub club;

    [SerializeField] private ParticleSystem dirtSplashBurst;
    [SerializeField] private ParticleSystem dirtSplashBehind;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GolfClub")
        {
            if (club.clubIsSwinging)
            {
                rb.AddForce(shootDirection.forward * hitForceMultiplier);
                if (!club.audioSource.isPlaying)
                {
                    club.audioSource.Play();
                }
                dirtSplashBurst.Play();
                dirtSplashBehind.Play();
            }
        }

        if (other.tag == "Catcher")
        {
            if (!hasPlayed)
            {
                confetti.transform.position = gameObject.transform.position;

                if (!confetti.gameObject.activeSelf)
                {
                    confetti.gameObject.SetActive(true);
                }
                confetti.Play();

                GetComponent<AudioSource>().Play();
                hasPlayed = true;
            }
            StartCoroutine(DestroyGolfBallDelayed(4f));
        }
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            StartCoroutine(DestroyGolfBallDelayed(0));
        }
    }

    private IEnumerator DestroyGolfBallDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        spawner.golfBalls.Remove(gameObject);
    }
}
