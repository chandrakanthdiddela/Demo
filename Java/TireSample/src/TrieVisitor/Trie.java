
package TrieVisitor;


public class Trie{

   NonWordNode root;
TrieNode node1,node2;

    public Trie (){
    root=new NonWordNode('#');
    
}

    public boolean add(String word){

        if (word == null) return false;
	if (word.isEmpty() ) return false;
        return root.addWord(word);
    }
    public void traverse(){
     
    }

    @Override
    public String toString(){
         AllWordsVisitor visitor=new AllWordsVisitor();
       root.accept(visitor);
           
       return visitor.result;

    }
    
    public String searchWordsWithSubString(String word){
    	SubStringVisitor visitor = new SubStringVisitor(word);
        root.accept(visitor);
              
        return visitor.stringList.toString();

   }
    public String collectWords(Strategy strat){
    	StrategyVisitor stratVisitor = new StrategyVisitor(strat);
    	root.accept(stratVisitor);
         
        return stratVisitor.stringList.toString();

   }

	

	
}