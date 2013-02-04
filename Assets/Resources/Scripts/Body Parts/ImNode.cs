using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNode : ImEntity {
	public NodePlacement nodePlacement = NodePlacement.None;
	
	public ImNode(NodePlacement nodePlacement, string name = "a node") : base(name) {		
		name = string.Format("node: a node at " + ImConfig.NameForNodePlacement(nodePlacement));
		
		this.nodePlacement = nodePlacement;
		
		ImSpriteComponent sc = new ImSpriteComponent("baseSpriteComponent", "circle.psd");
		sc.sprite.scale = 0.25f;
		sc.sprite.color = Color.blue;
		AddComponent(sc);
		
		ImRadialWipeSpriteComponent ssc = new ImRadialWipeSpriteComponent("diseaseRadialWipeComponent", "circle.psd");
		ssc.sprite.scale = 0.25f;
		ssc.sprite.color = Color.red;
		ssc.sprite.percentage = 0;
		AddComponent(ssc);
		
		AddComponent(new ImHealthComponent("healthComponent", 100));
	}
	
	override public void HandleUpdate() {
		base.HandleUpdate();
	}
	
	public ImOrgan CorrespondingOrganInOrganLayer(ImOrganLayer organLayer) {
		OrganType organType = ImConfig.OrganTypeForNodePlacement(nodePlacement);
		return organLayer.OrganForType(organType);
	}
	
	public List<ImVein> CorrespondingVeinsInVeinLayer(ImVeinLayer veinLayer) {
		return veinLayer.VeinsForNodePlacement(nodePlacement);
	}
	
	public bool ContainsGlobalPoint(Vector2 point) {
		return SpriteComponents()[0].SpriteContainsGlobalPoint(point);	
	}
	
	override public void HandleInfectionPercentChanged(ImInfectionComponent infectionComponent) {
		base.HandleInfectionPercentChanged(infectionComponent);
		RadialWipeSpriteComponents()[0].sprite.percentage = infectionComponent.infectionPercent;
		if (infectionComponent.infectionPercent == 1) {
			ImOrgan organ = CorrespondingOrganInOrganLayer(WTImmunity.instance.organLayer);
			if (organ != null) organ.SpriteComponents()[0].sprite.color = Color.red;
		}
	}
}
