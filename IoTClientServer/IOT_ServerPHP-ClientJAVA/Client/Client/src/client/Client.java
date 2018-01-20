/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client;

import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.HttpURLConnection;
import java.net.URL;

/**
 *
 * @author alcaillot1
 */
public class Client {
    private final String USER_AGENT = "Mozilla/5.0";
    
    protected String url;
    protected Reader readerKey;
    protected BufferedReader keyboard;    
    protected BufferedReader readerHttp;
    protected HttpURLConnection connection;
    
    public Client(String url) {
        this.url = url;
        
        this.readerKey = null;
        this.readerHttp = null;
        this.keyboard = null;
    }
    
    public static void main(String[] args) throws Exception {
        /*if (args.length != 1) {
            System.out.println("Usage : java client url");
            System.exit(0);
        }
        
        String url = args[0];*/
        
        Client client = new Client("http://hina/~nifradin1/IOT_ServerPHP-ClientJAVA/Server/");
        client.connect();
    }

    public void connect() throws Exception {
        String request, choice, line;
        
        this.readerKey = new InputStreamReader(System.in);
        this.keyboard = new BufferedReader(this.readerKey);
        
        // Show the commands
        this.showAllowCommands();

        while (true) {
            this.show("Text to send : ");
            line = this.keyboard.readLine();
            
            if (line.equals("QUIT")) { break; }
            
            this.show("Choice : ");
            choice = this.keyboard.readLine();

            request = String.format("%s: %s", choice, line);
            this.sendRequest(choice, request);
        }
    }
    
    protected void sendRequest(String choice, String request) throws Exception {
        switch(choice) {
            case "1":
                this.sendPost(request);
                break;
            case "2":
                this.sendGet(request);
                break;
            default:
                this.showln("Error, wrong choice !");
                break;
            }
    }
    
    // HTTP GET request
    protected void sendGet(String line) throws Exception {
        URL url = new URL(String.format("%s?Field=%s", this.url, line));
        this.connection = (HttpURLConnection) url.openConnection();

        // optional default is GET
        this.connection.setRequestMethod("GET");

        //add request header
        this.connection.setRequestProperty("User-Agent", USER_AGENT);

        int responseCode = this.connection.getResponseCode();
        this.showln("\nSending 'GET' request to URL : " + this.url);
        this.showln("Response Code : " + responseCode);

        this.readerHttp = new BufferedReader(new InputStreamReader(this.connection.getInputStream()));
        
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = this.readerHttp.readLine()) != null) {
            response.append(inputLine);
        }
        this.readerHttp.close();

        //print result
        this.showln(response.toString());
    }

    // HTTP POST request
    protected void sendPost(String line) throws Exception {
        URL url = new URL(this.url);
        this.connection = (HttpURLConnection) url.openConnection();

        //add reuqest header
        this.connection.setRequestMethod("POST");
        this.connection.setRequestProperty("User-Agent", USER_AGENT);
        this.connection.setRequestProperty("Accept-Language", "en-US,en;q=0.5");

        String urlParameters = String.format("Field=%s", line);

        // Send post request
        this.connection.setDoOutput(true);
        DataOutputStream wr = new DataOutputStream(this.connection.getOutputStream());
        wr.writeBytes(urlParameters);
        wr.flush();
        wr.close();

        int responseCode = this.connection.getResponseCode();
        this.showln("\nSending 'POST' request to URL : " + this.url);
        this.showln("Post parameters : " + urlParameters);
        this.showln("Response Code : " + responseCode);

        BufferedReader in = new BufferedReader(new InputStreamReader(this.connection.getInputStream()));
        String inputLine;
        StringBuffer response = new StringBuffer();

        while ((inputLine = in.readLine()) != null) {
            response.append(inputLine);
        }
        in.close();

        //print result
        this.showResponse(response.toString());
    }
    
    protected void showAllowCommands() {
        this.showln("Commands allow : \n"
                + "- 1: ... => Count words \n"
                + "- 2: ... => Count letters \n"
                + "- QUIT => Close Connection \n");
    }
    
    protected void showResponse(String response) throws IOException {
        this.showln("------------------------------");
        this.showln(String.format("Recu : %s", response));
        this.showln("------------------------------");
    }
    
    protected void show(String content) {
        System.out.print(content);
    }
    
    protected void showln(String content) {
        System.out.println(content);
    }
}
