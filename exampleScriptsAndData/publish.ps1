$timestamp=Get-Date -format s;
$mrn="185444";
$accNbr="12345";
$topic="https://hub.example.com/7jaa86kgdudewiaq0wtu";

$event= @"
{
  "timestamp": "$timestamp",
  "id": "wYXStHqxFQyHFELh",
  "event": {
    "hub.topic": "$topic",
    "hub.event": "close-patient-chart",
    "context": [
     {
      "key": "patient",
      "resource": {
        "resourceType": "Patient",
        "id": "",
        "identifier": [
          {
            "system": "urn:oid:1.2.840.114350",
            "value": "$mrn"
          },
          {
            "system": "urn:oid:1.2.840.114350.1.13.861.1.7.5.737384.27000",
            "value": "2667"
          }
        ]
      }
    },
    {
      "key": "study",
      "resource": {
        "resourceType": "ImagingStudy",
        "id": "",
        "uid": "urn:oid:2.16.124.113543.6003.1154777499.30246.19789.3503430045",
        "identifier": [
          {
            "system": "7678",
            "value": "$accNbr"
          }
        ]
      }
    }
  ]
}
}
"@;

return $event;
