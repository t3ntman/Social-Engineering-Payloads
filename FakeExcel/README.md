# FakeExcel

## Payload
The payload is a custom executable that uses the Excel icon and Right-to-Left Override (RTLO) to mask as an Excel document. The payload makes a non-malicious HTTP GET request to a specified domain (could be modified for more malicious intent), and copies an embedded Excel document in the resource section of the PE to %TEMP%. The copied %TEMP% file is then executed to not alarm the user.
