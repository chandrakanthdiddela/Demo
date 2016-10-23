package TrieVisitor;

class NonWordNode extends TrieNode implements Visitable {

	char letter; 
	TrieNode[] children = new TrieNode[26]; 
	 

	public NonWordNode() {

	}

	public NonWordNode(char letter) { 
		this.letter = letter;
		
		final int MAX=26;
		for (int i = 0; i < MAX; i++) {
			children[i] = new NullNode();
		}

	}

	public boolean isNull() {

		return false;
	}

	public TrieNode nodeFor(String word) {
		char c = word.charAt(0);
		int index = c - 'a';
		
		if (children[index].isNull()) {
		
			if (word.length() == 1) {
		
				WordNode wnode = new WordNode(c);
				System.arraycopy(children[index].children, 0, wnode.children, 0,
						children.length);
				
				children[index] = wnode;
				
			

				} 
			else {
	
				NonWordNode nonwnode = new NonWordNode(c);
				System.arraycopy( children[index].children, 0,nonwnode.children, 0,
						children.length);
				children[index].letter = nonwnode.letter;
				children[index] = nonwnode;
				
				

				
			}
		} else if (!children[index].isNull()) {
			

			
			if (word.length() == 1) {
			
				WordNode wnode = new WordNode(c);
				
			    System.arraycopy(children[index].children, 0, wnode.children, 0, children.length);
			    children[index].letter = wnode.letter;
				children[index] = wnode;
				
			}
		}
		return children[index];
	}
	

		public void accept(Visitor visitor) {
				visitor.visit(this);
	}

	
}