# Introduction
FHIRcast® adapter is a Windows application (.Net winform )  for integrating legacy applications with a FHIRcast Hub.


![UI.png](/images/UI.png)

It provides a file watcher that legacy applications can use to upload their events to the FHIRcast hub.  In order to support any file format, a scripting component is used to parse the file and convert it to a compliant JSON message.
The same scripting mechanism is used to deliver FHIRcast events to the legacy application.  Upon receiving a FHIRcast event, the adapter invokes a script that can be used to parse the JSON message and perform some integration action.

The goal of this open source effort is to facilitate end-client adaptation to FHIRcast by providing an simple example code set. It is not expected to have this software used as is in a production environment.  The adapter does not provide any security. For example, the 'secret' is contained in app.config unencrypted.  Furthermore, scripts could be modified to inject malicious code.  In a production environment, these scripts should be encrypted or stored only on a server and not on the client filesystem.

# Usage
The adapter is a 'system tray' application.  Clicking on the upper-right corner of the form will not shutdown the application; it will keep running and appear in the system tray.  Clicking on the icon in the system tray will bring the UI back and then the 'shutdown' button can be used to terminate the application.

The directory being watched is fixed to '.\req\' under the directory where the adapter is running.  If it does not exists, it will be created on start-up.  If it exists, all files in the directory will be deleted on start-up.

If a file is dropped with a ".json" extension, the content of the file will be posted to the hub 'as is' without modification.  Any other file extension will invoke a script named 'publish.ps1.txt' that must be present in the same directory as the adapter.  The content of the file dropped is accessible in a variable named 'fileContent'.  The script must do the necessary parsing and manipulation and return a valid FHIRcast JSON string.  The JSON string will be sent to the hub with websocket. 

Upon receiving a FHIRcast event from the hub, the adapter will invoke a script named 'receive.ps1.txt' and insert the JSON message in a variable called 'event'.  The script can use that data to do whatever is necessary to provide the desired integration.

To start the receiving and publishing of events, the adapter must first post a subscription to the hub.  It is not necessary to specify an event from the available checkboxes as some applications only want to publish events but a subsciption must be filed.  After a successful post, the websocket will be bound to receive events.



# Contribution
We welcome any contributions to help improve this tool for the FHIRcast community ! 

To contribute to this project, please issue a pull request on the fhircast/sandbox.js repository with your changes for review.

[Converse at chat.fhir.org](https://chat.fhir.org/#narrow/stream/fhircast)

HL7®, FHIR® and the FHIR logo 🔥® are the registered trademarks of Health Level Seven International.
