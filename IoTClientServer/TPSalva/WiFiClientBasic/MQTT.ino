#include <ESP8266WiFi.h>
#include "PubSubClient.h"

#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN            5 
#define DHTTYPE           DHT11     // DHT 11 
DHT_Unified dht(DHTPIN, DHTTYPE);
// Update these with values suitable for your network.

const char* ssid = "info-licence-a";
const char* password = "pm01web02pm03web04";
const char* mqtt_server = "192.168.1.58";

uint32_t delayMS;

WiFiClient espClient;
PubSubClient client(espClient);
long lastMsg = 0;
char msg[50];
int value = 0;

void setup_wifi() {

  delay(10);
  // We start by connecting to a WiFi network
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  randomSeed(micros());

  Serial.println("");
  Serial.println("WiFi connected");
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
}


void setupDHT() {
    dht.begin();
    sensor_t sensor;
    dht.temperature().getSensor(&sensor);
    // Print humidity sensor details.
    dht.humidity().getSensor(&sensor);
    delayMS = sensor.min_delay / 1000;
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
    String clientId = "ESP8266Client-";
    clientId += String(random(0xffff), HEX);
    // Attempt to connect
    if (client.connect(clientId.c_str())) {
      Serial.println("connected");
      // Once connected, publish an announcement...
      client.publish("out-nini-sysy", "hello world");
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

void setup() {
  pinMode(BUILTIN_LED, OUTPUT);     // Initialize the BUILTIN_LED pin as an output
  Serial.begin(115200);
  setup_wifi();
  setupDHT();
  client.setServer(mqtt_server, 1883);
  client.setCallback(callback);
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

  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  float temp = getTemp();
  float hum = getHum();

  long now = millis();
  if (now - lastMsg > 2000) {
    lastMsg = now;
    ++value;
    snprintf (msg, 75, "Temperature : %s\nHumidity : %s", String(temp).c_str(), String(hum).c_str());
    Serial.print("Publish message: ");
    Serial.println(msg);
    client.publish("out-nini-sysy", msg);
  }
}
