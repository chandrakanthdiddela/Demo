package SampleStringOperations;

import java.util.NoSuchElementException;
import java.util.Scanner;

//import com.sun.org.apache.xalan.internal.xsltc.compiler.Pattern;

public class SampleStringReverseop {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		try {

			// Pattern p = Pattern.Complie("");
			System.out.println("**********Welcome to String "
					+ "reverse Application*********");
			System.out.println();
			// Prompt the user to enter the String
			System.out.print("Enter the String to reverse: ");
			// Read the input from the keyboard//
			Scanner input = new Scanner(System.in);
			// read an input string from the keyboard
			String lstrInputText = input.nextLine();
			System.out.println("");
			if (lstrInputText.length() > 0) {
				System.out.println("Reversed string is :");
				System.out.println();

				for (int i = lstrInputText.length() - 1; i >= 0; i--) {
					System.out.print(lstrInputText.charAt(i));
				}

				System.out.println();
				System.out.println();
				System.out
						.println("****Thanks for using Reverse String Application****");

			} else {
				throw new NullPointerException("string is empty");
			}

		} catch (IllegalStateException lobjIllegalStateException) {

			System.out.println("Error Occured :"
					+ lobjIllegalStateException.getMessage());

		} catch (NoSuchElementException lobjNoSuchElementException) {
			System.out.println("Error Occured :"
					+ lobjNoSuchElementException.getMessage());

		} catch (NullPointerException lobjNullPointerException) {
			System.out.println("Error Occured :"
					+ lobjNullPointerException.getMessage());
		} catch (Exception lobjException) {

			System.out.println("Error Occured:" + lobjException.getMessage());

		}

	}
}
