package testrecursive;


public class Testrec {

	public static void main(String[] args) {
		int count = 0;
		do {
			System.out.println("Welcome to Java" + count);
		} while (count++ < 10);

		/*
		 * Scanner input = new Scanner(System.in); int number = input.nextInt();
		 * boolean even; if (number % 2 == 0) { even = true; } else { even =
		 * false; } boolean even1 = (number % 2 == 0) ? true : false; boolean
		 * even2 = number % 2 == 0; System.out.println(even);
		 * System.out.println(even1); System.out.println(even2); /* double[][] m
		 * = new double[4][4]; for (int i = 0; i < 4; i++) for (int j = 0; j <
		 * 4; j++) { System.out.println("enter a number"); m[i][j] =
		 * input.nextDouble(); }
		 * 
		 * System.out.print(ttt(m));
		 */
	}

	public static int ttt(double[][] m) {
		int sum = 0;

		for (int i = 0; i < m.length; i++)
			sum += m[i][i];

		return sum;
	}

}
