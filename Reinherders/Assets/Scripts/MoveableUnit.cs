using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableUnit : Unit {
    public System.Nullable<Vector3> destination;
    public float speed = 0.1f;

	void Start () {
        destination = null;
	}

	void Update() {
		if (destination != null)
        {
            transform.position = Vector3.Lerp(transform.position, (Vector3)destination, speed * Time.deltaTime);
        }
	}
}
