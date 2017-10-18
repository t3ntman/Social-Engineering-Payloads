# FakeExcel

## Payload
The payload is a custom executable that uses the Excel icon and Right-to-Left Override (RTLO) to mask as an Excel document. The payload makes a non-malicious HTTP GET request to a specified domain (could be modified for more malicious intent), and copies an embedded Excel document in the resource section of the PE to `%TEMP%`. The copied `%TEMP%` file is then executed to not alarm the user.

## Setup
1. Open Visual Studio and create a new `Console Application` project. I called mine "FakeExcel" for this example.
2. Paste the contents of `Program.cs` into the new project's `Program.cs`.
3. Change the `domain` string to the domain you want to make the HTTP GET request to.
4. Change the `temp_filename` string to the filename you want created in `%TEMP%`.
5. In Visual Studio, select `Project`, then `Properties`, and then `Application`. Change `Target Framework` to `.NET Framework 3.5`. Also change `Output Type` to `Windows Application`. This will prevent a console window from appearing when the victim double-clicks the executable. Within this same tab, make sure to change `Icon` to the provided `icon.ico` file.
5. In Visual Studio, select `Project`, then `Properties`, and then `Resources`. Select `Add Resource` to add an actual Excel document to the "Resource" section of the PE file. I called mine "test" so make sure you change the `global::FakeExcel.Properties.Resources.test` line in `Program.cs` to accurately reflect what you named the added resource.
6. In Visual Studio, select `Build`, and then select `Build Solution`. Verify that everything builds successfully. Execute program to verify that your website receives the HTTP GET request.
7. Take the compiled executable and use the following Ruby command to do the RTLO on the filename: `ruby -e 'File.rename("FakeExcel.exe", "2017 Salaries_tl\xe2\x80\xaexslx.exe")'`. This will create a file called `2017 Salaries_tlexe.xlsx`, so change that to match your pretext.
