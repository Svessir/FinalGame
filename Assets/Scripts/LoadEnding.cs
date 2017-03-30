using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadEnding : MonoBehaviour {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.contacts[0].otherCollider.gameObject.tag == "Player")
            {
                SceneManager.LoadScene("Ending");
            }

        }
}
