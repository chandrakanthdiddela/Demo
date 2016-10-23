package BMI;

import java.util.InputMismatchException;
import java.util.Scanner;

public class CalculateBMI {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		try {

			// introduction message
			System.out
					.println("**********Welcome to Body Mass Index Calcualtor*********");
			System.out.println();
			// Prompt the user to enter weight in pounds
			System.out.print("Enter weight in pounds: ");
			// Read the input from the keyboard
			Scanner input = new Scanner(System.in);
			// read input as string and next cast it to double type
			String lstrWeight = input.next();
			double ldlbweight = Double.parseDouble(lstrWeight);
			System.out.println();
			// Prompt the user to enter height in inches
			System.out.print("Enter height in inches: ");
			String lstrHeight = input.next();
			double ldlbheight = Double.parseDouble(lstrHeight);

			if (ldlbheight >= Double.MAX_VALUE) {
				throw new RuntimeException(
						" : Weight of the person exceeds the range of double datatype...");
			}

			// if (Double.isInfinite(ldlbweight + ldlbheight)) {
			// throw new RuntimeException(
			// "Weight of the person exceeds double Range...");
			// }
			// checking whether height and weight are positive integer
			if (!(ldlbheight >= 0 && ldlbweight >= 0)) {
				throw new InputMismatchException(
						"  please enter positive value");
			}
			ComputeAndInterpretBMI lobjComputeAndInterpretBMI = new ComputeAndInterpretBMI(
					ldlbweight, ldlbheight);

			lobjComputeAndInterpretBMI.setWeightInkgs(ldlbweight);
			lobjComputeAndInterpretBMI.setHeightInMeters(ldlbheight);
			double ldlbCalculateBMI = lobjComputeAndInterpretBMI.CalculateBMI(
					lobjComputeAndInterpretBMI.getWeightInKgs(),
					lobjComputeAndInterpretBMI.getHeightInMeters());
			lobjComputeAndInterpretBMI.recommendedWeeks(ldlbCalculateBMI);
			System.out.println("Thanks for using BMI calculator");
		}

		catch (NumberFormatException lobjNumberFormat) {
			System.out
					.println(" Number Format Exception has occurred please check "
							+ lobjNumberFormat.getMessage());
		} catch (InputMismatchException lobjInputMismatchException) {
			System.out.println(" Input MisMatch Exception has occurred"
					+ lobjInputMismatchException.getMessage());

		} catch (RuntimeException lobjException) {
			System.out.println("Run time Exception occurred"
					+ lobjException.getMessage());
		}

	}
}
