using UnityEngine;
using System.Collections;

public class ImSpriteComponent : ImAbstractComponent {	
	public float defaultSpriteRotation = 0;
	public float defaultSpriteScale = 1;
	
	private FSprite sprite_;
	private TweenChain spritePulsateTween_;
	
	public ImSpriteComponent(string name, string imageName) : base(name) {
		componentType_ = ComponentType.Sprite;
		
		sprite_ = new FSprite(imageName);
		sprite_.rotation = defaultSpriteRotation;
		sprite_.scale = defaultSpriteScale;
		
		/*spritePulsateTween_ = new TweenChain();
		spritePulsateTween_.setIterations(-1);
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_ + 0.03f)));
		spritePulsateTween_.append(new Tween(sprite_, 0.2f, new TweenConfig().floatProp("scale", defaultSpriteScale_)));
		Go.addTween(spritePulsateTween_);*/
	}
	
	public void StartPulsatingSprite() {
		//spritePulsateTween_.play();	
	}
	
	public void StopPulsatingSprite() {
		/*spritePulsateTween_.pause();
		sprite_.scale = defaultSpriteScale_;*/
	}
	
	public bool SpriteContainsGlobalPoint(Vector2 globalPoint) {
		return sprite_.localRect.Contains(sprite_.GlobalToLocal(globalPoint));
	}
	
	public FSprite sprite {
		get {return sprite_;}	
	}
}
