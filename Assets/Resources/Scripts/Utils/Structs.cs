public struct VeinEndpoints {
	public NodePlacement fromNodePlacement;
	public NodePlacement toNodePlacement;
	
	public VeinEndpoints(NodePlacement fromNode, NodePlacement toNode) {
		fromNodePlacement = fromNode;
		toNodePlacement = toNode;
	}
}

public struct WTEdgeInsets {
	public float top;
	public float left;
	public float bottom;
	public float right;
	
	public WTEdgeInsets(float top, float left, float bottom, float right) {
		this.top = top;
		this.left = left;
		this.bottom = bottom;
		this.right = right;
	}
}
