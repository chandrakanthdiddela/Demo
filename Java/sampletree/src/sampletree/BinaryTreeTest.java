/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package sampletree;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Varnith
 */
public class BinaryTreeTest {

  public static void main(String[] args) throws IOException {
      PdfReaderSample lobjPdfReaderSample= new PdfReaderSample();
     ArrayList<Integer> treecontent= lobjPdfReaderSample.ReadPdfDocument();
    new BinaryTreeTest().run(treecontent);
  }

  static class Node {
    Node left;

    Node right;

    int value;

    public Node(int value) {
      this.value = value;
    }
  }

  public void run(ArrayList<Integer> pobjtreecontent) {
    // build the simple tree from chapter 11.
    Node root = new Node(2000);
    System.out.println("Binary Tree Example");
    System.out.println("Building tree with root value " + root.value);
    int lastValue;
for (Integer i : pobjtreecontent) {
    // do stuff
    lastValue = i.intValue();
    insert(root,i );
    
}


    System.out.println("Traversing tree in order");
   printInOrder(root);
    int height=heightOfBinaryTree(root);
      System.out.println("height" +height);
      System.out.println(countLeaves(root));
   
  }

  public void insert(Node node, int value) {
    if (value < node.value) {
      if (node.left != null) {
        insert(node.left, value);
      } else {
        System.out.println("  Inserted " + value + " to left of "
            + node.value);
        node.left = new Node(value);
      }
    } else if (value > node.value) {
      if (node.right != null) {
        insert(node.right, value);
      } else {
        System.out.println("  Inserted " + value + " to right of "
            + node.value);
        node.right = new Node(value);
      }
    }
  }

  public int heightOfBinaryTree(Node node)
{
    if (node == null)
    {
        return 0;
    }
    else
    {
        return 1 +
        Math.max(heightOfBinaryTree(node.left),
            heightOfBinaryTree(node.right));
    }
}
  int countLeaves(Node node) {
             // Return the number of leaves in the tree to which node points.
          if (node == null)
             return 0;
          else if (node.left == null && node.right == null)
             return 1;  // Node is a leaf.
          else
             return countLeaves(node.left) + countLeaves(node.right);
      } // end countNodes()
  public void printInOrder(Node node) {
    if (node != null) {
      printInOrder(node.left);
      System.out.println("  Traversed " + node.value);
      printInOrder(node.right);
    }
  }

  
  

}