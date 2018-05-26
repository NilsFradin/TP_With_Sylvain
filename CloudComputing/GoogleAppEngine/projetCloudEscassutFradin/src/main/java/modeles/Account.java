package modeles;

import java.util.UUID;

import com.googlecode.objectify.annotation.Entity;
import com.googlecode.objectify.annotation.Id;

@Entity
public class Account {
	private @Id String id;
	private String name;
	private String firstName;
	private int account;
	private Risk risk;
	
	public Account() {
		
	}
	
	public Account(String name, String firstName, int account, Risk risk) {
		this.id = UUID.randomUUID().toString();
		this.name = name;
		this.firstName = firstName;
		this.account = account;
		this.risk = risk;
	}
	
	public String getId() {
		return this.id;
	}
	
	public String getName() {
		return this.name;
	}

	public String getFirstName() {
		return this.firstName;
	}
	
	public int getAccount() {
		return this.account;
	}
	
	public Risk getRisk() {
		return this.risk;
	}
	
	public void setAccount (int account) {
		this.account = account;
	}
}
