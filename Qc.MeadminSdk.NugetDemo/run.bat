taskkill /F /T /FI "WINDOWTITLE eq Qc.MeadminSdk.NugetDemo" /IM dotnet.exe
start "Qc.MeadminSdk.NugetDemo" dotnet run
exit