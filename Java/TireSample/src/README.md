TrieDictionary
==============

A Java mini-project which uses TrieNodes to store and search words. You can also fin words with a particular substring
	

        A trie, is a multi-way tree structure useful for storing strings over an alphabet.
        It is an ordered tree data structure. The words in the dictionary are stored in a data type trie.
        In this type of tree, each node can have a maximum of 26 children, one for each letter of the alphabet.
	Each node is structured like this.

	class TrieNode
        {
            char letter;
            TrieNode[] children;
            boolean endofWord;
            
            // functions to manipulate TRIE
        }

	Each node stores a char letter, a boolean variable (indicates if the letter stored
	in the node ends a word or not), array of pointers to the children of the node.
	Each node can have a maximum of 26 children, one for each letter of the alphabet.
        This class implements the following functions over a Trie:

        1)Insert a word into Trie
        2)Print all words in Trie
        3)Find words with 'ck'
        4)Find a word in Trie
