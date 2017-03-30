using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreamSoundManager : MonoBehaviour {

    public float FadeLenghtSeconds = 2;
    public AudioSource audio;
    public GameObject stream;
    private bool stopping = false;
    private float runtime = 0;

    

	// Update is called once per frame
	void Update () {
        if (stopping)
        {
            return;
        }

        if(stream != null)
        {
            if (stream.activeInHierarchy)
            {
                return;
            }
        }

        stopping = true;
        StartCoroutine(FadeSound());
	}

    IEnumerator FadeSound()
    {
        while (audio.volume > 0.01f)
        {
            runtime += Time.deltaTime;
            float t = runtime / FadeLenghtSeconds;
            audio.volume = Mathf.Lerp(1, 0, t);
            yield return null;
        }

        audio.Stop();
    }
}
