using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour, IPickupable {

	[SerializeField] private GameObject tracer;
	private float offset;
	private Vector2 dir;
	private float range = 10;
	private float damage = 1;
	[SerializeField]
	private LayerMask shootableMask;

	private float roundPerSecond = 5;
	private float SecondBetweenShots {
		get {
			return 1f / roundPerSecond;
		}
	}
	private float lastShootTime;

	void Start() {
	}
	
	void Update() {

	}

	public void PointTo(Vector2 dir) {
		this.dir = dir;
		transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + offset);
	}

	public void Shoot() {
		if (Time.time - lastShootTime < SecondBetweenShots) return;
		RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, range, shootableMask);
		LineRenderer tracerLr = Instantiate(tracer, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
		tracerLr.SetPosition(0, transform.position);
		if (hit) {
			IHitable hitable = hit.transform.GetComponent<IHitable>();
			if(hitable != null)
				hitable.Hit(damage);
			tracerLr.SetPosition(1, hit.point);
		} else {
			tracerLr.SetPosition(1, (Vector2)transform.position + dir * range);
		}
		lastShootTime = Time.time;
	}

	public void Dropped() {

	}

	public void PickedUp() {

	}
}
