## PR 45/2023 Marija Krsmanovic

# ⚙️ dCom Project – RTU Communication System

## 📌 Overview

This project implements a remote communication system using a dCom application to interact with an RTU (Remote Terminal Unit) simulator.

The system is designed to periodically read and control digital and analog signals over a TCP connection, simulating industrial process monitoring (e.g., water tank level and pump control).

---

## 🧩 System Description

The application communicates with an RTU device configured via a `RtuCfg.txt` file.

### Defined Signals

| Name      | Type           | Address | Description                  |
| --------- | -------------- | ------- | ---------------------------- |
| L         | Analog Input   | 700     | Water level in tank (liters) |
| STOP      | Digital Output | 1300    | STOP switch (ON/OFF)         |
| Ventil V1 | Digital Output | 1302    | Valve state (OPEN/CLOSED)    |
| P1        | Digital Output | 1305    | Pump switch P1 (ON/OFF)      |
| P2        | Digital Output | 1306    | Pump switch P2 (ON/OFF)      |
| N1        | Analog Output  | 300     | Pump motor power             |

---

## 🌐 Communication Configuration

* **RTU Slave Address:** 111
* **Protocol:** TCP
* **Port:** 34234

The system uses a configuration file (`RtuCfg.txt`) where:

* Digital outputs (coils) are initialized with default value `0`
* Additional parameters are defined for digital signals

---

## 🚀 Features

* Establish TCP communication with RTU simulator
* Periodic reading of digital outputs (coils)
* Periodic reading of analog outputs (holding registers)
* Real-time UI updates
* Control panel for writing digital values (ON/OFF)
* Control panel for writing analog values
* Automatic refresh after each write operation

---

## ⏱️ Data Refresh Rates

* Digital signals: every **2 seconds**
* Analog signals: every **1 second**

---

## ⚙️ How It Works

1. The application reads configuration from `RtuCfg.txt`
2. Establishes a TCP connection with the RTU simulator
3. Periodically reads:

   * Digital values (coils)
   * Analog values (holding registers)
4. Displays values in the user interface
5. Allows user interaction through control panel
6. Updates UI after each command

---

## 🛠️ Technologies Used

* C# / .NET
* TCP/IP Communication
* RTU / Industrial communication concepts
* Visual Studio

---

## ▶️ How to Run

### Prerequisites

* Visual Studio
* .NET Framework / SDK
* RTU Simulator

### Steps

1. Clone the repository:

   ```bash
   git clone https://github.com/marijjak/dCom-project.git
   ```

2. Open `dCom.sln` in Visual Studio

3. Configure `RtuCfg.txt` according to system specification

4. Start RTU simulator

5. Run the application

---

## 📚 Learning Objectives

This project demonstrates:

* Industrial communication basics
* TCP-based client-server interaction
* Working with digital and analog signals
* Configuration-driven system design
* Real-time data visualization

---

## ⚠️ Notes

* Proper configuration of `RtuCfg.txt` is required
* RTU simulator must be running before starting the app
* Communication depends on correct IP/port setup

---

## 👩‍💻 Author

GitHub: https://github.com/marijjak

---

## 📄 License

This project is for educational purposes.
