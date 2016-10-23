
package TrieVisitor;

public class VowelWords implements Strategy {
	
	StringBuilder sb1=new StringBuilder();

    public String collectwords(String str) {
    	   	
    	String[] t=str.split("\\n+");
		
		int j=0;
		int count;
		int k;
		char c;	 
		
		for(k=0;k<t.length;k++){
			 count = 0; 
		 for(j = 0; j < t[k].length(); j++) {
		   c= t[k].charAt(j);
		  if (c=='a' || c=='e' || c=='i' || c=='o' || c=='u') {
		  count++;
		  }
		}
		  if(count>=2){
			  sb1=sb1.append(t[k]);
			  sb1=sb1.append(' ');
		 }
		}
		
		return sb1.toString();
    	        
    }

    }

