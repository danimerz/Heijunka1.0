<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataSet1 = New AccessToSQL.DataSet1()
        Me.Tbl_FAUF_StatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_FAUF_StatusTableAdapter = New AccessToSQL.DataSet1TableAdapters.tbl_FAUF_StatusTableAdapter()
        Me.TableAdapterManager = New AccessToSQL.DataSet1TableAdapters.TableAdapterManager()
        Me.Tbl_FAUF_Status1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_FAUF_Status1TableAdapter = New AccessToSQL.DataSet1TableAdapters.tbl_FAUF_Status1TableAdapter()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_FAUF_StatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_FAUF_Status1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(274, 129)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(246, 73)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "ÜBERTRAGEN"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_FAUF_StatusBindingSource
        '
        Me.Tbl_FAUF_StatusBindingSource.DataMember = "tbl_FAUF_Status"
        Me.Tbl_FAUF_StatusBindingSource.DataSource = Me.DataSet1
        '
        'Tbl_FAUF_StatusTableAdapter
        '
        Me.Tbl_FAUF_StatusTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_FAUF_Status1TableAdapter = Nothing
        Me.TableAdapterManager.tbl_FAUF_StatusTableAdapter = Me.Tbl_FAUF_StatusTableAdapter
        Me.TableAdapterManager.tbl_ProdKontrolle1TableAdapter = Nothing
        Me.TableAdapterManager.tbl_ProdKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_Status1TableAdapter = Nothing
        Me.TableAdapterManager.tbl_Rueckmelden_StatusTableAdapter = Nothing
        Me.TableAdapterManager.tbl_SMT_Ruestung1TableAdapter = Nothing
        Me.TableAdapterManager.tbl_SMT_RuestungTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolle1TableAdapter = Nothing
        Me.TableAdapterManager.tbl_vcheckKontrolleTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = AccessToSQL.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_FAUF_Status1BindingSource
        '
        Me.Tbl_FAUF_Status1BindingSource.DataMember = "tbl_FAUF_Status1"
        Me.Tbl_FAUF_Status1BindingSource.DataSource = Me.DataSet1
        '
        'Tbl_FAUF_Status1TableAdapter
        '
        Me.Tbl_FAUF_Status1TableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_FAUF_StatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_FAUF_Status1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents Tbl_FAUF_StatusBindingSource As BindingSource
    Friend WithEvents Tbl_FAUF_StatusTableAdapter As DataSet1TableAdapters.tbl_FAUF_StatusTableAdapter
    Friend WithEvents TableAdapterManager As DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents Tbl_FAUF_Status1BindingSource As BindingSource
    Friend WithEvents Tbl_FAUF_Status1TableAdapter As DataSet1TableAdapters.tbl_FAUF_Status1TableAdapter
End Class
