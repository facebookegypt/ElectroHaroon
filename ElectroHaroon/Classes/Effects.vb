Public Class Effects
    Public Sub BackgroundGradient(ByRef Control As Control,
                                    ByVal Color1 As Drawing.Color,
                                    ByVal Color2 As Drawing.Color)

        Dim vLinearGradient As Drawing.Drawing2D.LinearGradientBrush =
            New Drawing.Drawing2D.LinearGradientBrush(New Drawing.Point(Control.Width, Control.Height),
                                                        New Drawing.Point(Control.Width, 0),
                                                        Color1,
                                                        Color2)

        Dim vGraphic As Drawing.Graphics = Control.CreateGraphics
        ' To tile the image background - Using the same image background of the image
        Dim vTexture As New Drawing.TextureBrush(Control.BackgroundImage)

        vGraphic.FillRectangle(vLinearGradient, Control.DisplayRectangle)
        vGraphic.FillRectangle(vTexture, Control.DisplayRectangle)

        vGraphic.Dispose() : vGraphic = Nothing : vTexture.Dispose() : vTexture = Nothing
    End Sub
    Public Sub RoundButton(ByVal Btn As Button)
        Dim Raduis As New Drawing2D.GraphicsPath

        Raduis.StartFigure()
        'appends an elliptical arc to the current figure
        'left corner top
        Raduis.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(10, 0, Btn.Width - 20, 0)
        'appends an elliptical arc to the current figure
        'right corner top
        Raduis.AddArc(New Rectangle(Btn.Width - 20, 0, 20, 20), -90, 90)
        'appends a line segment to the current figure
        Raduis.AddLine(Btn.Width, 20, Btn.Width, Btn.Height - 10)
        'appends an elliptical arc to the current figure 
        'right corner buttom
        Raduis.AddArc(New Rectangle(Btn.Width - 25, Btn.Height - 25, 25, 25), 0, 90)
        'appends a line segment to the current figure
        'left corner bottom
        Raduis.AddLine(Btn.Width - 10, Btn.Width, 20, Btn.Height)
        'appends an elliptical arc to the current figure
        Raduis.AddArc(New Rectangle(0, Btn.Height - 20, 20, 20), 90, 90)
        'Close the current figure and start a new one.
        Raduis.CloseFigure()
        'set the window associated with the control
        Btn.Region = New Region(Raduis)
    End Sub
End Class
