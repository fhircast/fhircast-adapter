# fhircast-adapter
FHIRcast adapter is a Windows application (.Net winform )  for integrating legacy applications with a FHIRcast Hub.
![UI.png](/images/UI.png)

It provides a file watcher that legacy applications can use to upload their events to the FHIRcast hub.  In order to support any file format, a scripting component is used to parse the file and convert it to a compliant JSON message.
The same scripting mechanism is used to deliver FHIRcast events to the legacy application.  Upon receiving a FHIRcast event, the adapter invokes a script that can be used to parse the JSON message and :
*  Drop a file in a directory being watched by the legacy app.
*  Invoke a command-line executable with arguments.
*  Launch an Internet Explorer session.
*  Redirect an existing Internet Explorer session.
*  Anything that can be done in PowerShell...

The goal of this open source effort is to facilitate end-client adaptation to FHIRcast by providing an simple example code set. It is not expected to have this software used as is in a production environment.  The software on its own does not provide any security, for example, the 'secret' is contained in app.config unencrypted.  Furthermore, scripts could be modified to inject malicious code.  In a produciton environment, these script should be encrypted or stored only on a server and not on the filesystem.
