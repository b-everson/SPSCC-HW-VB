Public Class EnrollmentsForm

    Private ReadOnly Property MyData As SPSCCDatasetClass
        Get
            Return MyParent.SPSCCDataset
        End Get
    End Property

    Private _myParent As MainForm

    Private ReadOnly Property MyParent As MainForm
        Get
            Return _myParent
        End Get
    End Property

    Private Sub EnrollmentsForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _myParent = DirectCast(Me.MdiParent, MainForm)
        cboStudent.DataSource = MyData.Students
        cboStudent.DisplayMember = MyData.Students.Columns.Item(3).ColumnName
        cboStudent.ValueMember = MyData.Students.Columns.Item(0).ColumnName

        If MyData.Students.Rows.Count > 0 Then
            displayStudent()
        End If
    End Sub

    Private Sub cboStudent_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboStudent.SelectedIndexChanged
        If cboStudent.SelectedIndex <> -1 Then
            displayStudent()
        End If
    End Sub

    Private Sub displayStudent()
        Dim studentIDstring As String = cboStudent.SelectedValue.ToString()

        For Each studentRow As DataRow In MyData.Students.Rows
            'if student id from combobox matches studentID of row
            If studentIDstring = studentRow.Item(0).ToString() Then

                'display student ID in textbox
                txtStudentID.Text = studentIDstring

                'get child rows of enrollments table
                Dim enrollmentRows() As DataRow = studentRow.GetChildRows("FK_Enrollments_Students")

                'display count of student's enrollments
                txtCourseEnrolledCount.Text = enrollmentRows.Length.ToString()

                Dim creditsAttempted As Integer = 0

                'for each enrollment
                For Each enrollRow As DataRow In enrollmentRows
                    'get section of enrollment
                    Dim sectionRow As DataRow = enrollRow.GetParentRow("FK_Enrollments_Sections")

                    'get course of section
                    Dim courseRow As DataRow = sectionRow.GetParentRow("FK_Sections_Courses")

                    'get number of credits from class
                    Dim credits As Integer = Convert.ToInt32(courseRow(4))

                    'accumulate into credits attempted
                    creditsAttempted += credits
                Next

                txtCreditsAttempted.Text = creditsAttempted.ToString()
            End If
        Next
    End Sub

End Class