package ws;

import com.googlecode.objectify.annotation.Entity;
import com.googlecode.objectify.annotation.Id;

@Entity
public class Employe {
	@Id String name;
	String firstName;
	
	public Employe(String name, String firstName) {
		this.name = name;
		this.firstName = firstName;
	}
	
	public String getName() {
		return this.name;
	}

	public String getFirstName() {
		return this.firstName;
	}
}
