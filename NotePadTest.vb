Public Class MainForm
    Dim txtChanged As Boolean
    Dim theStr As String

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        MsgBox("Do you want to save the changes ?", MsgBoxStyle.YesNoCancel)
        TextArea.Text = ""
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextArea.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog.FileName)
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog.FileName, TextArea.Text, False)
        End If
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        TextArea.Undo()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
        TextArea.Copy()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripMenuItem.Click
        TextArea.Cut()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
        TextArea.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        TextArea.SelectAll()
    End Sub

    Private Sub FontToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FontToolStripMenuItem.Click
        If FontDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextArea.Font = FontDialog.Font
        End If
    End Sub

    Private Sub ColourToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColourToolStripMenuItem.Click
        If ColorDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextArea.ForeColor = ColorDialog.Color
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("A simple notepad by " & vbCrLf & "Masungulo.")
    End Sub

    Private Sub SelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectToolStripMenuItem.Click
        TextArea.Select()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        TextArea.SelectedText = ""
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        TextArea.Clear()
    End Sub

    Private Sub TimeDateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeDateToolStripMenuItem.Click
        TextArea.Text = TextArea.Text.Insert(TextArea.SelectionStart, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
    End Sub

    Private Sub PrintToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        PrintDialog.ShowDialog()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        PrintPreviewDialog.ShowDialog()
    End Sub

    Private Sub PageSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageSetupToolStripMenuItem.Click
        With PageSetupDialog
            .PageSettings = New System.Drawing.Printing.PageSettings
            .PrinterSettings = New System.Drawing.Printing.PrinterSettings
            .ShowDialog()
        End With
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim saveDlg As New SaveFileDialog()
        Dim theFile As String
        Dim buff As String
        saveDlg.Filter = "Text Files (*.txt)|*.txt"
        saveDlg.ShowDialog()
        If saveDlg.CheckFileExists = False Then Exit Sub
        theFile = saveDlg.FileName
        FileOpen(1, theFile, OpenMode.Output)
        buff = TextArea.Text
        Print(1, buff)
        FileClose(1)
        txtChanged = False
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        theStr = InputBox("What do word do you want to search for?", " Find")
        If TextArea.Text.Contains(theStr) Then
            Dim text = TextArea.Text.Contains(theStr).ToString
            TextArea.SelectionStart = ((TextArea.Text.IndexOf(text)) + 1)
            TextArea.SelectionLength = (text.Length - 2)
        End If
    End Sub

    Private Sub GotoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GotoToolStripMenuItem.Click
        Dim lineNum As Integer
        Dim txtLineCount As Integer
        txtLineCount = TextArea.Lines.Length
        txtLineCount = CStr(txtLineCount)
        lineNum = InputBox("Please enter the line number you want to goto.", " Goto Line Number", txtLineCount)
        If lineNum > txtLineCount Then MsgBox("Line number is out of range!", MsgBoxStyle.Exclamation, " Out of range") : Exit Sub
        lineNum = CInt(lineNum)
        Cursor.Position = New Point(0, lineNum)
    End Sub
End Class
