using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImVeinComponent : ImEntity {
	public VeinEndpoints veinEndpoints = new VeinEndpoints(NodePlacement.None, NodePlacement.None);
	
	public ImVeinComponent(string name, VeinEndpoints veinEndpoints) : base(name) {		
		this.veinEndpoints = veinEndpoints;
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
