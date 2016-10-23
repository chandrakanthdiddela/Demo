
package TrieVisitor;


public class SubStringWords implements Strategy {

	StringBuilder sb1=new StringBuilder();
	
    public String collectwords(String str) {
    	
    	String st1="th"; 	
		
		String[] t=str.split("\\n+");
		
    	int i;
		
		for(i=0;i<t.length;i++){
    	if(t[i].contains(st1)){
    		
     		sb1=sb1.append(t[i]);
    		sb1=sb1.append('\n');
    	}
    	}
    	
    	return sb1.toString();
    }

}
