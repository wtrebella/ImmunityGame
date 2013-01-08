using UnityEngine;
using System.Collections;

public class ImSpriteComponent : ImAbstractComponent {	
	private FSprite sprite_;
	private float defaultSpriteRotation_ = 0.0f;
	private float defaultSpriteScale_ = 1.0f;
	private Color defaultSpriteColor_ = Color.white;
	private TweenChain spritePulsateTween_;
	
	public ImSpriteComponent(string name, string imageName, float defaultSpriteRotation, float defaultSpriteScale, Color defaultSpriteColor) : base(name) {
		componentType_ = ComponentType.Sprite;
		
		defaultSpriteRotation_ = defaultSpriteRotation;
		defaultSpriteScale_ = defaultSpriteScale;
		defaultSpriteColor_ = defaultSpriteColor;
	
		sprite_ = new FSprite(imageName);
		sprite_.rotation = defaultSpriteRotation_;
		sprite_.scale = defaultSpriteScale_;
		sprite_.color = defaultSpriteColor_;
		
		spritePulsateTween_ = new TweenChain();
		spritePulsateTween_.setIterations(-1);
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_ + 0.03f)));
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_)));
		Go.addTween(spritePulsateTween_);
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
