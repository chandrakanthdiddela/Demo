package TestRegex;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

import RegexPack.Student;

public class validateInputsUsingRegex {
	@Test
	public void ValidateInput1() {

		Student lobj = new Student("chandrakanth", "diddela", "959-999-2098",
				"1234567890");
		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a Valid student record");
	}

	@Test
	public void ValidateInput2() {

		Student lobj = new Student("John", "cena_", "203-123-2098",
				"4567890123");
		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a Valid student record");
	}

	@Test
	public void ValidateInput3() {

		Student lobj = new Student("Randy", "Orton", "859-969-2091",
				"3456781290");
		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a Valid student record");
	}

	@Test
	public void ValidateInput4() {

		Student lobj = new Student("chandrakan_h", "diddela", "959-999-2098",
				"1234567890");
		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a not Valid Student record");
	}

	@Test
	public void ValidateInput5() {

		Student lobj = new Student("John1", "cena_", "203-1423-2098",
				"4567@90123");

		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a not Valid Student record");
	}

	@Test
	public void ValidateInput6() {

		Student lobj = new Student("Randy", "Orton", "859-969-45091",
				"3456!!81290");
		String output = lobj.ValidateStudentDetails();
		assertEquals(output, "Entered is a not Valid Student record");
	}

}
