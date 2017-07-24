# ARRacingLeague
 Quickstart
 
 Required Hardware:
 HTC Vive
 NTC Chip or Raspberry pi
 PCA9685 servo control board
 
 Unity side:
 Import Steamvr
 bring a camerarig prefab into your scene
 put the script GetVRDeviceOrientation on the left or right controller
 
 NTC Chip / Raspberry pi side
 follow the instructions here to meet the software dependencies: https://cdn-learn.adafruit.com/downloads/pdf/adafruit-16-channel-servo-driver-with-raspberry-pi.pdf
 
 hook up the i2c interface of the PCA9685 to the board your using to control it
 
 
 TODO
 there are hard coded ip's in the current examples, I just did the poc tonight, and i'll update it later as I make more progress.
