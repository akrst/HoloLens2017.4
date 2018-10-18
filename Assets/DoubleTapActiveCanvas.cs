using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

public class DoubleTapActiveCanvas : MonoBehaviour {
	public GameObject canvas;

	//GestureRecognizer使用準備
	UnityEngine.XR.WSA.Input.GestureRecognizer gestureRecognizer;

	void Start()
	{
		gestureRecognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
		gestureRecognizer.SetRecognizableGestures(UnityEngine.XR.WSA.Input.GestureSettings.DoubleTap);
		gestureRecognizer.TappedEvent += GestureRecognizer_TappedEvent;
		gestureRecognizer.StartCapturingGestures();
	}

	private void GestureRecognizer_TappedEvent(UnityEngine.XR.WSA.Input.InteractionSourceKind source, int tapCount, Ray headRay)
	{
		if (tapCount == 2)
		{
			if (canvas.activeSelf ==false) {
				canvas.SetActive(true);
			}
			else {
				canvas.SetActive(false);
			}
		}
	}
}
