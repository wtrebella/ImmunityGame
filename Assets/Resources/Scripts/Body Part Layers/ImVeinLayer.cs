using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImVeinLayer : ImAbstractEntityLayer {
	public ImVeinLayer() {
		Color veinColor = Color.black;
		
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.HandLeft, NodePlacement.ElbowLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.ElbowLeft, NodePlacement.ShoulderLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Neck, NodePlacement.Brain), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.ShoulderLeft, NodePlacement.LungLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.LungLeft, NodePlacement.Heart), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Heart, NodePlacement.LungRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.LungRight, NodePlacement.ShoulderRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.ShoulderRight, NodePlacement.ElbowRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.ElbowRight, NodePlacement.HandRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Neck, NodePlacement.Heart), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Heart, NodePlacement.Liver), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Liver, NodePlacement.Stomach), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Stomach, NodePlacement.Intestines), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Intestines, NodePlacement.HipLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.Intestines, NodePlacement.HipRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.HipLeft, NodePlacement.KneeLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.KneeLeft, NodePlacement.FootLeft), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.HipRight, NodePlacement.KneeRight), veinColor));
		entities.Add(new ImVein(new VeinEndpoints(NodePlacement.KneeRight, NodePlacement.FootRight), veinColor));
		
		foreach (ImEntity entity in entities) {
			ImVein vein = entity as ImVein;
			vein.name = string.Format("vein; from " + ImConfig.NameForNodePlacement(vein.veinEndpoints.fromNodePlacement) + " to " + ImConfig.NameForNodePlacement(vein.veinEndpoints.toNodePlacement));
			AddChild(vein);
			
			Vector2 fromNodePosition = ImConfig.PositionForNodePlacement(vein.veinEndpoints.fromNodePlacement);
			Vector2 toNodePosition = ImConfig.PositionForNodePlacement(vein.veinEndpoints.toNodePlacement);
			Vector2 lowerNodePosition = fromNodePosition.y <= toNodePosition.y ? fromNodePosition : toNodePosition;
			Vector2 higherNodePosition = toNodePosition.y >= fromNodePosition.y ? toNodePosition : fromNodePosition;
			
			float sRotation = 90 + 360 - Mathf.Rad2Deg * Mathf.Atan((higherNodePosition.y - lowerNodePosition.y) / (higherNodePosition.x - lowerNodePosition.x));
			if (Mathf.Sign(higherNodePosition.x - lowerNodePosition.x) == -1f) sRotation += 180f;
			
			vein.x = lowerNodePosition.x;
			vein.y = lowerNodePosition.y;
		}
	}
	
	public List<ImVein> VeinsForNodePlacement(NodePlacement nodePlacement) {
		List<ImVein> veins = new List<ImVein>();
		
		foreach (ImEntity entity in entities) {
			ImVein vein = entity as ImVein;
			if (vein.veinEndpoints.fromNodePlacement == nodePlacement ||
				vein.veinEndpoints.toNodePlacement == nodePlacement) {
				veins.Add(vein);	
			}
		}
		
		return veins;
	}
}
