using UnityEngine;
using System.Collections;

public class ImPopoverDialogue : ImEntity {

	public ImPopoverDialogue(string name = "popover dialogue") : base(name) {
		AddComponent(new ImSliceSpriteComponent("sliceSpriteComponent", "uiPopover.psd", 100, 100, 16, 16, 16, 16));
		//AddComponent(new ImScrollContainerComponent("scrollContainerComponent"));
	}
}