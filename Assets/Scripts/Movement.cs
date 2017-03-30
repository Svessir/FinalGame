using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float maxSpeed = 10;
    public float acceleration = 10;
    public float drag = 0.3f;
    public float reorientationFactor = 10;

    public bool inAir = false;
    private float gravity = 10f;
    private Rigidbody rb;


	private bool inMenu = false;
	private InGameMenuManager menu;
	private ShaderControl shaderControl;
	private PointToLight pointToLight;

	public bool lastScene = false;

	void Start () {
		menu = FindObjectOfType<InGameMenuManager> ();
		if (lastScene) { return; }
		shaderControl = FindObjectOfType<ShaderControl> ();
		pointToLight = FindObjectOfType<PointToLight> ();
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			ToggleMenu ();
		}
		if (inMenu || lastScene) {
			return;
		}
        WasdMove();
	}

	public void ToggleMenu() {
		inMenu = !inMenu;
		if (!lastScene) {
			shaderControl.inMenu = inMenu;
			pointToLight.animated = inMenu;
		}
		if (inMenu) {
			menu.StartMenu ();
		} else {
			menu.EndMenu ();
		}

	}


    void Reorient() {
		
        float angle = Vector3.Angle(transform.up, Vector3.up);
        rb.angularVelocity += new Vector3(0, 0, 1) * angle * reorientationFactor*Mathf.Sign(transform.up.x)*Time.deltaTime;
    }

    void WasdMove() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 dir = Vector2.zero;
        if (Mathf.Abs(x) > 0.05f || Mathf.Abs(y) > 0.05f)
        {
            dir = new Vector2(x, y).normalized;
        }
        Move(dir);
    }

    public float mouseBaseDist = 30;

    void MouseMove() {
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Vector2 diff = Input.mousePosition - center;
        diff /= mouseBaseDist;
        if (diff.magnitude > 1)
        {
            diff = diff.normalized;
        }
        Move(diff);
    }


    void Move(Vector2 dir)
    {
        Vector3 vel = rb.velocity;

        if (inAir)
        {
            vel -= new Vector3(0, gravity, 0) * Time.deltaTime;
        }
        else {
            Reorient();
            if (dir.magnitude < 0.5 || Vector3.Angle(dir, vel) > 90)
            {
                vel = vel - (vel * drag * Time.deltaTime);
            }
            vel = vel + new Vector3(dir.x, dir.y, 0) * Time.deltaTime * acceleration;
            if (vel.magnitude > maxSpeed)
            {
                vel = vel.normalized * maxSpeed;
            }
        }
        rb.velocity = vel;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Air") {
            inAir = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.transform.tag == "Air")
        {
            inAir = false;
        }
    }
}
