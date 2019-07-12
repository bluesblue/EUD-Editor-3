﻿Imports System.IO
Imports Pfim
Public Module SCConst
    Public SCUnitCount As Byte = 228
    Public SCWeaponCount As Byte = 130
    Public SCFlingyCount As Byte = 209
    Public SCSpriteCount As UShort = 517
    Public SCImageCount As UShort = 999
    Public SCUpgradeCount As Byte = 61
    Public SCTechCount As Byte = 44
    Public SCOrderCount As UShort = 189
    Public SCPortdataCount As UShort = 220
    Public SCSfxdataCount As UShort = 1144
    Public SCIconCount As UShort = 390
    Public SCtbltxtCount As UShort = 1547
    Public SCIscriptCount As UShort = 412


    Public SCButtonCount As Byte = 250

    Public SCMenCount As Byte = 106
    Public SCGrpWireCount As Byte = 131
    Public ASCIICount As UShort = 127


    Public SCCodeCount() As UShort = {
        SCUnitCount,'units
        SCWeaponCount,
        SCFlingyCount,
        SCSpriteCount,
        SCImageCount,
        SCUpgradeCount,
        SCTechCount,
        SCOrderCount,
        SCPortdataCount,
        SCSfxdataCount,
        SCIconCount,
        SCtbltxtCount,
        SCIscriptCount,
        228,'statusinfor
        228,'wireframe
        228,'Unitrequire
        61,'Upgraderequire
        44,'TechResearchrequire
        44,'TechUserequire
        189,'Orderrequire
        SCButtonCount,
        SCButtonCount,'butto
        SCTechCount
    }
    Public Datfilesname() As String = {
        "units",
        "weapons",
        "flingy",
        "sprites",
        "images",
        "upgrades",
        "techdata",
        "orders",
        "portdata",
        "sfxdata",
        "Icon",
        "Startxt",
        "Iscript",
        "statusinfor",
        "wireframe",
        "Unitrequire",
        "Upgraderequire",
        "TechResearchrequire",
        "TechUserequire",
        "Orderrequire",
        "button",
        "buttonSet",
        "Stechdata"
    }



    Public Function CheckOverFlow(Datfiles As SCDatFiles.DatFiles, Value As Long) As Boolean
        Return (SCCodeCount(Datfiles) > Value) And Value >= 0
    End Function

    Public ColorTable() As Color = {
    Nothing,
    Color.FromRgb(184, 184, 232),
    Color.FromRgb(184, 184, 232),
    Color.FromRgb(220, 220, 60),
    Color.FromRgb(255, 255, 255),
    Color.FromRgb(132, 116, 116),
    Color.FromRgb(200, 24, 24),
    Color.FromRgb(16, 252, 24),
    Color.FromRgb(244, 4, 4),
    Nothing,
    Nothing,
    Color.FromArgb(0, 0, 0, 0),
    Nothing,
    Nothing,
    Color.FromRgb(12, 72, 204),
    Color.FromRgb(44, 180, 148),
    Color.FromRgb(136, 64, 156),
    Color.FromRgb(248, 140, 20),
    Nothing,'우측정렬
    Nothing,'가운대정렬
    Color.FromArgb(0, 0, 0, 0),
    Color.FromRgb(112, 48, 20),
    Color.FromRgb(204, 224, 208),
    Color.FromRgb(252, 252, 56),
    Color.FromRgb(8, 128, 8),
    Color.FromRgb(252, 252, 124),
    Color.FromRgb(184, 184, 232),
    Color.FromRgb(236, 196, 176),
    Color.FromRgb(64, 104, 212),
    Color.FromRgb(116, 164, 124),
    Color.FromRgb(144, 144, 184),
    Color.FromRgb(0, 228, 252)}
End Module

Public Class StarCraftData
    Private pstatusFnVal1 As List(Of UInteger)
    Private pstatusFnVal2 As List(Of UInteger)
    Public ReadOnly Property statusFnVal1 As List(Of UInteger)
        Get
            Return pstatusFnVal1
        End Get
    End Property

    Public ReadOnly Property statusFnVal2 As List(Of UInteger)
        Get
            Return pstatusFnVal2
        End Get
    End Property
    Private piscriptData As IScript.CIScript
    Public ReadOnly Property IscriptData As IScript.CIScript
        Get
            Return piscriptData
        End Get
    End Property


    Private GRPFiles(SCImageCount) As String
    Private ImageName(SCImageCount) As String
    Private pSfxName(SCSfxdataCount) As String
    Private pSfxFileName As tblReader

    Private pPortdataName(SCPortdataCount) As String
    Private pIconName(SCIconCount) As String
    Private pIscriptName(SCIscriptCount) As String
    Private pvirtualCode(255) As String
    Private pASCIICode(128) As String
    Public ReadOnly Property IscriptName(index As Integer) As String
        Get
            Return pIscriptName(index)
        End Get
    End Property
    Public ReadOnly Property IconName(index As Integer) As String
        Get
            Return pIconName(index)
        End Get
    End Property
    Public ReadOnly Property ImageStr(index As Integer) As String
        Get
            Return ImageName(index)
        End Get
    End Property
    Public ReadOnly Property SfxCodeName(index As Integer) As String
        Get
            Return pSfxName(index)
        End Get
    End Property
    Public ReadOnly Property SfxFileName(index As Integer) As String
        Get
            Return pSfxFileName.Strings(index).val1
        End Get
    End Property
    Public ReadOnly Property PortdataName(index As Integer) As String
        Get
            Return pPortdataName(index)
        End Get
    End Property

    Public ReadOnly Property VirtualCode(index As Integer) As String
        Get
            Return pvirtualCode(index)
        End Get
    End Property

    Public ReadOnly Property ASCIICode(index As Integer) As String
        Get
            Return pASCIICode(index)
        End Get
    End Property

    Private ExtraBtnStr(22) As String
    Public ReadOnly Property BtnStr(index As Integer) As String
        Get
            Return ExtraBtnStr(index)
        End Get
    End Property

    Public ReadOnly Property VirtualKeyCodesPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "Data\Texts\Virtual-Key Codes.txt"
        End Get
    End Property
    Public ReadOnly Property ASCIICodesPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "Data\Texts\ASCII Codes.txt"
        End Get
    End Property

    Private ReadOnly Property IscirptPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\IscriptIDList.txt"
        End Get
    End Property
    Private ReadOnly Property IconPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\Icon.txt"
        End Get
    End Property
    Private ReadOnly Property GRPTextPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\GRPfile.txt"
        End Get
    End Property
    Private ReadOnly Property ImageStrPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\Images.txt"
        End Get
    End Property
    Private ReadOnly Property SfxNamePath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\Sfxdata.txt"
        End Get
    End Property
    Private ReadOnly Property PordataPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\Portdata.txt"
        End Get
    End Property
    Private ReadOnly Property BtnStrPath As String
        Get
            Return System.AppDomain.CurrentDomain.BaseDirectory & "\Data\Texts\UnitBtn.txt"
        End Get
    End Property



    Private ReadOnly stat_txt As tblReader
    Public ReadOnly Property GetStat_txt(index As Integer, Optional TrueVal As Boolean = False) As String
        Get
            Try
                If TrueVal Then
                    Return stat_txt.Strings(index).val2
                Else
                    Select Case pgData.Setting(ProgramData.TSetting.CDLanuage)
                        Case 1
                            Return stat_txt_kor_eng.Strings(index).val1
                        Case 2
                            Return stat_txt_kor_kor.Strings(index).val1
                        Case Else
                            Return stat_txt.Strings(index).val1
                    End Select

                    Return "Error"
                End If
            Catch ex As Exception
                Return "None"
            End Try
        End Get
    End Property


    Private ReadOnly stat_txt_kor_eng As tblReader
    Private ReadOnly stat_txt_kor_kor As tblReader


    Private SDGRP(SCImageCount) As SDGRP
    Private HDGRP(SCImageCount) As HDGRP
    Private CTGRP(SCImageCount) As HDGRP



    'Private SDGRP(SCImageCount) As GRP
    'Private HDGRP(SCImageCount) As GRP
    Private SDICON As GRP
    Private HDICON As GRP
    Private SDWireFrame As GRP
    Private HDWireFrame As GRP
    Private SDGrpFrame As GRP
    Private HDGrpFrame As GRP
    Private SDTramFrame As GRP
    Private HDTramFrame As GRP
    Public ReadOnly Property GetGRPImage(index As Integer, frame As Integer) As BitmapSource
        Get
            Select Case pgData.Setting(ProgramData.TSetting.Graphic)
                Case 1
                    Try
                        Return SDGRP(index).DrawGRP(frame)
                    Catch ex As Exception
                        'MsgBox(ex.ToString & vbCrLf & index)
                    End Try

                Case 2
                    Try
                        Return HDGRP(index).DrawGRP(frame)
                    Catch ex As Exception
                        'MsgBox(ex.ToString & vbCrLf & index)
                    End Try
                Case 3
                    Try
                        Return CTGRP(index).DrawGRP(frame)
                    Catch ex As Exception
                        'MsgBox(ex.ToString & vbCrLf & index)
                    End Try
            End Select


            Return New BitmapImage()
            'Return SDGRP(index).DrawGRP(frame)
        End Get
    End Property
    Public ReadOnly Property GetGrp(index As Integer) As GRP
        Get
            Return Nothing
            'Return SDGRP(index)
        End Get
    End Property
    Public ReadOnly Property GetIcon(index As Integer) As BitmapImage
        Get
            Return New BitmapImage()
            Return SDICON.DrawGRP(index)
        End Get
    End Property
    Public ReadOnly Property GetWireFrame(index As Integer) As BitmapImage
        Get
            Return New BitmapImage()
            Return SDWireFrame.DrawGRP(index)
        End Get
    End Property
    Public ReadOnly Property GetGrpFrame(index As Integer) As BitmapImage
        Get
            Return New BitmapImage()
            Return SDGrpFrame.DrawGRP(index)
        End Get
    End Property
    Public ReadOnly Property GetTranFrame(index As Integer) As BitmapImage
        Get
            Return New BitmapImage()
            Return SDTramFrame.DrawGRP(index)
        End Get
    End Property




    Private IsLoadMPQ As Boolean
    Public ReadOnly Property LoadStarCraftData As Boolean
        Get
            Return IsLoadMPQ
        End Get
    End Property



    Public DefaultExtraDat As ExtraDatFiles
    Public DefaultDat As SCDatFiles
    Private Offsets As Dictionary(Of String, String)

    Private _StatusCode As List(Of Byte())
    Public ReadOnly Property StatusCode(index As Integer) As Byte()
        Get
            Return _StatusCode(index)
        End Get
    End Property
    Public ReadOnly Property StatusCodeCount() As Integer
        Get
            Return _StatusCode.Count
        End Get
    End Property

    Public Sub New()
        _StatusCode = New List(Of Byte())
        _StatusCode.Add({2, 1})
        _StatusCode.Add({1, 0})
        _StatusCode.Add({4, 3})
        _StatusCode.Add({3, 2})
        _StatusCode.Add({7, 6})
        _StatusCode.Add({8, 7})
        _StatusCode.Add({6, 5})
        _StatusCode.Add({5, 4})
        _StatusCode.Add({0, 8})
        _StatusCode.Add({1, 8})
        _StatusCode.Add({2, 8})


        DefaultDat = New SCDatFiles(False)
        DefaultExtraDat = New ExtraDatFiles
        Offsets = New Dictionary(Of String, String)
        '오프셋 읽기

        piscriptData = New IScript.CIScript
        piscriptData.LoadIscriptToFile(Tool.DataPath("iscript.bin"))

        stat_txt = New tblReader(Tool.GetTblFolder & "\stat_txt.tbl")
        stat_txt_kor_eng = New tblReader(Tool.GetTblFolder & "\stat_txt_kor_eng.tbl")
        stat_txt_kor_kor = New tblReader(Tool.GetTblFolder & "\stat_txt_kor_kor.tbl")

        pSfxFileName = New tblReader(Tool.GetTblFolder & "\sfxdata.tbl")


        LoadTexts()

        ReadActConCode()


        LoadGRPData()

        IScript.readOpcodes()

        pstatusFnVal1 = New List(Of UInteger)
        pstatusFnVal2 = New List(Of UInteger)
        statusFnVal1.AddRange({4343040, 4344192, 4346240, 4345616, 4344656, 4344560, 4344512, 4348160, 4343072})
        statusFnVal2.AddRange({4353872, 4356240, 4357264, 4355232, 4355040, 4354656, 4357424, 4353760, 4349664})
    End Sub

    Public ReadOnly Property FuncConDict As Dictionary(Of UInteger, ButtonFunc)
        Get
            Return ConDict
        End Get
    End Property
    Public ReadOnly Property FuncActDict As Dictionary(Of UInteger, ButtonFunc)
        Get
            Return ActDict
        End Get
    End Property


    Private ConDict As Dictionary(Of UInteger, ButtonFunc) '코드 번호에 대응하는 이름
    Private ActDict As Dictionary(Of UInteger, ButtonFunc) '코드 번호에 대응하는 이름
    Private Sub ReadActConCode()
        ConDict = New Dictionary(Of UInteger, ButtonFunc)
        ActDict = New Dictionary(Of UInteger, ButtonFunc)


        Dim fs As New FileStream(Tool.FiregraftConFunPath, FileMode.Open)
        Dim sr As New StreamReader(fs)

        While (Not sr.EndOfStream)
            Dim str As String = sr.ReadLine
            Dim values() As String = str.Split(vbTab)

            Dim DatType As SCDatFiles.DatFiles


            If values.Count <= 2 Then
                DatType = SCDatFiles.DatFiles.None
            Else
                DatType = values(2)
            End If
            Dim BtnFunc As New ButtonFunc(values(0), DatType, ConDict.Count)

            ConDict.Add("&H" & values(1), BtnFunc)
        End While

        sr.Close()
        fs.Close()

        fs = New FileStream(Tool.FiregraftActFunPath, FileMode.Open)
        sr = New StreamReader(fs)

        While (Not sr.EndOfStream)
            Dim str As String = sr.ReadLine
            Dim values() As String = str.Split(vbTab)

            Dim DatType As SCDatFiles.DatFiles


            If values.Count <= 2 Then
                DatType = SCDatFiles.DatFiles.None
            Else
                DatType = values(2)
            End If
            Dim BtnFunc As New ButtonFunc(values(0), DatType, ActDict.Count)

            ActDict.Add("&H" & values(1), BtnFunc)
        End While

        sr.Close()
        fs.Close()
    End Sub


    Public Structure ButtonFunc
        Public Index As Integer
        Public Name As String
        Public DatType As SCDatFiles.DatFiles
        Public Sub New(tName As String, tDatType As SCDatFiles.DatFiles, tindex As Integer)
            Name = tName
            DatType = tDatType
            Index = tindex
        End Sub
    End Structure

    Private Sub LoadTexts()
        'ReadGRPFilenames
        Dim sr As StreamReader = New StreamReader(GRPTextPath)
        Dim index As Integer = 0
        While Not sr.EndOfStream
            GRPFiles(index) = sr.ReadLine().Replace("<0>", "")

            index += 1
        End While
        sr.Close()

        sr = New StreamReader(ImageStrPath)
        index = 0
        While Not sr.EndOfStream
            ImageName(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()

        sr = New StreamReader(BtnStrPath)
        index = 0
        While Not sr.EndOfStream
            ExtraBtnStr(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()

        sr = New StreamReader(SfxNamePath)
        index = 0
        While Not sr.EndOfStream
            pSfxName(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()


        sr = New StreamReader(PordataPath)
        index = 0
        While Not sr.EndOfStream
            pPortdataName(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()

        sr = New StreamReader(IconPath)
        index = 0
        While Not sr.EndOfStream
            pIconName(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()


        sr = New StreamReader(IscirptPath)
        index = 0
        While Not sr.EndOfStream
            pIscriptName(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()


        sr = New StreamReader(VirtualKeyCodesPath)
        index = 0
        While Not sr.EndOfStream
            pvirtualCode(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()


        sr = New StreamReader(ASCIICodesPath)
        index = 0
        While Not sr.EndOfStream
            pASCIICode(index) = sr.ReadLine()

            index += 1
        End While
        sr.Close()

    End Sub

    Private isSDGLoad As Boolean
    Private isHDGLoad As Boolean
    Private isCarbotGLoad As Boolean


    Public Sub LoadGRPData()
        Dim grptype As Integer = pgData.Setting(ProgramData.TSetting.Graphic)


        If grptype = 0 Then
            IsLoadMPQ = True
            Return
        End If

        'MsgBox(pgData.Setting(ProgramData.TSetting.Graphic))


        IsLoadMPQ = False
        If Not My.Computer.FileSystem.FileExists(pgData.Setting(ProgramData.TSetting.starcraft)) Then
            pgData.Setting(ProgramData.TSetting.Graphic) = 0
            Tool.ErrorMsgBox(Tool.GetText("Error NotExistMPQ"))
            IsLoadMPQ = True
            Return
        End If
        Tool.CascData.OpenCascStorage()
        Try
            Select Case grptype
                Case 1
                    LoadSDGRP()
                Case 2
                    LoadHDGRP()
                Case 3
                    LoadCarbotGRP()
            End Select




            'MsgBox("시작")
            'MGRP.GRPMoudleInit()
            'MsgBox("GRP로드끝")

            'piscriptData.LoadIscriptToBuff(Tool.CascData.ReadFile("scripts/iscript.bin"))

            'Tool.CascData.OpenCascStorage()
            'For i = 0 To SCImageCount - 1
            '    Dim grpindex As Integer = DefaultDat.Data(SCDatFiles.DatFiles.images, "GRP File", i)
            '    Dim DrawFunc As Integer = DefaultDat.Data(SCDatFiles.DatFiles.images, "Draw Function", i)
            '    Dim Remapping As Integer = DefaultDat.Data(SCDatFiles.DatFiles.images, "Remapping", i)
            '    Dim filename As String = "unit\" & GRPFiles(grpindex)
            '    SDGRP(i) = New GRP(Tool.CascData.ReadFileCascStorage(filename), DrawFunc, Remapping)
            'Next
            'Tool.CascData.CloseCascStorage()

            'SDICON = New GRP("cmdbtns/cmdicons.grp", 0, 0, PalettType.Icons)


            'SDWireFrame = New GRP("wirefram/wirefram.grp", 0, 0, PalettType.Icons)
            'SDGrpFrame = New GRP("wirefram/grpwire.grp", 0, 0, PalettType.Icons)
            'SDTramFrame = New GRP("wirefram/tranwire.grp", 0, 0, PalettType.Icons)
        Catch ex As Exception
            pgData.Setting(ProgramData.TSetting.Graphic) = 0
            Tool.ErrorMsgBox(Tool.GetText("Error LoadMPQData Fail"), ex.ToString)
            IsLoadMPQ = True
            Return
        End Try
        Tool.CascData.CloseCascStorage()


        IsLoadMPQ = True
    End Sub

    Private Sub LoadSDGRP()
        If isSDGLoad Then
            Return
        End If
        Dim pos As UInteger = 0
        Dim bytes As Byte() = Tool.CascData.ReadFileCascStorage("SD/mainSD.anim")


        BReader.ReadUint32(pos, bytes) 'unsigned Int magic; // "ANIM"
        BReader.ReadUint16(pos, bytes) 'unsigned Short version; // Version? 0x0101, 0x0202, 0x0204
        BReader.ReadUint16(pos, bytes) 'unsigned Short unk2; // 0 -- more bytes for version?
        Dim layercount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short layers; 레이어의 갯수
        Dim entrycount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short entries;


        Dim layerstrs As New List(Of String)
        For i = 0 To 9
            Dim tstr As String = ""
            For j = 0 To 31
                Dim tb As Byte = BReader.ReadByte(pos, bytes)

                tstr = tstr & Chr(tb)

            Next
            tstr = tstr.Split(Chr(0)).First

            layerstrs.Add(tstr)
        Next

        Dim entrypoints(entrycount) As UInteger
        For i = 0 To entrycount - 1
            entrypoints(i) = BReader.ReadUint32(pos, bytes)
        Next



        For i = 0 To entrycount - 1
            Dim grpfile As String = GRPFiles(DefaultDat.Data(SCDatFiles.DatFiles.images, "GRP File", i)).ToLower

            pos = entrypoints(i)

            Dim framescount As UInt16 = BReader.ReadUint16(pos, bytes)
            BReader.ReadUint16(pos, bytes) 'always 0xFFFF?

            BReader.ReadUint16(pos, bytes) 'width and height are 0 in SD images, and should be retrieved from the appropriate GRP file.
            BReader.ReadUint16(pos, bytes)

            Dim frameinfoptr As UInteger = BReader.ReadUint32(pos, bytes)
            '프레임들 쫙 있음



            Dim mainbitsource As ByteBitmap = Nothing
            For j = 0 To layercount - 1
                'If i = 27 Then
                '    MsgBox("ID : " & i & " offset : " & pos)
                'End If


                Dim ddsptr As UInt32 = BReader.ReadUint32(pos, bytes)
                Dim ddssize As UInt32 = BReader.ReadUint32(pos, bytes)

                Dim width As UInt16 = BReader.ReadUint16(pos, bytes)
                Dim height As UInt16 = BReader.ReadUint16(pos, bytes)
                If ddssize = 0 Then
                    Continue For
                End If

                If layerstrs(j) = "diffuse" Then
                    Dim tpos As UInteger = ddsptr
                    Dim ms As New MemoryStream(BReader.ReadBytes(tpos, ddssize, bytes))
                    ms.Position = 0

                    mainbitsource = BitmapManager.LoadImage(ms)
                    'If i = 10 Or i = 0 Then
                    '    'Dim testwindow As New TestWindow(bitsource, i)
                    '    Dim testwindow As New TestWindow(Cutoff(mainbitsource, New Int32Rect(0, 0, mainbitsource.Width, mainbitsource.Height)), i)

                    '    testwindow.ShowDialog()
                    'End If
                    '                 Try
                    '                 Catch ex As Exception
                    '                     MsgBox(i & vbCrLf & "ddsptr : " & ddsptr & vbCrLf &
                    '"ddssize : " & ddssize & vbCrLf &
                    '"width : " & width & vbCrLf &
                    '"height : " & height)
                    '                 End Try
                    ms.Close()
                ElseIf layerstrs(j) = "teamcolor" Then
                    'MsgBox("ddsptr : " & ddsptr & vbCrLf &
                    '       "ddssize : " & ddssize & vbCrLf &
                    '       "width : " & width & vbCrLf &
                    '       "height : " & height)

                    Dim tpos As UInteger = ddsptr
                    BReader.ReadBytes(tpos, ddssize, bytes)
                End If
            Next

            Dim framedata As New List(Of FrameData)
            pos = frameinfoptr
            For j = 0 To framescount - 1
                framedata.Add(New FrameData(pos, bytes))
            Next

            SDGRP(i) = New SDGRP()
            If mainbitsource Is Nothing Then
                If i = 651 Then
                    SDGRP(i) = SDGRP(643)
                Else
                    For k = 0 To SDGRP.Count - 1
                        If SDGRP(k) IsNot Nothing Then
                            If SDGRP(k).grpfile = grpfile Then
                                SDGRP(i) = SDGRP(k)
                                Exit For
                            End If
                        End If
                    Next
                End If

            Else
                SDGRP(i).LoadGRP(mainbitsource, framedata, grpfile)
            End If

        Next
        isSDGLoad = True
    End Sub



    Private Sub LoadHDGRP()
        Dim bytetotal As Integer
        If isHDGLoad Then
            Return
        End If
        For imagecode = 0 To 998
            Try
                Dim pos As UInteger = 0
                Dim bytes As Byte() = Tool.CascData.ReadFileCascStorage("HD2/anim/main_" & String.Format("{0:D3}", imagecode) & ".anim")

                Dim framedata As New List(Of FrameData)
                Dim grpfile As String = GRPFiles(DefaultDat.Data(SCDatFiles.DatFiles.images, "GRP File", imagecode)).ToLower
                Dim mainbitsource As ByteBitmap = Nothing
                If bytes.Count <> 0 Then
                    BReader.ReadUint32(pos, bytes) 'unsigned Int magic; // "ANIM"
                    BReader.ReadUint16(pos, bytes) 'unsigned Short version; // Version? 0x0101, 0x0202, 0x0204
                    BReader.ReadUint16(pos, bytes) 'unsigned Short unk2; // 0 -- more bytes for version?
                    Dim layercount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short layers; 레이어의 갯수
                    Dim entrycount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short entries;

                    Dim layerstrs As New List(Of String)
                    For i = 0 To 9
                        Dim tstr As String = ""
                        For j = 0 To 31
                            Dim tb As Byte = BReader.ReadByte(pos, bytes)

                            tstr = tstr & Chr(tb)

                        Next
                        tstr = tstr.Split(Chr(0)).First

                        layerstrs.Add(tstr)
                    Next

                    Dim framescount As UInt16 = BReader.ReadUint16(pos, bytes)
                    BReader.ReadUint16(pos, bytes) 'always 0xFFFF?

                    BReader.ReadUint16(pos, bytes) 'width and height are 0 in SD images, and should be retrieved from the appropriate GRP file.
                    BReader.ReadUint16(pos, bytes)

                    Dim frameinfoptr As UInteger = BReader.ReadUint32(pos, bytes)
                    For j = 0 To layercount - 1
                        'If i = 27 Then
                        '    MsgBox("ID : " & i & " offset : " & pos)
                        'End If


                        Dim ddsptr As UInt32 = BReader.ReadUint32(pos, bytes)
                        Dim ddssize As UInt32 = BReader.ReadUint32(pos, bytes)

                        Dim width As UInt16 = BReader.ReadUint16(pos, bytes)
                        Dim height As UInt16 = BReader.ReadUint16(pos, bytes)
                        If ddssize = 0 Then
                            Continue For
                        End If

                        If layerstrs(j) = "diffuse" Then
                            Dim tpos As UInteger = ddsptr
                            Dim ms As New MemoryStream(BReader.ReadBytes(tpos, ddssize, bytes))
                            ms.Position = 0

                            mainbitsource = BitmapManager.LoadImage(ms)
                            ms.Close()
                            ms.Dispose()

                        ElseIf layerstrs(j) = "teamcolor" Then
                            Dim tpos As UInteger = ddsptr
                            BReader.ReadBytes(tpos, ddssize, bytes)
                        End If
                    Next

                    pos = frameinfoptr
                    For j = 0 To framescount - 1
                        framedata.Add(New FrameData(pos, bytes))
                    Next
                End If


                HDGRP(imagecode) = New HDGRP()
                If mainbitsource Is Nothing Then
                    If imagecode = 651 Then
                        HDGRP(imagecode) = HDGRP(643)
                    Else
                        For k = 0 To HDGRP.Count - 1
                            If HDGRP(k) IsNot Nothing Then
                                If HDGRP(k).grpfile = grpfile Then
                                    HDGRP(imagecode) = HDGRP(k)
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                Else
                    HDGRP(imagecode).LoadGRP(mainbitsource, framedata, grpfile)

                    bytetotal += mainbitsource.Bytes.Count
                End If
            Catch ex As Exception
                MsgBox(imagecode & vbCrLf & ex.ToString)
            End Try

        Next


        'MsgBox(bytetotal)
        '프레임들 쫙 있음

        isHDGLoad = True
    End Sub


    Private Sub LoadCarbotGRP()
        If isCarbotGLoad Then
            Return
        End If
        For imagecode = 0 To 998
            Try
                Dim pos As UInteger = 0
                Dim bytes As Byte() = Tool.CascData.ReadFileCascStorage("HD2/anim/Carbot/main_" & String.Format("{0:D3}", imagecode) & ".anim")

                Dim framedata As New List(Of FrameData)
                Dim grpfile As String = GRPFiles(DefaultDat.Data(SCDatFiles.DatFiles.images, "GRP File", imagecode)).ToLower
                Dim mainbitsource As ByteBitmap = Nothing
                If bytes.Count <> 0 Then
                    BReader.ReadUint32(pos, bytes) 'unsigned Int magic; // "ANIM"
                    BReader.ReadUint16(pos, bytes) 'unsigned Short version; // Version? 0x0101, 0x0202, 0x0204
                    BReader.ReadUint16(pos, bytes) 'unsigned Short unk2; // 0 -- more bytes for version?
                    Dim layercount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short layers; 레이어의 갯수
                    Dim entrycount As UInt16 = BReader.ReadUint16(pos, bytes) 'unsigned Short entries;

                    Dim layerstrs As New List(Of String)
                    For i = 0 To 9
                        Dim tstr As String = ""
                        For j = 0 To 31
                            Dim tb As Byte = BReader.ReadByte(pos, bytes)

                            tstr = tstr & Chr(tb)

                        Next
                        tstr = tstr.Split(Chr(0)).First

                        layerstrs.Add(tstr)
                    Next

                    Dim framescount As UInt16 = BReader.ReadUint16(pos, bytes)
                    BReader.ReadUint16(pos, bytes) 'always 0xFFFF?

                    BReader.ReadUint16(pos, bytes) 'width and height are 0 in SD images, and should be retrieved from the appropriate GRP file.
                    BReader.ReadUint16(pos, bytes)

                    Dim frameinfoptr As UInteger = BReader.ReadUint32(pos, bytes)
                    For j = 0 To layercount - 1
                        'If i = 27 Then
                        '    MsgBox("ID : " & i & " offset : " & pos)
                        'End If


                        Dim ddsptr As UInt32 = BReader.ReadUint32(pos, bytes)
                        Dim ddssize As UInt32 = BReader.ReadUint32(pos, bytes)

                        Dim width As UInt16 = BReader.ReadUint16(pos, bytes)
                        Dim height As UInt16 = BReader.ReadUint16(pos, bytes)
                        If ddssize = 0 Then
                            Continue For
                        End If

                        If layerstrs(j) = "diffuse" Then
                            Dim tpos As UInteger = ddsptr
                            Dim ms As New MemoryStream(BReader.ReadBytes(tpos, ddssize, bytes))
                            ms.Position = 0

                            mainbitsource = BitmapManager.LoadImage(ms)
                            ms.Close()
                            ms.Dispose()

                        ElseIf layerstrs(j) = "teamcolor" Then
                            Dim tpos As UInteger = ddsptr
                            BReader.ReadBytes(tpos, ddssize, bytes)
                        End If
                    Next

                    pos = frameinfoptr
                    For j = 0 To framescount - 1
                        framedata.Add(New FrameData(pos, bytes))
                    Next
                End If


                CTGRP(imagecode) = New HDGRP()
                If mainbitsource Is Nothing Then
                    If imagecode = 651 Then
                        CTGRP(imagecode) = CTGRP(643)
                    Else
                        For k = 0 To CTGRP.Count - 1
                            If CTGRP(k) IsNot Nothing Then
                                If CTGRP(k).grpfile = grpfile Then
                                    CTGRP(imagecode) = CTGRP(k)
                                    Exit For
                                End If
                            End If
                        Next
                    End If

                Else
                    CTGRP(imagecode).LoadGRP(mainbitsource, framedata, grpfile)
                End If
            Catch ex As Exception
                MsgBox(imagecode & vbCrLf & ex.ToString)
            End Try

        Next



        '프레임들 쫙 있음

        isCarbotGLoad = True
    End Sub










    Public ReadOnly Property GetOffset(Name As String) As String
        Get
            Return Offsets(Name)
        End Get
    End Property


End Class




