/** ***************************************************************************************
	


 1) Implement an iterator on your Trie class to iterate through all the words in the trie.
 2) Use the iterator to select all words in the Trie that contains the letters "ck"
 3) Implement a toString() method on your Trie class that returns a string representation of the
    Trie object.

/******************************************************************************************/

package trieiterator;

class TrieNode {

	char letter; 
	TrieNode[] children;
	boolean isendOfWord;

	
	public TrieNode(char letter) {
		this.letter = letter;
		children = new TrieNode[26]; 
		this.isendOfWord = false; 
	}

	public boolean addWord(String word) {
		if (word.length() == 0) {
			isendOfWord = true;
			return true;
		}
		TrieNode forWord = nodeFor(word);
		word = word.substring(1);
		forWord.addWord(word);
                return true;            
	}

	public TrieNode nodeFor(String word) {
		char c = word.charAt(0);
		int index = c - 'a';
		if (children[index] == null)
			children[index] = new TrieNode(c);
		return children[index];
	}
}
