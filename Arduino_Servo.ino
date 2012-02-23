#include <Servo.h>   // Used for servo control

int Serial_Value = 0;  // Initialize the serial value to 0
Servo test_servo;      // Initialize test servo


void setup(){
  Serial.begin(9600);  // Start serial communication at 9600 baud
  test_servo.attach(9);  // Servo control to pin 9
}
 
void loop(){
  if(Serial.available())        // Check if serial port is available
  {
    Serial_Value = Serial.read();  // Read in serial value
  }
   test_servo.write(Serial_Value);    // Output to servo
}
