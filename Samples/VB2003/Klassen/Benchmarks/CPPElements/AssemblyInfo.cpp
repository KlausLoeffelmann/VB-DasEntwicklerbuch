#include "stdafx.h"

using namespace System::Reflection;
using namespace System::Runtime::CompilerServices;

//
// Allgemeine Informationen über eine Assembly werden über folgende Attribute 
// gesteuert. Ändern Sie diese Attributswerte, um die Informationen zu modifizieren,
// die mit einer Assembly verknüpft sind.
//
[assembly:AssemblyTitleAttribute("")];
[assembly:AssemblyDescriptionAttribute("")];
[assembly:AssemblyConfigurationAttribute("")];
[assembly:AssemblyCompanyAttribute("")];
[assembly:AssemblyProductAttribute("")];
[assembly:AssemblyCopyrightAttribute("")];
[assembly:AssemblyTrademarkAttribute("")];
[assembly:AssemblyCultureAttribute("")];		

//
// Versionsinformationen für eine Assembly bestehen aus folgenden vier Werten:
//
//      Hauptversion
//      Nebenversion 
//      Buildnummer
//      Revision
//
// Sie können alle Werte oder die standardmäßige Revision und Buildnummer 
// mit '*' angeben:

[assembly:AssemblyVersionAttribute("1.0.*")];

//
// Um die Assembly zu signieren, müssen Sie einen Schlüssel angeben. Weitere Informationen 
// über die Assemblysignierung finden Sie in der Microsoft .NET Framework-Dokumentation.
//
// Verwenden Sie folgende Attribute, um festzulegen welcher Schlüssel verwendet wird. 
//
// Hinweis: 
//   (*) Wenn kein Schlüssel angegeben ist, wird die Assembly nicht signiert.
//   (*) KeyName verweist auf einen Schlüssel, der im CSP (Crypto Service
//       Provider) auf Ihrem Computer installiert wurde. KeyFile verweist auf eine Datei, die einen
//       Schlüssel enthält.
//   (*) Wenn die Werte für KeyFile und KeyName angegeben werden, 
//       werden folgende Vorgänge ausgeführt:
//       (1) Wenn KeyName im CSP gefunden wird, wird dieser Schlüssel verwendet.
//       (2) Wenn KeyName nicht vorhanden ist und KeyFile vorhanden ist, 
//           wird der Schlüssel in KeyFile im CSP installiert und verwendet.
//   (*) Um eine KeyFile zu erstellen, können Sie das Programm sn.exe (Strong Name) verwenden.
//       Wenn KeyFile angegeben wird, muss der Pfad von KeyFile
//       relativ zum Projektausgabeverzeichnis sein.
//   (*) Das verzögern der Signierung ist eine erweiterte Option. Weitere Informationen finden Sie in der
//       Microsoft .NET Framework-Dokumentation.
//
[assembly:AssemblyDelaySignAttribute(false)];
[assembly:AssemblyKeyFileAttribute("")];
[assembly:AssemblyKeyNameAttribute("")];

