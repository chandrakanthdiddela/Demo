/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package TrieVisitor;


public interface Visitor {
    public void visit(TrieNode node1);
    public void visit(WordNode node1);
  public void visit(NonWordNode node2);
   public void visit(NullNode node3);
}
