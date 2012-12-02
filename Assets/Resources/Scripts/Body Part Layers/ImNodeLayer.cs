using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractBodyPartLayer {	
	public ImNodeLayer(WTImmunity owner) : base(owner) {		
		for (int i = 0; i < (int)(NodePlacement.MAX - 1); i++) {
			ImBodyPart node = new ImBodyPart(NodeType.NormalNode, 0, 0.13f, new Color(0.5f, 0, 0, 1));
			
			node.nodeComponent.nodePlacement = (NodePlacement)(i + 1);
			Vector2 pos = PositionForNodePlacement(node.nodeComponent.nodePlacement);
			node.spriteComponent.PlaceSpriteAt(pos.x, pos.y);
			
			node.nodeComponent.SignalHealthChanged += BodyPartHealthChanged;
			bodyParts.Add(node);
			AddChild(node.spriteComponent.sprite);
		}
	}
	
	public static Vector2 PositionForNodePlacement(NodePlacement placement) {
		switch (placement) {
		case NodePlacement.Brain:
			return new Vector2(-5, 181);
		case NodePlacement.ElbowLeft:
			return new Vector2(-50, 43);
		case NodePlacement.ElbowRight:
			return new Vector2(44, 48);
		case NodePlacement.FootLeft:
			return new Vector2(-29, -180);
		case NodePlacement.FootRight:
			return new Vector2(50, -183);
		case NodePlacement.HandLeft:
			return new Vector2(-63, -25);
		case NodePlacement.HandRight:
			return new Vector2(62, -22);
		case NodePlacement.Heart:
			return new Vector2(2, 87);
		case NodePlacement.HipLeft:
			return new Vector2(-24, -27);
		case NodePlacement.HipRight:
			return new Vector2(22, -23);
		case NodePlacement.Intestines:
			return new Vector2(-2, 6);
		case NodePlacement.KneeLeft:
			return new Vector2(-26, -91);
		case NodePlacement.KneeRight:
			return new Vector2(33, -89);
		case NodePlacement.Liver:
			return new Vector2(-7, 62);
		case NodePlacement.LungLeft:
			return new Vector2(-21, 93);
		case NodePlacement.LungRight:
			return new Vector2(22, 95);
		case NodePlacement.Neck:
			return new Vector2(-5, 136);
		case NodePlacement.ShoulderLeft:
			return new Vector2(-43, 108);
		case NodePlacement.ShoulderRight:
			return new Vector2(35, 115);
		case NodePlacement.Stomach:
			return new Vector2(14, 47);
		default:
			Debug.Log("Bad nodePlacement");
			return new Vector2(0, 0);
		}
	}
	
	public ImBodyPart NodeForPlacement(NodePlacement placement) {
		foreach (ImBodyPart node in bodyParts) {
			if (node.nodeComponent.nodePlacement == placement) return node;		
		}
		return null;
	}
}
