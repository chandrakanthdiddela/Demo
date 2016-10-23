package RegexPack;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Student {

	String mstrFristName;
	String mstrLastName;
	String mstrPhoneNo, mstrStudentID;
	boolean[] ValidOutput = new boolean[4];

	public Student(String pstrFristName, String pstrLastName,
			String pstrPhoneNo, String pstrStudentID)

	{
		// System.out.println("constructor called");
		mstrFristName = pstrFristName;
		mstrLastName = pstrLastName;
		mstrStudentID = pstrStudentID;
		mstrPhoneNo = pstrPhoneNo;

	}

	public String getFirstName() {

		return mstrFristName;
	}

	public String getLastName() {

		return mstrLastName;
	}

	public String getStudentID() {

		return mstrStudentID;
	}

	public String getPhoneNo() {

		return mstrPhoneNo;
	}

	public void ValidateFirstName(String pstrFristName) {

		String pattern = "[A-Za-z]{2,15}";

		boolean output = patternMatcherHelper(pstrFristName, pattern);
		ValidOutput[0] = output;
		// ValidateOutput(output);
	}

	public void ValidateLastName(String pstrLastName) {
		String pattern = "[A-Za-z',-_]{2,15}";

		boolean output = patternMatcherHelper(pstrLastName, pattern);
		ValidOutput[1] = output;
		// ValidateOutput(output);
	}

	public void ValidateStudentID(String pstrStudentID) {
		String pattern = "\\d{10}";

		boolean output = patternMatcherHelper(pstrStudentID, pattern);
		ValidOutput[2] = output;
		// ValidateOutput(output);
	}

	public void ValidatePhoneNumber(String pstrphoneNumber) {
		String pattern = "[1-9][0-9]{2}-[0-9]{3}-[0-9]{4}";
		boolean output = patternMatcherHelper(pstrphoneNumber, pattern);
		ValidOutput[3] = output;
		// ValidateOutput(output);
	}

	boolean patternMatcherHelper(String pstrInput, String pstrPattern) {
		Pattern r = Pattern.compile(pstrPattern);

		// Now create matcher object.
		Matcher m = r.matcher(pstrInput);
		boolean isMatchFound = m.matches();
		return isMatchFound;
	}

	public String ValidateStudentDetails() {
		String message = "";
		ValidateFirstName(getFirstName());
		ValidateLastName(getLastName());
		ValidatePhoneNumber(getPhoneNo());
		ValidateStudentID(getStudentID());
		message = ValidateOutput(ValidOutput);
		return message;

	}

	public String ValidateOutput(boolean[] poutput) {
		boolean message = false;
		String output = "";
		for (boolean result : poutput) {
			if (!result) {
				message = true;
				output = "Entered is a not Valid Student record";
				System.out.println(output);
				break;
			}

		}
		if (!message) {
			output = "Entered is a Valid student record";
			System.out.println(output);
		}

		return output;
	}
}
