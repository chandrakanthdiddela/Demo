
package TrieVisitor;

import java.util.*;

public class SubStringVisitor implements Visitor{
Stack<TrieNode> s=new Stack<TrieNode>();

List<String> stringList;
String word;
int index=0;

	public SubStringVisitor(){
		stringList=new ArrayList<String>();
	}
	
    public SubStringVisitor(String word){
    	this.word = word;
    }
    
    public void visit(NonWordNode node) {
        s.push(node);
        
        int index;
        s.size();
        for(index=0;index<node.children.length;index++){
            if(!node.children[index].isNull()){
                break;
            }
        }
        
        if(index!=26)
        node.children[index].accept(this);
    }

    
    public void visit(WordNode node) {
       s.push(node);

        int j=0;
        TrieNode tnodes[] = new TrieNode[100];
        String str="";
        while(!s.isEmpty())
        {
            tnodes[j]=s.pop();
            str = tnodes[j].letter+str;
            j++;  
        }
        
        if(str.contains(this.word))
          stringList.add(str);
        
        for(int k=j-1; k>=0; k--)
              s.push(tnodes[k]);        
        
        findChild(node);
    }

    private void findChild(TrieNode node) {
        int i;
        final int OFFSET=97;
        char root='#';
        
        for(i=index;i<node.children.length;i++){
            if(!node.children[i].isNull()){
                break;
            }
        }
        if(i==26)
        {
            TrieNode tnode;
        
            tnode = s.pop();
        
            index=tnode.letter-OFFSET;
            if(tnode.letter==root)
                return;
            else{
        
            tnode = s.peek();
        
            findChild(tnode);
            }
        }
        else{
        
            node.children[i].accept(this);
        }    
     }      
  
    public void visit(NullNode node3) {
      
    }

    public void visit(TrieNode node1) {
      
    }

}
