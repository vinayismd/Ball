using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initializati

	public Text countText;
	public Text winText;
	public float speed;

	private Rigidbody rb;
	private int count;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		count = 0;
		countText.text = "Count :" + count.ToString();
		winText.text = "";

	}
	
	// Update is called once per frame
	void FixedUpdate() {
	   
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			float movehor = Input.GetAxis ("Horizontal");
			float movever = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (movehor, 0.0f, movever);

			rb.AddForce (movement * 10 );
		} else {
			float movehor = Input.acceleration.x;
			float movever = Input.acceleration.y;

			Vector3 movement = new Vector3 (movehor, 0.0f, movever);
			rb.AddForce(movement * 10);
		
		}
	}

	void OnTriggerEnter(Collider other){
	  if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive(false);
			count++;
			countText.text = "Count :" + count.ToString();
			if(count>=8){
				winText.text="YOU WIN!!!";
			}
	}
}



}
