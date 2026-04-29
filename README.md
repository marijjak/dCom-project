PR 45/2023-Marija Krsmanovic

⚙️ dCom Project – RTU Communication System
📌 Overview
This project implements a remote communication system using a dCom application to interact with an RTU (Remote Terminal Unit) simulator.
The system is designed to periodically read and control digital and analog signals over a TCP connection, simulating industrial process monitoring (e.g., water tank level and pump control).

🧩 System Description

The application communicates with an RTU device configured via a RtuCfg.txt file.
| Name      | Type           | Address | Description                  |
| --------- | -------------- | ------- | ---------------------------- |
| L         | Analog Input   | 700     | Water level in tank (liters) |
| STOP      | Digital Output | 1300    | STOP switch (ON/OFF)         |
| Ventil V1 | Digital Output | 1302    | Valve state (OPEN/CLOSED)    |
| P1        | Digital Output | 1305    | Pump switch P1 (ON/OFF)      |
| P2        | Digital Output | 1306    | Pump switch P2 (ON/OFF)      |
| N1        | Analog Output  | 300     | Pump motor power             |
🌐 Communication Configuration
RTU Slave Address: 111
Protocol: TCP
Port: 34234

The system uses a configuration file (RtuCfg.txt) where:
Digital outputs (coils) are initialized with default value 0
Additional parameters are defined for digital signals

🚀 Features
✅ Establish TCP communication with RTU simulator
🔄 Periodic reading of:
Digital outputs (coils)
Analog outputs (holding registers)
⏱️ Real-time UI updates:
Digital signals every 2 seconds
Analog signals every 1 second
🎛️ Control panel for:
Writing digital outputs (ON/OFF)
Writing analog outputs (numeric values)
🔁 Automatic UI refresh after each write operation

⚙️ How It Works
The application reads configuration from RtuCfg.txt
Establishes a TCP connection with the RTU simulator
Periodically:
Reads digital values (coils)
Reads analog values (holding registers)
Displays values in the user interface
Allows user to:
Change digital states (e.g., valve ON/OFF)
Set analog values (e.g., pump power)
Updates UI after each command

🛠️ Technologies Used
C# / .NET
TCP/IP Communication
Industrial communication concepts (RTU, coils, registers)
Visual Studio

▶️ How to Run
Prerequisites
Visual Studio
.NET Framework / SDK
RTU Simulator

Steps:
Clone the repository:
git clone https://github.com/marijjak/dCom-project.git
Open solution (dCom.sln) in Visual Studio
Configure RtuCfg.txt according to system specification
Start RTU simulator
Run the application

📚 Learning Objectives

This project demonstrates:
Industrial communication basics
TCP-based client-server interaction
Working with digital and analog signals
Configuration-driven system design
Real-time data visualization

⚠️ Notes
Proper configuration of RtuCfg.txt is required
RTU simulator must be running before starting the app
Communication depends on correct IP/port setup

👩‍💻 Author
GitHub: https://github.com/marijjak


