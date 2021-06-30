Imports System.Windows.Forms
Module Module1
    ''' <summary>
    ''' Punto de entrada principal para la aplicación.
    ''' </summary>
    <STAThread()>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1)
    End Sub

End Module
