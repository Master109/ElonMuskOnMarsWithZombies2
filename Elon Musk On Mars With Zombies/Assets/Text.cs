using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour
{
	float createTime;
	public float duration;
	public int endHeight;
	float riseRate;

	// Use this for initialization
	void Start ()
	{
		createTime = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void Update ()
	{
		riseRate = endHeight / duration * Time.deltaTime;
		transform.position += Vector3.up * riseRate;
		if (Time.timeSinceLevelLoad - createTime > duration)
			Destroy(gameObject);
	}
}
