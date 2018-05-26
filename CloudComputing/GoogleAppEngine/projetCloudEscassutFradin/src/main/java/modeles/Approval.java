package modeles;

import java.util.UUID;

import com.googlecode.objectify.annotation.Entity;
import com.googlecode.objectify.annotation.Id;

@Entity
public class Approval {
	private @Id String id;
	private String name;
	private ManualResponse manualResponse;
	
	public Approval() {
		
	}
	
	public Approval(String name, ManualResponse manualResponse) {
		this.id = UUID.randomUUID().toString();
		this.name = name;
		this.manualResponse = manualResponse;
	}
	
	public String getId() {
		return this.id;
	}
	
	public String getName() {
		return this.name;
	}

	public ManualResponse getManualResponse() {
		return this.manualResponse;
	}
}
