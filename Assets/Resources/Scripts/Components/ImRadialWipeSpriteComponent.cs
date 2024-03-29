using UnityEngine;
using System.Collections;

public class ImRadialWipeSpriteComponent : ImAbstractComponent {	
	private FRadialWipeSprite sprite_;
	
	public ImRadialWipeSpriteComponent(string name, string imageName) : base(name) {
		componentType_ = ComponentType.RadialWipeSprite;
	
		sprite_ = new FRadialWipeSprite(imageName, true, 90, 1);
	}
	
	public bool SpriteContainsGlobalPoint(Vector2 globalPoint) {
		return sprite_.localRect.Contains(sprite_.GlobalToLocal(globalPoint));
	}
	
	public FRadialWipeSprite sprite {
		get {return sprite_;}
	}
}
