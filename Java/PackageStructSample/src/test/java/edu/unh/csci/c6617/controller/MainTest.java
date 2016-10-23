package test.java.edu.unh.csci.c6617.controller;

import main.java.edu.unh.csci.c6617.Controller.MainClass;

import org.junit.Test;

public class MainTest {

	// this test will create an object of type BMI and print the value of height
	// and weight
	@Test
	public void MainClasstest() {

		System.out.println("before creating main class object");
		MainClass lobjmainclass = new MainClass();
		System.out.println("after creating main class object");
	}
}
