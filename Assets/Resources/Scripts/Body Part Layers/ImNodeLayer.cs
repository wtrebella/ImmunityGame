using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImNodeLayer : ImAbstractBodyPartLayer {	
	public ImNodeLayer(WTImmunity owner) : base(owner) {		
		for (int i = 0; i < (int)(NodePlacement.MAX - 1); i++) {
			ImBodyPart node = new ImBodyPart(NodeType.NormalNode, 0, 0.25f, new Color(0.5f, 0, 0, 1));
			
			node.nodeComponent.nodePlacement = (NodePlacement)(i + 1);
			Vector2 pos = PositionForNodePlacement(node.nodeComponent.nodePlacement);
			node.spriteComponent.PlaceSpriteAt(pos.x, pos.y);
			
			node.nodeComponent.SignalHealthChanged += BodyPartHealthChanged;
			bodyParts.Add(node);
			AddChild(node.spriteComponent.sprite);
		}
	}
	
	public static Vector2 PositionForNodePlacement(NodePlacement placement) {
		float maxWidth = 105 * 1.3f;
		float maxHeight = 305 * 1.3f;
		
		switch (placement) {
		case NodePlacement.Brain:
			return new Vector2(-0.076f * maxWidth, 0.99f * maxHeight);
		case NodePlacement.ElbowLeft:
			return new Vector2(-0.79f * maxWidth, 0.267f * maxHeight);
		case NodePlacement.ElbowRight:
			return new Vector2(0.695f * maxWidth, 0.262f * maxHeight);
		case NodePlacement.FootLeft:
			return new Vector2(-0.457f * maxWidth, -0.983f * maxHeight);
		case NodePlacement.FootRight:
			return new Vector2(0.79f * maxWidth, -1.0f * maxHeight);
		case NodePlacement.HandLeft:
			return new Vector2(-1.0f * maxWidth, -0.141f * maxHeight);
		case NodePlacement.HandRight:
			return new Vector2(0.981f * maxWidth, -0.121f * maxHeight);
		case NodePlacement.Heart:
			return new Vector2(0.029f * maxWidth, 0.475f * maxHeight);
		case NodePlacement.HipLeft:
			return new Vector2(-0.381f * maxWidth, -0.148f * maxHeight);
		case NodePlacement.HipRight:
			return new Vector2(0.352f * maxWidth, -0.125f * maxHeight);
		case NodePlacement.Intestines:
			return new Vector2(-0.029f * maxWidth, 0.033f * maxHeight);
		case NodePlacement.KneeLeft:
			return new Vector2(-0.41f * maxWidth, -0.498f * maxHeight);
		case NodePlacement.KneeRight:
			return new Vector2(0.524f * maxWidth, -0.485f * maxHeight);
		case NodePlacement.Liver:
			return new Vector2(-0.114f * maxWidth, 0.338f * maxHeight);
		case NodePlacement.LungLeft:
			return new Vector2(-0.333f * maxWidth, 0.508f * maxHeight);
		case NodePlacement.LungRight:
			return new Vector2(0.352f * maxWidth, 0.518f * maxHeight);
		case NodePlacement.Neck:
			return new Vector2(-0.076f * maxWidth, 0.744f * maxHeight);
		case NodePlacement.ShoulderLeft:
			return new Vector2(-0.686f * maxWidth, 0.59f * maxHeight);
		case NodePlacement.ShoulderRight:
			return new Vector2(0.552f * maxWidth, 0.63f * maxHeight);
		case NodePlacement.Stomach:
			return new Vector2(0.219f * maxWidth, 0.256f * maxHeight);
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
