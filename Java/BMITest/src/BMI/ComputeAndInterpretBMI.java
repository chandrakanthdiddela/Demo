package BMI;

//this class is a helper class which holds information about BMI calculation
//
public class ComputeAndInterpretBMI {

	final double KILOGRAMS_PER_POUND = 0.45359237; // Constant
	final double METERS_PER_INCH = 0.0254; // Constant
	private double mdlbWeight;
	private double mdlbHeight;
	private double mdlbweightInKilograms;
	private double mdlbheightInMeters;

	// Parameterized constructor
	public ComputeAndInterpretBMI(double pdlbWeight, double pdlbHeight) {

		mdlbWeight = pdlbWeight;
		mdlbHeight = pdlbHeight;
	}

	// converts weight in pounds to kgs
	public void setWeightInkgs(double pdlbWeight) {

		mdlbweightInKilograms = pdlbWeight * KILOGRAMS_PER_POUND;
	}

	// use to get weights in kgs
	public double getWeightInKgs() {
		return mdlbweightInKilograms;
	}

	// converts height in inches to meters
	public void setHeightInMeters(double pdlbHeight) {

		mdlbheightInMeters = pdlbHeight * METERS_PER_INCH;
	}

	// get the height in meters
	public double getHeightInMeters() {
		return mdlbheightInMeters;
	}

	public void setWeight(double pdlbWeight) {

		mdlbWeight = pdlbWeight;
	}

	public double getWeight() {
		return mdlbWeight;
	}

	public void setHeight(double pdlbWeight) {

		mdlbHeight = pdlbWeight;
	}

	public double getHeight() {
		return mdlbHeight;
	}

	// calculate BMI based on weight(kgs) and heights(meters)
	public double CalculateBMI(double pdlbWeightInKgs, double pdlbHeightInMeters) {
		double ldlbBMI = 0;

		try {

			if (pdlbHeightInMeters == 0) {
				throw new ArithmeticException("height cannot be zero");
			}
			// double ldlbBMI=0;
			ldlbBMI = pdlbWeightInKgs
					/ (pdlbHeightInMeters * pdlbHeightInMeters);
			return ldlbBMI;

		} catch (ArithmeticException e) {
			System.out.println("Arithmetic Exception occurred" + e);
			System.exit(0);
			return ldlbBMI;
		}

	}

	public void recommendedWeeks(double ldlbBMI) {
		try {
			if (ldlbBMI == 0) {
				throw new Exception("ldlbBMI cannot be zero");

			}
			System.out.println("BMI is " + ldlbBMI);
			if (ldlbBMI < 18.5) {
				System.out
						.println("Based on weight and height input provided person fall under Underweight category");
				// subtracting UpperLimit normal weight from given input weight
				double ldlbRequiredBMI = 18.5 - ldlbBMI;
				double ldlbNormalWeightUpperLimit = ldlbRequiredBMI
						* mdlbheightInMeters * mdlbheightInMeters;
				double ldlbRequiredRecommenedWeek = (ldlbNormalWeightUpperLimit)
						/ KILOGRAMS_PER_POUND;
				System.out.println();

				System.out
						.println("Recommended number of weeks for person to become Normal from Underweight is "
								+ " "
								+ Math.floor(Math
										.abs(ldlbRequiredRecommenedWeek)));
				System.out.println();
			}

			else if (ldlbBMI >= 18.5 && ldlbBMI < 30) {
				System.out
						.println("No Recommendation.. provided height and weight correspond to normal person ");

			}

			else {
				System.out
						.println("Based on weight and height input provided person fall under Obese category");
				System.out.println();
				// subtracting from excess bmi
				double ldlbExcessBMI = ldlbBMI - 30.0;
				double ldlbObseLimit = ldlbExcessBMI * mdlbheightInMeters
						* mdlbheightInMeters;
				double ldlbRequiredRecommenedWeek = ldlbObseLimit
						/ KILOGRAMS_PER_POUND;
				System.out
						.println("Recommended number of weeks for person to become overweight from Obese is "
								+ " "
								+ Math.floor(Math
										.abs(ldlbRequiredRecommenedWeek)));
				System.out.println();
			}

		} catch (Exception lobjException) {
			System.out
					.println("Exception occured BMI cannot be zero : please check input weight parameter");
			System.exit(0);
		}

	}

}