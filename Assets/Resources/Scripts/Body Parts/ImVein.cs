using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImVein : ImEntity {
	public VeinEndpoints veinEndpoints = new VeinEndpoints(NodePlacement.None, NodePlacement.None);
	
	public ImVein(VeinEndpoints veinEndpoints, Color color, string name = "a vein") : base(name) {		
		this.veinEndpoints = veinEndpoints;
		
		InitSpriteComponent(color);
	}
	
	public void InitSpriteComponent(Color color) {
		ImSpriteComponent sc = new ImSpriteComponent("whiteSquare.png", 0, 1, color);
	
		Vector2 fromNodePosition = ImConfig.PositionForNodePlacement(veinEndpoints.fromNodePlacement);
		Vector2 toNodePosition = ImConfig.PositionForNodePlacement(veinEndpoints.toNodePlacement);
		Vector2 lowerNodePosition = fromNodePosition.y <= toNodePosition.y ? fromNodePosition : toNodePosition;
		Vector2 higherNodePosition = toNodePosition.y >= fromNodePosition.y ? toNodePosition : fromNodePosition;
		
		float sRotation = 90 + 360 - Mathf.Rad2Deg * Mathf.Atan((higherNodePosition.y - lowerNodePosition.y) / (higherNodePosition.x - lowerNodePosition.x));
		if (Mathf.Sign(higherNodePosition.x - lowerNodePosition.x) == -1f) sRotation += 180f;
		
		sc.sprite.anchorY = 0;
		sc.sprite.width = 5f;
		sc.sprite.height = Mathf.Sqrt(Mathf.Pow(toNodePosition.y - fromNodePosition.y, 2) + Mathf.Pow(toNodePosition.x - fromNodePosition.x, 2));
		sc.sprite.rotation = sRotation;
		sc.sprite.x = lowerNodePosition.x;
		sc.sprite.y = lowerNodePosition.y;
		
		AddComponent(sc);
	}
	
	public List<ImNode> CorrespondingNodesInNodeLayer(ImNodeLayer nodeLayer) {
		List<ImNode> nodes = new List<ImNode>();
		
		ImNode fromNode = nodeLayer.NodeForPlacement(veinEndpoints.fromNodePlacement);
		ImNode toNode = nodeLayer.NodeForPlacement(veinEndpoints.toNodePlacement);
		
		if (fromNode != null) nodes.Add(fromNode);
		if (toNode != null) nodes.Add(toNode);
		
		return nodes;
	}

	override public string Description() {
		string description = "";
		
		// add this in later
		
		return description;
	}
}
