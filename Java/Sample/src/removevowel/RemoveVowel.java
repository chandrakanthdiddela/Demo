package removevowel;


public class RemoveVowel {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String str = "Your String";
		str = str.replaceAll("[AEIOUaeiou]", "");
		System.out.println(str);

	}
}
