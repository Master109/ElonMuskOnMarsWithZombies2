using UnityEngine;
using System.Collections;

public class Barricade : MonoBehaviour
{
	public float buildTime;
	public int buildDistance;
	float buildTimer;
	public int cost;
	public float hp;

	// Use this for initialization
	void Start ()
	{
		collider.enabled = false;
		GetComponent<NavMeshObstacle>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < buildDistance)
			buildTimer += Time.deltaTime;
		if (buildTimer > buildTime && buildTimer - Time.deltaTime < buildTime)
		{
			collider.enabled = true;
			GetComponent<NavMeshObstacle>().enabled = true;
			rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
			transform.GetChild(0).renderer.material.color = new Color(transform.GetChild(0).renderer.material.color.r, transform.GetChild(0).renderer.material.color.g, transform.GetChild(0).renderer.material.color.b, 1);
		}
		if (rigidbody.velocity.y > 0)
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, rigidbody.velocity.z);
	}

	void OnCollisionEnter (Collision collision)
	{
		//Debug.Log("YAY");
		if (collision.gameObject.name == "Terrain")
			rigidbody.constraints = RigidbodyConstraints.FreezeAll;
	}
}
