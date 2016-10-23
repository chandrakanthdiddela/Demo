
package TrieVisitor;

class TrieNode implements Visitable{

 char letter;                            
 TrieNode[] children=new TrieNode[26];   
                     

    public TrieNode(){
 
    }
    public TrieNode(char letter)
    {           
         this.letter = letter;           
        for(int i=0;i<26;i++){
            children[i]= new NullNode();
     
        }
     
    }
  public boolean isNull(){

            return false;
   }
  public boolean addWord(String word) {
		if (word.length() == 0) {
			return true;
		}
		TrieNode forWord = nodeFor(word);
		word = word.substring(1);
		forWord.addWord(word);
              return true;            
	}
  
   public TrieNode nodeFor(String word){
        char c= word.charAt(0);
      
        int index = c-'a';
      
        	
        if(children[index].isNull()){
            if(word.length()==1)
       {
            children[index]=new WordNode(c);
            }
            else{
        
            children[index]=new NonWordNode(c);

            }
        }
            
        return children[index];
    }
   
    public void accept(Visitor visitor) {
              visitor.visit(this);
    }
}