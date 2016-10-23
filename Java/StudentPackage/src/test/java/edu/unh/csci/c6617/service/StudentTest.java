package test.java.edu.unh.csci.c6617.service;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import static org.junit.Assert.assertTrue;
import main.java.edu.unh.csci.c6617.service.Student;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;

/**
 * 
 * @author Varnith
 */
public class StudentTest {

	public StudentTest() {
	}

	@BeforeClass
	public static void setUpClass() {
	}

	@AfterClass
	public static void tearDownClass() {
	}

	@Before
	public void setUp() {
	}

	@After
	public void tearDown() {
	}

	// TODO add test methods here.
	// The methods must be annotated with annotation @Test. For example:
	//
	// @Test
	@Test
	public void test1() {
		Student S1 = new Student();
		S1.setAssignments(30);
		S1.setExam1(30);
		S1.setFinalExam(40);
		S1.setCheat(false);
		S1.setPlagiarism(false);
		S1.setFName("A1");
		S1.setLName("B1");
		assertTrue("A" == S1.calculateGrade());
	}

	@Test
	public void test2() {
		Student S1 = new Student();
		S1.setAssignments(30);
		S1.setExam1(30);
		S1.setFinalExam(40);
		S1.setCheat(true);
		S1.setPlagiarism(false);
		S1.setFName("A2");
		S1.setLName("B1");
		assertTrue("F" == S1.calculateGrade());
	}

	@Test
	public void test3() {
		Student S3 = new Student("A3", "B3", 20, 20, 20, false, false);
		assertTrue("D" == S3.calculateGrade());
	}

	@Test
	public void test4() {
		Student S4 = new Student("A4", "B4", 24, 26, 20, false, false);
		assertTrue("C" == S4.calculateGrade());
	}

	@Test
	public void test5() {
		Student S5 = new Student("A5", "B5", 24, 26, 30, false, false);
		assertTrue("B" == S5.calculateGrade());
	}
}
