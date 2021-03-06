﻿Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Partial Public Class ProjectData
    '여기에 모든게 들어간다
    '스타 dat데이터를 클래스로 만들어 관리하자.
    Public Shared Sub Load(isNewfile As Boolean, ByRef _pjdata As ProjectData)
        If isNewfile Then
            _pjdata = New ProjectData
            _pjdata.NewFIle()
            _pjdata.InitData()
        Else
            Dim tFilename As String
            Dim LoadProjectDialog As New System.Windows.Forms.OpenFileDialog
            LoadProjectDialog.Filter = Tool.GetText("LoadFliter")

            If LoadProjectDialog.ShowDialog() = Forms.DialogResult.OK Then
                tFilename = LoadProjectDialog.FileName '파일 이름 교체
            Else
                Exit Sub
            End If

            If Tool.IsProjectLoad() Then
                '꺼야됨
                If Not _pjdata.CloseFile Then
                    Exit Sub
                End If
            End If

            Load(tFilename, _pjdata)
        End If
    End Sub
    Public Shared Sub Load(FileName As String, ByRef _pjdata As ProjectData)
        Dim stm As Stream = System.IO.File.Open(FileName, FileMode.Open, FileAccess.Read)
        Try
            If FileName.Split(".").Last = "e3s" Then
                Dim bf As BinaryFormatter = New BinaryFormatter()
                _pjdata = New ProjectData
                _pjdata.NewFIle()
                _pjdata.InitData()
                _pjdata.SaveData = bf.Deserialize(stm)
                _pjdata.LoadInit(FileName)
                _pjdata.Legacy()
                stm.Close()

                'If _pjdata.SaveData.LastVersion.ToString <> pgData.Version.ToString Then
                '    Tool.ErrorMsgBox("테스트 버전은 다른 버전의 세이브 파일을 열 수 없습니다")
                '    pjData.CloseFile()
                'End If
            Else
                stm.Close()

                _pjdata = New ProjectData
                _pjdata.NewFIle()
                _pjdata.InitData()
                _pjdata.LoadInit(FileName)

                Lagacy.LagacySaveLoad.Load(FileName)
            End If
        Catch ex As Exception
            Tool.ErrorMsgBox(Tool.GetText("Error SaveFileOpen"), ex.ToString)
            stm.Close()
            pjData.CloseFile()
        End Try

    End Sub
End Class
