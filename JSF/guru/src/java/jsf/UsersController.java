package jsf;

import jpa.entities.Users;
import jsf.util.JsfUtil;
import jsf.util.JsfUtil.PersistAction;
import jpa.session.UsersFacade;

import java.io.Serializable;
import java.util.List;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ejb.EJB;
import javax.ejb.EJBException;
import javax.inject.Named;
import javax.enterprise.context.SessionScoped;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.FacesConverter;

@Named("usersController")
@SessionScoped
public class UsersController implements Serializable {

    @EJB
    private jpa.session.UsersFacade ejbFacade;
    private List<Users> items = null;
    private Users selected;

    public UsersController() {
    }

     public String setParam(Users user){
        
        selected=new Users(user.getUserid(),user.getLastName(),user.getFirstName(),user.getGender(),user.getUserName(),user.getPassword(),
        user.getUserType(),user.getEmail(),user.getBirthDate(),user.getPhoneNumber());
        return "usersEdit.xhtml";
    } 
    
    
    public Users getSelected() {
       if(selected == null){
           selected=new Users();
       }
        return selected;
    }

    public void setSelected(Users selected) {
        this.selected = selected;
    }

    protected void setEmbeddableKeys() {
    }

    protected void initializeEmbeddableKey() {
    }

    private UsersFacade getFacade() {
        return ejbFacade;
    }

    public Users prepareCreate() {
       System.out.println("prepare create called");
        selected = new Users();
        initializeEmbeddableKey();
        return selected;
    }

    public void create() {
         System.out.println(" create called");
        persist(PersistAction.CREATE, ResourceBundle.getBundle("/Bundle").getString("UsersCreated"));
        if (!JsfUtil.isValidationFailed()) {
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public void update() {
        persist(PersistAction.UPDATE, ResourceBundle.getBundle("/Bundle").getString("UsersUpdated"));
    }

    public void destroy() {
        persist(PersistAction.DELETE, ResourceBundle.getBundle("/Bundle").getString("UsersDeleted"));
        if (!JsfUtil.isValidationFailed()) {
            selected = null; // Remove selection
            items = null;    // Invalidate list of items to trigger re-query.
        }
    }

    public List<Users> getItems() {
        if (items == null) {
            items = getFacade().findAll();
        }
        return items;
    }

    
    
     public String login() {

      
        selected.getUserName();
        String userName = selected.getUserName();
        String password = selected.getPassword();
        System.out.println("User entered UserName : " + userName);
        System.out.println("User entered password : " + password);

        List<Users> result = getFacade().findAll();
        for (int i = 0; i < result.size(); i++) 
        {           
            if ((result.get(i).getUserName().equals(userName)) && (result.get(i).getPassword().equals(password))) 
            {
                if (result.get(i).getUserType().equals("User")) 
                {
                    getSelected().setFirstName(userName);
                    getSelected().setPassword(password);
                    return "loginsuccess";
                }
                
                else if(result.get(i).getUserType().equals("Admin"))
                {
                    getSelected().setFirstName(userName);
                    getSelected().setPassword(password);
                    return "admin/resources/pages/sitemap";
                }
                else{
                    return "Invalid User Type";
                }

            } 
//            else 
//            {
//                return "login";
//            }
        }
        return "PageNotFound";
    }
    
     
     public String UpdatePassword()
     {

      
      
        String userEmail = selected.getEmail();
        String password = selected.getPassword();
       

        List<Users> result = getFacade().findAll();
        for (int i = 0; i < result.size(); i++) {
           
            if (result.get(i).getEmail().equals(userEmail) )
            {
                // update the new password
                 getSelected().setPassword(password);
                 getSelected().setUserid(result.get(i).getUserid());
                 getSelected().setFirstName(result.get(i).getFirstName());
                 getSelected().setLastName(result.get(i).getLastName());
                 getSelected().setGender(result.get(i).getGender());
                 getSelected().setUserName(result.get(i).getUserName());
                 getSelected().setUserType(result.get(i).getUserType());
                 getSelected().setBirthDate(result.get(i).getBirthDate());
                 getSelected().setPhoneNumber(result.get(i).getPhoneNumber());
                 getSelected().setEmail(result.get(i).getEmail());
                 getSelected().setCity(result.get(i).getCity());
                 getSelected().setCountry(result.get(i).getCountry());
                 getSelected().setState(result.get(i).getState());
               

                
                 persist(PersistAction.UPDATE, ResourceBundle.getBundle("/Bundle").getString("UsersUpdated"));
                   
                   
                   
        }
        return "PageNotFound";
    }
     return "";
     }
    private void persist(PersistAction persistAction, String successMessage) {
        if (selected != null) {
            setEmbeddableKeys();
            try {
                if (persistAction != PersistAction.DELETE) {
                    getFacade().edit(selected);
                } else {
                    getFacade().remove(selected);
                }
                JsfUtil.addSuccessMessage(successMessage);
            } catch (EJBException ex) {
                String msg = "";
                Throwable cause = ex.getCause();
                if (cause != null) {
                    msg = cause.getLocalizedMessage();
                }
                if (msg.length() > 0) {
                    JsfUtil.addErrorMessage(msg);
                } else {
                    JsfUtil.addErrorMessage(ex, ResourceBundle.getBundle("/Bundle").getString("PersistenceErrorOccured"));
                }
            } catch (Exception ex) {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
                JsfUtil.addErrorMessage(ex, ResourceBundle.getBundle("/Bundle").getString("PersistenceErrorOccured"));
            }
        }
    }

    public Users getUsers(java.lang.Integer id) {
        return getFacade().find(id);
    }

    public List<Users> getItemsAvailableSelectMany() {
        return getFacade().findAll();
    }

    public List<Users> getItemsAvailableSelectOne() {
        return getFacade().findAll();
    }

    @FacesConverter(forClass = Users.class)
    public static class UsersControllerConverter implements Converter {

        @Override
        public Object getAsObject(FacesContext facesContext, UIComponent component, String value) {
            if (value == null || value.length() == 0) {
                return null;
            }
            UsersController controller = (UsersController) facesContext.getApplication().getELResolver().
                    getValue(facesContext.getELContext(), null, "usersController");
            return controller.getUsers(getKey(value));
        }

        java.lang.Integer getKey(String value) {
            java.lang.Integer key;
            key = Integer.valueOf(value);
            return key;
        }

        String getStringKey(java.lang.Integer value) {
            StringBuilder sb = new StringBuilder();
            sb.append(value);
            return sb.toString();
        }

        @Override
        public String getAsString(FacesContext facesContext, UIComponent component, Object object) {
            if (object == null) {
                return null;
            }
            if (object instanceof Users) {
                Users o = (Users) object;
                return getStringKey(o.getUserid());
            } else {
                Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, "object {0} is of type {1}; expected type: {2}", new Object[]{object, object.getClass().getName(), Users.class.getName()});
                return null;
            }
        }

    }

}
