using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImVeinLayer : ImAbstractEntityLayer {
	public ImVeinLayer(WTImmunity owner) : base(owner) {
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
