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
        Me.components = New System.ComponentModel.Container()
        Me.recordingLbl = New System.Windows.Forms.Label()
        Me.videoPnl = New System.Windows.Forms.Panel()
        Me.videoPic = New System.Windows.Forms.PictureBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.captureLsv = New System.Windows.Forms.ListView()
        Me.captureImageCtx = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.captureIml = New System.Windows.Forms.ImageList(Me.components)
        Me.commandPnl = New System.Windows.Forms.Panel()
        Me.resolutionCbo = New System.Windows.Forms.ComboBox()
        Me.nextCameraBtn = New System.Windows.Forms.Button()
        Me.recordBtn = New System.Windows.Forms.Button()
        Me.captureBtn = New System.Windows.Forms.Button()
        Me.elapsedTmr = New System.Windows.Forms.Timer(Me.components)
        Me.videoPnl.SuspendLayout()
        CType(Me.videoPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.captureImageCtx.SuspendLayout()
        Me.commandPnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'recordingLbl
        '
        Me.recordingLbl.AutoSize = True
        Me.recordingLbl.BackColor = System.Drawing.Color.DarkRed
        Me.recordingLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.recordingLbl.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.recordingLbl.Location = New System.Drawing.Point(13, 12)
        Me.recordingLbl.Name = "recordingLbl"
        Me.recordingLbl.Size = New System.Drawing.Size(106, 20)
        Me.recordingLbl.TabIndex = 3
        Me.recordingLbl.Text = "Recording..."
        Me.recordingLbl.Visible = False
        '
        'videoPnl
        '
        Me.videoPnl.BackColor = System.Drawing.SystemColors.Window
        Me.videoPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.videoPnl.Controls.Add(Me.recordingLbl)
        Me.videoPnl.Controls.Add(Me.videoPic)
        Me.videoPnl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.videoPnl.Location = New System.Drawing.Point(200, 0)
        Me.videoPnl.Name = "videoPnl"
        Me.videoPnl.Padding = New System.Windows.Forms.Padding(10)
        Me.videoPnl.Size = New System.Drawing.Size(584, 358)
        Me.videoPnl.TabIndex = 7
        '
        'videoPic
        '
        Me.videoPic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.videoPic.Location = New System.Drawing.Point(10, 10)
        Me.videoPic.Name = "videoPic"
        Me.videoPic.Size = New System.Drawing.Size(564, 338)
        Me.videoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.videoPic.TabIndex = 4
        Me.videoPic.TabStop = False
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(200, 358)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(584, 3)
        Me.Splitter1.TabIndex = 8
        Me.Splitter1.TabStop = False
        '
        'captureLsv
        '
        Me.captureLsv.ContextMenuStrip = Me.captureImageCtx
        Me.captureLsv.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.captureLsv.LargeImageList = Me.captureIml
        Me.captureLsv.Location = New System.Drawing.Point(200, 361)
        Me.captureLsv.Name = "captureLsv"
        Me.captureLsv.Size = New System.Drawing.Size(584, 200)
        Me.captureLsv.TabIndex = 5
        Me.captureLsv.UseCompatibleStateImageBehavior = False
        '
        'captureImageCtx
        '
        Me.captureImageCtx.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.CopyPathToolStripMenuItem})
        Me.captureImageCtx.Name = "captureImageCtx"
        Me.captureImageCtx.Size = New System.Drawing.Size(130, 48)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'CopyPathToolStripMenuItem
        '
        Me.CopyPathToolStripMenuItem.Name = "CopyPathToolStripMenuItem"
        Me.CopyPathToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.CopyPathToolStripMenuItem.Text = "Copy Path"
        '
        'captureIml
        '
        Me.captureIml.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.captureIml.ImageSize = New System.Drawing.Size(96, 96)
        Me.captureIml.TransparentColor = System.Drawing.Color.Transparent
        '
        'commandPnl
        '
        Me.commandPnl.BackColor = System.Drawing.SystemColors.Window
        Me.commandPnl.Controls.Add(Me.resolutionCbo)
        Me.commandPnl.Controls.Add(Me.nextCameraBtn)
        Me.commandPnl.Controls.Add(Me.recordBtn)
        Me.commandPnl.Controls.Add(Me.captureBtn)
        Me.commandPnl.Dock = System.Windows.Forms.DockStyle.Left
        Me.commandPnl.Location = New System.Drawing.Point(0, 0)
        Me.commandPnl.Name = "commandPnl"
        Me.commandPnl.Size = New System.Drawing.Size(200, 561)
        Me.commandPnl.TabIndex = 6
        '
        'resolutionCbo
        '
        Me.resolutionCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.resolutionCbo.FormattingEnabled = True
        Me.resolutionCbo.Location = New System.Drawing.Point(11, 150)
        Me.resolutionCbo.Name = "resolutionCbo"
        Me.resolutionCbo.Size = New System.Drawing.Size(171, 28)
        Me.resolutionCbo.TabIndex = 3
        '
        'nextCameraBtn
        '
        Me.nextCameraBtn.Location = New System.Drawing.Point(11, 104)
        Me.nextCameraBtn.Name = "nextCameraBtn"
        Me.nextCameraBtn.Size = New System.Drawing.Size(171, 40)
        Me.nextCameraBtn.TabIndex = 2
        Me.nextCameraBtn.Text = "Next Camera"
        Me.nextCameraBtn.UseVisualStyleBackColor = True
        '
        'recordBtn
        '
        Me.recordBtn.Location = New System.Drawing.Point(11, 58)
        Me.recordBtn.Name = "recordBtn"
        Me.recordBtn.Size = New System.Drawing.Size(171, 40)
        Me.recordBtn.TabIndex = 1
        Me.recordBtn.Text = "Record"
        Me.recordBtn.UseVisualStyleBackColor = True
        '
        'captureBtn
        '
        Me.captureBtn.Location = New System.Drawing.Point(11, 12)
        Me.captureBtn.Name = "captureBtn"
        Me.captureBtn.Size = New System.Drawing.Size(171, 40)
        Me.captureBtn.TabIndex = 0
        Me.captureBtn.Text = "Capture"
        Me.captureBtn.UseVisualStyleBackColor = True
        '
        'elapsedTmr
        '
        Me.elapsedTmr.Interval = 1000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.videoPnl)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.captureLsv)
        Me.Controls.Add(Me.commandPnl)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.videoPnl.ResumeLayout(False)
        Me.videoPnl.PerformLayout()
        CType(Me.videoPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.captureImageCtx.ResumeLayout(False)
        Me.commandPnl.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents recordingLbl As Label
    Friend WithEvents videoPnl As Panel
    Friend WithEvents videoPic As PictureBox
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents captureLsv As ListView
    Friend WithEvents captureImageCtx As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents captureIml As ImageList
    Friend WithEvents commandPnl As Panel
    Friend WithEvents resolutionCbo As ComboBox
    Friend WithEvents nextCameraBtn As Button
    Friend WithEvents recordBtn As Button
    Friend WithEvents captureBtn As Button
    Friend WithEvents elapsedTmr As Timer
End Class
