#

## Directions
Meadows  
[Getting Started Deploying Meadows](http://developer.wildernesslabs.co/Meadow/Getting_Started/Deploying_Meadow/)

#### Install or update Meadow CLI 
```PowerShell
#Install
dotnet tool install WildernessLabs.Meadow.CLI --global

#Update
dotnet tool update WildernessLabs.Meadow.CLI --global
```

#### Download Meadow OS and network binaries
```PowerShell
# Download meadows
meadow download os
```

#### Install dfu-util to update USB driver
```PowerShell
#Install (need admin permissions)
meadow install dfu-util
```

#### Update USB driver for ST devices
In-depth explanation [Scott Hanselman - Meadows](https://www.hanselman.com/blog/how-to-fix-dfuutil-stm-winusb-zadig-bootloaders-and-other-firmware-flashing-issues-on-windows)

1. Run [Zadig](https://zadig.akeo.ie/)
2. Connect a Meadow device in bootloader mode
3. In Zadig, list devices and select STM32 BOOTLOADER in the dropdown
4. Replace Driver (After the installation is complete, driver should be WinUSB)

#### Put Device into DFU Bootloader mode
1. Hold down `boot` button while board boots up.  If board is disconnect, hold `boot` and connect board via computer.  If board is connected, hold the boot button press and release the `rst` button.

#### Flash Meadow.OS and Coprocessor Firmware
```PowerShell
# From bootloader mode
meadow install dfu-util

# Not from bootloader mode there are more directions.
```
