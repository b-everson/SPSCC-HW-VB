<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiStudents = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEnrollments = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCascade = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCollapseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiCloseAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.slStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile, Me.tsmiEdit, Me.WindowToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(536, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSave, Me.tsmiExit})
        Me.tsmiFile.Name = "tsmiFile"
        Me.tsmiFile.Size = New System.Drawing.Size(37, 20)
        Me.tsmiFile.Text = "&File"
        '
        'tsmiSave
        '
        Me.tsmiSave.Name = "tsmiSave"
        Me.tsmiSave.Size = New System.Drawing.Size(152, 22)
        Me.tsmiSave.Text = "&Save"
        '
        'tsmiExit
        '
        Me.tsmiExit.Name = "tsmiExit"
        Me.tsmiExit.Size = New System.Drawing.Size(152, 22)
        Me.tsmiExit.Text = "E&xit"
        '
        'tsmiEdit
        '
        Me.tsmiEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiStudents, Me.tsmiEnrollments})
        Me.tsmiEdit.Name = "tsmiEdit"
        Me.tsmiEdit.Size = New System.Drawing.Size(39, 20)
        Me.tsmiEdit.Text = "&Edit"
        '
        'tsmiStudents
        '
        Me.tsmiStudents.Name = "tsmiStudents"
        Me.tsmiStudents.Size = New System.Drawing.Size(152, 22)
        Me.tsmiStudents.Text = "&Students"
        '
        'tsmiEnrollments
        '
        Me.tsmiEnrollments.Name = "tsmiEnrollments"
        Me.tsmiEnrollments.Size = New System.Drawing.Size(152, 22)
        Me.tsmiEnrollments.Text = "&Enrollments"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiCascade, Me.tsmiHorizontal, Me.tsmiVertical, Me.tsmiCollapseAll, Me.tsmiCloseAll})
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'tsmiCascade
        '
        Me.tsmiCascade.Name = "tsmiCascade"
        Me.tsmiCascade.Size = New System.Drawing.Size(152, 22)
        Me.tsmiCascade.Text = "&Cascade"
        '
        'tsmiHorizontal
        '
        Me.tsmiHorizontal.Name = "tsmiHorizontal"
        Me.tsmiHorizontal.Size = New System.Drawing.Size(152, 22)
        Me.tsmiHorizontal.Text = "&Tile Horizontal"
        '
        'tsmiVertical
        '
        Me.tsmiVertical.Name = "tsmiVertical"
        Me.tsmiVertical.Size = New System.Drawing.Size(152, 22)
        Me.tsmiVertical.Text = "Tile &Vertical"
        '
        'tsmiCollapseAll
        '
        Me.tsmiCollapseAll.Name = "tsmiCollapseAll"
        Me.tsmiCollapseAll.Size = New System.Drawing.Size(152, 22)
        Me.tsmiCollapseAll.Text = "C&ollapse All"
        '
        'tsmiCloseAll
        '
        Me.tsmiCloseAll.Name = "tsmiCloseAll"
        Me.tsmiCloseAll.Size = New System.Drawing.Size(152, 22)
        Me.tsmiCloseAll.Text = "C&lose All"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.slStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 384)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(536, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'slStatus
        '
        Me.slStatus.Name = "slStatus"
        Me.slStatus.Size = New System.Drawing.Size(121, 17)
        Me.slStatus.Text = "ToolStripStatusLabel1"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 406)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.Text = "SPSCC Student Registration"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tsmiFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiStudents As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEnrollments As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCascade As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCollapseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiCloseAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents slStatus As System.Windows.Forms.ToolStripStatusLabel

End Class
