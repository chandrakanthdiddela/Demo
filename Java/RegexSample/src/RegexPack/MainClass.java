package RegexPack;

public class MainClass {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		System.out
				.println("***Welcome to Regex expression Sample Validator****");
		Student lobjHelper = new Student("Chandrakanth", "diddela",
				"959-999-2098", "1234567890");
		String output = lobjHelper.ValidateStudentDetails();

	}
}
