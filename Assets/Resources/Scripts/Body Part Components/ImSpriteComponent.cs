using UnityEngine;
using System.Collections;

public class ImSpriteComponent {
	public string imageName;
	public ImBodyPart owner;
	
	private FSprite sprite_;
	private float defaultSpriteRotation_ = 0.0f;
	private float defaultSpriteScale_ = 1.0f;
	private Color defaultSpriteColor_ = Color.white;
	private TweenChain spritePulsateTween_;
	
	public ImSpriteComponent(ImBodyPart owner, float defaultSpriteRotation, float defaultSpriteScale, Color defaultSpriteColor) {
		this.owner = owner;
		defaultSpriteRotation_ = defaultSpriteRotation;
		defaultSpriteScale_ = defaultSpriteScale;
		defaultSpriteColor_ = defaultSpriteColor;
	}
	
	public void InitSprite(ImAbstractBodyPartComponent component) {
		if (component.owner.bodyPartType == BodyPartType.Organ) {
			ImOrganComponent orgComponent = component as ImOrganComponent;
			switch (orgComponent.organType) {
			case OrganType.Brain:
				imageName = "brain.png";
				break;
			case OrganType.Heart:
				imageName = "heart.png";
				break;
			case OrganType.Intestines:
				imageName = "intestines.png";
				break;
			case OrganType.Liver:
				imageName = "liver.png";
				break;
			case OrganType.LungLeft:
				imageName = "lungLeft.png";
				break;
			case OrganType.LungRight:
				imageName = "lungRight.png";
				break;
			case OrganType.Stomach:
				imageName = "stomach.png";
				break;
			default:
				break;
			}
			
			sprite_ = new FSprite(imageName);
			sprite_.rotation = defaultSpriteRotation_;
			sprite_.scale = defaultSpriteScale_;
		}
		else if (component.owner.bodyPartType == BodyPartType.Node) {
			imageName = "circle.psd";
			sprite_ = new FSprite(imageName);
			sprite_.rotation = defaultSpriteRotation_;
			sprite_.scale = defaultSpriteScale_;
		}
		else if (component.owner.bodyPartType == BodyPartType.Vein) {
			imageName = "whiteSquare.png";
			
			sprite_ = new FSprite(imageName);
			sprite_.anchorY = 0;
			
			Vector2 fromNodePosition = ImNodeLayer.PositionForNodePlacement(component.owner.veinComponent.veinEndpoints.fromNodePlacement);
			Vector2 toNodePosition = ImNodeLayer.PositionForNodePlacement(component.owner.veinComponent.veinEndpoints.toNodePlacement);
			Vector2 lowerNodePosition = fromNodePosition.y <= toNodePosition.y ? fromNodePosition : toNodePosition;
			Vector2 higherNodePosition = toNodePosition.y >= fromNodePosition.y ? toNodePosition : fromNodePosition;
			
			sprite_.width = 5f;
			sprite_.height = Mathf.Sqrt(Mathf.Pow(toNodePosition.y - fromNodePosition.y, 2) + Mathf.Pow(toNodePosition.x - fromNodePosition.x, 2));
			float rotation = 90 + 360 - Mathf.Rad2Deg * Mathf.Atan((higherNodePosition.y - lowerNodePosition.y) / (higherNodePosition.x - lowerNodePosition.x));
			if (Mathf.Sign(higherNodePosition.x - lowerNodePosition.x) == -1f) rotation += 180f;
			sprite_.rotation = rotation;
			sprite_.x = lowerNodePosition.x;
			sprite_.y = lowerNodePosition.y;
		}		
		
		sprite_.color = defaultSpriteColor_;
		
		spritePulsateTween_ = new TweenChain();
		spritePulsateTween_.setIterations(-1);
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_ + 0.03f)));
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_)));
		Go.addTween(spritePulsateTween_);
	}
	
	public void PlaceSpriteAt(float x, float y) {
		sprite_.x = x;
		sprite_.y = y;
	}
	
	public void StartPulsatingSprite() {
		spritePulsateTween_.play();	
	}
	
	public void StopPulsatingSprite() {
		spritePulsateTween_.pause();
		sprite_.scale = defaultSpriteScale_;
	}
	
	public bool SpriteContainsGlobalPoint(Vector2 globalPoint) {
		return sprite_.localRect.Contains(sprite_.GlobalToLocal(globalPoint));
	}
	
	public FSprite sprite {
		get {return sprite_;}	
	}
	
	public float defaultSpriteRotation {
		get {return defaultSpriteRotation_;}
	}
	
	public float defaultSpriteScale {
		get {return defaultSpriteScale_;}
	}
	
	public Color defaultSpriteColor {
		get {return defaultSpriteColor_;}
	}
}
