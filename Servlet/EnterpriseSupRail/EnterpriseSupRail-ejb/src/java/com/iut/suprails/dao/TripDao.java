package com.iut.suprails.dao;

import com.iut.suprails.entity.Trip;
import java.util.List;
import javax.ejb.Local;
import com.iut.suprails.entity.TrainStation;

/**
 *
 * @author bargenson
 */
@Local
public interface TripDao {
    
    Trip addTrip(Trip trip);
    
    List<Trip> getAllTrips();

    public Trip findTripById(Long tripId);

    public void removeTrip(Trip findTripById);
    
    public List<Trip> findTripByDepArr(TrainStation departure, TrainStation arrival);
    
    public List<Trip> findTripByDepArrBis(Long departure, Long arrival);
    
}
