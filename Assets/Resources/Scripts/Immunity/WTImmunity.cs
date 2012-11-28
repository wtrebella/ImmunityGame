//#define DEBUG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WTImmunity : FStage, FSingleTouchableInterface {
	public ImOrganLayer organLayer;
	public ImNodeLayer nodeLayer;
	ImBodyPart currentOrgan;

	public WTImmunity() : base("") {	
		FSprite sprite = new FSprite("body.png");
		sprite.scale = 0.6f;
		sprite.x = Futile.screen.halfWidth;
		sprite.y = Futile.screen.halfHeight;
		AddChild(sprite);
		
		organLayer = new ImOrganLayer(this);
		organLayer.x = Futile.screen.halfWidth;
		organLayer.y = Futile.screen.halfHeight;
		AddChild(organLayer);
		
		nodeLayer = new ImNodeLayer(this);
		nodeLayer.x = Futile.screen.halfWidth;
		nodeLayer.y = Futile.screen.halfHeight;
		AddChild(nodeLayer);
		
		ConnectLayers();
	}

	override public void HandleAddedToStage() {
		base.HandleAddedToStage();
		Futile.touchManager.AddSingleTouchTarget(this);
	}
	
	override public void HandleRemovedFromStage() {
		base.HandleRemovedFromStage();
		Futile.touchManager.RemoveSingleTouchTarget(this);
	}
	
	private void ConnectLayers() {
		organLayer.OrganForType(OrganType.Brain).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.Brain);
		organLayer.OrganForType(OrganType.Heart).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.Heart);
		organLayer.OrganForType(OrganType.Intestines).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.Intestines);
		organLayer.OrganForType(OrganType.Liver).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.Liver);
		organLayer.OrganForType(OrganType.LungLeft).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.LungLeft);
		organLayer.OrganForType(OrganType.LungRight).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.LungRight);
		organLayer.OrganForType(OrganType.Stomach).organComponent.correspondingNode = nodeLayer.NodeForPlacement(NodePlacement.Stomach);
		
		nodeLayer.NodeForPlacement(NodePlacement.Brain).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.Brain);
		nodeLayer.NodeForPlacement(NodePlacement.Heart).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.Heart);
		nodeLayer.NodeForPlacement(NodePlacement.Intestines).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.Intestines);
		nodeLayer.NodeForPlacement(NodePlacement.Liver).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.Liver);
		nodeLayer.NodeForPlacement(NodePlacement.LungLeft).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.LungLeft);
		nodeLayer.NodeForPlacement(NodePlacement.LungRight).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.LungRight);
		nodeLayer.NodeForPlacement(NodePlacement.Stomach).nodeComponent.correspondingOrgan = organLayer.OrganForType(OrganType.Stomach);
	}
	
	public bool HandleSingleTouchBegan(FTouch touch) {
		foreach (ImBodyPart node in nodeLayer.bodyParts) {
			if (node.spriteComponent.SpriteContainsGlobalPoint(touch.position)) {
				node.nodeComponent.health -= Random.Range(1, 50);
				return true;
			}
		}
		
		bool touchedOrgan = false;
		foreach (ImBodyPart organ in organLayer.bodyParts) {
			if (organ.spriteComponent.SpriteContainsGlobalPoint(touch.position)) {
				touchedOrgan = true;
				if (currentOrgan != null) {
					if (currentOrgan == organ) break;
					currentOrgan.isSelected = false;
					currentOrgan = null;
				}
				currentOrgan = organ;
				currentOrgan.isSelected = true;
				return true;
			}
		}
		if (!touchedOrgan && currentOrgan != null) {
			currentOrgan.isSelected = false;
			currentOrgan = null;
		}
		
		return false;
	}
	
	public void HandleSingleTouchMoved(FTouch touch) {

	}
	
	public void HandleSingleTouchEnded(FTouch touch) {

	}
	
	public void HandleSingleTouchCanceled(FTouch touch) {
		
	}
}
