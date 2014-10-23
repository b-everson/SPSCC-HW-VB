Imports System.Data.SqlClient

Public Class MainForm

    Private _collapsed As Boolean = False

    Private _spsccDataset As SPSCCDatasetClass

    Public ReadOnly Property SPSCCDataset As SPSCCDatasetClass
        Get
            Return _spsccDataset
        End Get
    End Property

    Public WriteOnly Property StatusText As String
        Set(value As String)
            slStatus.Text = value
        End Set
    End Property

    Public Sub New()
        InitializeComponent()
        _spsccDataset = New SPSCCDatasetClass()
        StatusText = "Ready"
    End Sub

    Private Sub tsmiSave_Click(sender As System.Object, e As System.EventArgs) Handles tsmiSave.Click
        Try
            SPSCCDataset.Save()

            StatusText = "Records saved, records may be resorted."
        Catch ex As SqlException
            MessageBox.Show("Error saving data to database")
        End Try
    End Sub

    Private Sub tsmiExit_Click(sender As System.Object, e As System.EventArgs) Handles tsmiExit.Click
        Me.Close()
    End Sub

    Private Sub tsmiStudents_Click(sender As System.Object, e As System.EventArgs) Handles tsmiStudents.Click
        ShowForm(New StudentsForm())
    End Sub

    Private Sub tsmiEnrollments_Click(sender As System.Object, e As System.EventArgs) Handles tsmiEnrollments.Click
        ShowForm(New EnrollmentsForm())
    End Sub

    Private Sub tsmiCascade_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCascade.Click
        LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub tsmiHorizontal_Click(sender As System.Object, e As System.EventArgs) Handles tsmiHorizontal.Click
        LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub tsmiVertical_Click(sender As System.Object, e As System.EventArgs) Handles tsmiVertical.Click
        LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub tsmiCollapseAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCollapseAll.Click
        If _collapsed <> True Then
            For Each nextForm As Form In Me.MdiChildren
                nextForm.WindowState = FormWindowState.Minimized
                tsmiCollapseAll.Checked = True
                _collapsed = True
            Next
        Else
            For Each nextForm As Form In Me.MdiChildren
                nextForm.WindowState = FormWindowState.Normal
                tsmiCollapseAll.Checked = False
                _collapsed = False
            Next
        End If
    End Sub

    Private Sub tsmiCloseAll_Click(sender As System.Object, e As System.EventArgs) Handles tsmiCloseAll.Click
        For Each nextForm As Form In Me.MdiChildren
            nextForm.Close()
        Next
    End Sub

    Private Sub ShowForm(form As Form)
        form.MdiParent = Me
        form.Show()
    End Sub

End Class
