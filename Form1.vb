Imports System
Imports System.Xml
Imports Newtonsoft.Json
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        My.Computer.FileSystem.WriteAllText("C:\" + "" & TextBox4.Text + ".txt", "Name: " & TextBox1.Text + Environment.NewLine + "Age: " & TextBox2.Text + Environment.NewLine + "Address: " & TextBox3.Text, True)
        MessageBox.Show("Txt file saved.")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim settings As New XmlWriterSettings()
        settings.Indent = True

        ' Initialize the XmlWriter.
        Dim XmlWrt As XmlWriter = XmlWriter.Create("C:\" + TextBox4.Text + ".xml", settings)

        With XmlWrt

            ' Write the Xml declaration.
            .WriteStartDocument()

            ' Write a comment.
            .WriteComment("XML File")

            ' Write the root element.
            .WriteStartElement("Data")

            ' The person nodes.

            .WriteStartElement("Name")
            .WriteString(TextBox1.Text.ToString())
            .WriteEndElement()

            .WriteStartElement("Age")
            .WriteString(TextBox2.Text.ToString())
            .WriteEndElement()

            .WriteStartElement("Address")
            .WriteString(TextBox3.Text.ToString())
            .WriteEndElement()

            ' The end of this person.
            .WriteEndElement()

            ' Close the XmlTextWriter.
            .WriteEndDocument()
            .Close()

        End With

        MessageBox.Show("XML file saved.")

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim data As New Players()
        data.Name = TextBox1.Text
        data.Age = TextBox2.Text
        data.Address = TextBox3.Text

        Dim json As String = JsonConvert.SerializeObject(data)
        Dim file As IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("C:\" + TextBox4.Text + ".json", True)
        file.WriteLine(json)
        file.Close()
        MessageBox.Show("JSON file saved.")
    End Sub
End Class
