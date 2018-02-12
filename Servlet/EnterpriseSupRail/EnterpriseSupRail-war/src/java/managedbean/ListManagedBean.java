/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package managedbean;

import com.iut.suprails.entity.TrainStation;
import com.iut.suprails.entity.Trip;
import com.iut.suprails.service.TrainStationService;
import com.iut.suprails.service.TripService;
import java.util.List;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;

@ManagedBean(name="listBean")
public class ListManagedBean {

    @EJB
    private TrainStationService stations;
    @EJB
    private TripService trips;
    
    private TrainStation newStation = new TrainStation();
    private Trip newTrip = new Trip();
    
    private long id1;
    private long id2;
    
    private String filterDeparture;
    private String filterArrival;
    private long filterPrice;

    public String getFilterDeparture() {return filterDeparture;}
    public void setFilterDeparture(String filterDeparture) {this.filterDeparture = filterDeparture;}
    public String getFilterArrival() {return filterArrival;}
    public void setFilterArrival(String filterArrival) {this.filterArrival = filterArrival;}
    public long getFilterPrice() {return filterPrice;}
    public void setFilterPrice(long filterPrice) {this.filterPrice = filterPrice;}  
    
    
    public ListManagedBean() {}

    public void setId1(long id1) {this.id1 = id1;}
    public void setId2(long id2) {this.id2 = id2;}
    
    public long getId1() {return id1;}
    public long getId2() {return id2;}
    
    public TrainStation getNewStation() {return newStation;}
    
    public Trip getNewTrip() {return newTrip;}
    
    public List<TrainStation> getStations() {return stations.getAllTrainStations();}
    public String addStation() {
        stations.addTrainStation(newStation);
        
        return "stations";
    }
    
    public List<Trip> getTrips() {return trips.getAllTrips();}    
    public String addTrip(){        
        newTrip.setDepartureStation(stations.findTrainStationById(id1));
        newTrip.setArrivalStation(stations.findTrainStationById(id2));        
        
        trips.addTrip(newTrip);
        
        return "trips";
    }    
    public String deleteTrip(long id){
        this.trips.removeTrip(id);
        return "trips";
    }
    
    public String Login(){
        return "index";
    }
    
    public String filter(){
        return "trips";
    }
    
}
