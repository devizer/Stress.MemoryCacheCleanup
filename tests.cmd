"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" Stress.MemoryCacheCleanup.sln  /t:Rebuild /p:Configuration=Debug


packages\NUnit.ConsoleRunner.3.4.1\tools\nunit3-console.exe --labels=On --workers=1 Stress.MemoryCacheCleanup\bin\Debug\Stress.MemoryCacheCleanup.dll