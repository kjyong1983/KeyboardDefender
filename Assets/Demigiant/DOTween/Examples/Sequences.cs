using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Sequences : MonoBehaviour
{
	public Transform target, target02;

	void Start()
	{
		// FIRST OF ALL, note this!
		// Sequences contain and animate other tweens,
		// but they DON'T need to be one after each other:
		// you can overlap them how you want :)

		// Let's create a Sequence which will first rotate AND move the target's Y at the same time,
		// then when the move + rotation is finished it will scale it.
		// Also, during all the tween, we will make sure that the target also moves on the X axis.

		// Create new Sequence object
		Sequence mySequence = DOTween.Sequence();
		// Add a 1 second move tween only on the Y axis
		mySequence.Append(target.DOMoveY(2, 1));
		// Add a 1 second rotation tween, using Join so it will start when the previous one starts
		mySequence.Join(target.DORotate(new Vector3(0, 135, 0), 1));
		// Add a 1 second scale Y tween, using Append so it will start after the previously added tweens end
		mySequence.Append(target.DOScaleY(0.2f, 1));
		// Add an X axis relative move tween that will start from the beginning of the Sequence
		// and last for the whole Sequence duration
		mySequence.Insert(0, target.DOMoveX(4, mySequence.Duration()).SetRelative());

		// Oh, and let's also make the whole Sequence loop backward and forward 4 times
		mySequence.SetLoops(4, LoopType.Yoyo);

	}

	void Update()
	{
		Sequence mySequence2;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			// Debug.Log("boing");
			mySequence2 = DOTween.Sequence();
			//mySequence2.Append(target02.DOScaleY(2,.5f));
			// mySequence2.Append(target02.DOShakeScale(.2f,1,30,90,true));
			mySequence2.Append(target02.DOPunchScale(Vector3.up*2, 1, 10, 0));
			mySequence2.Append(target02.DOScaleY(1,.1f));
			// mySequence2.SetLoops(-1, LoopType.Restart);
		
		}
	}
}