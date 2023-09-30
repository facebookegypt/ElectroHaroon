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
End Class
