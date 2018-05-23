package com.iut.suprails.service;

import com.iut.suprails.dao.TripDao;
import com.iut.suprails.entity.TrainStation;
import com.iut.suprails.entity.Trip;
import java.util.List;
import javax.ejb.EJB;
import javax.ejb.Stateless;

/**
 *
 * @author bargenson
 */
@Stateless
public class TripService {
    
    @EJB
    private TripDao tripDao;
    
    
    public Trip addTrip(Trip trip) {
        return tripDao.addTrip(trip);
    }
    
    public List<Trip> getAllTrips() {
        return tripDao.getAllTrips();
    }

    public void removeTrip(Long tripId) {
        tripDao.removeTrip(findTripById(tripId));
    }
    
    public Trip findTripById(Long tripId) {
        return tripDao.findTripById(tripId);
    }
    
    public List<Trip> findTripByDepArr(TrainStation departure, TrainStation arrival){
        return tripDao.findTripByDepArr(departure, arrival);
    }
    
     public List<Trip> findTripByDepArrBis(Long departure, Long arrival){
        return tripDao.findTripByDepArrBis(departure, arrival);
    }

}
