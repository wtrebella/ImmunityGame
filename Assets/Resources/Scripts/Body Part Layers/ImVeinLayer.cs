using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImVeinLayer : ImAbstractBodyPartLayer {
	public ImVeinLayer(WTImmunity owner) : base(owner) {
		Color veinColor = Color.black;
		
		ImBodyPart newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.HandLeft, NodePlacement.ElbowLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.ElbowLeft, NodePlacement.ShoulderLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Neck, NodePlacement.Brain), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.ShoulderLeft, NodePlacement.LungLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.LungLeft, NodePlacement.Heart), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Heart, NodePlacement.LungRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.LungRight, NodePlacement.ShoulderRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.ShoulderRight, NodePlacement.ElbowRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.ElbowRight, NodePlacement.HandRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Neck, NodePlacement.Heart), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Heart, NodePlacement.Liver), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Liver, NodePlacement.Stomach), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Stomach, NodePlacement.Intestines), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Intestines, NodePlacement.HipLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.Intestines, NodePlacement.HipRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.HipLeft, NodePlacement.KneeLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.KneeLeft, NodePlacement.FootLeft), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.HipRight, NodePlacement.KneeRight), veinColor);
		bodyParts.Add(newVein);
		
		newVein = new ImBodyPart(new VeinEndpoints(NodePlacement.KneeRight, NodePlacement.FootRight), veinColor);
		bodyParts.Add(newVein);
		
		foreach (ImBodyPart vein in bodyParts) {
			AddChild(vein.spriteComponent.sprite);	
		}
	}
	
	public List<ImBodyPart> VeinsForNodePlacement(NodePlacement nodePlacement) {
		List<ImBodyPart> veins = new List<ImBodyPart>();
		
		foreach (ImBodyPart vein in bodyParts) {
			if (vein.veinComponent.veinEndpoints.fromNodePlacement == nodePlacement ||
				vein.veinComponent.veinEndpoints.toNodePlacement == nodePlacement) {
				veins.Add(vein);	
			}
		}
		
		return veins;
	}
}
