using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float m_pan_Speed = 30f;
	public float m_zoom_Speed = 5f;
	public float m_border_Thickness = 10f;
	public float m_pan_maximum_Range = 50f;
	public Vector2 m_zoom_Range = new Vector2(10f, 40f);

	private Vector3 m_start_transform;	//default transform
	private Vector3 m_pan_maximum_distance;	//maximum distance camera can move along x and z axists
	private bool can_Move = true;

	void Awake()
	{
		m_start_transform = transform.position;
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
			can_Move = !can_Move;

		if (!can_Move)
			return;
		
		if ((Input.GetKey (KeyCode.W) || Input.mousePosition.y > Screen.height - m_border_Thickness) &&
			(transform.position.z < m_start_transform.z + m_pan_maximum_Range))	{
			transform.Translate (Vector3.forward * m_pan_Speed * Time.deltaTime, Space.World);
		}

		if ((Input.GetKey (KeyCode.S) || Input.mousePosition.y < m_border_Thickness) &&
			(transform.position.z > m_start_transform.z - m_pan_maximum_Range))	{
			transform.Translate (Vector3.back * m_pan_Speed * Time.deltaTime, Space.World);
		}

		if ((Input.GetKey (KeyCode.A) || Input.mousePosition.x < m_border_Thickness) &&
			(transform.position.x > m_start_transform.x - m_pan_maximum_Range))	{
			transform.Translate (Vector3.left * m_pan_Speed * Time.deltaTime, Space.World);
		}

		if ((Input.GetKey (KeyCode.D) || Input.mousePosition.x > Screen.width - m_border_Thickness) &&
			(transform.position.x < m_start_transform.x + m_pan_maximum_Range))	{
			transform.Translate (Vector3.right * m_pan_Speed * Time.deltaTime, Space.World);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && transform.position.y < m_start_transform.y + m_zoom_Range.x) {
			transform.Translate (Vector3.up * Input.GetAxis ("Mouse ScrollWheel") * m_zoom_Speed * Time.deltaTime * 100f, Space.World);
			Debug.Log ("zoom out");
		}

		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && transform.position.y > m_start_transform.y - m_zoom_Range.y) {
			transform.Translate (Vector3.up * Input.GetAxis ("Mouse ScrollWheel") * m_zoom_Speed * Time.deltaTime * 100f, Space.World);
			Debug.Log ("zoom in");
		}
	}
}
