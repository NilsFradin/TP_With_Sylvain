package com.iut.suprails.dao.jpa;

import com.iut.suprails.dao.TripDao;
import com.iut.suprails.entity.TrainStation;
import com.iut.suprails.entity.Trip;
import java.util.ArrayList;
import java.util.List;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

/**
 *
 * @author bargenson
 */
@Stateless
public class JpaTripDao implements TripDao {

    @PersistenceContext
    private EntityManager em;

    @Override
    public Trip addTrip(Trip trip) {
        em.persist(trip);
        return trip;
    }

    @Override
    public List<Trip> getAllTrips() {
        return em.createQuery("SELECT t FROM Trip t").getResultList();
    }

    @Override
    public Trip findTripById(Long tripId) {
        return em.find(Trip.class, tripId);
    }

    @Override
    public void removeTrip(Trip trip) {
        em.remove(trip);
    }

    @Override
    public List<Trip> findTripByDepArr(TrainStation departure, TrainStation arrival) {

        if (departure != null && arrival != null) {
            Long departure_id = departure.getId();
            Long arrival_id = arrival.getId();

            Query query = em.createQuery("SELECT t FROM Trip t WHERE t.departureStation.id = :departure_id and t.arrivalStation.id = :arrival_id");
            query.setParameter("departure_id", departure_id);
            query.setParameter("arrival_id", arrival_id);

            return query.getResultList();
        }else if(departure != null && arrival == null){
            Long departure_id = departure.getId();

            Query query = em.createQuery("SELECT t FROM Trip t WHERE t.departureStation.id = :departure_id ");
            query.setParameter("departure_id", departure_id);
            return query.getResultList();
            
        }else if(departure == null && arrival != null){
            Long arrival_id = arrival.getId();

            Query query = em.createQuery("SELECT t FROM Trip t WHERE t.arrivalStation.id = :arrival_id");
            query.setParameter("arrival_id", arrival_id);
            
            return query.getResultList();
        }
        return null;
    }

    @Override
    public List<Trip> findTripByDepArrBis(Long departure, Long arrival) {
        CriteriaBuilder criteriaBuilder = em.getCriteriaBuilder();        
        CriteriaQuery<Trip> query = criteriaBuilder.createQuery(Trip.class);
        
        Root<Trip> trip = query.from(Trip.class);
        
        List<Predicate> predicates = new ArrayList<Predicate>();
        if(departure != null){
            predicates.add(criteriaBuilder.equal(trip.get("departureStation").get("id").as(Long.class), departure));
        }
        if(arrival != null){
            predicates.add(criteriaBuilder.equal(trip.get("arrivalStation").get("id").as(Long.class), arrival));
        }
        
        query.where(predicates.toArray(new Predicate[predicates.size()]));
        
        List<Trip> lesTrips =  em.createQuery(query).getResultList();
        
        return lesTrips;
    }

}
