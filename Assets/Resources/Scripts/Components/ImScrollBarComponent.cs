using UnityEngine;
using System.Collections;

public class ImScrollBarComponent : ImAbstractComponent {
	public WTScrollBar scrollBar;
	
	public ImScrollBarComponent(string name) : base(name) {
		componentType_ = ComponentType.ScrollBar;
		
		scrollBar = new WTScrollBar();
	}
}
