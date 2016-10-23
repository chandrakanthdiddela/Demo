package trieiterator;

class stackNode{
     TrieNode node;
        String character;
       
        public stackNode(TrieNode node, String letter){
            this.node=node;
             this.character=letter;
            }       
}

public class stackADT {
    stackNode[] arr=new stackNode[10];
        int top = -1;
        stackNode node;

        stackADT(){

        }
        
        public void push(stackNode n)
        {
                  top=top+1;
                  node=new stackNode(n.node,n.character);
                  arr[top] = node;
        }

        public stackNode pop()
        {
                  stackNode popped = arr[top];
                  top--;
                
                  return popped;
        }

        public stackNode peek()
        {
                 return arr[top];
        }

        public boolean isEmpty()
        {
                  if(top==-1)
                    return true;
                  return false;
    }

}

