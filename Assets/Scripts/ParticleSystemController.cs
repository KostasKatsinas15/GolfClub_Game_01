using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private ParticleSystem pSystem_01;
    [SerializeField] private ParticleSystem pSystem_02;

    [SerializeField] private Transform club;
    private Vector3 movementDirection;
    private Vector3 lastPosition;
    private float zValue;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GolfClub")
        {
            pSystem_02.Play();

            pSystem_01.transform.position = other.transform.position;
            pSystem_01.Play();
        }
    }

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("GolfClub"))
		{
			pSystem_02.Stop();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.CompareTag("GolfClub"))
		{
            //determine club movement direction
            movementDirection = club.position - lastPosition;
            zValue = movementDirection.z;
            lastPosition = club.position;

            //backward
            if (zValue < 0)
            {
                pSystem_02.transform.rotation = Quaternion.Euler(
                    pSystem_02.transform.rotation.x,
                    180,
                    pSystem_02.transform.rotation.z
                    );
			}
			else //forward
			{
                pSystem_02.transform.rotation = Quaternion.Euler(
                    pSystem_02.transform.rotation.x,
                    0,
                    pSystem_02.transform.rotation.z
                    );
            }
        }
    }
}
