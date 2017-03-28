/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jsf;

import java.io.Serializable;
import javax.faces.application.FacesMessage;
import javax.faces.context.FacesContext;
import javax.inject.Named;
import javax.faces.view.ViewScoped;
import org.primefaces.event.DashboardReorderEvent;
import org.primefaces.model.DashboardColumn;
import org.primefaces.model.DashboardModel;
import org.primefaces.model.DefaultDashboardColumn;
import org.primefaces.model.DefaultDashboardModel;

/**
 *
 * @author chandrakanth
 */
@Named(value = "dashboardController")
@ViewScoped
public class DashboardController implements Serializable {

    /**
     * Creates a new instance of DashboardController
     */
   
    
    private static final long serialVersionUID = -291033332986147359L;

	private DashboardModel model;

	public DashboardController() {
		model = new DefaultDashboardModel();
		DashboardColumn column1 = new DefaultDashboardColumn();
		DashboardColumn column2 = new DefaultDashboardColumn();
		DashboardColumn column3 = new DefaultDashboardColumn();

		column1.addWidget("sports");
		column1.addWidget("events");

		column2.addWidget("weather");
		column2.addWidget("clicks");

		column3.addWidget("politics");
		column3.addWidget("entertainment");

		model.addColumn(column1);
		model.addColumn(column2);
		model.addColumn(column3);
	}

	public void handleReorder(DashboardReorderEvent event) {
		FacesMessage message = new FacesMessage();
		message.setSeverity(FacesMessage.SEVERITY_INFO);
		message.setSummary("Reordered: " + event.getWidgetId());
		message.setDetail("Item index: " + event.getItemIndex() + ", Column index: "
				+ event.getColumnIndex() + ", Sender index: " + event.getSenderColumnIndex());
		addMessage(message);
	}

	private void addMessage(FacesMessage message) {
		FacesContext.getCurrentInstance().addMessage(null, message);
	}

	public DashboardModel getModel() {
		return model;
	}
}
