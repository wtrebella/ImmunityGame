using UnityEngine;
using System.Collections;

public class ImVirus : ImEntity {
	public float spread;
	public float power;
	
	public ImVirus(string name, float spread, float power) : base(name) {
		this.spread = spread;
		this.power = power;
	}
}
