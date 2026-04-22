namespace EView360.Data
{
    public class TreeView
    {
        public List<TreeViewNode>? treeNodes { get; set; }
    }

    public class TreeViewNode
    {
        public string? Text { get; set; }
        public string? Id { get; set; }
        public string? Icon { get; set; }
        public string? Type { get; set; }
        public bool Expanded { get; set; }
        public bool HasChildren { get; set; }
        public bool DroppingEnabled { get; set; }
        public bool EditingEnabled { get; set; }
        public bool DraggingEnabled { get; set; }
        public string? ToolTip { get; set; }
        public List<TreeViewNode>? Nodes { get; set; }
    }
}
