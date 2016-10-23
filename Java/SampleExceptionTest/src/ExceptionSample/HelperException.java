package ExceptionSample;

import java.util.InputMismatchException;

public class HelperException {
	
	public void overLimit()
	{
		try
		{
			/*double ldlbmax = Double.MAX_VALUE;
			System.out.println(ldlbmax);
			double overlimt = ldlbmax +1.7976931348623157E308;
			System.out.println(overlimt);*/
			// double d = Double.parseDouble("abc");
			
			throw new InputMismatchException("negative number");
			  
		}
		 catch (NumberFormatException nfe) {
	            nfe.printStackTrace();
	        }
		
		catch (InputMismatchException e)
		{
			System.out.println("input mismatch");
		}
		catch(Exception e)
		{
			//System.out.println(e.getMessage()+"" );
			//e.printStackTrace();
			System.out.println(e.getLocalizedMessage());
		}
	}

}
