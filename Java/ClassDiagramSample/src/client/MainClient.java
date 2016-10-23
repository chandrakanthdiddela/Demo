package client;

import cdMain.Booking;
import cdMain.Payment;
import cdMain.Seat;
import cdMain.Show;
import cdMain.Ticket;
import cdMain.TicketType;
import cdMain.User;
import cdMain.Venue;

public class MainClient {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub

		System.out.println("****Welcome to client class****");
		Booking lobjBook = new Booking();
		Payment lobjPayment = new Payment();
		Seat lobjSeat = new Seat();
		Show lobjShow = new Show();
		Ticket lobjTicket = new Ticket();
		TicketType lobjTicketType = new TicketType();
		User lobjUser = new User();
		Venue lobjVenue = new Venue();
		System.out.println("****Thank you for using client class****");

	}

}
