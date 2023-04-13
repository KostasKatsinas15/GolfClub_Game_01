using UnityEngine;
using System.Collections;

public class GolfClub : MonoBehaviour
{
    private Animator animator;
    public bool clubIsSwinging;
    [HideInInspector] public AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("HitBall", 0, 0);
            clubIsSwinging = true;
            StartCoroutine(SwitchStateBackDelayed());
        }
    }

    private IEnumerator SwitchStateBackDelayed()
    {
        yield return new WaitForSeconds(1);
        clubIsSwinging = false;
    }
}
