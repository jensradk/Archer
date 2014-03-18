using UnityEngine;
using System.Collections;

public class LightFading : MonoBehaviour
{
	private SpriteRenderer sr;

	public float alphaMin = 0.2f;
	public float alphaMax = 0.9f;
	
	private float alphaRangeHalf;
	private float alphaMid;

	public float sinPeriod = 2.0f;

	private float timer;

	// Use this for initialization
	void Start()
	{
		this.sr = this.GetComponent<SpriteRenderer>();
		this.alphaRangeHalf = ( this.alphaMax - this.alphaMin ) / 2.0f;
		this.alphaMid = this.alphaMin + this.alphaRangeHalf;
	}

	// Update is called once per frame
	void Update()
	{
		if( this.sr != null )
		{
			this.timer += Time.deltaTime;
			while( this.timer > sinPeriod )
			    this.timer -= sinPeriod;

			float newAlpha = this.alphaMid + ( Mathf.Sin( ( this.timer / this.sinPeriod ) * Mathf.PI * 2.0f ) * ( this.alphaRangeHalf ) );
			
			this.sr.color = new Color( 1.0f, 1.0f, 1.0f, newAlpha );
		}
	}
}
