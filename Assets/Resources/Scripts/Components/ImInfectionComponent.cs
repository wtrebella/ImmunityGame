using UnityEngine;
using System.Collections;
using System;

public class ImInfectionComponent : ImAbstractComponent {
	public ImVirus virus;
	public float infectionPercent = 0; // 0 to 1
	public event Action<ImInfectionComponent> SignalInfectionPercentChanged;
	public bool hasStartedInfecting = false;
	
	public ImInfectionComponent(string name, ImVirus virus) : base(name) {
		componentType_ = ComponentType.Infection;
		
		this.virus = virus;
	}
	
	override public void HandleUpdate() {
		base.HandleUpdate();
		
		if (!hasStartedInfecting) return;
		
		if (infectionPercent < 1f) {
			infectionPercent += virus.power * Time.deltaTime;
			if (SignalInfectionPercentChanged != null) SignalInfectionPercentChanged(this);
		}
	}
	
	public void StartInfecting() {
		hasStartedInfecting = true;
	}
}
