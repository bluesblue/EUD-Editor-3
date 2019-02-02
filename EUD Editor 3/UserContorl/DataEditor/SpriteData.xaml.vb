﻿Public Class SpriteData
    Private DatFiles As SCDatFiles.DatFiles = SCDatFiles.DatFiles.sprites

    Public Property ObjectID As Integer


    Public Sub New(tObjectID As Integer)
        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.
        DataContext = pjData
        ObjectID = tObjectID

        UsedCodeList.Init(DatFiles, ObjectID)

        NameBar.Init(ObjectID, DatFiles, 0)

        IFI.Init(DatFiles, ObjectID, IFI.Tag, 100)
        IV.Init(DatFiles, ObjectID, IV.Tag, 100)

        SCI.Init(DatFiles, ObjectID, SCI.Tag, 100)
        SCO.Init(DatFiles, ObjectID, SCO.Tag, InputField.SFlag.None, 100)
        HB.Init(DatFiles, ObjectID, HB.Tag, InputField.SFlag.None, 100)
    End Sub
    Public Sub ReLoad(DatFiles As SCDatFiles.DatFiles, ObjectID As Integer)
        ObjectID = ObjectID

        UsedCodeList.ReLoad(DatFiles, ObjectID)

        NameBar.ReLoad(ObjectID, DatFiles, 0)

        IFI.ReLoad(DatFiles, ObjectID, IFI.Tag)
        IV.ReLoad(DatFiles, ObjectID, IV.Tag)
        SCI.ReLoad(DatFiles, ObjectID, SCI.Tag)
        SCO.ReLoad(DatFiles, ObjectID, SCO.Tag)
        HB.ReLoad(DatFiles, ObjectID, HB.Tag)
    End Sub
End Class
