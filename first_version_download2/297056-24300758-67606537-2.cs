    public override ProblemCollection Check(TypeNode type)
	{
        ClassNode classNode = type as ClassNode;
        if (classNode == null)
            return;
		if (classNode.BaseType == null)
			return;
		if (classNode.BaseType.NodeType == NodeType.Object)
			return;
    
		// Namechecking logic
        return Problems;
	}
