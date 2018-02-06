/*
 *  This sketch sends a message to a TCP server
 *
 */

#include <ESP8266WiFi.h>
#include <ESP8266WiFiMulti.h>
#include <ESP8266WebServer.h>
#include "PubSubClient.h"

#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN            5 
#define TOPIC "nini-sysy"
#define DHTTYPE           DHT11     // DHT 11 
//#define DHTTYPE           DHT22     // DHT 22 (AM2302)
//#define DHTTYPE           DHT21     // DHT 21 (AM2301)

ESP8266WiFiMulti WiFiMulti;

ESP8266WebServer server(80);

DHT_Unified dht(DHTPIN, DHTTYPE);

uint32_t delayMS;

const char* mqtt_server = "192.168.1.58";

WiFiClient espClient;
PubSubClient client(espClient);
long lastMsg = 0;
char msg[50];
int value = 0;

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
    pinMode(BUILTIN_LED, OUTPUT);
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

    client.setServer(mqtt_server, 1883);
    client.setCallback(callback);

    delay(500);
}

void callback(char* topic, byte* payload, unsigned int length) {
  Serial.print("Message arrived [");
  Serial.print(topic);
  Serial.print("] ");
  for (int i = 0; i < length; i++) {
    Serial.print((char)payload[i]);
  }
  Serial.println();

  // Switch on the LED if an 1 was received as first character
  if ((char)payload[0] == '1') {
    digitalWrite(BUILTIN_LED, LOW);   // Turn the LED on (Note that LOW is the voltage level
    // but actually the LED is on; this is because
    // it is acive low on the ESP-01)
  } else {
    digitalWrite(BUILTIN_LED, HIGH);  // Turn the LED off by making the voltage HIGH
  }

}

void reconnect() {
  // Loop until we're reconnected
  while (!client.connected()) {
    Serial.print("Attempting MQTT connection...");
    // Create a random client ID
    String clientId = "ESP8266Client-nini-sysy";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str())) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish(TOPIC, "hello world");
      // ... and resubscribe
      client.subscribe("nini-sysy");
    } else {
      Serial.print("failed, rc=");
      Serial.print(client.state());
      Serial.println(" try again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}
float getTemp() {
    // Delay between measurements.
    delay(delayMS);
    // Get temperature event and print its value.
    sensors_event_t event;  
    dht.temperature().getEvent(&event);
    float temp;
    if (isnan(event.temperature)) {
      Serial.println("Error reading temperature!");
    }
    else {
      Serial.print("Temperature: ");
      temp = event.temperature;
      Serial.print(temp);
      Serial.println(" *C");
    } 

    return temp;
}

float getHum() {
    // Get humidity event and print its value.
    sensors_event_t event;
    dht.humidity().getEvent(&event);
    float hum;
    if (isnan(event.relative_humidity)) {
      Serial.println("Error reading humidity!");
    }
    else {
      Serial.print("Humidity: ");
      hum = event.relative_humidity;
      Serial.print(hum);
      Serial.println("%");
    }

    return hum;
}

void loop() {
    const uint16_t port = 80;
    const char * host = "192.168.1.1"; // ip or dns
    
    Serial.print("\nconnecting to ");
    Serial.println(host);

    // Use WiFiClient class to create TCP connections
    WiFiClient espClient;

    if (!espClient.connect(host, port)) {
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
    espClient.print("Send this data to server");

    //read back one line from server
    String line = espClient.readStringUntil('\r');
    espClient.println(line);

    float temp = getTemp();
    float hum = getHum();
    
    if (!client.connected()) {
      reconnect();
    }
    client.loop();
  
    long now = millis();
    if (now - lastMsg > 2000) {
      lastMsg = now;
      ++value;
      snprintf (msg, 75, "Temperature : %s\nHumidity : %s", String(temp).c_str(), String(hum).c_str());
      Serial.print("Publish message: ");
      Serial.println(msg);
      client.publish("nini-sysy", msg);
    }

    /*
    Serial.println("closing connection");
    client.stop();
    */
    
    Serial.println("wait 5 sec...");
    delay(5000);
}


