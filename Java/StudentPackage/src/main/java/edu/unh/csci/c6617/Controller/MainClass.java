/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package main.java.edu.unh.csci.c6617.Controller;

import main.java.edu.unh.csci.c6617.service.Student;

/**
 * 
 * @author Varnith
 */
public class MainClass {

	/**
	 * @param args
	 *            the command line arguments
	 */
	public static void main(String[] args) {
		// TODO code application logic here
		Student lobjstudent = new Student();
		lobjstudent.setAssignments(30);
		lobjstudent.setExam1(30);
		lobjstudent.setFinalExam(40);
		lobjstudent.setCheat(false);
		lobjstudent.setPlagiarism(false);
		lobjstudent.setFName("Chandrakanth");
		lobjstudent.setLName("Diddela");
		lobjstudent.calculateGrade();

		Student lobjstudent2 = new Student();
	}

}
