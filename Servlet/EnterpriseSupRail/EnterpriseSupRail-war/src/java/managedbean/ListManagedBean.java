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
import java.util.ArrayList;
import java.util.List;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.model.SelectItem;

@ManagedBean(name = "listBean")
public class ListManagedBean {

    @EJB
    private TrainStationService stations;
    @EJB
    private TripService trips;

    private TrainStation newStation = new TrainStation();
    private Trip newTrip = new Trip();

    private List<Trip> lesTrips = new ArrayList<>();

    public List<Trip> getLesTrips() {
        return lesTrips;
    }

    private long idaddArrival;
    private long idaddDeparture;
    
    private Long idfilterArrival;
    private Long idfilterDeparture;

    public Long getIdfilterArrival() {return idfilterArrival;}
    public void setIdfilterArrival(Long idfilterArrival) {this.idfilterArrival = idfilterArrival;}
    public Long getIdfilterDeparture() {return idfilterDeparture;}
    public void setIdfilterDeparture(Long idfilterDeparture) {this.idfilterDeparture = idfilterDeparture;}

    private String filterDeparture;
    private String filterArrival;
    private long filterPrice;

    public String getFilterDeparture() {
        return filterDeparture;
    }

    public void setFilterDeparture(String filterDeparture) {
        this.filterDeparture = filterDeparture;
    }

    public String getFilterArrival() {
        return filterArrival;
    }

    public void setFilterArrival(String filterArrival) {
        this.filterArrival = filterArrival;
    }

    public long getFilterPrice() {
        return filterPrice;
    }

    public void setFilterPrice(long filterPrice) {
        this.filterPrice = filterPrice;
    }

    public ListManagedBean() {
        //this.lesTrips = trips.getAllTrips();
    }

    public void setIdaddArrival(long idaddArrival) {this.idaddArrival = idaddArrival;}
    public void setIdaddDeparture(long idaddDeparture) {this.idaddDeparture = idaddDeparture;}
    public long getIdaddArrival() {return idaddArrival;}
    public long getIdaddDeparture() {return idaddDeparture;}

    public TrainStation getNewStation() {
        return newStation;
    }

    public Trip getNewTrip() {
        return newTrip;
    }

    public List<TrainStation> getStations(){
        return stations.getAllTrainStations();
    }
    
    public List<SelectItem> getSelectItems() {
        List<SelectItem> selectItems = new ArrayList<SelectItem>();
        selectItems.add(new SelectItem(null, ""));
        
        for(TrainStation ts : stations.getAllTrainStations()){
            selectItems.add(new SelectItem(ts.getId(), ts.getName()));
        }
        return selectItems;
    }

    public String addStation() {
        stations.addTrainStation(newStation);

        return "stations";
    }

    public List<Trip> getTrips() {
        return trips.getAllTrips();
    }

    public String addTrip() {
        newTrip.setDepartureStation(stations.findTrainStationById(idaddDeparture));
        newTrip.setArrivalStation(stations.findTrainStationById(idaddArrival));

        trips.addTrip(newTrip);

        return "trips";
    }

    public String filterTrips() {
        TrainStation departure = stations.findTrainStationById(idfilterDeparture);
        TrainStation arrival = stations.findTrainStationById(idfilterArrival);

        lesTrips = trips.findTripByDepArr(departure, arrival);

        return "trips";
    }

    public String filterTripsBis() {
        TrainStation departure = new TrainStation();
        TrainStation arrival = new TrainStation();


        lesTrips = trips.findTripByDepArrBis(idfilterDeparture, idfilterArrival);

        return "trips";
    }

    public String allTrips() {
        this.lesTrips = trips.getAllTrips();
        return "trips";
    }

    public String deleteTrip() {
        //this.trips.removeTrip(id);
        return "trips";
    }

    public String Login() {
        return "index";
    }

    public String filter() {
        return "trips";
    }

}
