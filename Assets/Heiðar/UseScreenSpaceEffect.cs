//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//[ExecuteInEditMode]
//public class UseScreenSpaceEffect : MonoBehaviour {
//
//	public Material effect;
//
//	private void OnRenderImage(RenderTexture sourceImage, RenderTexture destinationImage) {
//		Graphics.Blit (sourceImage, destinationImage, effect);
//	}
//}


using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class UseScreenSpaceEffect : MonoBehaviour {

	public Material effect;

	void OnRenderImage(RenderTexture source, RenderTexture destination) {
		Graphics.Blit(source, destination, effect);
	}
}