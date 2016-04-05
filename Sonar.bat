if %1.==. (
    set version=dev
) else (
    set version=%1
)

C:\APPS\Sonar\MSBuild.SonarQube.Runner-2.0\MSBuild.SonarQube.Runner.exe begin /k:"IPX800cs" /n:"IPX800 C#" /v:"%version%" /d:sonar.resharper.cs.reportPath="resharper.xml" /d:sonar.resharper.solutionFile="IPX800cs.sln"
"C:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" IPX800cs.sln /t:Rebuild
"D:\jetbrains-commandline-tools\inspectcode.exe" /output=resharper.xml IPX800cs.sln
C:\APPS\Sonar\MSBuild.SonarQube.Runner-2.0\MSBuild.SonarQube.Runner.exe end