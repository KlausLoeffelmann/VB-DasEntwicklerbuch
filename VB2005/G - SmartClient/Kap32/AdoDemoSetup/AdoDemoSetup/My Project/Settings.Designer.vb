﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:2.0.50727.42
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings),MySettings)
        
#Region "Funktion zum automatischen Speichern von My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property AppAnwendungZuvorGestartet() As Boolean
            Get
                Return CType(Me("AppAnwendungZuvorGestartet"),Boolean)
            End Get
            Set
                Me("AppAnwendungZuvorGestartet") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("/****** Object:  Table [dbo].[Berater]    Script Date: 03/04/2006 16:01:45 ******"& _ 
            "/"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET ANSI_NULLS ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET QUOTED_IDENTIFIER ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"IF NOT EXISTS (SELECT * "& _ 
            "FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Berater]') AND type in (N'"& _ 
            "U'))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"BEGIN"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"CREATE TABLE [dbo].[Berater]("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDBerater] [int] IDENTITY(1,1) NOT"& _ 
            " NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Nachname] [nvarchar](255) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Vorname] [nvarchar](255) NOT NU"& _ 
            "LL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Straße] [nvarchar](255) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Plz] [nvarchar](50) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Ort"& _ 
            "] [nvarchar](255) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" CONSTRAINT [PK_Berater] PRIMARY KEY CLUSTERED "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDBerater] ASC"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&")WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&") ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"EN"& _ 
            "D"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"/****** Object:  Table [dbo].[Projekte]    Script Date: 03/04/2006 16:01:"& _ 
            "45 ******/"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET ANSI_NULLS ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET QUOTED_IDENTIFIER ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"IF NOT EXISTS ("& _ 
            "SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Projekte]') AND t"& _ 
            "ype in (N'U'))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"BEGIN"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"CREATE TABLE [dbo].[Projekte]("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDProjekte] [int] IDENT"& _ 
            "ITY(1,1) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Projektname] [nvarchar](50) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Projektbeschreibu"& _ 
            "ng] [nvarchar](2000) NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Startzeitpunkt] [datetime] NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Endzeitpun"& _ 
            "kt] [datetime] NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Ausführungsort] [nvarchar](255) NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" CONSTRAINT ["& _ 
            "PK_Projekte] PRIMARY KEY CLUSTERED "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDProjekte] ASC"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&")WITH (IGNORE_DUP_KEY"& _ 
            " = OFF) ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&") ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"END"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"/****** Object:  Table [dbo].[Zei"& _ 
            "ten]    Script Date: 03/04/2006 16:01:45 ******/"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET ANSI_NULLS ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"SET QUO"& _ 
            "TED_IDENTIFIER ON"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id "& _ 
            "= OBJECT_ID(N'[dbo].[Zeiten]') AND type in (N'U'))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"BEGIN"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"CREATE TABLE [dbo].[Z"& _ 
            "eiten]("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDZeiten] [int] IDENTITY(1,1) NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDProjekt] [int] NOT NULL,"& _ 
            ""&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDBerater] [int] NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Startzeit] [datetime] NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[Endzeit] [d"& _ 
            "atetime] NOT NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[ArbBeschreibung] [nvarchar](2000) NULL,"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&" CONSTRAINT [PK_Z"& _ 
            "eiten] PRIMARY KEY CLUSTERED "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"("&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(9)&"[IDZeiten] ASC"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&")WITH (IGNORE_DUP_KEY = OFF) "& _ 
            "ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&") ON [PRIMARY]"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"END"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"IF NOT EXISTS (SELECT * FROM sys.foreign_"& _ 
            "keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Zeiten_Berater]') AND parent_object"& _ 
            "_id = OBJECT_ID(N'[dbo].[Zeiten]'))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ALTER TABLE [dbo].[Zeiten]  WITH CHECK ADD "& _ 
            " CONSTRAINT [FK_Zeiten_Berater] FOREIGN KEY([IDBerater])"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"REFERENCES [dbo].[Bera"& _ 
            "ter] ([IDBerater])"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"GO"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE obje"& _ 
            "ct_id = OBJECT_ID(N'[dbo].[FK_Zeiten_Projekte]') AND parent_object_id = OBJECT_I"& _ 
            "D(N'[dbo].[Zeiten]'))"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ALTER TABLE [dbo].[Zeiten]  WITH CHECK ADD  CONSTRAINT [F"& _ 
            "K_Zeiten_Projekte] FOREIGN KEY([IDProjekt])"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"REFERENCES [dbo].[Projekte] ([IDPro"& _ 
            "jekte])"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10))>  _
        Public ReadOnly Property HeckTickDBCreationCommandText() As String
            Get
                Return CType(Me("HeckTickDBCreationCommandText"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property HeckTickConnectionString() As String
            Get
                Return CType(Me("HeckTickConnectionString"),String)
            End Get
            Set
                Me("HeckTickConnectionString") = value
            End Set
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.AdoDemoSetup.My.MySettings
            Get
                Return Global.AdoDemoSetup.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
