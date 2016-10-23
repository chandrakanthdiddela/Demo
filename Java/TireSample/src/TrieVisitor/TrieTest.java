package TrieVisitor;

import static org.junit.Assert.*;

import org.junit.AfterClass;
import org.junit.Test;

public class TrieTest {


	 @Test
	    public void testAdd() {
	        System.out.println("add");
	        String word = "hello";
	        Trie instance = new Trie();

	        boolean expResult = true;
	        boolean result = instance.add(word);
	        assertEquals(expResult, result);
	        word = "world";
	        result=instance.add(word);
	        assertEquals(expResult, result);
	        word = "hi";
	        result=instance.add(word);
	        assertEquals(expResult, result);
	        
	     }
	 @Test
	    public void testToString() {
	        System.out.println("toString");
	        Trie instance = new Trie();
	        String[] words={"hi","hello","okay"};
	        instance.add(words[0]);
	        instance.add(words[1]);
	        instance.add(words[2]);
	        String expResult = "hi hello okay";
	        String result = instance.toString();
	        assertEquals(expResult, result);
	        
	    }
	 
	 @Test
	    public void searchWordsWithSubString() {
	        System.out.println("searchWordsWithSubString");
	        Trie instance = new Trie();
	        String subString="ck";
	        String[] words={"luck","lucky","fate"};
	        instance.add(words[0]);
	        instance.add(words[1]);
	        instance.add(words[2]);
	        String expResult = "luck lucky";
	        String result = instance.searchWordsWithSubString(subString);
	        assertEquals(expResult, result);
	        
	    }
	 @Test
	    public void collectWords() {
	        System.out.println("collectWords");
	        Trie instance = new Trie();
	        Strategy strat= new VowelWords();
	        String[] words={"panda","kith","bowl"};
	        instance.add(words[0]);
	        instance.add(words[1]);
	        instance.add(words[2]);
	        
	        String expResult = "panda";
	        String result = instance.collectWords(strat);
	        assertEquals(expResult, result);
	        
	        strat= new SubStringWords();
	        expResult = "kith";
	        result = instance.collectWords(strat);
	        assertEquals(expResult, result);
	    }
	 
	
	 
}
