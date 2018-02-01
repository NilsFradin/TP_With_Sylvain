/*
 *  This sketch sends a message to a TCP server
 *
 */

#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266WebServer.h>

#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN            5 

#define DHTTYPE           DHT11     // DHT 11 
//#define DHTTYPE           DHT22     // DHT 22 (AM2302)
//#define DHTTYPE           DHT21     // DHT 21 (AM2301)

ESP8266WiFiMulti WiFiMulti;

ESP8266WebServer server(80);

DHT_Unified dht(DHTPIN, DHTTYPE);

uint32_t delayMS;

void handleRoot() {
  server.send(200, "text/html", "<h1>You are connected</h1>");
}

void setupDHT() {
    dht.begin();
    sensor_t sensor;
    dht.temperature().getSensor(&sensor);
    // Print humidity sensor details.
    dht.humidity().getSensor(&sensor);
    delayMS = sensor.min_delay / 1000;
}

void setup() {
    Serial.begin(115200);
    delay(10);
    
    setupDHT(); 
       
    // We start by connecting to a WiFi network
    WiFiMulti.addAP("info-licence-a", "pm01web02pm03web04");

    Serial.println();
    Serial.println();
    Serial.print("Wait for WiFi... ");

    while(WiFiMulti.run() != WL_CONNECTED) {
        Serial.print(".");
        delay(500);
    }
    
    Serial.println("");
    Serial.println("WiFi connected");
    Serial.println("IP address: ");
    Serial.println(WiFi.localIP());

    delay(500);
}

void getTempAndHum() {
  // Delay between measurements.
    delay(delayMS);
    // Get temperature event and print its value.
    sensors_event_t event;  
    dht.temperature().getEvent(&event);
    if (isnan(event.temperature)) {
      Serial.println("Error reading temperature!");
    }
    else {
      Serial.print("Temperature: ");
      Serial.print(event.temperature);
      Serial.println(" *C");
    } 
    
    // Get humidity event and print its value.
    dht.humidity().getEvent(&event);
    if (isnan(event.relative_humidity)) {
      Serial.println("Error reading humidity!");
    }
    else {
      Serial.print("Humidity: ");
      Serial.print(event.relative_humidity);
      Serial.println("%");
    }
}

void loop() {
    const uint16_t port = 80;
    const char * host = "192.168.1.1"; // ip or dns

    
    
    Serial.print("\nconnecting to ");
    Serial.println(host);

    // Use WiFiClient class to create TCP connections
    WiFiClient client;

    if (!client.connect(host, port)) {
        Serial.println("connection failed");
        Serial.println("wait 5 sec...");
        delay(5000);
        WiFi.mode(WIFI_AP);
        IPAddress IP(192,168,2,1);
        IPAddress Gateway(192,168,2,255);
        IPAddress subnet(255,255,255,0);
        WiFi.softAPConfig(IP, Gateway, subnet);
        WiFi.softAP("ESP8266", "password");
        IPAddress myIP = WiFi.softAPIP();
        Serial.print("AP IP address: ");
        Serial.println(myIP);
        server.on("/", handleRoot);
        server.begin();
        Serial.println("HTTP server started");
    }

    // This will send the request to the server
    client.print("Send this data to server");

    //read back one line from server
    String line = client.readStringUntil('\r');
    client.println(line);

    getTempAndHum();

    /*
    Serial.println("closing connection");
    client.stop();
    */
    
    Serial.println("wait 5 sec...");
    delay(5000);
}


