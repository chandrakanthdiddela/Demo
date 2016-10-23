
package TrieVisitor;

import java.util.*;


public class StrategyVisitor implements Visitor {

    private Strategy strategy;
    Stack<TrieNode> s=new Stack<TrieNode>();
    List<Character> stringList=new ArrayList<Character>();
    
    
    int index=0;
    

    public StrategyVisitor(Strategy strategy) {
        this.strategy = strategy;
    }
    

    public String executeStrategy(String str) {
        return strategy.collectwords(str);
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
          TrieNode tnodes[] = new TrieNode[10];
        
          while(!s.isEmpty())
          {
              tnodes[j]=s.pop();
             
              stringList.add(tnodes[j].letter);
             
              j++;
             
          }
          
          for(int k=j-1; k>=0; k--)
              s.push(tnodes[k]);
                             
          findChild(node);
      }

      private void findChild(TrieNode node) {
          int i;
          final int OFFSET=97;
          char root=26;
          
          for(i=index;i<node.children.length;i++){
              if(!node.children[i].isNull()){
                  break;
              }
          }
          if(i!=26)
          {
        	  node.children[i].accept(this);
                  
          }
          
          else{
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
                          
       }

      
      public void visit(NullNode node3) {
      
      }

      public void visit(TrieNode node1) {
      
      }


}
