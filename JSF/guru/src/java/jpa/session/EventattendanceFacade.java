/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package jpa.session;

import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import jpa.entities.Eventattendance;

/**
 *
 * @author chandrakanth
 */
@Stateless
public class EventattendanceFacade extends AbstractFacade<Eventattendance> {

    @PersistenceContext(unitName = "guruPU")
    private EntityManager em;

    @Override
    protected EntityManager getEntityManager() {
        return em;
    }

    public EventattendanceFacade() {
        super(Eventattendance.class);
    }
    
}
