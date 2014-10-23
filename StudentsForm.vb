Public Class StudentsForm

    Private Enum EditState
        Adding
        Editing
        Unchanged
    End Enum

    Private availableRows As New List(Of Integer)()
    Private myEditState As EditState
    Private position As Integer

    Private _myParent As MainForm

    Private ReadOnly Property MyParent As MainForm
        Get
            Return _myParent
        End Get
    End Property

    Private ReadOnly Property StudentsDT As DataTable
        Get
            Return MyParent.SPSCCDataset.Students
        End Get
    End Property

    Private Sub setStatus(status As String)
        MyParent.StatusText = status
    End Sub

    Private Sub StudentsForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        position = 0
        btnPrevious.Enabled = False

        _myParent = DirectCast(MdiParent, MainForm)

        fillAvailableRowsList()
        AddHandler MyParent.SPSCCDataset.Saved, AddressOf Me.SPSCCDataset_Saved

        'set main form's text status
        setStatus("Students Loaded")
        If availableRows.Count > 0 Then
            showRow(position)

            If availableRows.Count = 1 Then
                btnNext.Enabled = False
            End If
        Else
            'no rows, disable navigation and deletion
            disableNavigationAndDelete()
            clearAndDisableControls()
        End If

        myEditState = EditState.Unchanged
    End Sub

    Public Sub fillAvailableRowsList()
        'set availableRows variable to refer to new instance
        availableRows = Nothing
        availableRows = New List(Of Integer)()

        For i As Integer = 0 To StudentsDT.Rows.Count - 1
            availableRows.Add(i)
        Next

    End Sub

    Private Sub SPSCCDataset_Saved(sender As Object, e As EventArgs)
        fillAvailableRowsList()

        'show row of current position
        showRow(position)
    End Sub

    Private Sub showRow(position As Integer)
        'store edit state
        Dim myState As EditState
        'get datarow of position
        Dim row As DataRow = StudentsDT.Rows.Item(availableRows.Item(position))

        'display row's values in appropriate control
        txtStudentID.Text = row.Item(0).ToString()
        txtFirstName.Text = row.Item(1).ToString()
        txtLastName.Text = row.Item(2).ToString()

        'restore edit state
        myEditState = myState
    End Sub

    Private Sub disableNavigationAndDelete()
        btnNext.Enabled = False
        btnPrevious.Enabled = False
        btnDelete.Enabled = False
    End Sub

    Private Sub clearAndDisableControls()
        controlsEnabled(False)
        clearControls()
    End Sub

    Private Sub controlsEnabled(enabled As Boolean)
        txtStudentID.Enabled = enabled
        txtFirstName.Enabled = enabled
        txtLastName.Enabled = enabled
    End Sub

    Private Sub clearControls()
        txtStudentID.Clear()
        txtFirstName.Clear()
        txtLastName.Clear()
    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        Select Case myEditState
            Case EditState.Unchanged
                clearControls()
                controlsEnabled(True)

                changeEditState(EditState.Adding)
            Case EditState.Editing
                saveRow(position)
                myEditState = EditState.Unchanged
                btnAdd.Text = "Add"
            Case EditState.Adding
                'create new datarow and populate from textboxes
                Dim row As DataRow = StudentsDT.NewRow()
                row.Item(0) = txtStudentID.Text
                row.Item(1) = txtFirstName.Text
                row.Item(2) = txtLastName.Text

                'add row to table
                Try
                    StudentsDT.Rows.Add(row)
                    'add index of added row to available rows 
                    availableRows.Add(StudentsDT.Rows.Count - 1)
                    'set position to row count - 1
                    position = availableRows.Count - 1

                    'if count > 1 enable previous button
                    If availableRows.Count > 1 Then
                        btnPrevious.Enabled = True
                    End If

                    'set add buttn and delete button text
                    btnAdd.Text = "Add"
                    btnDelete.Text = "Delete"
                    btnDelete.Enabled = True

                    myEditState = EditState.Unchanged
                Catch ex As Exception
                    MessageBox.Show("Invalid entry, check that student ID is unique")
                End Try
        End Select
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click

        Select Case myEditState
            Case EditState.Unchanged

                'call delete function on student's table row that is at index related to current position
                StudentsDT.Rows.Item(availableRows.Item(position)).Delete()

                'remove reference to student row that has been flagged for deletion
                availableRows.RemoveAt(position)

                If position < availableRows.Count Then
                    showRow(position)

                    If position = availableRows.Count - 1 Then
                        btnNext.Enabled = False
                    End If
                ElseIf availableRows.Count > 0 Then
                    position -= 1
                    showRow(position)
                    If availableRows.Count = 1 Then
                        btnPrevious.Enabled = False
                    End If
                Else
                    disableNavigationAndDelete()
                    clearAndDisableControls()
                End If

            Case EditState.Adding
                'cancels addition
                If availableRows.Count > 0 Then
                    showRow(position)

                    If position > 0 Then
                        btnPrevious.Enabled = True
                    End If

                    If position < availableRows.Count - 1 Then
                        btnNext.Enabled = True
                    End If
                Else
                    disableNavigationAndDelete()
                    clearAndDisableControls()
                End If

            Case EditState.Editing
                showRow(position)
        End Select

        changeEditState(EditState.Unchanged)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnPrevious.Click
        saveRow(position)
        position -= 1
        showRow(position)

        If position = 0 Then
            btnPrevious.Enabled = False
        End If

        changeEditState(EditState.Unchanged)
        btnNext.Enabled = True
    End Sub

    Private Sub btnNext_Click(sender As System.Object, e As System.EventArgs) Handles btnNext.Click
        saveRow(position)
        position += 1
        showRow(position)

        If position = availableRows.Count - 1 Then
            btnNext.Enabled = False
        End If

        changeEditState(EditState.Unchanged)
        btnPrevious.Enabled = True
    End Sub


    Private Sub textValueChanged(sender As System.Object, e As System.EventArgs) Handles txtStudentID.TextChanged, txtLastName.TextChanged, txtFirstName.TextChanged
        If myEditState = EditState.Unchanged Then
            changeEditState(EditState.Editing)
        End If
    End Sub

    Private Sub changeEditState(myState As EditState)
        'update buttons to reflect state
        Select Case myState
            Case EditState.Unchanged
                btnAdd.Text = "Add"
                btnDelete.Text = "Delete"
            Case EditState.Adding
                btnAdd.Text = "Save"
                btnDelete.Text = "Cancel"
                btnDelete.Enabled = True
            Case EditState.Editing
                btnAdd.Text = "Update"
                btnDelete.Text = "Cancel"
        End Select

        myEditState = myState
    End Sub

    Private Sub StudentsForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        setStatus("Students form closing")
    End Sub

    Private Sub saveRow(position As Integer)
        Dim row As DataRow = StudentsDT.Rows.Item(availableRows.Item(position))
        row(0) = txtStudentID.Text
        row(1) = txtFirstName.Text
        row(2) = txtLastName.Text
    End Sub

End Class