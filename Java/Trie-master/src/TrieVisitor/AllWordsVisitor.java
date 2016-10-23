
package TrieVisitor;

import java.util.*;

public class AllWordsVisitor implements Visitor{
	
Stack<TrieNode> s;
String result;

List<Character> stringList;
int index=0;

    public AllWordsVisitor(){
    	s=new Stack<TrieNode>();

    	stringList = new ArrayList<Character>();
     }
    
 public void visit(NonWordNode node) {
        
        s.push(node);
        final int MAX=26;
        int index=0;
        s.size();
        for(index=0;index<node.children.length;index++){
            if(!node.children[index].isNull()){
                break;
            }
        }
        
        if(index!=MAX)
        node.children[index].accept(this);
        
    }

    
    public void visit(WordNode node) {
    	
        s.push(node);
        int index=0;
        TrieNode tnodes[] = new TrieNode[20];
       
        while(!s.isEmpty())
        {
            tnodes[index]=s.pop();
            stringList.add(tnodes[index].letter);
            index++;
        }

        for(int k=index-1; k>=0; k--)
            s.push(tnodes[k]);
                               
        findChild(node);
    }

    private void findChild(TrieNode node) {
        int i;
        final int MAX=26;
        final int OFFSET=97;
        char root='#';
        TrieNode tnode;
        
        for(i=index;i<node.children.length;i++){
            if(!node.children[i].isNull()){
                break;
            }
        }
        if(i!=MAX)
        {
        	 node.children[i].accept(this);  
        }
        else{
             
            tnode = s.pop();
            index=tnode.letter-OFFSET;
            if(tnode.letter==root)
                return;
            else{
        
            tnode = s.peek();
        
            findChild(tnode);
            }
        } 
        
     }
   
    public void visit(NullNode node3) {
      
    }

    public void visit(TrieNode node1) {
      
    }

}
