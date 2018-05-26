package project;

import java.rmi.server.UID;

import com.googlecode.objectify.annotation.Entity;
import com.googlecode.objectify.annotation.Id;

@Entity
public class Approval {
	private @Id UID id;
	private String name;
	private ManualResponse manualResponse;
	
	public Approval(String name, ManualResponse manualResponse) {
		this.id = new UID();
		this.name = name;
		this.manualResponse = manualResponse;
	}
	
	public UID getId() {
		return this.id;
	}
	
	public String getName() {
		return this.name;
	}

	public ManualResponse getManualResponse() {
		return this.manualResponse;
	}
}
