
package TrieVisitor;

class WordNode extends TrieNode implements Visitable{


 char letter;                            
 TrieNode[] children=new TrieNode[26];   
                     
    public WordNode(){

    }
    public WordNode(char letter)
    {              
         this.letter = letter;
                  
         for(int i=0;i<26;i++){
            children[i]= new NullNode();
         }

    }
     public boolean isNull(){
         
       return false;
   }

 
   public TrieNode nodeFor(String word){
        char c= word.charAt(0);
        int index = c-'a';
      
        if(children[index].isNull()){
      
            if(word.length()==1)
            {
            WordNode wn=new WordNode(c);
            System.arraycopy( children[index].children, 0, wn.children, 0, children.length);
            children[index] = wn;
            children[index].letter = wn.letter; 

            }
            else{
                  NonWordNode nwn=new NonWordNode(c);
            System.arraycopy( children[index].children, 0, nwn.children, 0, children.length);
            children[index] = nwn;
            children[index].letter = nwn.letter;
      
            }
        }
        else if (!children[index].isNull())
        {
            if(word.length()==1){
                 WordNode wn=new WordNode(c);          
      
           System.arraycopy(children[index].children, 0, wn.children, 0, children.length);
            children[index].letter = wn.letter;
             children[index] = wn;       

        }
       }
        return children[index];
    }
   
  
   
    public void accept(Visitor visitor) {
  
          visitor.visit(this);
    }
}