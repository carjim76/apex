Imports System.Web
Imports System.Web.Services
Imports System
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Text


Public Class BarcodeGenerator1
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Dim cd As String
        'Dim fm As String
        Dim width As Integer
        Dim height As Integer
        Dim size As Integer

        cd = context.Request.QueryString.Get("code")
        'fm = context.Request.QueryString.Get("format")

        'dim width = (!string.IsNullOrEmpty(context.Request.QueryString.Get("width"))))? int.Parse(context.Request.QueryString.Get("width")): 200
        width = IIf(Not String.IsNullOrEmpty(context.Request.QueryString.Get("width")), CType(context.Request.QueryString.Get("width"), Integer), 300)
        height = IIf(Not String.IsNullOrEmpty(context.Request.QueryString.Get("height")), CType(context.Request.QueryString.Get("height"), Integer), 200)
        size = IIf(Not String.IsNullOrEmpty(context.Request.QueryString.Get("size")), CType(context.Request.QueryString.Get("size"), Integer), 200)

        If Not String.IsNullOrEmpty(cd) Then
            Using (New System.IO.MemoryStream())
                Dim bitmap = New Bitmap(width, height)
                Dim grafic = Graphics.FromImage(bitmap)
                'Dim font = loadFont(fm, size)
                Dim font = loadFont(size)
                Dim point = New Point()
                Dim brush = New SolidBrush(Color.Black)

                grafic.FillRectangle(New SolidBrush(Color.White), 0, 0, width, height)
                grafic.DrawString(FormatBarCode(cd), font, brush, 30, 30)
                context.Response.ContentType = "image/jpeg"
                bitmap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            End Using
        Else
            context.Response.Write("")
        End If

    End Sub

    Private Function loadFont(ByVal size As Integer) As Font
        Dim collectionOfFonts As New PrivateFontCollection()
        Dim pathFont As String

        pathFont = System.AppDomain.CurrentDomain.BaseDirectory & "Fonts\3OF9_NEW.TTF"
        collectionOfFonts.AddFontFile(pathFont)

        Return New Font(collectionOfFonts.Families(0), 36)
    End Function

    Private Function FormatBarCode(ByVal code As String) As String
        Return String.Format("*{0}*", code)
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class