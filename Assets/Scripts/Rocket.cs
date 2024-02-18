using UnityEngine;

public class Rocket : MonoBehaviour
{

	public int damage = 10;
	public float speed = 20;
	public GameObject explosionPrefab;

	void Start()
	{
		Destroy(gameObject,3f);
	}

	void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject);


		Instantiate(explosionPrefab);

		var health = other.gameObject.GetComponent<Health>();
		if(health != null)
        {
			health.Damage(damage);
        }
	}
}