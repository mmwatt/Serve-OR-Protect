using UnityEngine;

public class CameraController : MonoBehaviour
{

	private Camera m_Camera;                        // Used for referencing the camera.
	private Vector3 startPosition;
	public float leftLimit;
	public float rightLimit;

	void Start(){
		startPosition = transform.position;
	}
	private void Awake ()
	{
		m_Camera = GetComponentInChildren<Camera> ();
	}


	void Update ()
	{
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);

	}
		
}