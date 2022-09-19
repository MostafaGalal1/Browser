
Imports System.IO
Imports System.Net
Public Class Form1
    Private ReadOnly txtURl As Object

    Private Sub TextBox1_mousedoubleclick(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.SelectAll()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Navigate("http://www.google.com.eg/search?q=" + TextBox1.Text)
        If TextBox1.Text.Contains("www.") Then
            If TextBox1.Text.Contains(".com") Then
                WebBrowser1.Navigate(TextBox1.Text)
            End If
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WebBrowser1.Stop()
        geticon()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WebBrowser1.GoBack()
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        WebBrowser1.Navigate("http://www.google.com.eg")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        WebBrowser1.Navigate(ComboBox1.Text)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
        If TabControl1.TabPages.Count.Equals(0) Then
            Me.Close()
        End If
    End Sub

    Private Sub button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TabControl1.TabPages.Add(TabPage1)
    End Sub
    Private Sub ComboBox1_lostfocus(sender As Object, e As EventArgs) Handles ComboBox1.LostFocus
        If ComboBox1.Text.Length = 0 Then
            ComboBox1.Text = "Search"
            ComboBox1.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        TextBox1.Text = WebBrowser1.Document.Url.AbsoluteUri
        TabPage1.Text = "        " + WebBrowser1.DocumentTitle
        TextBox1.ForeColor = Color.Black
        Button1.Hide()
        geticon()
        Timer1.Interval = 25
        Timer1.Stop()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.SystemColorsChanged
        ComboBox1.Text = "Search"
        Button1.Hide()
        Timer1.Interval = 15000
        Me.Opacity = 89

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Button1.Show()
        Button1.BringToFront()
        If TextBox1.Text.Length = 0 Then
            TextBox1.Text = "Search Or Enter Address"
            TextBox1.ForeColor = Color.Gray
        End If
        If TextBox1.Text.Contains("Search" + " Or" + " Enter" + " Address") Then
            If TextBox1.Text.Length > 23 Then
                TextBox1.Text = " "
                TextBox1.ForeColor = Color.Black
            End If
        End If

    End Sub

    Private Sub TextBox1_lostfocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Button1.Show()
        Button1.BringToFront()
        If TextBox1.Text.Length = 0 Then
            TextBox1.Text = "Search Or Enter Address"
            TextBox1.ForeColor = Color.Gray
            Button1.Enabled = False
        End If
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        WebBrowser1.Refresh()
    End Sub
    Private Sub ComboBox1_gotfocus(sender As Object, e As EventArgs) Handles ComboBox1.GotFocus
        ComboBox1.Text = ""
        ComboBox1.ForeColor = Color.Black
    End Sub
    Private Sub geticon()
        Try
            Dim Webclient As New WebClient
            Dim IconUrl As New Uri(WebBrowser1.Url.ToString)
            Dim memorystream As New MemoryStream(Webclient.DownloadData("http://" & IconUrl.Host & "/favicon.ico"))
            Dim webicon As New Icon(memorystream)
            PictureBox1.Image = webicon.ToBitmap
        Catch ex As Exception
        End Try
    End Sub
    Private Sub webbrowser1_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser1.Navigated
        If TextBox1.Text.Contains("res://ieframe.dll/navcancl.htm#http://") Then
            PictureBox1.ImageLocation = ("C:\Users\fcc\Documents\Visual Studio 2015\Projects\WindowsApplication1\WindowsApplication1\Resources\o.jpg")
        End If
    End Sub
    Private Sub WebBrowser1_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles WebBrowser1.Navigating
        Timer1.Start()
        PictureBox1.ImageLocation = "C:\Users\fcc\Desktop\a.gif"

    End Sub
    Private Sub TextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            WebBrowser1.Navigate(TextBox1.Text)
        End If
    End Sub
    Private Sub Combobox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown

        If e.KeyCode = Keys.Enter Then
            WebBrowser1.Navigate(ComboBox1.Text)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = ComboBox1.SelectedItem Then
            WebBrowser1.Navigate(ComboBox1.Text)
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ContextMenuStrip1.Show(Button10, 0, Button10.Height)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        Me.Width = 500
    End Sub

    Private Sub KknlToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KknlToolStripMenuItem.Click
        Me.Height = 300
        WebBrowser1.Navigate("http://www.google.com")
    End Sub

    Private Sub JToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JToolStripMenuItem.Click
        WebBrowser1.Navigate("http://www.facebook.com")
    End Sub

    Private Sub NToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NToolStripMenuItem.Click
        WebBrowser1.Navigate("http://www.yahoo.com")
    End Sub

    Private Sub NToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NToolStripMenuItem1.Click
        WebBrowser1.Navigate("http://www.amazon.com")
    End Sub

    Private Sub NToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles NToolStripMenuItem2.Click
        WebBrowser1.Navigate("http://www.wikipedia.com")
    End Sub

    Private Sub NToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles NToolStripMenuItem3.Click
        WebBrowser1.Navigate("http://www.twitter.com")
    End Sub

    Private Sub BingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BingToolStripMenuItem.Click
        WebBrowser1.Navigate("http://www.bing.com")
    End Sub
    Private Sub YoutubeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YoutubeToolStripMenuItem.Click
        WebBrowser1.Navigate("http://www.youtube.com")
    End Sub

End Class


