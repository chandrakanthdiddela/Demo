import java.util.ArrayList;
import java.util.List;

public class testdata {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		String[] vowels = { "a", "e", "i", "o", "u" };
		String resultString = "";
		List<String> vowelsData = new ArrayList<String>();
		vowelsData.add("a");
		vowelsData.add("e");
		vowelsData.add("i");
		vowelsData.add("o");
		vowelsData.add("u");
		String input = "Example to remove vowels from input string";
		input = input.toLowerCase();
		for (int stringEntered = 0; stringEntered < input.length(); stringEntered++) {
			if (!vowelsData.contains(input.charAt(stringEntered))) {
				resultString = resultString + (input.charAt(stringEntered));
			}

		}
		System.out.println("String after removing vowels:" + resultString);
	}

}
