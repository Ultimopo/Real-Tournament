using UnityEngine;

public class Rocket : MonoBehaviour
{

	public int damage = 10;
	public float speed = 20;

	public GameObject explosionPrefab;


	public int bounceCount;
	public bool HasGravity;
	public bool velocityOn;
	Rigidbody rb;


	void Start()
	{
		Destroy(gameObject,3f);
		 rb = GetComponent<Rigidbody>();
		if (!HasGravity && velocityOn)
		{
			rb.AddForce(transform.forward.normalized * 700);
			velocityOn = false;
		}

	}

	void Update()
	{
		if (HasGravity)
        {
			transform.position += transform.forward * speed * Time.deltaTime;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		//Destroy(gameObject);



		var health = other.gameObject.GetComponent<Health>();
		if(health != null)
        {
			health.Damage(damage);
        }
		if (bounceCount > 0)
        {
			transform.forward = other.contacts[0].normal;
			bounceCount--;
        }
		else
        {
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
        }
	}
}