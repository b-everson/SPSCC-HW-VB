<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnrollmentsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboStudent = New System.Windows.Forms.ComboBox()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.txtCourseEnrolledCount = New System.Windows.Forms.TextBox()
        Me.txtCreditsAttempted = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Student"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Student ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Courses Enrolled In"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 145)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Credits Attempted"
        '
        'cboStudent
        '
        Me.cboStudent.FormattingEnabled = True
        Me.cboStudent.Location = New System.Drawing.Point(142, 31)
        Me.cboStudent.Name = "cboStudent"
        Me.cboStudent.Size = New System.Drawing.Size(198, 21)
        Me.cboStudent.TabIndex = 4
        '
        'txtStudentID
        '
        Me.txtStudentID.Location = New System.Drawing.Point(142, 69)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.ReadOnly = True
        Me.txtStudentID.Size = New System.Drawing.Size(89, 20)
        Me.txtStudentID.TabIndex = 5
        '
        'txtCourseEnrolledCount
        '
        Me.txtCourseEnrolledCount.Location = New System.Drawing.Point(142, 107)
        Me.txtCourseEnrolledCount.Name = "txtCourseEnrolledCount"
        Me.txtCourseEnrolledCount.ReadOnly = True
        Me.txtCourseEnrolledCount.Size = New System.Drawing.Size(42, 20)
        Me.txtCourseEnrolledCount.TabIndex = 6
        '
        'txtCreditsAttempted
        '
        Me.txtCreditsAttempted.Location = New System.Drawing.Point(142, 142)
        Me.txtCreditsAttempted.Name = "txtCreditsAttempted"
        Me.txtCreditsAttempted.ReadOnly = True
        Me.txtCreditsAttempted.Size = New System.Drawing.Size(42, 20)
        Me.txtCreditsAttempted.TabIndex = 7
        '
        'EnrollmentsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 190)
        Me.Controls.Add(Me.txtCreditsAttempted)
        Me.Controls.Add(Me.txtCourseEnrolledCount)
        Me.Controls.Add(Me.txtStudentID)
        Me.Controls.Add(Me.cboStudent)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "EnrollmentsForm"
        Me.Text = "Enrollments"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboStudent As System.Windows.Forms.ComboBox
    Friend WithEvents txtStudentID As System.Windows.Forms.TextBox
    Friend WithEvents txtCourseEnrolledCount As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditsAttempted As System.Windows.Forms.TextBox
End Class
