using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*public enum UIButtonType {
	ZoomIn,
	ZoomOut
}*/

public class ImUILayer : ImEntity {
	//public FButton zoomInButton;
	//public FButton zoomOutButton;
	public FLabel dollarsLabel;
	
	public ImUILayer() {
		/*zoomInButton = new FButton("whiteSquare.png", "whiteSquare.png", null);
		zoomOutButton = new FButton("whiteSquare.png", "whiteSquare.png", null);
		zoomInButton.data = UIButtonType.ZoomIn;
		zoomOutButton.data = UIButtonType.ZoomOut;
		zoomInButton.sprite.color = Color.blue;
		zoomOutButton.sprite.color = Color.red;
		zoomInButton.sprite.width = zoomOutButton.sprite.width = 40f;
		zoomInButton.sprite.height = zoomOutButton.sprite.height = 20f;
		zoomInButton.anchorX = zoomOutButton.anchorX = 1f;
		zoomInButton.anchorY = zoomOutButton.anchorY = 1f;
		float padding = 5f;
		zoomInButton.x = zoomOutButton.x = Futile.screen.width - padding;
		zoomInButton.y = Futile.screen.height - padding;
		zoomOutButton.y = zoomInButton.y - zoomInButton.sprite.height - padding;
		AddChild(zoomInButton);
		AddChild(zoomOutButton);*/
		
		dollarsLabel = new FLabel("TwCen", string.Format("$" + ImPlayerStats.dollars));
		dollarsLabel.anchorX = 0;
		dollarsLabel.anchorY = 1;
		dollarsLabel.x = 10f;
		dollarsLabel.y = Futile.screen.height - 10f;
		dollarsLabel.scale = 0.25f;
		AddChild(dollarsLabel);
		
		ImPlayerStats.SignalDollarsChanged += HandleDollarsChanged;
	}
	
	public void HandleDollarsChanged () {
		dollarsLabel.text = string.Format("$" + ImPlayerStats.dollars);
	}
}
