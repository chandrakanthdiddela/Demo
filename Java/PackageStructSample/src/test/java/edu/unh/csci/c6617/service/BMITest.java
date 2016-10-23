package test.java.edu.unh.csci.c6617.service;

import static org.junit.Assert.assertTrue;
import main.java.edu.unh.csci.c6617.service.BMI;

import org.junit.Test;

public class BMITest {

	@Test
	public void test() {

		System.out.println("Before creating BMI object");
		BMI lobj = new BMI(20.5, 30.5);
		System.out.println("height in meters" + lobj.getHeight());
		System.out.println(" weight in kgs" + lobj.getWeight());
		System.out.println("After creating BMI object");
		// Check that a condition is true
		assertTrue(20.5 == lobj.getHeightInMeters());
		System.out.println("end of the test");
	}

}
