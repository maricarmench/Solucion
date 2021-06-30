<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.Color.Black
        Me.textBox1.ForeColor = System.Drawing.Color.Lime
        Me.textBox1.Location = New System.Drawing.Point(7, 78)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New System.Drawing.Size(900, 387)
        Me.textBox1.TabIndex = 7
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.Button1)
        Me.groupBox1.Controls.Add(Me.btnStart)
        Me.groupBox1.Controls.Add(Me.btnStop)
        Me.groupBox1.Location = New System.Drawing.Point(7, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(900, 62)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(126, 18)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(205, 38)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(352, 18)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(205, 38)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(580, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(205, 38)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 477)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.textBox1)
        Me.Name = "Form1"
        Me.Text = "Studio.Vision.Telko.Backend.Test"
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents textBox1 As Windows.Forms.TextBox
    Private WithEvents groupBox1 As Windows.Forms.GroupBox
    Private WithEvents btnStart As Windows.Forms.Button
    Private WithEvents btnStop As Windows.Forms.Button
    Friend WithEvents Timer1 As Windows.Forms.Timer
    Private WithEvents Button1 As Windows.Forms.Button
End Class
