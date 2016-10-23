
package TrieVisitor;

class NullNode extends TrieNode implements Visitable{

    public NullNode(){
       

    }

    public boolean isNull(){
                return true;
    }

    public void accept(Visitor visitor) {
         visitor.visit(this);
    }

}