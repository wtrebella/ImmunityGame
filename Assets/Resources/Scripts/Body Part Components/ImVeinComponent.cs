using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct VeinEndpoints {
	public NodePlacement fromNodePlacement;
	public NodePlacement toNodePlacement;
	
	public VeinEndpoints(NodePlacement fromNode, NodePlacement toNode) {
		fromNodePlacement = fromNode;
		toNodePlacement = toNode;
	}
}

public class ImVeinComponent : ImAbstractBodyPartComponent {
	public VeinEndpoints veinEndpoints = new VeinEndpoints(NodePlacement.None, NodePlacement.None);
	
	public ImVeinComponent(ImBodyPart owner, VeinEndpoints veinEndpoints) : base(owner) {		
		this.veinEndpoints = veinEndpoints;
	}
	
	public List<ImBodyPart> CorrespondingNodesInNodeLayer(ImNodeLayer nodeLayer) {
		List<ImBodyPart> nodes = new List<ImBodyPart>();
		
		ImBodyPart fromNode = nodeLayer.NodeForPlacement(veinEndpoints.fromNodePlacement);
		ImBodyPart toNode = nodeLayer.NodeForPlacement(veinEndpoints.toNodePlacement);
		
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
