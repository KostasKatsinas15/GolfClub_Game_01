using UnityEngine;
public class ClubController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    private Vector3 controlPoinInitPosition;
	private void Start()
	{
        //Cursor.visible = false;
        controlPoinInitPosition = transform.position;
	}

	private void Update()
	{
        transform.position = new Vector3(controlPoinInitPosition.x, controlPoinInitPosition.y, transform.position.z);
	}
	private void OnMouseDown()
	{
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

	private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
