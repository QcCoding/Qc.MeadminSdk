taskkill /F /T /FI "WINDOWTITLE eq Qc.MeadminSdk.Sample" /IM dotnet.exe
start "Qc.MeadminSdk.Sample" dotnet run
exit