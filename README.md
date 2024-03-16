# ky001_temperatureSensor for DS18B20 

# C# port of https://gitlab.com/alvariviris/raspberry/-/blob/main/07_ky001_temp/07_ky001_temp.py 
# Configuration of the temperature sensor can be found: https://www.youtube.com/watch?v=RDW24UtcJ0Y&ab_channel=alvariviris

edit config.txt file with sudo nano /boot/config.txt
add [all] dtoverlay=w1-gpio
reboot
sudo modprobe w1-gpio
sudo modprobe w1-therm

Thanks to alvariviris for the original python lib.
