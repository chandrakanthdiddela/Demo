/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package main.java.edu.unh.csci.c6617.service;

/**
 * 
 * @author Varnith
 */
public class Student {
	private int Assignments;
	private int Exam1;
	private int FinalExam;
	private boolean Cheat;
	private boolean Plagiarism;
	private String FName;
	private String LName;

	public Student() {

	}

	public Student(String pFName, String pLname, int pAssignments, int pexam1,
			int pfinalexam, boolean pcheat, boolean pPlagirism) {

		Assignments = pAssignments;
		Exam1 = pexam1;
		FinalExam = pfinalexam;
		Cheat = pcheat;

		Plagiarism = pPlagirism;
		FName = pFName;
		LName = pLname;

	}

	/**
	 * @return the Assignments
	 */
	public int getAssignments() {
		return Assignments;
	}

	/**
	 * @param Assignments
	 *            the Assignments to set
	 */
	public void setAssignments(int Assignments) {
		this.Assignments = Assignments;
	}

	/**
	 * @return the Exam1
	 */
	public int getExam1() {
		return Exam1;
	}

	/**
	 * @param Exam1
	 *            the Exam1 to set
	 */
	public void setExam1(int Exam1) {
		this.Exam1 = Exam1;
	}

	/**
	 * @return the FinalExam
	 */
	public int getFinalExam() {
		return FinalExam;
	}

	/**
	 * @param FinalExam
	 *            the FinalExam to set
	 */
	public void setFinalExam(int FinalExam) {
		this.FinalExam = FinalExam;
	}

	/**
	 * @return the Cheat
	 */
	public boolean isCheat() {
		return Cheat;
	}

	/**
	 * @param Cheat
	 *            the Cheat to set
	 */
	public void setCheat(boolean Cheat) {
		this.Cheat = Cheat;
	}

	/**
	 * @return the Plagiarism
	 */
	public boolean isPlagiarism() {
		return Plagiarism;
	}

	/**
	 * @param Plagiarism
	 *            the Plagiarism to set
	 */
	public void setPlagiarism(boolean Plagiarism) {
		this.Plagiarism = Plagiarism;
	}

	/**
	 * @return the FName
	 */
	public String getFName() {
		return FName;
	}

	/**
	 * @param FName
	 *            the FName to set
	 */
	public void setFName(String FName) {
		this.FName = FName;
	}

	/**
	 * @return the LName
	 */
	public String getLName() {
		return LName;
	}

	/**
	 * @param LName
	 *            the LName to set
	 */
	public void setLName(String LName) {
		this.LName = LName;
	}

	public String calculateGrade() {
		String grade = "";
		String lFName = this.FName;
		String lLName = this.LName;
		double totalscore = this.getAssignments() + this.Exam1 + this.FinalExam;

		if (totalscore > 90) {
			if (this.isCheat() || this.Plagiarism) {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured F grade");
				grade = "F";
			} else {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured A grade");
				grade = "A";
			}
			// return grade;
		} else if (totalscore >= 80 && totalscore < 90) {

			if (this.isCheat() && this.Plagiarism) {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured C grade");
				grade = "C";
			} else {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured B grade");
				grade = "B";
			}
			// return grade;
		} else if (totalscore > 60 && totalscore < 80) {
			if (this.isCheat() && this.Plagiarism) {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured F grade");
				grade = "F";
			} else {
				System.out.println(lFName + " " + lLName + " "
						+ "Secured C grade");
				grade = "C";
			}
			// return grade;

		}

		else if (totalscore <= 60) {
			System.out.println(lFName + " " + lLName + " " + "Secured D grade");
			grade = "D";
			// return grade;
		}
		return grade;

	}

}
