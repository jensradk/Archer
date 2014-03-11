using UnityEngine;
using System.Collections;

public class LightFading : MonoBehaviour
{
	private SpriteRenderer sr;

	public float alphaMin = 0.2f;
	public float alphaMax = 0.9f;

	public float sinPeriod = 13.0f;

	private float timer;

	// Use this for initialization
	void Start()
	{
		this.sr = this.GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update()
	{
		if( this.sr != null )
		{
			this.timer += Time.deltaTime;
			while( this.timer > sinPeriod )
				this.timer -= sinPeriod;

			float mid = alphaMin + ( alphaMax / 2.0f );
			float newAlpha = mid + ( Mathf.Sin( this.timer / sinPeriod ) * ( alphaMax - alphaMin );

			this.sr.color = new Color( 1.0f, 1.0f, 1.0f, newAlpha );
		}
	}
}
